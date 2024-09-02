using BLL;
using System;

namespace testapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.DataSource = PlayerDetailsLogic.GetDetails();
        }
    }
}
