namespace LasMAN
{
    partial class Frm_User
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
            this.CBE_Screen = new DevExpress.XtraEditors.ComboBoxEdit();
            this.CBC_Check = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.GC_User = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GC_Set = new DevExpress.XtraEditors.GroupControl();
            this.GC_PC = new DevExpress.XtraEditors.GroupControl();
            this.BT_EditSlaveIp = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.TE_SlaveIP = new DevExpress.XtraEditors.TextEdit();
            this.BT_EditIP = new DevExpress.XtraEditors.SimpleButton();
            this.BT_ImportDB = new DevExpress.XtraEditors.SimpleButton();
            this.BT_BackupDB = new DevExpress.XtraEditors.SimpleButton();
            this.TE_IP = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.BT_OK = new DevExpress.XtraEditors.SimpleButton();
            this.GC_Oper = new DevExpress.XtraEditors.GroupControl();
            this.BT_Add = new DevExpress.XtraEditors.SimpleButton();
            this.BT_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.BT_Edit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.CBE_Screen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CBC_Check)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GC_User)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GC_Set)).BeginInit();
            this.GC_Set.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GC_PC)).BeginInit();
            this.GC_PC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TE_SlaveIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_IP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GC_Oper)).BeginInit();
            this.GC_Oper.SuspendLayout();
            this.SuspendLayout();
            // 
            // CBE_Screen
            // 
            this.CBE_Screen.EditValue = "操作员";
            this.CBE_Screen.Location = new System.Drawing.Point(25, 39);
            this.CBE_Screen.Name = "CBE_Screen";
            this.CBE_Screen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CBE_Screen.Properties.Items.AddRange(new object[] {
            "操作员",
            "一般管理员",
            "高级管理员"});
            this.CBE_Screen.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.CBE_Screen.Size = new System.Drawing.Size(184, 20);
            this.CBE_Screen.TabIndex = 4;
            this.CBE_Screen.SelectedIndexChanged += new System.EventHandler(this.CBE_Screen_SelectedIndexChanged);
            // 
            // CBC_Check
            // 
            this.CBC_Check.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "主控机器人"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "从控机器人"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "外设"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "生产监控"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "配置管理")});
            this.CBC_Check.Location = new System.Drawing.Point(25, 65);
            this.CBC_Check.Name = "CBC_Check";
            this.CBC_Check.Size = new System.Drawing.Size(184, 118);
            this.CBC_Check.TabIndex = 3;
            // 
            // GC_User
            // 
            this.GC_User.Dock = System.Windows.Forms.DockStyle.Top;
            this.GC_User.Location = new System.Drawing.Point(0, 0);
            this.GC_User.MainView = this.gv;
            this.GC_User.Name = "GC_User";
            this.GC_User.Size = new System.Drawing.Size(822, 442);
            this.GC_User.TabIndex = 9;
            this.GC_User.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.GridControl = this.GC_User;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gv.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsCustomization.AllowColumnMoving = false;
            this.gv.OptionsCustomization.AllowColumnResizing = false;
            this.gv.OptionsCustomization.AllowFilter = false;
            this.gv.OptionsCustomization.AllowGroup = false;
            this.gv.OptionsCustomization.AllowSort = false;
            this.gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv.OptionsView.EnableAppearanceOddRow = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.SynchronizeClones = false;
            // 
            // GC_Set
            // 
            this.GC_Set.Controls.Add(this.GC_PC);
            this.GC_Set.Controls.Add(this.BT_OK);
            this.GC_Set.Controls.Add(this.CBE_Screen);
            this.GC_Set.Controls.Add(this.CBC_Check);
            this.GC_Set.Dock = System.Windows.Forms.DockStyle.Right;
            this.GC_Set.Location = new System.Drawing.Point(822, 0);
            this.GC_Set.Name = "GC_Set";
            this.GC_Set.Size = new System.Drawing.Size(244, 537);
            this.GC_Set.TabIndex = 10;
            this.GC_Set.Text = "权限定义";
            // 
            // GC_PC
            // 
            this.GC_PC.Controls.Add(this.BT_EditSlaveIp);
            this.GC_PC.Controls.Add(this.labelControl2);
            this.GC_PC.Controls.Add(this.TE_SlaveIP);
            this.GC_PC.Controls.Add(this.BT_EditIP);
            this.GC_PC.Controls.Add(this.BT_ImportDB);
            this.GC_PC.Controls.Add(this.BT_BackupDB);
            this.GC_PC.Controls.Add(this.TE_IP);
            this.GC_PC.Controls.Add(this.labelControl1);
            this.GC_PC.Location = new System.Drawing.Point(9, 230);
            this.GC_PC.Name = "GC_PC";
            this.GC_PC.Size = new System.Drawing.Size(226, 295);
            this.GC_PC.TabIndex = 5;
            this.GC_PC.Text = "软件选项配置选项";
            // 
            // BT_EditSlaveIp
            // 
            this.BT_EditSlaveIp.Location = new System.Drawing.Point(57, 173);
            this.BT_EditSlaveIp.Name = "BT_EditSlaveIp";
            this.BT_EditSlaveIp.Size = new System.Drawing.Size(137, 23);
            this.BT_EditSlaveIp.TabIndex = 15;
            this.BT_EditSlaveIp.Text = "输入从控控制器IP";
            this.BT_EditSlaveIp.Click += new System.EventHandler(this.BT_EditSlaveIp_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 63);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(98, 13);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "从控控制器IP地址:";
            // 
            // TE_SlaveIP
            // 
            this.TE_SlaveIP.Enabled = false;
            this.TE_SlaveIP.Location = new System.Drawing.Point(120, 56);
            this.TE_SlaveIP.Name = "TE_SlaveIP";
            this.TE_SlaveIP.Size = new System.Drawing.Size(84, 20);
            this.TE_SlaveIP.TabIndex = 13;
            // 
            // BT_EditIP
            // 
            this.BT_EditIP.Location = new System.Drawing.Point(57, 144);
            this.BT_EditIP.Name = "BT_EditIP";
            this.BT_EditIP.Size = new System.Drawing.Size(137, 23);
            this.BT_EditIP.TabIndex = 12;
            this.BT_EditIP.Text = "输入主控控制器IP";
            this.BT_EditIP.Click += new System.EventHandler(this.BT_EditIP_Click);
            // 
            // BT_ImportDB
            // 
            this.BT_ImportDB.Location = new System.Drawing.Point(57, 116);
            this.BT_ImportDB.Name = "BT_ImportDB";
            this.BT_ImportDB.Size = new System.Drawing.Size(137, 23);
            this.BT_ImportDB.TabIndex = 9;
            this.BT_ImportDB.Text = "导入数据库";
            this.BT_ImportDB.Click += new System.EventHandler(this.BT_ImportDB_Click);
            // 
            // BT_BackupDB
            // 
            this.BT_BackupDB.Location = new System.Drawing.Point(57, 84);
            this.BT_BackupDB.Name = "BT_BackupDB";
            this.BT_BackupDB.Size = new System.Drawing.Size(137, 23);
            this.BT_BackupDB.TabIndex = 8;
            this.BT_BackupDB.Text = "备份数据库";
            this.BT_BackupDB.Click += new System.EventHandler(this.BT_BackupDB_Click);
            // 
            // TE_IP
            // 
            this.TE_IP.Enabled = false;
            this.TE_IP.Location = new System.Drawing.Point(120, 30);
            this.TE_IP.Name = "TE_IP";
            this.TE_IP.Size = new System.Drawing.Size(84, 20);
            this.TE_IP.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(98, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "主控控制器IP地址:";
            // 
            // BT_OK
            // 
            this.BT_OK.Location = new System.Drawing.Point(66, 189);
            this.BT_OK.Name = "BT_OK";
            this.BT_OK.Size = new System.Drawing.Size(75, 23);
            this.BT_OK.TabIndex = 0;
            this.BT_OK.Text = "确定";
            this.BT_OK.Click += new System.EventHandler(this.BT_OK_Click);
            // 
            // GC_Oper
            // 
            this.GC_Oper.Controls.Add(this.BT_Add);
            this.GC_Oper.Controls.Add(this.BT_Delete);
            this.GC_Oper.Controls.Add(this.BT_Edit);
            this.GC_Oper.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GC_Oper.Location = new System.Drawing.Point(0, 448);
            this.GC_Oper.Name = "GC_Oper";
            this.GC_Oper.Size = new System.Drawing.Size(822, 89);
            this.GC_Oper.TabIndex = 11;
            this.GC_Oper.Text = "操作";
            // 
            // BT_Add
            // 
            this.BT_Add.Location = new System.Drawing.Point(24, 40);
            this.BT_Add.Name = "BT_Add";
            this.BT_Add.Size = new System.Drawing.Size(75, 23);
            this.BT_Add.TabIndex = 5;
            this.BT_Add.Text = "增加";
            this.BT_Add.Click += new System.EventHandler(this.BT_Add_Click);
            // 
            // BT_Delete
            // 
            this.BT_Delete.Location = new System.Drawing.Point(145, 40);
            this.BT_Delete.Name = "BT_Delete";
            this.BT_Delete.Size = new System.Drawing.Size(75, 23);
            this.BT_Delete.TabIndex = 6;
            this.BT_Delete.Text = "删除";
            this.BT_Delete.Click += new System.EventHandler(this.BT_Delete_Click);
            // 
            // BT_Edit
            // 
            this.BT_Edit.Location = new System.Drawing.Point(268, 40);
            this.BT_Edit.Name = "BT_Edit";
            this.BT_Edit.Size = new System.Drawing.Size(75, 23);
            this.BT_Edit.TabIndex = 7;
            this.BT_Edit.Text = "编辑";
            this.BT_Edit.Click += new System.EventHandler(this.BT_Edit_Click);
            // 
            // Frm_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 537);
            this.Controls.Add(this.GC_Oper);
            this.Controls.Add(this.GC_User);
            this.Controls.Add(this.GC_Set);
            this.Name = "Frm_User";
            this.Text = "Frm_User";
            this.Load += new System.EventHandler(this.Frm_User_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CBE_Screen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CBC_Check)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GC_User)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GC_Set)).EndInit();
            this.GC_Set.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GC_PC)).EndInit();
            this.GC_PC.ResumeLayout(false);
            this.GC_PC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TE_SlaveIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TE_IP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GC_Oper)).EndInit();
            this.GC_Oper.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit CBE_Screen;
        private DevExpress.XtraEditors.CheckedListBoxControl CBC_Check;
        public DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraEditors.GroupControl GC_Set;
        private DevExpress.XtraEditors.SimpleButton BT_OK;
        private DevExpress.XtraEditors.GroupControl GC_Oper;
        public DevExpress.XtraEditors.SimpleButton BT_Add;
        public DevExpress.XtraEditors.SimpleButton BT_Delete;
        public DevExpress.XtraEditors.SimpleButton BT_Edit;
        public DevExpress.XtraGrid.GridControl GC_User;
        private DevExpress.XtraEditors.GroupControl GC_PC;
        private DevExpress.XtraEditors.SimpleButton BT_EditSlaveIp;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit TE_SlaveIP;
        private DevExpress.XtraEditors.SimpleButton BT_EditIP;
        private DevExpress.XtraEditors.SimpleButton BT_ImportDB;
        private DevExpress.XtraEditors.SimpleButton BT_BackupDB;
        private DevExpress.XtraEditors.TextEdit TE_IP;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}