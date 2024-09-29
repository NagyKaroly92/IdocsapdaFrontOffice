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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(258, 18);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(399, 28);
            comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoEllipsis = true;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(16, 18);
            label2.Name = "label2";
            label2.Size = new Size(187, 28);
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
            label3.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(16, 63);
            label3.Name = "label3";
            label3.Size = new Size(86, 28);
            label3.TabIndex = 4;
            label3.Text = "Időpont";
            label3.TextAlign = ContentAlignment.TopCenter;
            label3.Paint += label1_Paint;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "HH:mm";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(258, 67);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(399, 27);
            dateTimePicker1.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoEllipsis = true;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 238);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(16, 114);
            label4.Name = "label4";
            label4.Size = new Size(89, 28);
            label4.TabIndex = 7;
            label4.Text = "Létszám";
            label4.TextAlign = ContentAlignment.TopCenter;
            label4.Paint += label1_Paint;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(258, 114);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(399, 28);
            comboBox2.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources.hand_drawn_cartoon_design_button_5504519;
            pictureBox1.Location = new Point(575, 343);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(105, 89);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += button1_Click;
            // 
            // GamePropertyUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(comboBox2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Name = "GamePropertyUserControl";
            Size = new Size(695, 456);
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
    }
}
