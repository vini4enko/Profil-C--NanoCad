using Npgsql;
using System.Data;

namespace VV_Profil
{
    public partial class MainForm : Form
    {
        public int contourID
        {
            get; set;
        }
        public int typID
        {
            get; set;
        }
        public double SolLen;
        public int rotFlip { get; private set; } = 0;
        static byte[] SourceBMP;
        public bool chBox = false;
        string curdir;

        //public string curdir;


        private void GetData(string SQL)
        {
            try
            {
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter(SQL, AllCommands.Connection);
                NpgsqlCommandBuilder commandBuilder = new NpgsqlCommandBuilder(DA);
                DataTable table = new DataTable
                {
                    Locale = System.Globalization.CultureInfo.CurrentCulture
                };
                DA.Fill(table);
                bindingSource1.DataSource = table;
                GridViewPalet.AutoGenerateColumns = true;
                GridViewPalet.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Тип: " + ex.GetType() + "\n" +
                               "Сообщение: " + ex.Message);
            }
        }

        private string SQLMake()
        {
            ProfParams newP = new ProfParams();
            try
            {
                SerProc rProc = new SerProc(curdir);
                rProc.RestoreParam(ref newP);
                SolLen = newP.h;
                checkBox.Checked = newP.doSolid;
                contourID = newP.CurID;
                typID = newP.CurTyp;

                string palet = null;
                foreach (ProfParam P in newP.PrLst)
                {
                    ListViewItem item = new ListViewItem();
                    string CurID = P.ID.ToString();
                    string CurTyp = P.Typ.ToString();
                    palet = palet + $"'{CurID}" + "," + $"{CurTyp}'" + ",";
                }
                palet = palet.Trim(',');

                string SQL = $"SELECT idst, standard, pic, prnum, note, idpr FROM \"PROKAT\".Allprofils " +
                    $"WHERE idst || ',' || idpr IN ({palet});";
                return SQL;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Тип: " + ex.GetType() + "\n" +
                               "Сообщение: " + ex.Message);
                return null;
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        public int selectRowByMark(string idst, string idpr)
        {
            int result = 0;
            foreach (DataGridViewRow row in GridViewPalet.Rows)
                if ((row.Cells["idst"].Value.ToString() == idst) &&
                    (row.Cells["idpr"].Value.ToString() == idpr))
                {
                    result = row.Index;
                    row.Selected = true;
                }
            return result;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            curdir = AllCommands.GetCurDir();
            GridViewPalet.DataSource = bindingSource1;
            string SQL = SQLMake();
            if (SQL != null)
            {
                txtBoxLen.Text = SolLen.ToString();
                GetData(SQL);
                GridViewPalet.Columns["idst"].Visible = false;
                GridViewPalet.Columns["standard"].Width = 200;
                GridViewPalet.Columns["standard"].HeaderText = "Стандарт";
                GridViewPalet.Columns["pic"].Visible = false;
                GridViewPalet.Columns["prnum"].Width = 60;
                GridViewPalet.Columns["prnum"].HeaderText = "Типоразмер";
                GridViewPalet.Columns["note"].Width = 100;
                GridViewPalet.Columns["note"].HeaderText = "Примечание";
                GridViewPalet.Columns["idpr"].Visible = false;
                int curRow = selectRowByMark(contourID.ToString(), typID.ToString());
                GridViewPalet.Select();
                GridViewPalet.FirstDisplayedScrollingRowIndex = curRow;
            }
            else
            {
                SetupForm frm = new SetupForm();
                DialogResult diaResult = frm.ShowDialog();
                Close();
            }
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            SetupForm frm = new SetupForm();
            DialogResult diaResult = frm.ShowDialog();
            if (diaResult == DialogResult.OK)
            {// настройка списка палитры
                string SQL = SQLMake();
                GetData(SQL);
            };
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            btnOK.Select();
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ProfParams newP = new ProfParams();
            foreach (DataGridViewRow r in GridViewPalet.Rows)
            {
                newP.CurID = Convert.ToInt32(r.Cells["idst"].Value.ToString().Trim());
                newP.CurTyp = Convert.ToInt32(r.Cells["idpr"].Value.ToString().Trim());
                newP.Add(newP.CurID, newP.CurTyp);
            }
            SolLen = Convert.ToDouble(txtBoxLen.Text.Trim());
            newP.h = SolLen;
            newP.doSolid = checkBox.Checked;
            SerProc sProc = new SerProc(curdir);
            sProc.SaveParam(ref newP);

            DialogResult = DialogResult.OK;
            Close();
        }

        System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms) as System.Drawing.Image;
                return img;
            }
        }

        static int old_r;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Point a = new Point(0, 0);
            Point b = new Point(panel1.Width, panel1.Height);
            int d = (e.X - a.X) * (b.Y - a.Y) - (e.Y - a.Y) * (b.X - a.X);
            a = new Point(0, panel1.Height);
            b = new Point(panel1.Width, 0);
            int d1 = (e.X - a.X) * (b.Y - a.Y) - (e.Y - a.Y) * (b.X - a.X);
            int g = e.Y - panel1.Height / 2;
            int f = e.X - panel1.Width / 2;

            if ((d > 0) && (d1 > 0) && (f > 0))
                rotFlip = 1;
            else if ((d > 0) && (d1 > 0) && (f <= 0))
                rotFlip = 11;
            else if ((d <= 0) && (d1 > 0) && (g < 0))
                rotFlip = 10;
            else if ((d <= 0) && (d1 > 0) && (g >= 0))
                rotFlip = 8;
            else if ((d <= 0) && (d1 <= 0) && (f <= 0))
                rotFlip = 7;
            else if ((d <= 0) && (d1 <= 0) && (f > 0))
                rotFlip = 5;
            else if ((d > 0) && (d1 <= 0) && (g > 0))
                rotFlip = 4;
            else if ((d >= 0) && (d1 < 0) && (g <= 0))
                rotFlip = 2;
            else
                rotFlip = 0;

            if (rotFlip != old_r)
            {
                picBox.Image = ByteArrayToImage(SourceBMP);
                picBox.Invalidate();
                switch (rotFlip)
                {
                    case 1:
                        panel1.BackgroundImage = VV_Profil.Properties.Resources._1;
                        picBox.Image.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipNone);
                        picBox.Invalidate();
                        break;
                    case 11:
                        panel1.BackgroundImage = VV_Profil.Properties.Resources._11;
                        picBox.Image.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipX);
                        picBox.Invalidate();
                        break;
                    case 10:
                        panel1.BackgroundImage = VV_Profil.Properties.Resources._10;
                        picBox.Image.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipNone);
                        picBox.Invalidate();
                        break;
                    case 8:
                        panel1.BackgroundImage = VV_Profil.Properties.Resources._8;
                        picBox.Image.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipX);
                        break;
                    case 7:
                        panel1.BackgroundImage = VV_Profil.Properties.Resources._7;
                        picBox.Image.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipXY);
                        picBox.Invalidate();
                        break;
                    case 5:
                        panel1.BackgroundImage = VV_Profil.Properties.Resources._5;
                        picBox.Image.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipY);
                        picBox.Invalidate();
                        break;
                    case 4:
                        panel1.BackgroundImage = VV_Profil.Properties.Resources._4;
                        picBox.Image.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipNone);
                        picBox.Invalidate();
                        break;
                    case 2:
                        panel1.BackgroundImage = VV_Profil.Properties.Resources._2;
                        picBox.Image.RotateFlip(System.Drawing.RotateFlipType.Rotate90FlipY);
                        picBox.Invalidate();
                        break;
                    default:
                        panel1.BackgroundImage = VV_Profil.Properties.Resources.Циферблат;
                        picBox.Invalidate();
                        break;
                }
                old_r = rotFlip;
            }
        }

        private void GridViewPalet_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (sender != null)
            {
                SourceBMP = (byte[])GridViewPalet.Rows[e.RowIndex].Cells["pic"].Value;
                picBox.Image = ByteArrayToImage(SourceBMP);
                panel1.BackgroundImage = VV_Profil.Properties.Resources._1;
                contourID = Convert.ToInt32(GridViewPalet.Rows[e.RowIndex].Cells["idst"].Value);
                typID = Convert.ToInt32(GridViewPalet.Rows[e.RowIndex].Cells["idpr"].Value);
                btnOK.Enabled = true;
            }
        }

        private void checkBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked == true)
            {
                txtBoxLen.Enabled = true;
                chBox = true;
            }
            else
            {
                txtBoxLen.Enabled = false;
                chBox = false;
            }
        }

        private void txtBoxLen_DoubleClick_1(object sender, EventArgs e)
        {
            AllCommands.GetDistance();
            txtBoxLen.Text = AllCommands.dist;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            ProfParams newP = new ProfParams();
            foreach (DataGridViewRow r in GridViewPalet.Rows)
            {
                newP.CurID = Convert.ToInt32(r.Cells["idst"].Value.ToString().Trim());
                newP.CurTyp = Convert.ToInt32(r.Cells["idpr"].Value.ToString().Trim());
                newP.Add(newP.CurID, newP.CurTyp);
            }
            SolLen = Convert.ToDouble(txtBoxLen.Text.Trim());
            newP.h = SolLen;
            newP.doSolid = checkBox.Checked;
            SerProc sProc = new SerProc(curdir);
            sProc.SaveParam(ref newP);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllCommands.GetDistance();
            txtBoxLen.Text = AllCommands.dist;
        }
    }
}
