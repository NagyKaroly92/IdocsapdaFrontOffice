namespace DeclarationOfConsentForm.UserControls
{
    partial class GamePropertyUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            comboBox2 = new ComboBox();
            pictureBox1 = new PictureBox();
            cb_Time1 = new ComboBox();
            cb_Time2 = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 14F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(593, 18);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(399, 39);
            comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoEllipsis = true;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Calibri", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(233, 21);
            label2.Name = "label2";
            label2.Size = new Size(221, 33);
            label2.TabIndex = 2;
            label2.Text = "Pálya kiválasztása";
            label2.TextAlign = ContentAlignment.TopCenter;
            label2.Paint += label1_Paint;
            // 
            // label3
            // 
            label3.AutoEllipsis = true;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Calibri", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(233, 98);
            label3.Name = "label3";
            label3.Size = new Size(101, 33);
            label3.TabIndex = 4;
            label3.Text = "Időpont";
            label3.TextAlign = ContentAlignment.TopCenter;
            label3.Paint += label1_Paint;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "HH:mm";
            dateTimePicker1.Font = new Font("Segoe UI", 14F);
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(455, 329);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(399, 39);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.Visible = false;
            // 
            // label4
            // 
            label4.AutoEllipsis = true;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Calibri", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(233, 176);
            label4.Name = "label4";
            label4.Size = new Size(106, 33);
            label4.TabIndex = 7;
            label4.Text = "Létszám";
            label4.TextAlign = ContentAlignment.TopCenter;
            label4.Paint += label1_Paint;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Font = new Font("Segoe UI", 14F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(593, 173);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(399, 39);
            comboBox2.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources.hand_drawn_cartoon_design_button_5504519;
            pictureBox1.Location = new Point(892, 294);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(105, 89);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += button1_Click;
            // 
            // cb_Time1
            // 
            cb_Time1.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Time1.Font = new Font("Segoe UI", 14F);
            cb_Time1.FormattingEnabled = true;
            cb_Time1.Location = new Point(593, 96);
            cb_Time1.Name = "cb_Time1";
            cb_Time1.Size = new Size(176, 39);
            cb_Time1.TabIndex = 9;
            // 
            // cb_Time2
            // 
            cb_Time2.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Time2.Font = new Font("Segoe UI", 14F);
            cb_Time2.FormattingEnabled = true;
            cb_Time2.Location = new Point(827, 96);
            cb_Time2.Name = "cb_Time2";
            cb_Time2.Size = new Size(165, 39);
            cb_Time2.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(792, 99);
            label1.Name = "label1";
            label1.Size = new Size(19, 32);
            label1.TabIndex = 11;
            label1.Text = ":";
            // 
            // GamePropertyUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(cb_Time2);
            Controls.Add(cb_Time1);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(comboBox2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Name = "GamePropertyUserControl";
            Size = new Size(1092, 456);
            Load += GamePropertyUserControl_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBox1;
        private Label label2;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private ComboBox comboBox2;
        private PictureBox pictureBox1;
        private ComboBox cb_Time1;
        private ComboBox cb_Time2;
        private Label label1;
    }
}
