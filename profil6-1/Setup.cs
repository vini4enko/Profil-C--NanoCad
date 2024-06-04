using Npgsql;
using System.Data;

namespace VV_Profil
{
    public partial class SetupForm : Form
    {
        public int contourID
        {
            get
            {
                try
                {
                    return (int)MasterGrid.CurrentRow.Cells[0].Value;
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбран явно контур!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show("Тип: " + ex.GetType() + "\n" +
                    //           "Сообщение: " + ex.Message);
                    return (int)MasterGrid.Rows[0].Cells[0].Value;
                }
            }
        }

        string dir;

        public string typnum
        {
            get
            {
                try
                {
                    return DetailGrid.CurrentRow.Cells[3].Value.ToString().Trim();
                }
                catch (Exception)
                {
                    MessageBox.Show("Не выбран явно типоразмер!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show("Тип: " + ex.GetType() + "\n" +
                    //           "Сообщение: " + ex.Message);
                    return DetailGrid.Rows[0].Cells[3].Value.ToString().Trim();
                }
            }
        }

        public SetupForm()
        {
            InitializeComponent();
            try
            {
                string masterSQL = "SELECT id, namestandard, standard, pic FROM \"PROKAT\".profil ORDER BY id;";
                NpgsqlDataAdapter masterDA = new NpgsqlDataAdapter(masterSQL, AllCommands.Connection);
                string detailSQL = "SELECT profilid, numer, note, typnum FROM \"PROKAT\".typorazmer ORDER BY profilid, typnum;";
                NpgsqlDataAdapter detailDA = new NpgsqlDataAdapter(detailSQL, AllCommands.Connection);
                ds.Locale = System.Globalization.CultureInfo.CurrentCulture;
                masterDA.Fill(ds, "profil");
                detailDA.Fill(ds, "typorazmer");
                DataRelation rl = new DataRelation("prof_typ", ds.Tables["profil"].Columns["id"], ds.Tables["typorazmer"].Columns["profilid"]);
                ds.Relations.Add(rl);
                masterBinding.DataMember = "profil";
                MasterGrid.DataSource = masterBinding;
                MasterGrid.Columns["id"].Visible = false;
                MasterGrid.Columns["pic"].Visible = false;

                detailBinding.DataMember = "prof_typ";
                DetailGrid.DataSource = detailBinding;
                DetailGrid.Columns["profilid"].Visible = false;
                DetailGrid.Columns["typnum"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Тип: " + ex.GetType() + "\n" +
                               "Сообщение: " + ex.Message);
                throw;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            ListViewItem item = new ListViewItem();
            listViewSelected.Items.Add(item);
            item.Checked = true;
            item.SubItems.Add(contourID.ToString());
            item.SubItems.Add(typnum);
            item.SubItems.Add(MasterGrid.CurrentRow.Cells[1].Value.ToString());
            item.SubItems.Add(DetailGrid.CurrentRow.Cells[1].Value.ToString());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ListViewItem item = listViewSelected.FocusedItem;
            listViewSelected.Items.Remove(item);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProfParams newP = new ProfParams();
            foreach (ListViewItem item in listViewSelected.Items)
            {
                newP.CurID = Convert.ToInt32(item.SubItems[1].Text.Trim());
                newP.CurTyp = Convert.ToInt32(item.SubItems[2].Text.Trim());
                if (item.Checked)
                    newP.Add(newP.CurID, newP.CurTyp);
            }
            newP.h = 0;
            SerProc sProc = new SerProc(dir);
            sProc.SaveParam(ref newP);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            ProfParams newP = new ProfParams();

            SerProc rProc = new SerProc(dir);
            rProc.RestoreParam(ref newP);
            listViewSelected.Items.Clear();
            foreach (ProfParam P in newP.PrLst)
            {
                ListViewItem item = new ListViewItem();
                listViewSelected.Items.Add(item);
                item.Checked = true;
                string CurID = P.ID.ToString();
                string CurTyp = P.Typ.ToString();
                string CurProfName = null;
                string CurSize = null;
                string SQL = $"SELECT idst, standard, prnum, idpr FROM \"PROKAT\".allprofils " +
                    $"WHERE idst = {CurID} AND idpr = {CurTyp};";
                NpgsqlCommand command = new NpgsqlCommand(SQL, AllCommands.Connection);
                NpgsqlDataReader dr = command.ExecuteReader(CommandBehavior.SingleRow);
                try
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        CurProfName = dr["standard"].ToString();
                        CurSize = dr["prnum"].ToString();

                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Тип: " + ex.GetType() + "\n" +
                   "Сообщение: " + ex.Message);
                }
                finally
                {
                    dr.Close();
                }

                item.SubItems.Add(CurID);
                item.SubItems.Add(CurTyp);
                item.SubItems.Add(CurProfName);
                item.SubItems.Add(CurSize);
            }
        }
        static byte[] SourceBMP;

        System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms) as System.Drawing.Image;
                return img;
            }
        }

        private void MasterGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            SourceBMP = (byte[])MasterGrid.Rows[e.RowIndex].Cells["pic"].Value;
            picBox.Image = ByteArrayToImage(SourceBMP);
            picBox.Invalidate();
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            dir = AllCommands.GetCurDir();
            Pathlabel.Text = dir;
        }

        private void MasterGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
