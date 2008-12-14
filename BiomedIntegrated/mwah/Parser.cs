using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SerialBoard;


namespace mwah
{
    public partial class Parser : UserControl
    {
        char[] code = null;

        public Parser()
        {
            InitializeComponent();
        }

        private void btn_Parse_Click(object sender, EventArgs e)
        {
            code = textBox1.Text.ToUpper().ToCharArray();
            int i = 0;
            String temp;
            bool flag = false;
            while (i < code.Length - 1 && flag == false)
            {
                switch (code[i])
                {
                    default:
                        i++;
                        break;

                    case 'S':
                        if (code[i + 1] == 'T' && code[i + 2] == 'O' && code[i + 3] == 'P')
                        {
                            flag = true;
                            return;
                        }
                        break;

                    case 'W':
                        i++;
                        switch (code[i])
                        {
                            case 'S': //seconds
                                i++;
                                temp = new String('0', 0);
                                while ((code[i] >= '0' && code[i] <= '9') || i == code.Length)
                                {
                                    temp += code[i];
                                    if (i == code.Length-1) break;
                                    i++;
                                }
                                WaitS(System.Convert.ToInt16(temp));
                                break;
                            case 'M': //minutes
                                i++;
                                temp = new String('0', 0);
                                while ((code[i] >= '0' && code[i] <= '9') || i == code.Length)
                                {
                                    temp += code[i];
                                    if (i == code.Length - 1) break;
                                    i++;
                                }
                                WaitM(System.Convert.ToInt16(temp));
                                break;
                            case 'H': //hours
                                i++;
                                temp = new String('0', 0);
                                while ((code[i] >= '0' && code[i] <= '9') || i == code.Length)
                                {
                                    temp += code[i];
                                    if (i == code.Length - 1) break;
                                    i++;
                                }
                                WaitH(System.Convert.ToInt16(temp));
                                break;
                        }
                        break;

                    case 'R':
                        if (code[++i] == 'A')
                            for (int x = 0; x < Form1.getnumPorts(); x++)
                                SerialBoardDriver.reset(x); //reset all
                        i++;
                        break;

                    case 'P':
                        i++;

                        string temp2 = new string('0',0);
                        while (code[i] >= '0' && code[i] <= '9')
                        {
                            temp2 += code[i];
                            if (i == code.Length - 1) break;
                            i++;
                        }
                        int port = System.Convert.ToInt16(temp2);
                        i++;
                        temp = new String('0', 0);
                        while (code[i] >= '0' && code[i] <= '9')
                        {
                            temp += code[i];
                            if (i == code.Length - 1) break;
                            i++;
                        }
                        double voltage = System.Convert.ToDouble(temp);
                        SerialBoardDriver.WriteData(0x378, 0, 0, port, 3, voltage);
                        Form1.controls[port].maskedTextBox1.Text = String.Copy(temp);
                        break;
                }
            }
            MessageBox.Show("The code has stopped running.");
        }

        private void WaitS(int seconds)
        {
            System.Threading.Thread.Sleep(seconds * 1000);
        }

        private void WaitM(int minutes)
        {
            WaitS(minutes * 60);
        }

        private void WaitH(int hours)
        {
            WaitM(hours * 60);
        }

        private void Parser_Load(object sender, EventArgs e)
        {
            textBox2.Text = "Syntax for writing code:\r\nWSxx - Wait xx seconds\r\nWMxx - Wait xx minutes\r\nWHxx - Wait xx hours\r\nPXX-YYY - Set voltage of port XX to YYY%\r\nRA - Reset All Pins\r\nSTOP - End parsing";
        }
    }
}
/*
 * SYNTAX
 * WS50 - Wait 50 seconds
 * WM50 - Wait 50 minutes (simple conversion then call WS)
 * P0-100 - Port #0, 100%
 * RA - Reset All
 * STOP - Stop
*/


/*
Syntax for writing code:\n
WSxx - Wait xx seconds\n
WMxx - Wait xx minutes\n
WHxx - Wait xx hours\n
PXX-YYY - Set voltage of port XX to YYY%\n
RA - Reset All Pins\n
STOP - End parsing
*/

/*
RA
WS5
P0-100
ws5
p0-50
ws5
RA
STOP
*/