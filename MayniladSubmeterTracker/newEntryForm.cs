﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //allows you to connect to sql database

namespace MayniladSubmeterTracker
{
    public partial class newEntryForm : Form
    {
        // Declare the font variable
        private Font googleFont;
        private Font titleFont;

        public newEntryForm()
        {
            InitializeComponent();

            // Load the Google Font from the included font file
            PrivateFontCollection privateFontCollection = new PrivateFontCollection();
            privateFontCollection.AddFontFile("Fonts/Fredoka-Regular.ttf"); // Update with your font file path

            // Create the font with the desired size
            googleFont = new Font(privateFontCollection.Families[0], 16.0f);
            titleFont = new Font(privateFontCollection.Families[0], 20.0f);

            // Apply the font to all labels and buttons
            ApplyFontToControls(this.Controls);
        }

        private void ApplyFontToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Apply font to labels and buttons
                if (control is Label || control is Button)
                {
                    control.Font = googleFont;
                }

                // Recursively apply font to child controls
                if (control.HasChildren)
                {
                    ApplyFontToControls(control.Controls);
                }
            }

            entryLbl.Font = titleFont;
        }

        //the close button closes the current form and returns to the homepage
        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();

            homepage homepage = new homepage();
            homepage.Show();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {

            //get the input from the textboxes and convert to required data type
            int month = datePicker.Value.Month;
            int year = datePicker.Value.Year;
            int submeter1aValue = int.Parse(submeter1aTB.Text);
            int submeter2aValue = int.Parse(submeter2aTB.Text);
            int submeter2bValue = int.Parse(submeter2bTB.Text);
            int submeter3aValue = int.Parse(submeter3aTB.Text);
            int submeter3bValue = int.Parse(submeter3bTB.Text);
            int totalUsageValue = int.Parse(totalUsageTB.Text);
            double totalBillValue = double.Parse(billTotalTB.Text);
            int idValue = 0;

            //hide the current form
            this.Close();


            try
            {
                //connect to SQL Database
                SqlConnection conn = new SqlConnection("Data Source=LAPTOP-EF4ATSUG\\SQLEXPRESS01;Initial Catalog=Maynilad;Integrated Security=True;TrustServerCertificate=True");
                
                conn.Open(); //open the connection

                //add the values into the database
                SqlCommand cmd = new SqlCommand("INSERT INTO submeterReading VALUES ('"+month+"','"+year+"','"+submeter1aValue+"','"+submeter2aValue+"'" +
                ",'"+submeter2bValue+"','"+submeter3aValue+"','"+submeter3bValue+"','"+totalUsageValue+"','"+totalBillValue+"')", conn);
                cmd.ExecuteNonQuery();

                //filter the database to get the specific row created and get the id number
                string sqlQuery = $"SELECT * FROM submeterReading WHERE month = @Month AND year = @Year";

                // Create a SqlCommand with the query and connection
                using (SqlCommand getCurrentMonth = new SqlCommand(sqlQuery, conn))
                {
                    // Add parameters to the SqlCommand (prevent SQL injection)
                    getCurrentMonth.Parameters.AddWithValue("@Month", month);
                    getCurrentMonth.Parameters.AddWithValue("@Year", year);

                    // Execute the query
                    using (SqlDataReader reader = getCurrentMonth.ExecuteReader())
                    {
                        // Check if there are rows returned
                        if (reader.HasRows)
                        {
                            // Iterate through the rows
                            while (reader.Read())
                            {
                                // Access columns by name and set to variables
                                idValue = Convert.ToInt32(reader["id"]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No rows found.");
                        }
                    }

                    conn.Close(); //close the connection

                    //calculate the difference between the current and previous month usage
                    //then, populate the dataset with the correct information
                    populateDataset(CalculateUsage(conn, month, year, idValue, submeter1aValue, submeter2aValue, submeter2bValue, submeter3aValue, submeter3bValue), conn);

                }
            }

            catch (Exception ex)
            {
                //MessageBox.Show($"Error: {ex.Message}");
            }

            //create and show the other form
            calculatedValues calculatedValues = new calculatedValues();
            calculatedValues.Show();

        }

        private Submeter[] CalculateUsage(SqlConnection conn, int month, int year, int id, int sub1, int sub2a, int sub2b, int sub3a, int sub3b)
        {
            double billTotal = 0;
            int prevSub1a = 0, prevSub2a = 0, prevSub2b = 0, prevSub3a = 0, prevSub3b = 0;

            int sub1aDiff, sub2aDiff, sub2bDiff, sub3aDiff, sub3bDiff;
            int totalUsage;
            double sub1aPercent, sub2aPercent, sub2bPercent, sub3aPercent, sub3bPercent;
            double sub1aBill, sub2aBill, sub2bBill, sub3aBill, sub3bBill;
            double sub1aCostPer, sub2aCostPer, sub2bCostPer, sub3aCostPer, sub3bCostPer;
            
            conn.Open(); //open the connection

            //get the previous month information
            string sqlQuery = $"SELECT * FROM submeterReading WHERE id = @Id";

            // Create a SqlCommand with the query and connection
            using (SqlCommand getPreviousMonth = new SqlCommand(sqlQuery, conn))
            {
                // Add parameters to the SqlCommand (prevent SQL injection)
                getPreviousMonth.Parameters.AddWithValue("@Id", (id-1));

                // Execute the query
                using (SqlDataReader reader = getPreviousMonth.ExecuteReader())
                {
                    // Check if there are rows returned
                    if (reader.HasRows)
                    {
                        // Iterate through the rows
                        while (reader.Read())
                        {
                            // Access columns by name or index as needed
                            prevSub1a = Convert.ToInt32(reader["submeter1a"]);
                            prevSub2a = Convert.ToInt32(reader["submeter2a"]);
                            prevSub2b = Convert.ToInt32(reader["submeter2b"]);
                            prevSub3a = Convert.ToInt32(reader["submeter3a"]);
                            prevSub3b = Convert.ToInt32(reader["submeter3b"]);
                            billTotal = Convert.ToDouble(reader["billTotal"]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                }

                //close the connection
                conn.Close();

                //Calculation Start
                //Calculate the difference between the previous month usage and the current month
                sub1aDiff = sub1 - prevSub1a;
                sub2aDiff = sub2a - prevSub2a;
                sub2bDiff = sub2b - prevSub2b;
                sub3aDiff = sub3b - prevSub3b;
                sub3bDiff = sub3b - prevSub3b;

                //Calculate the total usage for the month
                totalUsage = sub1aDiff + sub2aDiff + sub2bDiff + sub3aDiff + sub3bDiff;

                //Calculate the usage percentage per unit
                sub1aPercent = sub1aDiff / totalUsage;
                sub2aPercent = sub2aDiff / totalUsage;
                sub2bPercent = sub2bDiff / totalUsage;
                sub3aPercent = sub3aDiff / totalUsage;
                sub3bPercent = sub3bDiff / totalUsage;

                //Calculate the individual bills
                sub1aBill = billTotal * sub1aPercent;
                sub2aBill = billTotal * sub2aPercent;
                sub2bBill = billTotal * sub2bPercent;
                sub3aBill = billTotal * sub3aPercent;
                sub3bBill = billTotal * sub3bPercent;

                //Calculate the cost per cubic meter
                sub1aCostPer = sub1aBill / sub1aDiff;
                sub2aCostPer = sub2aBill / sub2aDiff;
                sub2bCostPer = sub2bBill / sub2bDiff;
                sub3aCostPer = sub3aBill / sub3aDiff;
                sub3bCostPer = sub3bBill / sub3bDiff;

                //Create submeter objects to store the information
                Submeter submeter1a = new Submeter(month, year, sub1aDiff, sub1aCostPer, sub1aBill);
                MessageBox.Show(submeter1a.Month.ToString() + submeter1a.Year.ToString() + sub1aDiff.ToString() + sub1aCostPer.ToString() + sub1aBill.ToString());

                Submeter submeter2a = new Submeter(month, year, sub2aDiff, sub2aCostPer, sub2aBill);
                MessageBox.Show(submeter2a.Month.ToString() + submeter2a.Year.ToString() + sub2aDiff.ToString() + sub2aCostPer.ToString() + sub2aBill.ToString());

                Submeter submeter2b = new Submeter(month, year, sub2bDiff, sub2bCostPer, sub2bBill);
                MessageBox.Show(submeter2b.Month.ToString() + submeter2b.Year.ToString() + sub2bDiff.ToString() + sub2bCostPer.ToString() + sub2bBill.ToString());

                Submeter submeter3a = new Submeter(month, year, sub3aDiff, sub3aCostPer, sub3aBill);
                MessageBox.Show(submeter3a.Month.ToString() + submeter3a.Year.ToString() + sub3aDiff.ToString() + sub3aCostPer.ToString() + sub3aBill.ToString());

                Submeter submeter3b = new Submeter(month, year, sub3bDiff, sub3bCostPer, sub3bBill);
                MessageBox.Show(submeter3b.Month.ToString() + submeter3b.Year.ToString() + sub3bDiff.ToString() + sub3bCostPer.ToString() + sub3bBill.ToString());

                Submeter[] submeters = {submeter1a, submeter2a, submeter2b, submeter3a, submeter3b};

                //Return the created submeter objects list
                return submeters;
            }
        }

        //takes information from the submeter objects and puts them into the correct table
        private void populateDataset(Submeter[] submeters, SqlConnection conn)
        {
            try
            {
                //open connection to the dataset
                conn.Open();

                //add the values into the database
                SqlCommand fillSub1a = new SqlCommand("INSERT INTO submeter1A VALUES ('" + submeters[0].Month + "','" + submeters[0].Year + "','" + submeters[0].WaterUsage + "','" +
                    submeters[0].CostPerCubic + "','" + submeters[0].Amount + "')", conn);
                fillSub1a.ExecuteNonQuery();
                MessageBox.Show("Fill sub 1a complete");

                SqlCommand fillSub2a = new SqlCommand("INSERT INTO submeter2A VALUES ('" + submeters[1].Month + "','" + submeters[1].Year + "','" + submeters[1].WaterUsage + "','" +
                    submeters[1].CostPerCubic + "','" + submeters[1].Amount + "')", conn);
                fillSub2a.ExecuteNonQuery();
                MessageBox.Show("Fill sub 2a complete");

                SqlCommand fillSub2b = new SqlCommand("INSERT INTO submeter2B VALUES ('" + submeters[2].Month + "','" + submeters[2].Year + "','" + submeters[2].WaterUsage + "','" +
                    submeters[2].CostPerCubic + "','" + submeters[2].Amount + "')", conn);
                fillSub2b.ExecuteNonQuery();
                MessageBox.Show("Fill sub 2b complete");

                SqlCommand fillSub3a = new SqlCommand("INSERT INTO submeter3A VALUES ('" + submeters[3].Month + "','" + submeters[3].Year + "','" + submeters[3].WaterUsage + "','" +
                    submeters[3].CostPerCubic + "','" + submeters[3].Amount + "')", conn);
                fillSub3a.ExecuteNonQuery();
                MessageBox.Show("Fill sub 3a complete");

                SqlCommand fillSub3b = new SqlCommand("INSERT INTO submeter3B VALUES ('" + submeters[4].Month + "','" + submeters[4].Year + "','" + submeters[4].WaterUsage + "','" +
                    submeters[4].CostPerCubic + "','" + submeters[4].Amount + "')", conn);
                fillSub3b.ExecuteNonQuery();
                MessageBox.Show("Fill sub 3b complete");

                //close the connection to the dataset
                conn.Close();
            }

            catch (Exception ex)
            {
                //MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}