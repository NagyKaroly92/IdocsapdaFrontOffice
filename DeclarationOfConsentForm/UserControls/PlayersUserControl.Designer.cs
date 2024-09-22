using BLL;

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

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            l_ZipCode = new Label();
            l_BirthDate = new Label();
            l_Email = new Label();
            l_Name = new Label();
            listView1 = new ListView();
            linkLabel1 = new LinkLabel();
            l_BirthYear = new Label();
            tb_Name = new Controls.PlaceholderTextBox();
            tb_Email = new Controls.PlaceholderTextBox();
            tb_BirthYear = new Controls.PlaceholderTextBox();
            tb_BirthDate = new Controls.PlaceholderTextBox();
            tb_ZipCode = new Controls.PlaceholderTextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(1043, 499);
            button1.Name = "button1";
            button1.Size = new Size(99, 42);
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
            checkBox2.Location = new Point(200, 317);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(633, 32);
            checkBox2.TabIndex = 20;
            checkBox2.Text = "Az                                                   megkaptam és tudomásul vettem.";
            checkBox2.UseVisualStyleBackColor = false;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.Transparent;
            checkBox1.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic);
            checkBox1.ForeColor = SystemColors.ControlLightLight;
            checkBox1.Location = new Point(200, 272);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(849, 32);
            checkBox1.TabIndex = 19;
            checkBox1.Text = "A fent leírt információkat tudomásul vettem, és elfogadom a játékra szólószabályokat.";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // l_ZipCode
            // 
            l_ZipCode.AutoSize = true;
            l_ZipCode.BackColor = Color.Transparent;
            l_ZipCode.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic);
            l_ZipCode.ForeColor = SystemColors.ControlLightLight;
            l_ZipCode.Location = new Point(200, 215);
            l_ZipCode.Name = "l_ZipCode";
            l_ZipCode.Size = new Size(53, 28);
            l_ZipCode.TabIndex = 17;
            l_ZipCode.Text = "IRSZ";
            // 
            // l_BirthDate
            // 
            l_BirthDate.AutoSize = true;
            l_BirthDate.BackColor = Color.Transparent;
            l_BirthDate.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic);
            l_BirthDate.ForeColor = SystemColors.ControlLightLight;
            l_BirthDate.Location = new Point(200, 165);
            l_BirthDate.Name = "l_BirthDate";
            l_BirthDate.Size = new Size(125, 28);
            l_BirthDate.TabIndex = 15;
            l_BirthDate.Text = "Születésnap";
            // 
            // l_Email
            // 
            l_Email.AutoSize = true;
            l_Email.BackColor = Color.Transparent;
            l_Email.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic);
            l_Email.ForeColor = SystemColors.ControlLightLight;
            l_Email.Location = new Point(200, 71);
            l_Email.Name = "l_Email";
            l_Email.Size = new Size(65, 28);
            l_Email.TabIndex = 13;
            l_Email.Text = "Email";
            // 
            // l_Name
            // 
            l_Name.AutoSize = true;
            l_Name.BackColor = Color.Transparent;
            l_Name.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic);
            l_Name.ForeColor = SystemColors.ControlLightLight;
            l_Name.Location = new Point(200, 27);
            l_Name.Name = "l_Name";
            l_Name.Size = new Size(49, 28);
            l_Name.TabIndex = 11;
            l_Name.Text = "Név";
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
            listView1.Size = new Size(164, 531);
            listView1.TabIndex = 22;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Tile;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic);
            linkLabel1.Location = new Point(251, 317);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(252, 28);
            linkLabel1.TabIndex = 25;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "adatvédelmi tájékoztatót";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // l_BirthYear
            // 
            l_BirthYear.AutoSize = true;
            l_BirthYear.BackColor = Color.Transparent;
            l_BirthYear.Font = new Font("Calibri", 13.8F, FontStyle.Bold | FontStyle.Italic);
            l_BirthYear.ForeColor = SystemColors.ControlLightLight;
            l_BirthYear.Location = new Point(200, 115);
            l_BirthYear.Name = "l_BirthYear";
            l_BirthYear.Size = new Size(122, 28);
            l_BirthYear.TabIndex = 28;
            l_BirthYear.Text = "Születési év";
            // 
            // tb_Name
            // 
            tb_Name.ForeColor = Color.DarkGray;
            tb_Name.Location = new Point(547, 27);
            tb_Name.Name = "tb_Name";
            tb_Name.PlaceholderText = "pl.: Péda Játékos";
            tb_Name.Size = new Size(238, 27);
            tb_Name.TabIndex = 32;
            tb_Name.Text = "pl.: Péda Játékos";
            // 
            // tb_Email
            // 
            tb_Email.ForeColor = Color.DarkGray;
            tb_Email.Location = new Point(547, 71);
            tb_Email.Name = "tb_Email";
            tb_Email.PlaceholderText = "pl.: pelda@example.com";
            tb_Email.Size = new Size(238, 27);
            tb_Email.TabIndex = 33;
            tb_Email.Text = "pl.: pelda@example.com";
            // 
            // tb_BirthYear
            // 
            tb_BirthYear.ForeColor = Color.DarkGray;
            tb_BirthYear.Location = new Point(547, 116);
            tb_BirthYear.Name = "tb_BirthYear";
            tb_BirthYear.PlaceholderText = "pl.: 1995";
            tb_BirthYear.Size = new Size(238, 27);
            tb_BirthYear.TabIndex = 34;
            tb_BirthYear.Text = "pl.: 1995";
            // 
            // tb_BirthDate
            // 
            tb_BirthDate.ForeColor = Color.DarkGray;
            tb_BirthDate.Location = new Point(547, 165);
            tb_BirthDate.Name = "tb_BirthDate";
            tb_BirthDate.PlaceholderText = "pl.: 10.25";
            tb_BirthDate.Size = new Size(238, 27);
            tb_BirthDate.TabIndex = 35;
            tb_BirthDate.Text = "pl.: 10.25";
            // 
            // tb_ZipCode
            // 
            tb_ZipCode.ForeColor = Color.DarkGray;
            tb_ZipCode.Location = new Point(547, 218);
            tb_ZipCode.Name = "tb_ZipCode";
            tb_ZipCode.PlaceholderText = "pl.: 1075";
            tb_ZipCode.Size = new Size(238, 27);
            tb_ZipCode.TabIndex = 36;
            tb_ZipCode.Text = "pl.: 1075";
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = Properties.Resources.hand_drawn_cartoon_design_button_5504519;
            pictureBox1.Location = new Point(719, 375);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(66, 66);
            pictureBox1.TabIndex = 37;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // PlayersUserControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(tb_ZipCode);
            Controls.Add(tb_BirthDate);
            Controls.Add(tb_BirthYear);
            Controls.Add(tb_Email);
            Controls.Add(tb_Name);
            Controls.Add(l_BirthYear);
            Controls.Add(linkLabel1);
            Controls.Add(listView1);
            Controls.Add(button1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(l_ZipCode);
            Controls.Add(l_BirthDate);
            Controls.Add(l_Email);
            Controls.Add(l_Name);
            Name = "PlayersUserControl";
            Size = new Size(1145, 544);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void SetPlaceholders()
        {
            if (!RoomLogic.IsEnglish)
            {
                tb_Name.PlaceholderText = "pl.: Péda Játékos";
                tb_Email.PlaceholderText = "pl.: pelda@example.com";
                tb_BirthYear.PlaceholderText = "pl.: 1995";
                tb_BirthDate.PlaceholderText = "pl.: 10.25";
                tb_ZipCode.PlaceholderText = "pl.: 1075";
            }
            else
            {
                tb_Name.PlaceholderText = "e.g.: John Doe";
                tb_Email.PlaceholderText = "e.g.: example@example.com";
                tb_BirthYear.PlaceholderText = "e.g.: 1995";
                tb_BirthDate.PlaceholderText = "e.g.: 10.25";
                tb_ZipCode.PlaceholderText = "e.g.: 1075";
            }
        }

        private Button button1;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label l_ZipCode;
        private Label l_BirthDate;
        private Label l_Email;
        private Label l_Name;
        private ListView listView1;
        private LinkLabel linkLabel1;
        private Label l_BirthYear;
        private Controls.PlaceholderTextBox tb_Name;
        private Controls.PlaceholderTextBox tb_Email;
        private Controls.PlaceholderTextBox tb_BirthYear;
        private Controls.PlaceholderTextBox tb_BirthDate;
        private Controls.PlaceholderTextBox tb_ZipCode;
        private PictureBox pictureBox1;
    }
}
