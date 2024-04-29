using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayniladSubmeterTracker
{
    public partial class homepage : Form
    {
        // Declare the font variable
        private Font googleFont;
        private Font titleFont;
        private Font closeBtnFont;

        public homepage()
        {
            InitializeComponent();

            // Load the Google Font from the included font file
            PrivateFontCollection privateFontCollection = new PrivateFontCollection();
            privateFontCollection.AddFontFile("Fonts/Fredoka-Regular.ttf"); // Update with your font file path

            // Create the font with the desired size
            googleFont = new Font(privateFontCollection.Families[0], 16.0f);
            titleFont = new Font(privateFontCollection.Families[0], 25.0f);
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

            mayniladLbl.Font = titleFont;
            closeBtn.Font = closeBtnFont;
        }

        //the close button stops and closes the application 
        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //when new entry btn is pressed, hide homepage and show new entry form
        private void entryBtn_Click(object sender, EventArgs e)
        {
            
            //hide the current form
            this.Hide();

            //create and show the other form
            newEntryForm newEntryForm = new newEntryForm();
            newEntryForm.Show();
        }

        private void viewDataBtn_Click(object sender, EventArgs e)
        {
            //hide the current form
            this.Hide();

            //create and show the other form
            filterDataForm filterDataForm = new filterDataForm();
            filterDataForm.Show();
        }

        private void graphBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet available. Coming soon");
        }
    }
}
