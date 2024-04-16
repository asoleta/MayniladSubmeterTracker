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

        //generates PDF invoices for each tenant
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
    }
}
