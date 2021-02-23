using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Make_Home_Life_Easier
{
    public partial class frmControlPanel : Form
    {
        SerialPort sp;
        private string data = "";
        public char[] chr = new char[10];
        public char[] chr2 = new char[10];
        bool state = true;
        bool state2 = true;
        bool state3 = true;
        public frmControlPanel()
        {
            InitializeComponent();
            sp = new SerialPort();
            sp.PortName = "COM5";
            sp.BaudRate = 9600;
            sp.Open();
            sp.DataReceived += new SerialDataReceivedEventHandler(sp_data_received);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cpbLRoom.Value = 0;
            cpbLRoom.Minimum = 0;
            cpbLRoom.Maximum = 100;
            cpbCRoom.Value = 0;
            cpbCRoom.Minimum = 0;
            cpbCRoom.Maximum = 100;
            rbtnAH.Checked = true;
            picbAlert.Visible = false;
            picbNoAlert.Visible = true;
            picbFireAlert.Visible = false;
            picbNoFireAlert.Visible = true;
            sp.Write("%");        
        }
        private void sp_data_received(object sender , SerialDataReceivedEventArgs e)
        {
            data = sp.ReadExisting();
            this.Invoke(new EventHandler(display_data_event));
        }
        private void display_data_event(object sender, EventArgs e)
        {
            if(data.ToString() == "1")
            {
                txtWarning.Text = "MOTION DETECTED!";
                picbAlert.Visible = true;
                picbNoAlert.Visible = false;

                DialogResult dialogResult = new DialogResult();
                dialogResult = MessageBox.Show("MOTION DETECTED!"+ "\n"+ "Do you want to ring alarm?", "Warninng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dialogResult == DialogResult.Yes)
                {
                    sp.Write("R");
                }              
            }
            if (data.ToString() == "2")
            {
                txtFireWarnnig.Text = "FIRE ALERT!";
                picbFireAlert.Visible = true;
                picbNoFireAlert.Visible = false;
            }
            if (data.ToString() == "3")
            {
                txtFireWarnnig.Text = "NO WARNING";
                picbNoFireAlert.Visible = true;
                picbFireAlert.Visible = false;
            }
            if (data[0].ToString() == "t")
            {
                string value = data.ToString();
                for (int i = 1; i < value.Length; i++)
                {
                    chr[i - 1] = value[i];
                }
                chr[2] = ',';
                string value2 = new string(chr);
                lblLRT.Text = value2.ToString();
                cpbLRoom.Value = Convert.ToInt32(Convert.ToDouble(value2));
                cpbLRoom.Update();
            }
            if (data[0].ToString() == "T")
            {
                string value3 = data.ToString();
                for (int j = 1; j < value3.Length; j++)
                {
                    chr2[j - 1] = value3[j];
                }
                chr2[2] = ',';
                string value4 = new string(chr2);
                lblCRT.Text = value4.ToString();
                cpbCRoom.Value = Convert.ToInt32(Convert.ToDouble(value4));
                cpbCRoom.Update();
            }
            if (data.ToString() == "L" && state)
            {
                txtLRBWarning.Text = "LOW BRIGHTNESS!";
                state = false;
                DialogResult dialogResult = new DialogResult();
                dialogResult = MessageBox.Show("LOW BRIGHTNESS!" + "\n" + "Do you want to turn on the 'LIVING ROOM' light?", "Warninng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
           
                if (dialogResult == DialogResult.Yes)
                {
                    sp.Write("L" + 200);
                }
                else
                {
                    txtLRBWarning.Text = "LOW BRIGHTNESS!";
                }
                
            }
            if (data.ToString() == "H")
            {
                state = true;
                txtLRBWarning.Text = "GOOD BRIGHTNESS";
                
            }
            if (data.ToString() == "C" && state2)
            {
                state2 = false;
                txtCRBWarning.Text = "LOW BRIGHTNESS!";
                DialogResult dialogResult = new DialogResult();
                dialogResult = MessageBox.Show("LOW BRIGHTNESS!" + "\n" + "Do you want to turn on the 'CHILDREN'S ROOM' light?", "Warninng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    sp.Write("C" + 200);
                }
            }
            if (data.ToString() == "H2")
            {
                txtCRBWarning.Text = "GOOD BRIGHTNESS";
                state2 = true;
            }
            if (data.ToString() == "K" && state3)
            {
                state3 = false;
                txtKBWarning.Text = "LOW BRIGHTNESS!";
                DialogResult dialogResult = new DialogResult();
                dialogResult = MessageBox.Show("LOW BRIGHTNESS!" + "\n" + "Do you want to turn on the 'KITCHEN' light?", "Warninng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    sp.Write("K" + 200);
                }
            }
            if (data.ToString() == "H3")
            {
                txtKBWarning.Text = "GOOD BRIGHTNESS";
                state3 = true;
            }
            data = "";
        }
        private void rbtnNAT_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnNAT.Checked == true)
            {
                txtWarning.Clear();
                sp.Write("#" + 1);
            }
        }
        private void rbtnAH_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnAH.Checked == true)
            {
                picbAlert.Visible = false;
                picbNoAlert.Visible = true;
                txtWarning.Text = "SECURITY SYSTEM OFF!";
            }          
        }

        private void btnRingAlarm_Click(object sender, EventArgs e)
        {
            sp.Write("R");
        }
        private void btnRingOff_Click(object sender, EventArgs e)
        {
            sp.Write("S");
        }

        private void btnFireRingOn_Click(object sender, EventArgs e)
        {
            sp.Write("F");
        }

        private void btnFireRingOff_Click(object sender, EventArgs e)
        {
            sp.Write("E");
        }

        private void btnESOn_Click(object sender, EventArgs e)
        {
            sp.Write("*" + 2);
        }

        private void btnESOff_Click(object sender, EventArgs e)
        {
            sp.Write("*" + 3);
        }

        private void btnLSlow_Click(object sender, EventArgs e)
        {
            sp.Write("&" + 1);
        }

        private void btnLMedium_Click(object sender, EventArgs e)
        {
            sp.Write("&" + 2);
        }

        private void btnLFast_Click(object sender, EventArgs e)
        {
            sp.Write("&" + 3);
        }

        private void btnLClose_Click(object sender, EventArgs e)
        {
            sp.Write("&" + 0);
        }
        private void btnCSlow_Click(object sender, EventArgs e)
        {
            sp.Write("$" + 1);
        }

        private void btnCMedium_Click(object sender, EventArgs e)
        {
            sp.Write("$" + 2);
        }

        private void btnCFast_Click(object sender, EventArgs e)
        {
            sp.Write("$" + 3);
        }

        private void btnCClose_Click(object sender, EventArgs e)
        {
            sp.Write("$" + 0);
        }
        
        private void btnLRBclose_Click(object sender, EventArgs e)
        {
            sp.Write("L" + "0");
        }

        private void btnLRBlow_Click(object sender, EventArgs e)
        {
            sp.Write("L" + "50");
        }

        private void btnLRBmedium_Click(object sender, EventArgs e)
        {
            sp.Write("L" + "100");
        }

        private void btnLRBhigh_Click(object sender, EventArgs e)
        {
            sp.Write("L" + "255");
        }

        private void btnCRBclose_Click(object sender, EventArgs e)
        {
            sp.Write("C" + "0");
        }

        private void btnCRBlow_Click(object sender, EventArgs e)
        {
            sp.Write("C" + "50");
        }

        private void btnCRBmedium_Click(object sender, EventArgs e)
        {
            sp.Write("C" + "100");
        }

        private void btnCRBhigh_Click(object sender, EventArgs e)
        {
            sp.Write("C" + "255");
        }

        private void btnKclose_Click(object sender, EventArgs e)
        {
            sp.Write("K" + "0");
        }

        private void btnKlow_Click(object sender, EventArgs e)
        {
            sp.Write("K" + "50");
        }

        private void btnKmedium_Click(object sender, EventArgs e)
        {
            sp.Write("K" + "100");
        }

        private void btnKhigh_Click(object sender, EventArgs e)
        {
            sp.Write("K" + "255");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sp.IsOpen)
            {
                sp.Close();
            }
        }     
    }
}
