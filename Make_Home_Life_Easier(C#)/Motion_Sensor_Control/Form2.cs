using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Make_Home_Life_Easier
{
    public partial class frmHomepage : Form
    {       
        public frmHomepage()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            frmControlPanel frmControlPanel = new frmControlPanel();
            frmControlPanel.Show();
            this.Hide();
        }
        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            How_to_use how_To_Use = new How_to_use();
            how_To_Use.Show();
            how_To_Use.lblHowtouse.Text = "Very easy. Just click the buttons to make the settings you want." +
                "Let the program take care of the rest. If you check the 'I am not home' option, the security system will activate and warn you of any kind of action." +
                "Thanks to the system, your kitchen is now safe too. If there is a fire - I hope it won't - the system will alert you and you will be safe.";
        }
        private void howToLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry, we haven't added any 'user login' to the system yet."+ 
                "\n"+ "Just press the login button.", "Sorry :(", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
