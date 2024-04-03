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

            //declare variables
            int monthSearch = 0;
            int yearSearch = 0;
            int waterUsage;
            double cost = 0.0;
            double amtDue = 0.0;
            double billTotal = 0.0;

            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-EF4ATSUG\\SQLEXPRESS01;Initial Catalog=Maynilad;Integrated Security=True;TrustServerCertificate=True"))
            {
                //open the connection
                connection.Open();
                
                // SQL query to retrieve month and year from searchQuery table
                string sqlQuery = "SELECT TOP 1 [month], [year] FROM searchQueries ORDER BY id DESC";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there are rows returned
                        if (reader.Read())
                        {
                            // Assign month and year values from the query result
                            monthSearch = Convert.ToInt32(reader["month"]);
                            yearSearch = Convert.ToInt32(reader["year"]);
                        }
                        else
                        {
                            Console.WriteLine("No rows found in searchQuery table.");
                        }
                    }

                    //close the connection
                    connection.Close();
                }
            }

            MessageBox.Show(monthSearch.ToString() + " " + yearSearch.ToString());
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
