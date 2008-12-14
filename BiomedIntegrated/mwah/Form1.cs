using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SerialBoard;



namespace mwah {
    public partial class Form1 : Form {
        static int numPorts = 40;
        public static UserControl1 [] controls = new UserControl1[numPorts];
        int flag = 0;

        public Form1() {
            InitializeComponent();
            for ( int i = 0; i < numPorts; i++ ) {
                controls[i] = new UserControl1(i);
                controls[i].Parent = this;
                controls[i].Left = (i % 5) * (controls[i].Width + 3);
                controls[i].Top = (i / 5) * (controls[i].Height + 3);
            }
            Parser parse = new Parser();
            parse.Parent = this;
            parse.Left = 477;
            parse.Top = 98;
        }
        
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_UpdateAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numPorts; i++)
               controls[i].send();
        }

        private void btn_ResetAll_Click_1(object sender, EventArgs e)
        {
            reset();
            MessageBox.Show("All pins have been reset");
        }

        public static void reset()
        {
            for (int i = 0; i < numPorts; i++)
            {
                controls[i].reset();
            }
        }

        public static int getnumPorts() { return numPorts; }

        private void btn_CLK_Click(object sender, EventArgs e)
        {
            //22 = signal, 24 = clock
            if (flag == 0)
            {
                SerialBoardDriver.WriteData(0x378, 0, 0, 24, 3, 100);
                controls[24].maskedTextBox1.Text = "100";
                flag = 1;
                lbl_CLK.Text = System.Convert.ToString(flag);
            }
            else
            {
                SerialBoardDriver.WriteData(0x378, 0, 0, 24, 3, 0);
                flag = 0;
                lbl_CLK.Text = System.Convert.ToString(flag);
                controls[24].maskedTextBox1.Text = "0";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
