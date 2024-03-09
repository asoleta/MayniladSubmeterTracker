using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //allows you to connect to sql database

namespace MayniladSubmeterTracker
{
    public partial class filterDataResults : Form
    {
        public filterDataResults()
        {
            InitializeComponent();
        }

        //the close button stops and closes the application 
        private void closeBtn_Click(object sender, EventArgs e)
        {
            //close the calculated values form
            this.Close();

            //show the homepage
            homepage homepage = new homepage();
            homepage.Show();
        }
    }
}
