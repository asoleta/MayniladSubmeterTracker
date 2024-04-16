using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayniladSubmeterTracker
{
    public partial class filterDataForm : Form
    {
        // Declare the font variable
        private Font googleFont;
        private Font titleFont;
        private Font closeBtnFont;

        public filterDataForm()
        {
            InitializeComponent();

            // Load the Google Font from the included font file
            PrivateFontCollection privateFontCollection = new PrivateFontCollection();
            privateFontCollection.AddFontFile("Fonts/Fredoka-Regular.ttf"); // Update with your font file path

            // Create the font with the desired size
            googleFont = new Font(privateFontCollection.Families[0], 16.0f);
            titleFont = new Font(privateFontCollection.Families[0], 26.0f);
            closeBtnFont = new Font(privateFontCollection.Families[0], 22.0f);

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

            titleLbl.Font = titleFont;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //get the input from the textboxes and convert to the required data type
                int month = int.Parse(monthTB.Text);
                int year = int.Parse(yearTB.Text);

                //connect to SQL Database
                using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-EF4ATSUG\\SQLEXPRESS01;Initial Catalog=Maynilad;Integrated Security=True;TrustServerCertificate=True"))
                {
                    conn.Open(); //open the connection

                    //add the values into the database
                    SqlCommand cmd = new SqlCommand("INSERT INTO searchQueries VALUES (@month, @year)", conn);
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.ExecuteNonQuery();

                    // Check if the month and year are current entries with data
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM submeterReading WHERE month = @month AND year = @year", conn);
                    checkCmd.Parameters.AddWithValue("@month", month);
                    checkCmd.Parameters.AddWithValue("@year", year);
                    int existingRecords = (int)checkCmd.ExecuteScalar();

                    if (existingRecords > 0)
                    {
                        //create and show the other form
                        filterDataResults filterDataResults = new filterDataResults();
                        filterDataResults.Show();
                    }
                    else
                    {
                        // Show the error message without closing the program
                        MessageBox.Show($"There are no existing records for {month}/{year}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Show the error message without closing the program
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();

            homepage homepage = new homepage();
            homepage.Show();
        }
    }
}
