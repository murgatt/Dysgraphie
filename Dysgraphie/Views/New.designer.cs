namespace Dysgraphie.Views
{
    partial class New
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.gradeSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.forenameInput = new System.Windows.Forms.TextBox();
            this.birthInput = new System.Windows.Forms.DateTimePicker();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.leftRadioBtn = new System.Windows.Forms.RadioButton();
            this.rightRadioBtn = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.girlRadioBtn = new System.Windows.Forms.RadioButton();
            this.boyRadioBtn = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.pathInput = new System.Windows.Forms.TextBox();
            this.browsBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.validateBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox5);
            this.flowLayoutPanel1.Controls.Add(this.groupBox4);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(443, 340);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(433, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informations";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gradeSelect, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.nameInput, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.forenameInput, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.birthInput, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(427, 124);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom :";
            // 
            // gradeSelect
            // 
            this.gradeSelect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gradeSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradeSelect.FormattingEnabled = true;
            this.gradeSelect.Items.AddRange(new object[] {
            "CP",
            "CE1",
            "CE2",
            "CM1",
            "CM2"});
            this.gradeSelect.Location = new System.Drawing.Point(216, 98);
            this.gradeSelect.Name = "gradeSelect";
            this.gradeSelect.Size = new System.Drawing.Size(208, 21);
            this.gradeSelect.TabIndex = 1;
            this.gradeSelect.TextChanged += new System.EventHandler(this.input_Changed);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Prénom :";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date de naissance :";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Classe :";
            // 
            // nameInput
            // 
            this.nameInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nameInput.Location = new System.Drawing.Point(216, 5);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(208, 20);
            this.nameInput.TabIndex = 8;
            this.nameInput.TextChanged += new System.EventHandler(this.input_Changed);
            // 
            // forenameInput
            // 
            this.forenameInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.forenameInput.Location = new System.Drawing.Point(216, 36);
            this.forenameInput.Name = "forenameInput";
            this.forenameInput.Size = new System.Drawing.Size(208, 20);
            this.forenameInput.TabIndex = 9;
            this.forenameInput.TextChanged += new System.EventHandler(this.input_Changed);
            // 
            // birthInput
            // 
            this.birthInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.birthInput.Location = new System.Drawing.Point(216, 67);
            this.birthInput.Name = "birthInput";
            this.birthInput.Size = new System.Drawing.Size(208, 20);
            this.birthInput.TabIndex = 10;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel3);
            this.groupBox5.Location = new System.Drawing.Point(3, 152);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(433, 41);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Latéralité";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.leftRadioBtn, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.rightRadioBtn, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(427, 22);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // leftRadioBtn
            // 
            this.leftRadioBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.leftRadioBtn.AutoSize = true;
            this.leftRadioBtn.Location = new System.Drawing.Point(73, 3);
            this.leftRadioBtn.Name = "leftRadioBtn";
            this.leftRadioBtn.Size = new System.Drawing.Size(66, 16);
            this.leftRadioBtn.TabIndex = 0;
            this.leftRadioBtn.TabStop = true;
            this.leftRadioBtn.Text = "Gaucher";
            this.leftRadioBtn.UseVisualStyleBackColor = true;
            this.leftRadioBtn.CheckedChanged += new System.EventHandler(this.input_Changed);
            // 
            // rightRadioBtn
            // 
            this.rightRadioBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rightRadioBtn.AutoSize = true;
            this.rightRadioBtn.Location = new System.Drawing.Point(291, 3);
            this.rightRadioBtn.Name = "rightRadioBtn";
            this.rightRadioBtn.Size = new System.Drawing.Size(58, 16);
            this.rightRadioBtn.TabIndex = 1;
            this.rightRadioBtn.TabStop = true;
            this.rightRadioBtn.Text = "Droitier";
            this.rightRadioBtn.UseVisualStyleBackColor = true;
            this.rightRadioBtn.CheckedChanged += new System.EventHandler(this.input_Changed);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel4);
            this.groupBox4.Location = new System.Drawing.Point(3, 199);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(433, 42);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Genre";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.girlRadioBtn, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.boyRadioBtn, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(427, 23);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // girlRadioBtn
            // 
            this.girlRadioBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.girlRadioBtn.AutoSize = true;
            this.girlRadioBtn.Location = new System.Drawing.Point(85, 3);
            this.girlRadioBtn.Name = "girlRadioBtn";
            this.girlRadioBtn.Size = new System.Drawing.Size(43, 17);
            this.girlRadioBtn.TabIndex = 0;
            this.girlRadioBtn.TabStop = true;
            this.girlRadioBtn.Text = "Fille";
            this.girlRadioBtn.UseVisualStyleBackColor = true;
            this.girlRadioBtn.CheckedChanged += new System.EventHandler(this.input_Changed);
            // 
            // boyRadioBtn
            // 
            this.boyRadioBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.boyRadioBtn.AutoSize = true;
            this.boyRadioBtn.Location = new System.Drawing.Point(290, 3);
            this.boyRadioBtn.Name = "boyRadioBtn";
            this.boyRadioBtn.Size = new System.Drawing.Size(60, 17);
            this.boyRadioBtn.TabIndex = 1;
            this.boyRadioBtn.TabStop = true;
            this.boyRadioBtn.Text = "Garçon";
            this.boyRadioBtn.UseVisualStyleBackColor = true;
            this.boyRadioBtn.CheckedChanged += new System.EventHandler(this.input_Changed);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(3, 247);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(433, 50);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Répertoire";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.pathInput);
            this.flowLayoutPanel2.Controls.Add(this.browsBtn);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(427, 31);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // pathInput
            // 
            this.pathInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pathInput.Location = new System.Drawing.Point(3, 4);
            this.pathInput.Name = "pathInput";
            this.pathInput.Size = new System.Drawing.Size(338, 20);
            this.pathInput.TabIndex = 0;
            this.pathInput.TextChanged += new System.EventHandler(this.input_Changed);
            // 
            // browsBtn
            // 
            this.browsBtn.Location = new System.Drawing.Point(347, 3);
            this.browsBtn.Name = "browsBtn";
            this.browsBtn.Size = new System.Drawing.Size(75, 23);
            this.browsBtn.TabIndex = 1;
            this.browsBtn.Text = "Parcourir...";
            this.browsBtn.UseVisualStyleBackColor = true;
            this.browsBtn.Click += new System.EventHandler(this.browsBtn_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.cancelBtn, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.validateBtn, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 303);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(433, 31);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(70, 3);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 0;
            this.cancelBtn.Text = "Annuler";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // validateBtn
            // 
            this.validateBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.validateBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.validateBtn.Enabled = false;
            this.validateBtn.Location = new System.Drawing.Point(287, 3);
            this.validateBtn.Name = "validateBtn";
            this.validateBtn.Size = new System.Drawing.Size(75, 23);
            this.validateBtn.TabIndex = 1;
            this.validateBtn.Text = "Valider";
            this.validateBtn.UseVisualStyleBackColor = true;
            this.validateBtn.Click += new System.EventHandler(this.validateBtn_Click);
            // 
            // New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 340);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "New";
            this.Text = "Nouveau";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox gradeSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.TextBox forenameInput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox pathInput;
        private System.Windows.Forms.Button browsBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button validateBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton leftRadioBtn;
        private System.Windows.Forms.RadioButton rightRadioBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.RadioButton girlRadioBtn;
        private System.Windows.Forms.RadioButton boyRadioBtn;
        private System.Windows.Forms.DateTimePicker birthInput;
    }
}