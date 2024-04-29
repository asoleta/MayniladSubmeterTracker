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
            double checkBill = 0.0;

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

                            //display in the date textbox
                            dateTB.Text = monthSearch.ToString() + "/" + yearSearch.ToString();
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
                            checkBill += amtDue;
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
                            checkBill += amtDue;
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
                            checkBill += amtDue;
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
                            checkBill += amtDue;
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
                            checkBill += amtDue;
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
                            checkBillTB.Text = billTotal.ToString("0.00") + "P";
                            totalBillTB.Text = checkBill.ToString("0.00") + "P";
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }

                //close the connection
                connection.Close();
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
                            waterUsage = reader.GetInt32(reader.GetOrdinal("waterUsage"));
                            cost = Convert.ToDouble(reader["costPerCubic"]);
                            amtDue = Convert.ToDouble(reader["amtDue"]);

                            //Save the information in a PDF Invoice
                            // Create a new document
                            Document document = new Document();

                            // Create iTextSharp.text.Font objects for header and body text with different sizes
                            iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 40);

                            // Define the output file path to the Downloads folder
                            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                            string fileName = $"INVOICE_1a_{monthSearch}_{yearSearch}.pdf";
                            string outputPath = Path.Combine(downloadsPath, fileName);

                            // Create a PdfWriter to write the document to a file
                            PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));

                            // Open the document for writing
                            document.Open();

                            // Add content to the document
                            // Load the image
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\Users\\asoleta\\OneDrive - Desales University\\Documents\\School\\CS-453 Senior Sem\\Capstone Project\\MayniladSubmeterTracker\\MayniladSubmeterTracker\\Resources\\IyaSandraLogo.png");

                            // Set the position and size of the image
                            img.ScaleToFit(400f, 300f); // Adjust size as needed

                            // Add the image to the document
                            img.SetAbsolutePosition(300f, 600f);
                            document.Add(img);

                            Paragraph title = new Paragraph("INVOICE", headerFont);
                            document.Add(title);

                            Paragraph invoiceDate = new Paragraph("Billing Month: " + monthSearch.ToString() + "/" + yearSearch.ToString());
                            // Add spacing after invoiceDate
                            invoiceDate.SpacingAfter = 10f;
                            document.Add(invoiceDate);

                            Paragraph invoiceTenant = new Paragraph("Subunit: 1");
                            // Add spacing after invoiceTenant
                            invoiceTenant.SpacingAfter = 50f;
                            document.Add(invoiceTenant);

                            // Create a table with 2 columns
                            PdfPTable table = new PdfPTable(2);
                            // Set width percentage
                            table.WidthPercentage = 100;

                            // Function to create a PdfPCell with padding and background color
                            PdfPCell GetCell(string text, BaseColor backgroundColor, float padding)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(text));
                                cell.Padding = padding;
                                cell.BackgroundColor = backgroundColor; // Set background color
                                return cell;
                            }

                            // Add table content
                            table.AddCell(GetCell("Total Water Consumption: ", BaseColor.WHITE, 5f));
                            table.AddCell(GetCell(waterUsage.ToString(), BaseColor.WHITE, 5f));
                            table.AddCell(GetCell("Approximate Cost per Cubic Meter: ", BaseColor.WHITE, 5f));
                            table.AddCell(GetCell(cost.ToString(), BaseColor.WHITE, 5f));
                            table.AddCell(GetCell("Amount due: ", BaseColor.WHITE, 5f));
                            table.AddCell(GetCell(amtDue.ToString("0.00") + "P", new BaseColor(255, 204, 204), 5f)); // Light red color

                            document.Add(table);


                            //close the document
                            document.Close();

                            // Display a message indicating successful generation
                            MessageBox.Show($"PDF generated successfully. File saved to: {outputPath}");
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
                //Submeter 1a end

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

                            //Save the information in a PDF Invoice
                            // Create a new document
                            Document document = new Document();

                            // Create iTextSharp.text.Font objects for header and body text with different sizes
                            iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 40);

                            // Define the output file path to the Downloads folder
                            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                            string fileName = $"INVOICE_2a_{monthSearch}_{yearSearch}.pdf";
                            string outputPath = Path.Combine(downloadsPath, fileName);

                            // Create a PdfWriter to write the document to a file
                            PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));

                            // Open the document for writing
                            document.Open();

                            // Add content to the document
                            // Load the image
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\Users\\asoleta\\OneDrive - Desales University\\Documents\\School\\CS-453 Senior Sem\\Capstone Project\\MayniladSubmeterTracker\\MayniladSubmeterTracker\\Resources\\IyaSandraLogo.png");

                            // Set the position and size of the image
                            img.ScaleToFit(400f, 300f); // Adjust size as needed

                            // Add the image to the document
                            img.SetAbsolutePosition(300f, 600f);
                            document.Add(img);

                            Paragraph title = new Paragraph("INVOICE", headerFont);
                            document.Add(title);

                            Paragraph invoiceDate = new Paragraph("Billing Month: " + monthSearch.ToString() + "/" + yearSearch.ToString());
                            // Add spacing after invoiceDate
                            invoiceDate.SpacingAfter = 10f;
                            document.Add(invoiceDate);

                            Paragraph invoiceTenant = new Paragraph("Subunit: 2a");
                            // Add spacing after invoiceTenant
                            invoiceTenant.SpacingAfter = 50f;
                            document.Add(invoiceTenant);

                            // Create a table with 2 columns
                            PdfPTable table = new PdfPTable(2);
                            // Set width percentage
                            table.WidthPercentage = 100;

                            // Function to create a PdfPCell with padding and background color
                            PdfPCell GetCell(string text, BaseColor backgroundColor, float padding)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(text));
                                cell.Padding = padding;
                                cell.BackgroundColor = backgroundColor; // Set background color
                                return cell;
                            }

                            // Add table content
                            table.AddCell(GetCell("Total Water Consumption: ", BaseColor.WHITE, 5f));
                            table.AddCell(GetCell(waterUsage.ToString(), BaseColor.WHITE, 5f));
                            table.AddCell(GetCell("Approximate Cost per Cubic Meter: ", BaseColor.WHITE, 5f));
                            table.AddCell(GetCell(cost.ToString(), BaseColor.WHITE, 5f));
                            table.AddCell(GetCell("Amount due: ", BaseColor.WHITE, 5f));
                            table.AddCell(GetCell(amtDue.ToString("0.00") + "P", new BaseColor(255, 204, 204), 5f)); // Light red color

                            document.Add(table);


                            //close the document
                            document.Close();

                            // Display a message indicating successful generation
                            MessageBox.Show($"PDF generated successfully. File saved to: {outputPath}");
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
                //Submeter 2a end

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

                            //Save the information in a PDF Invoice
                            // Create a new document
                            Document document = new Document();

                            // Create iTextSharp.text.Font objects for header and body text with different sizes
                            iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 40);

                            // Define the output file path to the Downloads folder
                            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                            string fileName = $"INVOICE_2b_{monthSearch}_{yearSearch}.pdf";
                            string outputPath = Path.Combine(downloadsPath, fileName);

                            // Create a PdfWriter to write the document to a file
                            PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));

                            // Open the document for writing
                            document.Open();

                            // Add content to the document
                            // Load the image
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\Users\\asoleta\\OneDrive - Desales University\\Documents\\School\\CS-453 Senior Sem\\Capstone Project\\MayniladSubmeterTracker\\MayniladSubmeterTracker\\Resources\\IyaSandraLogo.png");

                            // Set the position and size of the image
                            img.ScaleToFit(400f, 300f); // Adjust size as needed

                            // Add the image to the document
                            img.SetAbsolutePosition(300f, 600f);
                            document.Add(img);

                            Paragraph title = new Paragraph("INVOICE", headerFont);
                            document.Add(title);

                            Paragraph invoiceDate = new Paragraph("Billing Month: " + monthSearch.ToString() + "/" + yearSearch.ToString());
                            // Add spacing after invoiceDate
                            invoiceDate.SpacingAfter = 10f;
                            document.Add(invoiceDate);

                            Paragraph invoiceTenant = new Paragraph("Subunit: 2b");
                            // Add spacing after invoiceTenant
                            invoiceTenant.SpacingAfter = 50f;
                            document.Add(invoiceTenant);

                            // Create a table with 2 columns
                            PdfPTable table = new PdfPTable(2);
                            // Set width percentage
                            table.WidthPercentage = 100;

                            // Function to create a PdfPCell with padding and background color
                            PdfPCell GetCell(string text, BaseColor backgroundColor, float padding)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(text));
                                cell.Padding = padding;
                                cell.BackgroundColor = backgroundColor; // Set background color
                                return cell;
                            }

                            // Add table content
                            table.AddCell(GetCell("Total Water Consumption: ", BaseColor.WHITE, 5f));
                            table.AddCell(GetCell(waterUsage.ToString(), BaseColor.WHITE, 5f));
                            table.AddCell(GetCell("Approximate Cost per Cubic Meter: ", BaseColor.WHITE, 5f));
                            table.AddCell(GetCell(cost.ToString(), BaseColor.WHITE, 5f));
                            table.AddCell(GetCell("Amount due: ", BaseColor.WHITE, 5f));
                            table.AddCell(GetCell(amtDue.ToString("0.00") + "P", new BaseColor(255, 204, 204), 5f)); // Light red color

                            document.Add(table);


                            //close the document
                            document.Close();

                            // Display a message indicating successful generation
                            MessageBox.Show($"PDF generated successfully. File saved to: {outputPath}");
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
                //Submeter 2b end

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

                            //Save the information in a PDF Invoice
                            // Create a new document
                            Document document = new Document();

                            // Create iTextSharp.text.Font objects for header and body text with different sizes
                            iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 40);

                            // Define the output file path to the Downloads folder
                            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                            string fileName = $"INVOICE_3a_{monthSearch}_{yearSearch}.pdf";
                            string outputPath = Path.Combine(downloadsPath, fileName);

                            // Create a PdfWriter to write the document to a file
                            PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));

                            // Open the document for writing
                            document.Open();

                            // Add content to the document
                            // Load the image
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\Users\\asoleta\\OneDrive - Desales University\\Documents\\School\\CS-453 Senior Sem\\Capstone Project\\MayniladSubmeterTracker\\MayniladSubmeterTracker\\Resources\\IyaSandraLogo.png");

                            // Set the position and size of the image
                            img.ScaleToFit(400f, 300f); // Adjust size as needed

                            // Add the image to the document
                            img.SetAbsolutePosition(300f, 600f);
                            document.Add(img);

                            Paragraph title = new Paragraph("INVOICE", headerFont);
                            document.Add(title);

                            Paragraph invoiceDate = new Paragraph("Billing Month: " + monthSearch.ToString() + "/" + yearSearch.ToString());
                            // Add spacing after invoiceDate
                            invoiceDate.SpacingAfter = 10f;
                            document.Add(invoiceDate);

                            Paragraph invoiceTenant = new Paragraph("Subunit: 3a");
                            // Add spacing after invoiceTenant
                            invoiceTenant.SpacingAfter = 50f;
                            document.Add(invoiceTenant);

                            // Create a table with 2 columns
                            PdfPTable table = new PdfPTable(2);
                            // Set width percentage
                            table.WidthPercentage = 100;

                            // Function to create a PdfPCell with padding and background color
                            PdfPCell GetCell(string text, BaseColor backgroundColor, float padding)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(text));
                                cell.Padding = padding;
                                cell.BackgroundColor = backgroundColor; // Set background color
                                return cell;
                            }

                            // Add table content
                            table.AddCell(GetCell("Total Water Consumption: ", BaseColor.WHITE, 5f));
                            table.AddCell(GetCell(waterUsage.ToString(), BaseColor.WHITE, 5f));
                            table.AddCell(GetCell("Approximate Cost per Cubic Meter: ", BaseColor.WHITE, 5f));
                            table.AddCell(GetCell(cost.ToString(), BaseColor.WHITE, 5f));
                            table.AddCell(GetCell("Amount due: ", BaseColor.WHITE, 5f));
                            table.AddCell(GetCell(amtDue.ToString("0.00") + "P", new BaseColor(255, 204, 204), 5f)); // Light red color

                            document.Add(table);


                            //close the document
                            document.Close();

                            // Display a message indicating successful generation
                            MessageBox.Show($"PDF generated successfully. File saved to: {outputPath}");
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
                //Submeter 3a end

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

                            //Save the information in a PDF Invoice
                            // Create a new document
                            Document document = new Document();

                            // Create iTextSharp.text.Font objects for header and body text with different sizes
                            iTextSharp.text.Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 40);

                            // Define the output file path to the Downloads folder
                            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                            string fileName = $"INVOICE_3b_{monthSearch}_{yearSearch}.pdf";
                            string outputPath = Path.Combine(downloadsPath, fileName);

                            // Create a PdfWriter to write the document to a file
                            PdfWriter.GetInstance(document, new FileStream(outputPath, FileMode.Create));

                            // Open the document for writing
                            document.Open();

                            // Add content to the document
                            // Load the image
                            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("C:\\Users\\asoleta\\OneDrive - Desales University\\Documents\\School\\CS-453 Senior Sem\\Capstone Project\\MayniladSubmeterTracker\\MayniladSubmeterTracker\\Resources\\IyaSandraLogo.png");

                            // Set the position and size of the image
                            img.ScaleToFit(400f, 300f); // Adjust size as needed

                            // Add the image to the document
                            img.SetAbsolutePosition(300f, 600f);
                            document.Add(img);

                            Paragraph title = new Paragraph("INVOICE", headerFont);
                            document.Add(title);

                            Paragraph invoiceDate = new Paragraph("Billing Month: " + monthSearch.ToString() + "/" + yearSearch.ToString());
                            // Add spacing after invoiceDate
                            invoiceDate.SpacingAfter = 10f;
                            document.Add(invoiceDate);

                            Paragraph invoiceTenant = new Paragraph("Subunit: 3b");
                            // Add spacing after invoiceTenant
                            invoiceTenant.SpacingAfter = 50f;
                            document.Add(invoiceTenant);

                            // Create a table with 2 columns
                            PdfPTable table = new PdfPTable(2);
                            // Set width percentage
                            table.WidthPercentage = 100;

                            // Function to create a PdfPCell with padding and background color
                            PdfPCell GetCell(string text, BaseColor backgroundColor, float padding)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(text));
                                cell.Padding = padding;
                                cell.BackgroundColor = backgroundColor; // Set background color
                                return cell;
                            }

                            // Add table content
                            table.AddCell(GetCell("Total Water Consumption: ", BaseColor.WHITE, 5f));
                            table.AddCell(GetCell(waterUsage.ToString(), BaseColor.WHITE, 5f));
                            table.AddCell(GetCell("Approximate Cost per Cubic Meter: ", BaseColor.WHITE, 5f));
                            table.AddCell(GetCell(cost.ToString(), BaseColor.WHITE, 5f));
                            table.AddCell(GetCell("Amount due: ", BaseColor.WHITE, 5f));
                            table.AddCell(GetCell(amtDue.ToString("0.00") + "P", new BaseColor(255, 204, 204), 5f)); // Light red color

                            document.Add(table);


                            //close the document
                            document.Close();

                            // Display a message indicating successful generation
                            MessageBox.Show($"PDF generated successfully. File saved to: {outputPath}");
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }
                }
                //Submeter 3b end
            }
        }

        //Deletes the record from the database, including the records in the subtables
        private void trashBtn_Click(object sender, EventArgs e)
        {
            int month = 0;
            int year = 0;

            DialogResult result = MessageBox.Show("Are you sure you want to delete the data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Perform deletion
                using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-EF4ATSUG\\SQLEXPRESS01;Initial Catalog=Maynilad;Integrated Security=True;TrustServerCertificate=True"))
                {
                    //open the connection
                    connection.Open();

                    // SQL query to retrieve month and year from searchQueries table
                    string sqlQuery = "SELECT TOP 1 [month], [year] FROM searchQueries ORDER BY id DESC";
                    string sqlDeleteQuery = "DELETE FROM submeterReading WHERE month = @Month AND year = @Year";
                    string sql1aDeleteQuery = "DELETE FROM submeter1A WHERE month = @Month AND year = @Year";
                    string sql2aDeleteQuery = "DELETE FROM submeter2A WHERE month = @Month AND year = @Year";
                    string sql2bDeleteQuery = "DELETE FROM submeter2B WHERE month = @Month AND year = @Year";
                    string sql3aDeleteQuery = "DELETE FROM submeter3A WHERE month = @Month AND year = @Year";
                    string sql3bDeleteQuery = "DELETE FROM submeter3B WHERE month = @Month AND year = @Year";

                    // Get the current month and year
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // Gets the desired month and year from the searchQueries table
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Check if there are rows returned
                            if (reader.Read())
                            {
                                // Assign month and year values from the query result
                                month = Convert.ToInt32(reader["month"]);
                                year = Convert.ToInt32(reader["year"]);
                            }
                            else
                            {
                                Console.WriteLine("No rows found in searchQuery table.");
                            }
                        }
                    }

                    // Delete from the submeterReadings
                    using (SqlCommand command = new SqlCommand(sqlDeleteQuery, connection))
                    {
                        // Add parameters to the SqlCommand to prevent SQL injection
                        command.Parameters.AddWithValue("@Month", month);
                        command.Parameters.AddWithValue("@Year", year);

                        // Execute the delete command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Rows deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No rows deleted.");
                        }
                    }

                    // Delete from the submeter1a
                    using (SqlCommand command = new SqlCommand(sql1aDeleteQuery, connection))
                    {
                        // Add parameters to the SqlCommand to prevent SQL injection
                        command.Parameters.AddWithValue("@Month", month);
                        command.Parameters.AddWithValue("@Year", year);

                        // Execute the delete command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Rows deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No rows deleted.");
                        }
                    }

                    // Delete from the submeter2a
                    using (SqlCommand command = new SqlCommand(sql2aDeleteQuery, connection))
                    {
                        // Add parameters to the SqlCommand to prevent SQL injection
                        command.Parameters.AddWithValue("@Month", month);
                        command.Parameters.AddWithValue("@Year", year);

                        // Execute the delete command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Rows deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No rows deleted.");
                        }
                    }

                    // Delete from the submeter2b
                    using (SqlCommand command = new SqlCommand(sql2bDeleteQuery, connection))
                    {
                        // Add parameters to the SqlCommand to prevent SQL injection
                        command.Parameters.AddWithValue("@Month", month);
                        command.Parameters.AddWithValue("@Year", year);

                        // Execute the delete command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Rows deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No rows deleted.");
                        }
                    }

                    // Delete from the submeter3a
                    using (SqlCommand command = new SqlCommand(sql3aDeleteQuery, connection))
                    {
                        // Add parameters to the SqlCommand to prevent SQL injection
                        command.Parameters.AddWithValue("@Month", month);
                        command.Parameters.AddWithValue("@Year", year);

                        // Execute the delete command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Rows deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No rows deleted.");
                        }
                    }

                    // Delete from the submeter3b
                    using (SqlCommand command = new SqlCommand(sql3bDeleteQuery, connection))
                    {
                        // Add parameters to the SqlCommand to prevent SQL injection
                        command.Parameters.AddWithValue("@Month", month);
                        command.Parameters.AddWithValue("@Year", year);

                        // Execute the delete command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Rows deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No rows deleted.");
                        }
                    }

                    MessageBox.Show("Record deleted successfully. You will now be returned to the home page.");
                    
                    // Close the form and open the homepage
                    this.Close();
                    homepage homepage = new homepage();
                    homepage.Show();

                    connection.Close(); //close the connection
                }
            }
            else
            {
                // User chose not to delete, do nothing or show a message
                MessageBox.Show("Deletion canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Allows edits to the fields
        private void editBtn_Click(object sender, EventArgs e)
        {
            // Changes the properties of the fields to be editable
            makeEditable();

            // Hide the edit button and shows the checkbox button
            editBtn.Visible = false;
            checkboxBtn.Visible = true;
        }

        // Saves changes to the database and recalculates the values
        private void checkboxBtn_Click(object sender, EventArgs e)
        {
            // Hide the checkbox button and show the edit button again
            checkboxBtn.Visible = false;
            editBtn.Visible = true;

            // Disable edits
            disableEdits();

            // Updates the database
            //get the input from the textboxes and convert to required data type
            int monthSearch = 0; //uses month from most recent search
            int yearSearch = 0; //uses year from most recent search

            // Declare variables to hold parsed values
            double submeter1aTotal = 0;
            double submeter2aTotal = 0;
            double submeter2bTotal = 0;
            double submeter3aTotal = 0;
            double submeter3bTotal = 0;


            // Remove the "P" character from the text before parsing
            string unit1TotalText = unit1TotalTB.Text.Replace("P", "");
            string unit2aTotalText = unit2aTotalTB.Text.Replace("P", "");
            string unit2bTotalText = unit2bTotalTB.Text.Replace("P", "");
            string unit3aTotalText = unit3aTotalTB.Text.Replace("P", "");
            string unit3bTotalText = unit3bTotalTB.Text.Replace("P", "");

            // Attempt to parse each textbox value
            if (double.TryParse(unit1TotalText, out submeter1aTotal) &&
                double.TryParse(unit2aTotalText, out submeter2aTotal) &&
                double.TryParse(unit2bTotalText, out submeter2bTotal) &&
                double.TryParse(unit3aTotalText, out submeter3aTotal) &&
                double.TryParse(unit3bTotalText, out submeter3bTotal))
            {
                // Parsing successful, calculate the updated bill cost
                double updatedBillCost = submeter1aTotal + submeter2aTotal + submeter2bTotal + submeter3aTotal + submeter3bTotal;
            }

            try
            {
                //connect to SQL Database
                SqlConnection conn = new SqlConnection("Data Source=LAPTOP-EF4ATSUG\\SQLEXPRESS01;Initial Catalog=Maynilad;Integrated Security=True;TrustServerCertificate=True");

                conn.Open(); //open the connection

                // SQL query to retrieve month and year from searchQueries table
                string sqlQuery = "SELECT TOP 1 [month], [year] FROM searchQueries ORDER BY id DESC";
                string queryBillTotal = $"SELECT * FROM submeterReading WHERE month = @Month AND year = @Year";
                string querySub1a = "UPDATE submeter1A SET amtDue = @AmtDue WHERE month = @Month AND year = @Year";
                string querySub2a = "UPDATE submeter2A SET amtDue = @AmtDue WHERE month = @Month AND year = @Year";
                string querySub2b = "UPDATE submeter2B SET amtDue = @AmtDue WHERE month = @Month AND year = @Year";
                string querySub3a = "UPDATE submeter3A SET amtDue = @AmtDue WHERE month = @Month AND year = @Year";
                string querySub3b = "UPDATE submeter3B SET amtDue = @AmtDue WHERE month = @Month AND year = @Year";

                using (SqlCommand command = new SqlCommand(sqlQuery, conn))
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
                using (SqlCommand updateCmd = new SqlCommand(querySub1a, conn))
                {
                    // Provide parameter values for the query
                    updateCmd.Parameters.AddWithValue("@AmtDue", submeter1aTotal);
                    updateCmd.Parameters.AddWithValue("@Month", monthSearch);
                    updateCmd.Parameters.AddWithValue("@Year", yearSearch);

                    // Execute the update command
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    // Check if any rows were affected by the update
                    if (rowsAffected > 0)
                    {
                        //MessageBox.Show("Submeter 1a total updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No rows were updated. Verify the month and year values.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                // Submeter1a end

                //Submeter 2a
                using (SqlCommand updateCmd = new SqlCommand(querySub2a, conn))
                {
                    // Provide parameter values for the query
                    updateCmd.Parameters.AddWithValue("@AmtDue", submeter2aTotal);
                    updateCmd.Parameters.AddWithValue("@Month", monthSearch);
                    updateCmd.Parameters.AddWithValue("@Year", yearSearch);

                    // Execute the update command
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    // Check if any rows were affected by the update
                    if (rowsAffected > 0)
                    {
                        //MessageBox.Show("Submeter 1a total updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No rows were updated. Verify the month and year values.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                // Submeter2a end

                //Submeter 2b
                using (SqlCommand updateCmd = new SqlCommand(querySub2b, conn))
                {
                    // Provide parameter values for the query
                    updateCmd.Parameters.AddWithValue("@AmtDue", submeter2bTotal);
                    updateCmd.Parameters.AddWithValue("@Month", monthSearch);
                    updateCmd.Parameters.AddWithValue("@Year", yearSearch);

                    // Execute the update command
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    // Check if any rows were affected by the update
                    if (rowsAffected > 0)
                    {
                        //MessageBox.Show("Submeter 1a total updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No rows were updated. Verify the month and year values.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                // Submeter2b end

                //Submeter 3a
                using (SqlCommand updateCmd = new SqlCommand(querySub3a, conn))
                {
                    // Provide parameter values for the query
                    updateCmd.Parameters.AddWithValue("@AmtDue", submeter3aTotal);
                    updateCmd.Parameters.AddWithValue("@Month", monthSearch);
                    updateCmd.Parameters.AddWithValue("@Year", yearSearch);

                    // Execute the update command
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    // Check if any rows were affected by the update
                    if (rowsAffected > 0)
                    {
                        //MessageBox.Show("Submeter 1a total updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No rows were updated. Verify the month and year values.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                // Submeter3a end

                //Submeter 3b
                using (SqlCommand updateCmd = new SqlCommand(querySub3b, conn))
                {
                    // Provide parameter values for the query
                    updateCmd.Parameters.AddWithValue("@AmtDue", submeter3bTotal);
                    updateCmd.Parameters.AddWithValue("@Month", monthSearch);
                    updateCmd.Parameters.AddWithValue("@Year", yearSearch);

                    // Execute the update command
                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    // Check if any rows were affected by the update
                    if (rowsAffected > 0)
                    {
                        //MessageBox.Show("Submeter 1a total updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No rows were updated. Verify the month and year values.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                // Submeter3b end

                conn.Close(); //close the connection
                MessageBox.Show("Edits have successfully been saved.");
            }
            
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        // Changes the properties of the fields to be editable
        private void makeEditable()
        {
            unit1waterTB.Enabled = true;
            unit1waterTB.ReadOnly = false;
            unit1CostTB.Enabled = true;
            unit1CostTB.ReadOnly = false;
            unit1TotalTB.Enabled = true;
            unit1TotalTB.ReadOnly = false;

            unit2aWaterTB.Enabled = true;
            unit2aWaterTB.ReadOnly = false;
            unit2aCostTB.Enabled = true;
            unit2aCostTB.ReadOnly = false;
            unit2aTotalTB.Enabled = true;
            unit2aTotalTB.ReadOnly = false;

            unit2bWaterTB.Enabled = true;
            unit2bWaterTB.ReadOnly = false;
            unit2bCostTB.Enabled = true;
            unit2bCostTB.ReadOnly = false;
            unit2bTotalTB.Enabled = true;
            unit2bTotalTB.ReadOnly = false;

            unit3aWaterTB.Enabled = true;
            unit3aWaterTB.ReadOnly = false;
            unit3aCostTB.Enabled = true;
            unit3aCostTB.ReadOnly = false;
            unit3aTotalTB.Enabled = true;
            unit3aTotalTB.ReadOnly = false;

            unit3bWaterTB.Enabled = true;
            unit3bWaterTB.ReadOnly = false;
            unit3bCostTB.Enabled = true;
            unit3bCostTB.ReadOnly = false;
            unit3bTotalTB.Enabled = true;
            unit3bTotalTB.ReadOnly = false;
        }

        // Changes the properties of the fields to be not editable
        private void disableEdits()
        {
            unit1waterTB.Enabled = false;
            unit1waterTB.ReadOnly = true;
            unit1CostTB.Enabled = false;
            unit1CostTB.ReadOnly = true;
            unit1TotalTB.Enabled = false;
            unit1TotalTB.ReadOnly = true;

            unit2aWaterTB.Enabled = false;
            unit2aWaterTB.ReadOnly = true;
            unit2aCostTB.Enabled = false;
            unit2aCostTB.ReadOnly = true;
            unit2aTotalTB.Enabled = false;
            unit2aTotalTB.ReadOnly = true;

            unit2bWaterTB.Enabled = false;
            unit2bWaterTB.ReadOnly = true;
            unit2bCostTB.Enabled = false;
            unit2bCostTB.ReadOnly = true;
            unit2bTotalTB.Enabled = false;
            unit2bTotalTB.ReadOnly = true;

            unit3aWaterTB.Enabled = false;
            unit3aWaterTB.ReadOnly = true;
            unit3aCostTB.Enabled = false;
            unit3aCostTB.ReadOnly = true;
            unit3aTotalTB.Enabled = false;
            unit3aTotalTB.ReadOnly = true;

            unit3bWaterTB.Enabled = false;
            unit3bWaterTB.ReadOnly = true;
            unit3bCostTB.Enabled = false;
            unit3bCostTB.ReadOnly = true;
            unit3bTotalTB.Enabled = false;
            unit3bTotalTB.ReadOnly = true;
        }

        // Calculate the change in total values in real time
        private void calculateChanges()
        {
            // Declare variables to hold parsed values
            double submeter1aTotal;
            double submeter2aTotal;
            double submeter2bTotal;
            double submeter3aTotal;
            double submeter3bTotal;

            // Remove the "P" character from the text before parsing
            string unit1TotalText = unit1TotalTB.Text.Replace("P", "");
            string unit2aTotalText = unit2aTotalTB.Text.Replace("P", "");
            string unit2bTotalText = unit2bTotalTB.Text.Replace("P", "");
            string unit3aTotalText = unit3aTotalTB.Text.Replace("P", "");
            string unit3bTotalText = unit3bTotalTB.Text.Replace("P", "");

            // Attempt to parse each textbox value
            if (double.TryParse(unit1TotalText, out submeter1aTotal) &&
                double.TryParse(unit2aTotalText, out submeter2aTotal) &&
                double.TryParse(unit2bTotalText, out submeter2bTotal) &&
                double.TryParse(unit3aTotalText, out submeter3aTotal) &&
                double.TryParse(unit3bTotalText, out submeter3bTotal))
            {
                // Parsing successful, calculate the updated bill cost
                double updatedBillCost = submeter1aTotal + submeter2aTotal + submeter2bTotal + submeter3aTotal + submeter3bTotal;
                totalBillTB.Text = updatedBillCost.ToString("0.00") + "P";
            }
            else
            {
                // Parsing failed for at least one of the values
                // Handle the error or notify the user
                totalBillTB.Text = "Invalid input";
            }
        }

        // Updates the total bill cost when the value in the textbox is changed
        private void unit1TotalTB_TextChanged(object sender, EventArgs e)
        {
            calculateChanges();
        }

        private void unit2aTotalTB_TextChanged(object sender, EventArgs e)
        {
            calculateChanges();
        }

        private void unit2bTotalTB_TextChanged(object sender, EventArgs e)
        {
            calculateChanges();
        }

        private void unit3aTotalTB_TextChanged(object sender, EventArgs e)
        {
            calculateChanges();
        }

        private void unit3bTotalTB_TextChanged(object sender, EventArgs e)
        {
            calculateChanges();
        }
        // End of the update group
    }
}

