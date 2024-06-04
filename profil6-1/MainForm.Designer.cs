namespace VV_Profil
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            picBox = new PictureBox();
            panel1 = new Panel();
            btnSetup = new Button();
            groupBox1 = new GroupBox();
            GridViewPalet = new DataGridView();
            checkBox = new CheckBox();
            label1 = new Label();
            txtBoxLen = new TextBox();
            btnOK = new Button();
            ds = new System.Data.DataSet();
            dataTable1 = new System.Data.DataTable();
            bindingSource1 = new BindingSource(components);
            btnMeasure = new Button();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GridViewPalet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ds).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataTable1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // picBox
            // 
            picBox.BackColor = Color.Transparent;
            picBox.Location = new Point(771, 21);
            picBox.Margin = new Padding(3, 4, 3, 4);
            picBox.Name = "picBox";
            picBox.Size = new Size(250, 250);
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox.TabIndex = 3;
            picBox.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = Properties.Resources.Циферблат;
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(771, 279);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 250);
            panel1.TabIndex = 4;
            panel1.MouseClick += panel1_MouseClick;
            panel1.MouseDoubleClick += panel1_MouseDoubleClick;
            panel1.MouseMove += panel1_MouseMove;
            // 
            // btnSetup
            // 
            btnSetup.Location = new Point(773, 598);
            btnSetup.Margin = new Padding(4, 6, 4, 6);
            btnSetup.Name = "btnSetup";
            btnSetup.Size = new Size(250, 50);
            btnSetup.TabIndex = 5;
            btnSetup.Text = "Настройка палитры";
            btnSetup.UseVisualStyleBackColor = true;
            btnSetup.Click += btnSetup_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(GridViewPalet);
            groupBox1.Location = new Point(20, 21);
            groupBox1.Margin = new Padding(4, 6, 4, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 6, 4, 6);
            groupBox1.Size = new Size(742, 633);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Палитра профилей";
            // 
            // GridViewPalet
            // 
            GridViewPalet.AllowUserToAddRows = false;
            GridViewPalet.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            GridViewPalet.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            GridViewPalet.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            GridViewPalet.BackgroundColor = SystemColors.Info;
            GridViewPalet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridViewPalet.Dock = DockStyle.Fill;
            GridViewPalet.GridColor = SystemColors.ControlDarkDark;
            GridViewPalet.Location = new Point(4, 30);
            GridViewPalet.Margin = new Padding(4, 6, 4, 6);
            GridViewPalet.MultiSelect = false;
            GridViewPalet.Name = "GridViewPalet";
            GridViewPalet.ReadOnly = true;
            GridViewPalet.RowHeadersWidth = 62;
            GridViewPalet.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            GridViewPalet.RowTemplate.Resizable = DataGridViewTriState.True;
            GridViewPalet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GridViewPalet.Size = new Size(734, 597);
            GridViewPalet.TabIndex = 0;
            GridViewPalet.RowEnter += GridViewPalet_RowEnter;
            // 
            // checkBox
            // 
            checkBox.AutoSize = true;
            checkBox.Location = new Point(115, 655);
            checkBox.Margin = new Padding(4, 6, 4, 6);
            checkBox.Name = "checkBox";
            checkBox.Size = new Size(157, 29);
            checkBox.TabIndex = 7;
            checkBox.Text = "Строить солид";
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckStateChanged += checkBox_CheckStateChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(296, 653);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(124, 25);
            label1.TabIndex = 8;
            label1.Text = "Длина солида";
            // 
            // txtBoxLen
            // 
            txtBoxLen.Enabled = false;
            txtBoxLen.Location = new Point(428, 653);
            txtBoxLen.Margin = new Padding(4, 6, 4, 6);
            txtBoxLen.Name = "txtBoxLen";
            txtBoxLen.Size = new Size(120, 31);
            txtBoxLen.TabIndex = 9;
            txtBoxLen.DoubleClick += txtBoxLen_DoubleClick_1;
            // 
            // btnOK
            // 
            btnOK.Enabled = false;
            btnOK.Location = new Point(773, 539);
            btnOK.Margin = new Padding(4, 6, 4, 6);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(250, 50);
            btnOK.TabIndex = 10;
            btnOK.Text = "Построить";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // ds
            // 
            ds.DataSetName = "NewDataSet";
            ds.Tables.AddRange(new System.Data.DataTable[] { dataTable1 });
            // 
            // dataTable1
            // 
            dataTable1.Namespace = "";
            dataTable1.TableName = "Table1";
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = ds;
            bindingSource1.Position = 0;
            // 
            // btnMeasure
            // 
            btnMeasure.Location = new Point(562, 652);
            btnMeasure.Name = "btnMeasure";
            btnMeasure.Size = new Size(200, 32);
            btnMeasure.TabIndex = 11;
            btnMeasure.Text = "Измерить длину";
            btnMeasure.UseVisualStyleBackColor = true;
            btnMeasure.Click += button1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1028, 694);
            Controls.Add(btnMeasure);
            Controls.Add(btnOK);
            Controls.Add(txtBoxLen);
            Controls.Add(label1);
            Controls.Add(checkBox);
            Controls.Add(groupBox1);
            Controls.Add(btnSetup);
            Controls.Add(picBox);
            Controls.Add(panel1);
            Margin = new Padding(4, 6, 4, 6);
            MaximizeBox = false;
            MaximumSize = new Size(1050, 750);
            MinimizeBox = false;
            MinimumSize = new Size(1050, 750);
            Name = "MainForm";
            Text = "Построение профиля";
            TopMost = true;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)GridViewPalet).EndInit();
            ((System.ComponentModel.ISupportInitialize)ds).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataTable1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxLen;
        private System.Windows.Forms.Button btnOK;
        private System.Data.DataSet ds;
        private System.Windows.Forms.DataGridView GridViewPalet;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Data.DataTable dataTable1;
        private Button btnMeasure;
    }
}