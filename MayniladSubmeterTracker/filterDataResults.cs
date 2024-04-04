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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

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
                
                // SQL query to retrieve month and year from searchQueries table
                string sqlQuery = "SELECT TOP 1 [month], [year] FROM searchQueries ORDER BY id DESC";
                string queryBillTotal = $"SELECT * FROM submeterReading WHERE month = @Month AND year = @Year";
                string querySub1a = "SELECT * FROM submeter1A WHERE month = @Month AND year = @Year;";
                string querySub2a = "SELECT * FROM submeter2A WHERE month = @Month AND year = @Year;";
                string querySub2b = "SELECT * FROM submeter2B WHERE month = @Month AND year = @Year;";
                string querySub3a = "SELECT * FROM submeter3A WHERE month = @Month AND year = @Year;";
                string querySub3b = "SELECT * FROM submeter3B WHERE month = @Month AND year = @Year;";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Gets the desired month and year from the searchQueries table
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
                }

                //Submeter 1a
                using (SqlCommand command = new SqlCommand(querySub1a, connection))
                {
                    // Add parameters to the SqlCommand
                    command.Parameters.AddWithValue("@Month", monthSearch);
                    command.Parameters.AddWithValue("@Year", yearSearch);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Access the columns by name and store them in variables
                            //month = reader.GetInt32(reader.GetOrdinal("month"));
                            //year = reader.GetInt32(reader.GetOrdinal("year"));
                            waterUsage = reader.GetInt32(reader.GetOrdinal("waterUsage"));
                            cost = Convert.ToDouble(reader["costPerCubic"]);
                            amtDue = Convert.ToDouble(reader["amtDue"]);

                            //Display the information in the textboxes
                            //dateTB.Text = month.ToString() + "/" + year.ToString();
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
                    // Add parameters to the SqlCommand
                    command.Parameters.AddWithValue("@Month", monthSearch);
                    command.Parameters.AddWithValue("@Year", yearSearch);

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
                    // Add parameters to the SqlCommand
                    command.Parameters.AddWithValue("@Month", monthSearch);
                    command.Parameters.AddWithValue("@Year", yearSearch);

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
                    // Add parameters to the SqlCommand
                    command.Parameters.AddWithValue("@Month", monthSearch);
                    command.Parameters.AddWithValue("@Year", yearSearch);

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

                    // Add parameters to the SqlCommand
                    command.Parameters.AddWithValue("@Month", monthSearch);
                    command.Parameters.AddWithValue("@Year", yearSearch);

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
                    command.Parameters.AddWithValue("@Month", monthSearch);
                    command.Parameters.AddWithValue("@Year", yearSearch);

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

        //generate reports button to create pdf invoices for each tenant
        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new document
            Document document = new Document();

            // Define the output file path to the Downloads folder
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            string outputPath = Path.Combine(downloadsPath, "output.pdf");

            // Create a PdfWriter to write the document to a file
            PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));

            // Open the document for writing
            document.Open();

            // Add content to the document
            Paragraph paragraph = new Paragraph("Hello, world! This is a simple PDF generated using iTextSharp.");
            document.Add(paragraph);

            // Close the document
            document.Close();

            // Display a message indicating successful generation
            Console.WriteLine($"PDF generated successfully. File saved to: {outputPath}");
        }
    }
}

