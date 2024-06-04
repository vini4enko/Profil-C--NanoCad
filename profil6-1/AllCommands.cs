using HostMgd.ApplicationServices;
using HostMgd.EditorInput;
using Npgsql;
using NUtils;
using Teigha.DatabaseServices;
using Teigha.Geometry;
using Teigha.Runtime;
using Platform = HostMgd;


[assembly: CommandClass(typeof(VV_Profil.AllCommands))]

namespace VV_Profil

{
    public class AllCommands
    {
        static NpgsqlTypes.NpgsqlPath ph;
        static double[] cornes;
        public static NpgsqlConnection Connection;

        private static string ReadConnection()
        {
            string constring;
            constring = "Server=127.0.0.1;Port=5432;Username=postgres;Password=postgres;database=postgres";//изменить при необходимости
            return constring;
            //try  //вариант для реестра Widows
            //{
            //    RegistryKey profil =
            //    Registry.CurrentUser.OpenSubKey("software").OpenSubKey("rubin-nord").OpenSubKey("301").OpenSubKey("profil");
            //    constring = (string)profil.GetValue("server");
            //    profil.Close();
            //    return constring;
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show("не удалось прочитать реестр\n" +
            //                    "тип ошибки: " + ex.GetType() + "\n" +
            //                    "сообщение: " + ex.Message);
            //    return string.Empty;
            //}
        }

        public static string GetCurDir()
        {
            return HostMgd.ApplicationServices.Application.GetSystemVariable("DWGPREFIX").ToString();
        }

        static void ReadData(int StId, int PrID)
        {
            string sqlProfCorn = $"SELECT corners FROM \"PROKAT\".profil WHERE id = {StId};";

            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(sqlProfCorn, Connection);
            cornes = (double[])npgSqlCommand.ExecuteScalar();
            string sqlPth = $"select pth FROM \"PROKAT\".typorazmer where profilid = {StId}" +
                $" and typnum = {PrID};";
            NpgsqlCommand npgSqlCommand1 = new NpgsqlCommand(sqlPth, Connection);
            try
            {
                ph = (NpgsqlTypes.NpgsqlPath)npgSqlCommand1.ExecuteScalar();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Не удалось прочитать данные БД\n" +
                               "Тип: " + ex.GetType() + "\n" +
                               "Сообщение: " + ex.Message);
            }
        }

        [CommandMethod("ProfPol")]

        public static void AddPol()
        {
            string connestring = ReadConnection();
            try
            {
                Connection = new NpgsqlConnection(connestring);
                Connection.Open();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Не удалось открыть БД " + connestring + "\n" +
                               "Тип: " + ex.GetType() + "\n" +
                               "Сообщение: " + ex.Message);
                return;
            }

            MainForm frm = new MainForm();

            DialogResult diaResult = frm.ShowDialog();
            if (diaResult != DialogResult.OK) return;

            int curRot = frm.rotFlip;
            int curStID = frm.contourID;
            int curPrID = frm.typID;
            double curH = frm.SolLen;
            bool makeSol = frm.chBox;

            switch (curRot)
            {
                case 11:
                    curH = -curH;
                    break;
                case 8:
                    curH = -curH;
                    break;
                case 5:
                    curH = -curH;
                    break;
                case 2:
                    curH = -curH;
                    break;
            }

            ReadData(curStID, curPrID);
            Connection.Close();
            Document Ndoc = Platform.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = Ndoc.Database;
            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                BlockTable blTable;
                blTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord blTableRec;
                blTableRec = tr.GetObject(blTable[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                Polyline aPol = new Polyline();
                aPol.SetDatabaseDefaults();
                for (int i = 0; i < ph.Count; i++)
                {
                    aPol.AddVertexAt(i, new Point2d(ph[i].X, ph[i].Y), cornes[i], 0, 0);
                }
                aPol.Closed = true;
                PromptPointResult pPtRes;
                PromptPointOptions pPtOpts = new PromptPointOptions("")
                {
                    Message = "\nУкажите точку вставки сечения: "
                };
                pPtRes = Ndoc.Editor.GetPoint(pPtOpts);

                Matrix3d curUCSMatrix = Ndoc.Editor.CurrentUserCoordinateSystem;
                Point3d ptStart = pPtRes.Value.TransformBy(curUCSMatrix);

                NGUtils.TransPoly(ref aPol, curRot, ref ptStart, curUCSMatrix);

                ObjectId aPolobjectId = blTableRec.AppendEntity(aPol);
                tr.AddNewlyCreatedDBObject(aPol, true);
                if (makeSol)
                {
                    Vector3d d = aPol.Normal;
                    using (var dbObjectCollection = new DBObjectCollection { aPol })
                    {
                        using (var regionCollection = Teigha.DatabaseServices.Region.CreateFromCurves(dbObjectCollection))
                        {
                            using (var region = (Teigha.DatabaseServices.Region)regionCollection[0])
                            {
                                using (var solid = new Solid3d())
                                {
                                    solid.Extrude(region, curH, 0.0);
                                    using (Ndoc.LockDocument())
                                    {
                                        using (var database = Ndoc.Database)
                                        {
                                            using (var transaction = database.TransactionManager.StartTransaction())
                                            {
                                                // get the current space for appending our extruded solid
                                                using (var currentSpace = (BlockTableRecord)transaction.GetObject(database.CurrentSpaceId, OpenMode.ForWrite))
                                                {
                                                    currentSpace.AppendEntity(solid);
                                                }
                                                transaction.AddNewlyCreatedDBObject(solid, true);
                                                transaction.Commit();
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                    DBObject obj = tr.GetObject(aPolobjectId, OpenMode.ForWrite);//удаляем исходную полилинию
                    obj.Erase();
                }
                tr.Commit();
            }
        }

        public static string dist = "0";
        [CommandMethod("GetDistance")]
        public static void GetDistance()
        {
            Editor ed = HostMgd.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
            PromptDistanceOptions opt1 = new PromptDistanceOptions("Укажите расстояние для размера")
            {
                AllowNegative = false,
                AllowZero = false,
                AllowNone = false,
                UseDashedLine = true
            };

            PromptDoubleResult res = ed.GetDistance(opt1);

            if (res.Status == PromptStatus.OK)
            {
                dist = res.Value.ToString();
            }
            else
                dist = "?";
        }
    }

}
