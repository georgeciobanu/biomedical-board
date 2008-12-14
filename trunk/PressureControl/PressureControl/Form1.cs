using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ParallelPortDriver;

namespace PressureControl
{
    public partial class Form1 : Form
    {
        bool PCon = false;
        double value = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            ParallelPort.Output(0x378, 0);
        }

        private void Form1_FormClosing()
        {
            ParallelPort.Output(0x378, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ParallelPort.Output(0x378, 0);
            Application.Exit();
        }

        private void btnOnOff_Click(object sender, EventArgs e)
        {
            if (PCon == false)
            {
                
                ParallelPort.Output(0x378, System.Convert.ToInt16(value / System.Convert.ToDouble(PCMaxPsi.Value) * 256 * 2));
                btnOnOff.BackColor = Color.Transparent;
                btnOnOff.Text = "Turn Off";
                pBar1.Value = System.Convert.ToInt16(value * 4);
                cur.Text = System.Convert.ToString(value);
                PCon = true;
            }
            else
            {
                ParallelPort.Output(0x378, 0);
                btnOnOff.BackColor = Color.Red;
                btnOnOff.Text = "Turn On";
                pBar1.Value = 0;
                cur.Text = "0";
                PCon = false;
            }
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            value = System.Convert.ToDouble(numericUpDown1.Value);
            if (PCon == true)
            {
                ParallelPort.Output(0x378, System.Convert.ToInt16(value / System.Convert.ToDouble(PCMaxPsi.Value) * 256 * 2));
                //ParallelPort.Output(0x378, System.Convert.ToInt16(value/12.5*256));
                cur.Text = System.Convert.ToString(value);
                pBar1.Value = System.Convert.ToInt16(value * 4);
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            label6.Text = System.Convert.ToString(numericUpDown2.Value * 5);
        }
    }
}

/* TO FIX:
-variable PSI numericupdown doesn't work immediately after change
-output voltage does not change with variable PSI
-progress bar and numericupdown for progress bar do not change with variable PSI
 * BUT EVERYTHING WORKS!
*/
