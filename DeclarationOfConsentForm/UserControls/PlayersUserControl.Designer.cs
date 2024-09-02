namespace DeclarationOfConsentForm.UserControls
{
    partial class PlayersUserControl
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
            button1 = new Button();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            listView1 = new ListView();
            linkLabel1 = new LinkLabel();
            label8 = new Label();
            button2 = new Button();
            tb_Name = new Controls.PlaceholderTextBox();
            tb_Email = new Controls.PlaceholderTextBox();
            tb_BirthYear = new Controls.PlaceholderTextBox();
            tb_BirthDate = new Controls.PlaceholderTextBox();
            tb_ZipCode = new Controls.PlaceholderTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(839, 494);
            button1.Name = "button1";
            button1.Size = new Size(77, 29);
            button1.TabIndex = 21;
            button1.Text = "Mentés";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.BackColor = Color.Transparent;
            checkBox2.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic);
            checkBox2.ForeColor = SystemColors.ControlLightLight;
            checkBox2.Location = new Point(228, 371);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(153, 32);
            checkBox2.TabIndex = 20;
            checkBox2.Text = "elfogadom 2";
            checkBox2.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.Transparent;
            checkBox1.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic);
            checkBox1.ForeColor = SystemColors.ControlLightLight;
            checkBox1.Location = new Point(228, 326);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(153, 32);
            checkBox1.TabIndex = 19;
            checkBox1.Text = "elfogadom 1";
            checkBox1.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(200, 215);
            label4.Name = "label4";
            label4.Size = new Size(53, 28);
            label4.TabIndex = 17;
            label4.Text = "IRSZ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(200, 165);
            label3.Name = "label3";
            label3.Size = new Size(125, 28);
            label3.TabIndex = 15;
            label3.Text = "Születésnap";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(200, 71);
            label2.Name = "label2";
            label2.Size = new Size(65, 28);
            label2.TabIndex = 13;
            label2.Text = "Email";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(200, 27);
            label1.Name = "label1";
            label1.Size = new Size(49, 28);
            label1.TabIndex = 11;
            label1.Text = "Név";
            // 
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listView1.BackColor = SystemColors.ControlDark;
            listView1.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic);
            listView1.Location = new Point(11, 0);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Scrollable = false;
            listView1.Size = new Size(164, 513);
            listView1.TabIndex = 22;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Tile;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic);
            linkLabel1.Location = new Point(372, 370);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(118, 28);
            linkLabel1.TabIndex = 25;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "nyilatkozat";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic);
            label8.ForeColor = SystemColors.ControlLightLight;
            label8.Location = new Point(200, 115);
            label8.Name = "label8";
            label8.Size = new Size(122, 28);
            label8.TabIndex = 28;
            label8.Text = "Születési év";
            // 
            // button2
            // 
            button2.Location = new Point(656, 361);
            button2.Name = "button2";
            button2.Size = new Size(129, 45);
            button2.TabIndex = 31;
            button2.Text = "Következő";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // tb_Name
            // 
            tb_Name.ForeColor = Color.Gray;
            tb_Name.Location = new Point(547, 27);
            tb_Name.Name = "tb_Name";
            tb_Name.PlaceholderText = "Péda Játékos";
            tb_Name.Size = new Size(238, 27);
            tb_Name.TabIndex = 32;
            tb_Name.Text = "Péda Játékos";
            // 
            // tb_Email
            // 
            tb_Email.ForeColor = Color.Gray;
            tb_Email.Location = new Point(547, 71);
            tb_Email.Name = "tb_Email";
            tb_Email.PlaceholderText = "pelda@example.com";
            tb_Email.Size = new Size(238, 27);
            tb_Email.TabIndex = 33;
            tb_Email.Text = "pelda@example.com";
            // 
            // tb_BirthYear
            // 
            tb_BirthYear.ForeColor = Color.Gray;
            tb_BirthYear.Location = new Point(547, 116);
            tb_BirthYear.Name = "tb_BirthYear";
            tb_BirthYear.PlaceholderText = "1995";
            tb_BirthYear.Size = new Size(238, 27);
            tb_BirthYear.TabIndex = 34;
            tb_BirthYear.Text = "1995";
            // 
            // tb_BirthDate
            // 
            tb_BirthDate.ForeColor = Color.Gray;
            tb_BirthDate.Location = new Point(547, 165);
            tb_BirthDate.Name = "tb_BirthDate";
            tb_BirthDate.PlaceholderText = "10.25";
            tb_BirthDate.Size = new Size(238, 27);
            tb_BirthDate.TabIndex = 35;
            tb_BirthDate.Text = "10.25";
            // 
            // tb_ZipCode
            // 
            tb_ZipCode.ForeColor = Color.Gray;
            tb_ZipCode.Location = new Point(547, 218);
            tb_ZipCode.Name = "tb_ZipCode";
            tb_ZipCode.PlaceholderText = "1075";
            tb_ZipCode.Size = new Size(238, 27);
            tb_ZipCode.TabIndex = 36;
            tb_ZipCode.Text = "1075";
            // 
            // PlayersUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tb_ZipCode);
            Controls.Add(tb_BirthDate);
            Controls.Add(tb_BirthYear);
            Controls.Add(tb_Email);
            Controls.Add(tb_Name);
            Controls.Add(button2);
            Controls.Add(label8);
            Controls.Add(linkLabel1);
            Controls.Add(listView1);
            Controls.Add(button1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PlayersUserControl";
            Size = new Size(919, 526);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ListView listView1;
        private LinkLabel linkLabel1;
        private Label label8;
        private Button button2;
        private Controls.PlaceholderTextBox tb_Name;
        private Controls.PlaceholderTextBox tb_Email;
        private Controls.PlaceholderTextBox tb_BirthYear;
        private Controls.PlaceholderTextBox tb_BirthDate;
        private Controls.PlaceholderTextBox tb_ZipCode;
    }
}
