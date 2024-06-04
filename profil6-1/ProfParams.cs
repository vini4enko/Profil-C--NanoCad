using System.Xml.Serialization;

namespace VV_Profil
{
    [Serializable]
    public class ProfParam
    {
        public int ID { get; set; }
        public int Typ { get; set; }
        public ProfParam() { }
        public ProfParam(int PrID, int PrTyp) { ID = PrID; Typ = PrTyp; }
    }

    [Serializable]
    public class ProfParams
    {
        public int CurID { get; set; }
        public int CurTyp { get; set; }
        //public int CurRotFlip { get; set; }
        public double h { get; set; }
        public bool doSolid { get; set; }

        public List<ProfParam> PrLst { get; set; }

        public ProfParams()
        {
            PrLst = new List<ProfParam>();
        }

        public void Add(int id, int type)
        {
            ProfParam P = new ProfParam(id, type);
            PrLst.Add(P);
        }

        public void Remove(int id, int type)
        {
            ProfParam P = new ProfParam();
            P.ID = id;
            P.Typ = type;
            PrLst.Remove(P);
        }
    }

    public class SerProc
    {
        const string fileName = "Profil.xml";
        string fullfilename;
        public SerProc(string dir)
        {
            fullfilename = Path.Combine(dir, fileName);
        }
        public void SaveParam(ref ProfParams P)
        {
            //XmlSerializer xml = new XmlSerializer(typeof(ProfParams));
            XmlSerializer xml = new XmlSerializer(P.GetType());
            try
            {
                //string f = Attrib3D.ReestrData.XMLPath + "\\" + fileName;
                using (Stream fStream = new FileStream(fullfilename, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xml.Serialize(fStream, P);
                }
            }
            catch (Exception ex)
            {   //ex.HResult
                MessageBox.Show("Ошибка серилизации!\n" +
                          "Тип: " + ex.GetType() + "\n" +
                          "Сообщение: " + ex.Message);
            }
        }

        public void RestoreParam(ref ProfParams P)
        {
            //XmlSerializer xml = new XmlSerializer(typeof(ProfParams));
            XmlSerializer xml = new XmlSerializer(P.GetType());
            try
            {
                //string f = Attrib3D.ReestrData.XMLPath + "\\" + fileName;
                using (Stream fStream = new FileStream(fullfilename, FileMode.Open, FileAccess.Read))
                {
                    P = xml.Deserialize(fStream) as ProfParams;
                }
            }
            catch (Exception ex)
            {   //ex.HResult
                MessageBox.Show("Ошибка десерилизации!\n" +
                           "Тип: " + ex.GetType() + "\n" +
                           "Сообщение: " + ex.Message);
            }
        }
    }
}
