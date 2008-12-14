using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SerialBoard;


namespace mwah {
    public partial class UserControl1 : UserControl {
        //private int _value = 0;
        private int _index;

        public UserControl1(int index1) {
            InitializeComponent();
            _index = index1;
            button1.Text = "Update " + _index.ToString();
            label2.Text = _index.ToString();
        }

        private void button1_Click( object sender, EventArgs e )
        {
            send(); 
        }

        public void send() {
            double val = System.Convert.ToDouble(maskedTextBox1.Text);
            if ( val >= 0 && val <= 100 )
                SerialBoardDriver.WriteData(0x378, 0, 0, _index, 3, val);
            else
                MessageBox.Show("Please enter a value between 0 and 100");
        }

        public void reset()
        {
            SerialBoardDriver.WriteData(0x378, 0, 0, _index, 3, 0);
            maskedTextBox1.Text = "0";
        }
    }
}

//