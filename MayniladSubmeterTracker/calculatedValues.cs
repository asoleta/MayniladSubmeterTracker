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
    public partial class calculatedValues : Form
    {
        public calculatedValues()
        {
            InitializeComponent();

            //declare variables
            int month = 0;
            int year = 0;
            int waterUsage;
            double cost = 0.0;
            double amtDue = 0.0;
            double billTotal = 0.0;

            //will order the table by id in descending order
            string queryBillTotal = $"SELECT * FROM submeterReading WHERE month = @Month AND year = @Year";
            string querySub1a = "SELECT TOP 1 * FROM submeter1A ORDER BY id DESC;";
            string querySub2a = "SELECT TOP 1 * FROM submeter2A ORDER BY id DESC;";
            string querySub2b = "SELECT TOP 1 * FROM submeter2B ORDER BY id DESC;";
            string querySub3a = "SELECT TOP 1 * FROM submeter3A ORDER BY id DESC;";
            string querySub3b = "SELECT TOP 1 * FROM submeter3B ORDER BY id DESC;";

            using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-EF4ATSUG\\SQLEXPRESS01;Initial Catalog=Maynilad;Integrated Security=True;TrustServerCertificate=True"))
            {
                //open the connection to the dataset
                connection.Open();

                //execute the SQL queries
                //Submeter 1a
                using (SqlCommand command = new SqlCommand(querySub1a, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Access the columns by name and store them in variables
                            month = reader.GetInt32(reader.GetOrdinal("month"));
                            year = reader.GetInt32(reader.GetOrdinal("year"));
                            waterUsage = reader.GetInt32(reader.GetOrdinal("waterUsage"));
                            cost = Convert.ToDouble(reader["costPerCubic"]);
                            amtDue = Convert.ToDouble(reader["amtDue"]);

                            //Display the information in the textboxes
                            dateTB.Text = month.ToString() + "/" + year.ToString();
                            unit1waterTB.Text = waterUsage.ToString();
                            unit1CostTB.Text = cost.ToString("0.00") + "P";
                            unit1TotalTB.Text = amtDue.ToString("0.00") + "P";
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }

                //Submeter 2a
                using (SqlCommand command = new SqlCommand(querySub2a, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Access the columns by name and store them in variables
                            waterUsage = reader.GetInt32(reader.GetOrdinal("waterUsage"));
                            cost = Convert.ToDouble(reader["costPerCubic"]);
                            amtDue = Convert.ToDouble(reader["amtDue"]);

                            //Display the information in the textboxes
                            unit2aWaterTB.Text = waterUsage.ToString();
                            unit2aCostTB.Text = cost.ToString("0.00") + "P";
                            unit2aTotalTB.Text = amtDue.ToString("0.00") + "P";
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }

                //Submeter 2b
                using (SqlCommand command = new SqlCommand(querySub2b, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Access the columns by name and store them in variables
                            waterUsage = reader.GetInt32(reader.GetOrdinal("waterUsage"));
                            cost = Convert.ToDouble(reader["costPerCubic"]);
                            amtDue = Convert.ToDouble(reader["amtDue"]);

                            //Display the information in the textboxes
                            unit2bWaterTB.Text = waterUsage.ToString();
                            unit2bCostTB.Text = cost.ToString("0.00") + "P";
                            unit2bTotalTB.Text = amtDue.ToString("0.00") + "P";
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }

                //Submeter 3a
                using (SqlCommand command = new SqlCommand(querySub3a, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Access the columns by name and store them in variables
                            waterUsage = reader.GetInt32(reader.GetOrdinal("waterUsage"));
                            cost = Convert.ToDouble(reader["costPerCubic"]);
                            amtDue = Convert.ToDouble(reader["amtDue"]);

                            //Display the information in the textboxes
                            unit3aWaterTB.Text = waterUsage.ToString();
                            unit3aCostTB.Text = cost.ToString("0.00") + "P";
                            unit3aTotalTB.Text = amtDue.ToString("0.00") + "P";
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }

                //Submeter 3b
                using (SqlCommand command = new SqlCommand(querySub3b, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Access the columns by name and store them in variables
                            waterUsage = reader.GetInt32(reader.GetOrdinal("waterUsage"));
                            cost = Convert.ToDouble(reader["costPerCubic"]);
                            amtDue = Convert.ToDouble(reader["amtDue"]);

                            //Display the information in the textboxes
                            unit3bWaterTB.Text = waterUsage.ToString();
                            unit3bCostTB.Text = cost.ToString("0.00") + "P";
                            unit3bTotalTB.Text = amtDue.ToString("0.00") + "P";
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }

                //Total Bill
                using (SqlCommand command = new SqlCommand(queryBillTotal, connection))
                {
                    // Add parameters to the SqlCommand (prevent SQL injection)
                    command.Parameters.AddWithValue("@Month", month);
                    command.Parameters.AddWithValue("@Year", year);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Access the columns by name and store them in variables
                            billTotal = Convert.ToDouble(reader["billTotal"]);

                            //Display the information in the textboxes
                            totalBillTB.Text = billTotal.ToString("0.00") + "P";
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
            }
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
