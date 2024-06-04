namespace VV_Profil
{
    partial class SetupForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DetailGrid = new DataGridView();
            grBoxDetail = new GroupBox();
            picBox = new PictureBox();
            MasterGrid = new DataGridView();
            grBoxMaster = new GroupBox();
            ds = new System.Data.DataSet();
            masterBinding = new BindingSource(components);
            detailBinding = new BindingSource(components);
            btnInsert = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            listViewSelected = new ListView();
            Picture = new ColumnHeader();
            ID = new ColumnHeader();
            TypNum = new ColumnHeader();
            ProfilName = new ColumnHeader();
            Size = new ColumnHeader();
            btnRestore = new Button();
            Pathlabel = new Label();
            ((System.ComponentModel.ISupportInitialize)DetailGrid).BeginInit();
            grBoxDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MasterGrid).BeginInit();
            grBoxMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ds).BeginInit();
            ((System.ComponentModel.ISupportInitialize)masterBinding).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detailBinding).BeginInit();
            SuspendLayout();
            // 
            // DetailGrid
            // 
            DetailGrid.AllowUserToAddRows = false;
            DetailGrid.AllowUserToDeleteRows = false;
            DetailGrid.AllowUserToOrderColumns = true;
            DetailGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DetailGrid.BackgroundColor = SystemColors.ActiveCaption;
            DetailGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DetailGrid.Location = new Point(3, 28);
            DetailGrid.Margin = new Padding(3, 2, 3, 2);
            DetailGrid.MultiSelect = false;
            DetailGrid.Name = "DetailGrid";
            DetailGrid.ReadOnly = true;
            DetailGrid.RowHeadersVisible = false;
            DetailGrid.RowHeadersWidth = 5;
            DetailGrid.RowTemplate.Height = 24;
            DetailGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DetailGrid.Size = new Size(298, 810);
            DetailGrid.TabIndex = 1;
            // 
            // grBoxDetail
            // 
            grBoxDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grBoxDetail.Controls.Add(DetailGrid);
            grBoxDetail.Location = new Point(867, 0);
            grBoxDetail.Margin = new Padding(3, 2, 3, 2);
            grBoxDetail.Name = "grBoxDetail";
            grBoxDetail.Padding = new Padding(3, 2, 3, 2);
            grBoxDetail.Size = new Size(308, 844);
            grBoxDetail.TabIndex = 7;
            grBoxDetail.TabStop = false;
            grBoxDetail.Text = "Типоразмер";
            // 
            // picBox
            // 
            picBox.BackColor = Color.Transparent;
            picBox.Location = new Point(407, 28);
            picBox.Margin = new Padding(3, 2, 3, 2);
            picBox.Name = "picBox";
            picBox.Size = new Size(200, 300);
            picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            picBox.TabIndex = 5;
            picBox.TabStop = false;
            // 
            // MasterGrid
            // 
            MasterGrid.AllowUserToAddRows = false;
            MasterGrid.AllowUserToDeleteRows = false;
            MasterGrid.AllowUserToOrderColumns = true;
            MasterGrid.BackgroundColor = SystemColors.Control;
            MasterGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            MasterGrid.DefaultCellStyle = dataGridViewCellStyle2;
            MasterGrid.Dock = DockStyle.Fill;
            MasterGrid.Location = new Point(3, 26);
            MasterGrid.Margin = new Padding(3, 2, 3, 2);
            MasterGrid.MultiSelect = false;
            MasterGrid.Name = "MasterGrid";
            MasterGrid.ReadOnly = true;
            MasterGrid.RowHeadersVisible = false;
            MasterGrid.RowHeadersWidth = 5;
            MasterGrid.RowTemplate.Height = 50;
            MasterGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MasterGrid.Size = new Size(394, 302);
            MasterGrid.TabIndex = 0;
            MasterGrid.CellContentClick += MasterGrid_CellContentClick;
            MasterGrid.RowEnter += MasterGrid_RowEnter;
            // 
            // grBoxMaster
            // 
            grBoxMaster.Controls.Add(MasterGrid);
            grBoxMaster.Location = new Point(0, 0);
            grBoxMaster.Margin = new Padding(3, 2, 3, 2);
            grBoxMaster.Name = "grBoxMaster";
            grBoxMaster.Padding = new Padding(3, 2, 3, 2);
            grBoxMaster.Size = new Size(400, 330);
            grBoxMaster.TabIndex = 6;
            grBoxMaster.TabStop = false;
            grBoxMaster.Text = "Стандарт";
            // 
            // ds
            // 
            ds.DataSetName = "NewDataSet";
            // 
            // masterBinding
            // 
            masterBinding.DataSource = ds;
            masterBinding.Position = 0;
            // 
            // detailBinding
            // 
            detailBinding.DataSource = masterBinding;
            detailBinding.Position = 0;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(616, 28);
            btnInsert.Margin = new Padding(4, 6, 4, 6);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(243, 51);
            btnInsert.TabIndex = 8;
            btnInsert.Text = "Включить";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(616, 92);
            btnDelete.Margin = new Padding(4, 6, 4, 6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(243, 51);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Исключить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(616, 156);
            btnSave.Margin = new Padding(4, 6, 4, 6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(243, 51);
            btnSave.TabIndex = 8;
            btnSave.Text = "Сохранить в XML";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(613, 278);
            btnCancel.Margin = new Padding(4, 6, 4, 6);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(243, 51);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Прервать";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // listViewSelected
            // 
            listViewSelected.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listViewSelected.BackColor = SystemColors.Info;
            listViewSelected.CheckBoxes = true;
            listViewSelected.Columns.AddRange(new ColumnHeader[] { Picture, ID, TypNum, ProfilName, Size });
            listViewSelected.FullRowSelect = true;
            listViewSelected.GridLines = true;
            listViewSelected.Location = new Point(3, 342);
            listViewSelected.Margin = new Padding(4, 6, 4, 6);
            listViewSelected.Name = "listViewSelected";
            listViewSelected.Size = new Size(851, 497);
            listViewSelected.TabIndex = 9;
            listViewSelected.UseCompatibleStateImageBehavior = false;
            listViewSelected.View = View.Details;
            // 
            // Picture
            // 
            Picture.Text = "Профиль";
            Picture.Width = 64;
            // 
            // ID
            // 
            ID.Text = "Код стандарта";
            // 
            // TypNum
            // 
            TypNum.Text = "Код типоразм.";
            // 
            // ProfilName
            // 
            ProfilName.Text = "Наименование проф.";
            ProfilName.Width = 216;
            // 
            // Size
            // 
            Size.Text = "Типоразмер";
            Size.Width = 95;
            // 
            // btnRestore
            // 
            btnRestore.Location = new Point(613, 219);
            btnRestore.Margin = new Padding(4, 6, 4, 6);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(243, 51);
            btnRestore.TabIndex = 8;
            btnRestore.Text = "Восстановить из XML";
            btnRestore.UseVisualStyleBackColor = true;
            btnRestore.Click += btnRestore_Click;
            // 
            // Pathlabel
            // 
            Pathlabel.AutoSize = true;
            Pathlabel.Location = new Point(16, 290);
            Pathlabel.Name = "Pathlabel";
            Pathlabel.Size = new Size(0, 25);
            Pathlabel.TabIndex = 10;
            // 
            // SetupForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1178, 844);
            Controls.Add(Pathlabel);
            Controls.Add(listViewSelected);
            Controls.Add(btnRestore);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnInsert);
            Controls.Add(grBoxDetail);
            Controls.Add(picBox);
            Controls.Add(grBoxMaster);
            Margin = new Padding(4, 6, 4, 6);
            Name = "SetupForm";
            Text = "Настройка палитры";
            TopMost = true;
            Load += SetupForm_Load;
            ((System.ComponentModel.ISupportInitialize)DetailGrid).EndInit();
            grBoxDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)MasterGrid).EndInit();
            grBoxMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ds).EndInit();
            ((System.ComponentModel.ISupportInitialize)masterBinding).EndInit();
            ((System.ComponentModel.ISupportInitialize)detailBinding).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView DetailGrid;
        private System.Windows.Forms.GroupBox grBoxDetail;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.DataGridView MasterGrid;
        private System.Windows.Forms.GroupBox grBoxMaster;
        private System.Data.DataSet ds;
        private System.Windows.Forms.BindingSource masterBinding;
        private System.Windows.Forms.BindingSource detailBinding;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView listViewSelected;
        private System.Windows.Forms.ColumnHeader Picture;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader TypNum;
        private System.Windows.Forms.ColumnHeader ProfilName;
        private new System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label Pathlabel;
    }
}