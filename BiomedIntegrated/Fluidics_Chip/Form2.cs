using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PneumaticControls;

namespace Fluidics_Chip {
    public partial class Form2 : Form {

        Valve VGrayValve = new Valve(8);
        Valve VRedValve = new Valve(5);
        Valve VBlueValve = new Valve(7);
        Valve VGreenValve = new Valve(6);
        Valve VYellowValve = new Valve(9);
        Valve VDrainValve = new Valve(10);

        Valve VCellFluid = new Valve(0);
        Valve VReagentFluid = new Valve(1);
        Valve VFlushFluid = new Valve(2);

        PressureController PFluidController = new PressureController(23);
        PressureController PPneumaticsController = new PressureController(21);

        public Form2() {

            InitializeComponent();

        }


        private void GreenValve_Click( object sender, EventArgs e ) {
            if ( GreenValve.BackColor == Color.Red) {
                if(VCellFluid.State == ValveStates.ON)
                    greenAni.Visible = true;
                GreenValve.BackColor = Color.Transparent;
                GreenValve.Text = "Flow";
                VGreenValve.State = ValveStates.OFF;
                pictureBox4.Visible = true;
            }
            else {
                greenAni.Visible = false;
                GreenValve.BackColor = Color.Red;
                GreenValve.Text = "NO Flow";
                pictureBox4.Visible = false;
                VGreenValve.State = ValveStates.ON;
            }
        }

        private void GrayValve_Click( object sender, EventArgs e ) {
            if ( GrayValve.BackColor == Color.Red ) {
                grayAni.Visible = true;
                if (VFlushFluid.State == ValveStates.ON)
                    grayAni2.Visible = true;
                if (VRedValve.State == ValveStates.OFF)
                    grayAni.Visible = true;
                GrayValve.BackColor = Color.Transparent;
                GrayValve.Text = "Flow";
                GrayValve2.BackColor = Color.Transparent;
                GrayValve2.Text = "Flow";
                VGrayValve.State = ValveStates.OFF;
            }
            else {
                grayAni.Visible = false;
                grayAni2.Visible = false;
                GrayValve.BackColor = Color.Red;
                GrayValve.Text = "NO Flow";
                GrayValve2.BackColor = Color.Red;
                GrayValve2.Text = "NO Flow";
                VGrayValve.State = ValveStates.ON;
            }
        }

        private void BlueValve1_Click( object sender, EventArgs e ) {
            if ( BlueValve1.BackColor == Color.Red ) {
                pictureBox2.Visible = true;
                blueAni1.Visible = true;
                blueAni3.Visible = true;
                //blueAni4.Visible = true;
                BlueValve1.BackColor = Color.Transparent;
                BlueValve1.Text = "Flow";
                BlueValve2.BackColor = Color.Transparent;
                BlueValve2.Text = "Flow";
                VBlueValve.State = ValveStates.OFF;

            }
            else {
                pictureBox2.Visible = false;
                blueAni1.Visible = false;                
                blueAni3.Visible = false;
                //blueAni4.Visible = false;
                BlueValve1.BackColor = Color.Red;
                BlueValve1.Text = "NO Flow";
                BlueValve2.BackColor = Color.Red;
                BlueValve2.Text = "NO Flow";
                VBlueValve.State = ValveStates.ON;
            }
        }

        private void RedValve2_Click(object sender, EventArgs e)
        {
            if (RedValve1.BackColor == Color.Red)
            {
                if (VFlushFluid.State == ValveStates.ON)
                    redAni1.Visible = true;
                if ((VFlushFluid.State == ValveStates.ON && VBlueValve.State == ValveStates.OFF) || VReagentFluid.State == ValveStates.ON)
                {
                    pictureBox6.Visible = true;
                    redAni2.Visible = true;
                }
                if (VGrayValve.State == ValveStates.OFF)
                    grayAni.Visible = true;
                RedValve1.BackColor = Color.Transparent;
                RedValve1.Text = "Flow";
                RedValve2.BackColor = Color.Transparent;
                RedValve2.Text = "Flow";
                VRedValve.State = ValveStates.OFF;
            }
            else
            {
                redAni1.Visible = false;
                redAni2.Visible = false;
                grayAni.Visible = false;
                pictureBox6.Visible = false;
                RedValve1.BackColor = Color.Red;
                RedValve1.Text = "NO Flow";
                RedValve2.BackColor = Color.Red;
                RedValve2.Text = "NO Flow";
                VRedValve.State = ValveStates.ON;
            }
        }

        private void PneumaticController_Click(object sender, EventArgs e)
        {
                PPneumaticsController.Percentage = (System.Convert.ToInt16(PneumaticPCControl.Value))*2;
        }

        private void ReagentValve_Click(object sender, EventArgs e)
        {
            if (ReagentValve.BackColor == Color.Red)
            {
                //TODO: to use logic functions
                pictureBox3.Visible = true;
                if (RedValve1.BackColor == Color.Transparent)
                {
                    redAni2.Visible = true;
                    pictureBox6.Visible = true;
                }
                if (GrayValve.BackColor == Color.Transparent && RedValve1.BackColor == Color.Transparent)
                    grayAni.Visible = true;
                if (YellowButton1.BackColor == Color.Transparent)
                    pictureBox7.Visible = true;
                ReagentValve.BackColor = Color.Transparent;
                ReagentValve.Text = "Flow";
                ReagentValve2.BackColor = Color.Transparent;
                ReagentValve2.Text = "Flow";
                VReagentFluid.State = ValveStates.ON;
            }
            else
            {
                pictureBox3.Visible = false;
                redAni2.Visible = false;
                grayAni.Visible = false;
                pictureBox6.Visible = false;
                pictureBox7.Visible = false;
                ReagentValve.BackColor = Color.Red;
                ReagentValve.Text = "NO Flow";
                ReagentValve2.BackColor = Color.Red;
                ReagentValve2.Text = "NO Flow";
                VReagentFluid.State = ValveStates.OFF;
            }
        }

        private void FlushValve_Click(object sender, EventArgs e)
        {
            if (FlushValve.BackColor == Color.Red)
            {
                //TODO: to use logic functions
                pictureBox11.Visible = true;
                redAni1.Visible = true;
                grayAni2.Visible = true;
                FlushValve.BackColor = Color.Transparent;
                FlushValve.Text = "Flow";
                FlushValve2.BackColor = Color.Transparent;
                FlushValve2.Text = "Flow";
                if (YellowButton1.BackColor == Color.Transparent)
                    blueAni4.Visible = true;
                VFlushFluid.State = ValveStates.ON;

            }
            else
            {
                //TODO: to use logic functions
                pictureBox11.Visible = false;
                redAni1.Visible = false;
                grayAni2.Visible = false;
                blueAni4.Visible = false;
                FlushValve.BackColor = Color.Red;
                FlushValve.Text = "NO Flow";
                FlushValve2.BackColor = Color.Red;
                FlushValve2.Text = "NO Flow";
                VFlushFluid.State = ValveStates.OFF;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            VGrayValve.State = ValveStates.OFF;
            VBlueValve.State = ValveStates.OFF;
            VGreenValve.State = ValveStates.OFF;
            VRedValve.State = ValveStates.OFF;
            VReagentFluid.State = ValveStates.OFF;
            VFlushFluid.State = ValveStates.OFF;
            VYellowValve.State = ValveStates.OFF;
            VDrainValve.State = ValveStates.OFF;
            VCellFluid.State = ValveStates.OFF;

            PPneumaticsController.Percentage = 0;
            PFluidController.Percentage = 0;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            VGrayValve.State = ValveStates.OFF;
            VBlueValve.State = ValveStates.OFF;
            VGreenValve.State = ValveStates.OFF;
            VRedValve.State = ValveStates.OFF;
            VReagentFluid.State = ValveStates.OFF;
            VFlushFluid.State = ValveStates.OFF;
            VYellowValve.State = ValveStates.OFF;
            VDrainValve.State = ValveStates.OFF;
            VCellFluid.State = ValveStates.OFF;

            PPneumaticsController.Percentage = 0;
            PFluidController.Percentage = 0;
        }

        private void CellValve_Click(object sender, EventArgs e)
        {
            if (CellValve.BackColor == Color.Red)
            {
                //TODO: to use logic functions
                pictureBox5.Visible = true;
                if (VGreenValve.State == ValveStates.OFF)
                    greenAni.Visible = true;                
                CellValve.BackColor = Color.Transparent;
                CellValve.Text = "Flow";
                CellValve2.BackColor = Color.Transparent;
                CellValve2.Text = "Flow";
                VCellFluid.State = ValveStates.ON;
            }
            else
            {
                //TODO: to use logic functions
                pictureBox5.Visible = false;
                greenAni.Visible = false;
                CellValve.BackColor = Color.Red;
                CellValve.Text = "NO Flow";
                CellValve2.BackColor = Color.Red;
                CellValve2.Text = "NO Flow";
                VCellFluid.State = ValveStates.OFF;
            }
        }

        private void FluidicPCOff_Click(object sender, EventArgs e)
        {
            if (progressBar1.Enabled == false)
            {
                //FluidPCControl.Enabled = true;
                progressBar1.Value = System.Convert.ToInt16(FluidPCControl.Value) * 4;
                progressBar1.Enabled = true;
                FluidicPCOff.Text = "TURN OFF";
                FluidicPCOff.BackColor = Color.Transparent;
                PFluidController.Percentage = System.Convert.ToInt16(FluidPCControl.Value)*4;
            }
            else
            {
                //FluidPCControl.Enabled = false;
                progressBar1.Value = 0;
                progressBar1.Enabled = false;
                FluidicPCOff.Text = "TURN ON";
                FluidicPCOff.BackColor = Color.Red;
                PFluidController.Percentage = 0;
            }
        }

        private void PneumaticPCOff_Click(object sender, EventArgs e)
        {
            if (progressBar2.Enabled == false)
            {
                //PneumaticPCControl.Enabled = true;
                progressBar2.Value = System.Convert.ToInt16(PneumaticPCControl.Value) * 2;
                progressBar2.Enabled = true;
                PneumaticPCOff.Text = "TURN OFF";
                PneumaticPCOff.BackColor = Color.Transparent;
                PPneumaticsController.Percentage = System.Convert.ToInt16(PneumaticPCControl.Value) * 2;
            }
            else
            {
                //PneumaticPCControl.Enabled = false;
                progressBar2.Value = 0;
                progressBar2.Enabled = false;
                PneumaticPCOff.Text = "TURN ON";
                PneumaticPCOff.BackColor = Color.Red;
                PPneumaticsController.Percentage = 0;
            }
        }

        private void progressBar1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X <= progressBar1.Maximum && e.X >= progressBar1.Minimum)
                {
                    progressBar1.Value = e.X;
                    PFluidController.Percentage = progressBar1.Value;
                    FluidPCControl.Value = ((System.Convert.ToInt16(progressBar1.Value / 4)));
                }
                else if (e.X < progressBar1.Minimum)
                {
                    progressBar1.Value = 0;
                    PFluidController.Percentage = 0;
                    FluidPCControl.Value = 0;
                }
                else if (e.X > progressBar1.Maximum)
                {
                    progressBar1.Value = 100;
                    PFluidController.Percentage = 100;
                    FluidPCControl.Value = 25;
                }
            }   
        }

        private void FluidPCControl_ValueChanged(object sender, EventArgs e)
        {
            if (progressBar1.Enabled == true)
            {
                PFluidController.Percentage = System.Convert.ToInt16(FluidPCControl.Value * 4);
                progressBar1.Value = System.Convert.ToInt16(FluidPCControl.Value * 4);
            }
        }

        private void PneumaticPCControl_ValueChanged(object sender, EventArgs e)
        {
            if (progressBar2.Enabled == true)
            {
                PPneumaticsController.Percentage = System.Convert.ToInt16(PneumaticPCControl.Value * 2);
                progressBar2.Value = System.Convert.ToInt16(PneumaticPCControl.Value * 2);
            }
        }

        private void progressBar2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.X <= progressBar2.Maximum && e.X >= progressBar2.Minimum)
                {
                    progressBar2.Value = e.X;
                    PPneumaticsController.Percentage = progressBar2.Value;
                    PneumaticPCControl.Value = ((System.Convert.ToInt16(progressBar2.Value / 2)));
                }
                else if (e.X < progressBar2.Minimum)
                {
                    progressBar2.Value = 0;
                    PPneumaticsController.Percentage = 0;
                    PneumaticPCControl.Value = 0;
                }
                else if (e.X > progressBar2.Maximum)
                {
                    progressBar2.Value = 100;
                    PPneumaticsController.Percentage = 100;
                    PneumaticPCControl.Value = 50;
                }
            }  
        }

        private void YellowButton1_Click(object sender, EventArgs e)
        {
            if (YellowButton1.BackColor == Color.Red)
            {
                blueAni4.Visible = true;
                if (VReagentFluid.State == ValveStates.ON)
                    pictureBox7.Visible = true;
                YellowButton1.BackColor = Color.Transparent;
                YellowButton1.Text = "Flow";
                YellowButton2.BackColor = Color.Transparent;
                YellowButton2.Text = "Flow";
                
                VYellowValve.State = ValveStates.OFF;

            }
            else
            {
                blueAni4.Visible = false;
                pictureBox7.Visible = false;
                YellowButton1.BackColor = Color.Red;
                YellowButton1.Text = "NO Flow";
                YellowButton2.BackColor = Color.Red;
                YellowButton2.Text = "NO Flow";

                VYellowValve.State = ValveStates.ON;
            }
        }

        private void DrainValve_Click(object sender, EventArgs e)
        {
            if (DrainValve.BackColor == Color.Red)
            {
                DrainValve.BackColor = Color.Transparent;
                DrainValve.Text = "Drain: ON";
                VDrainValve.State = ValveStates.OFF;
            }
            else
            {
                DrainValve.BackColor = Color.Red;
                DrainValve.Text = "Drain: OFF";
                VDrainValve.State = ValveStates.ON;
            }
        }

        private void ezStop_Click(object sender, EventArgs e)
        {
            ezFlowCells.BackColor = Color.Transparent;
            ezFlowReagents.BackColor = Color.Transparent;
            ezFlowFlush.BackColor = Color.Transparent;
            ezLockdown.BackColor = Color.Transparent;
            ezOpen.BackColor = Color.Transparent;

            if (VReagentFluid.State == ValveStates.ON)
                ReagentValve_Click(sender, e);
            if (VFlushFluid.State == ValveStates.ON)
                FlushValve_Click(sender, e);
            if (VCellFluid.State == ValveStates.ON)
                CellValve_Click(sender, e);

            if (VGrayValve.State == ValveStates.ON)
                GrayValve_Click(sender, e);
            if (VBlueValve.State == ValveStates.ON)
                BlueValve1_Click(sender, e);
            if (VGreenValve.State == ValveStates.ON)
                GreenValve_Click(sender, e);
            if (VRedValve.State == ValveStates.ON)
                RedValve2_Click(sender, e);
            if (VYellowValve.State == ValveStates.ON)
                YellowButton1_Click(sender, e);
            if (VDrainValve.State == ValveStates.ON)
                DrainValve_Click(sender, e);

            if(progressBar2.Enabled == true)
                PneumaticPCOff_Click(sender, e);
            if(progressBar1.Enabled == true)
                FluidicPCOff_Click(sender, e);
        }

        private void ezFlowCells_Click(object sender, EventArgs e)
        {
            ezFlowCells.BackColor = Color.Green;
            ezFlowReagents.BackColor = Color.Transparent;
            ezFlowFlush.BackColor = Color.Transparent;
            ezLockdown.BackColor = Color.Transparent;
            ezOpen.BackColor = Color.Transparent;

            if (VReagentFluid.State == ValveStates.ON)
                ReagentValve_Click(sender, e);
            if (VFlushFluid.State == ValveStates.ON)
                FlushValve_Click(sender, e);
            if (VCellFluid.State == ValveStates.OFF)
                CellValve_Click(sender, e);

            if (VGrayValve.State == ValveStates.OFF)
                GrayValve_Click(sender, e);
            if (VBlueValve.State == ValveStates.ON)
                BlueValve1_Click(sender, e);
            if (VGreenValve.State == ValveStates.ON)
                GreenValve_Click(sender, e);
            if (VRedValve.State == ValveStates.OFF)
                RedValve2_Click(sender, e);
            if (VYellowValve.State == ValveStates.OFF)
                YellowButton1_Click(sender, e);
            if (VDrainValve.State == ValveStates.ON)
                DrainValve_Click(sender, e);
        }

        private void ezFlowReagents_Click(object sender, EventArgs e)
        {
            ezFlowCells.BackColor = Color.Transparent;
            ezFlowReagents.BackColor = Color.Green;
            ezFlowFlush.BackColor = Color.Transparent;
            ezLockdown.BackColor = Color.Transparent;
            ezOpen.BackColor = Color.Transparent;

            if (VReagentFluid.State == ValveStates.OFF)
                ReagentValve_Click(sender, e);
            if (VFlushFluid.State == ValveStates.ON)
                FlushValve_Click(sender, e);
            if (VCellFluid.State == ValveStates.ON)
                CellValve_Click(sender, e);

            if (VGrayValve.State == ValveStates.OFF)
                GrayValve_Click(sender, e);
            if (VBlueValve.State == ValveStates.ON)
                BlueValve1_Click(sender, e);
            if (VGreenValve.State == ValveStates.OFF)
                GreenValve_Click(sender, e);
            if (VRedValve.State == ValveStates.ON)
                RedValve2_Click(sender, e);
            if (VYellowValve.State == ValveStates.ON)
                YellowButton1_Click(sender, e);
            if (VDrainValve.State == ValveStates.ON)
                DrainValve_Click(sender, e);
            redAni2.Visible = false;
        }

        private void ezFlowFlush_Click(object sender, EventArgs e)
        {
            ezFlowCells.BackColor = Color.Transparent;
            ezFlowReagents.BackColor = Color.Transparent;
            ezFlowFlush.BackColor = Color.Green;
            ezLockdown.BackColor = Color.Transparent;
            ezOpen.BackColor = Color.Transparent;

            if (VReagentFluid.State == ValveStates.ON)
                ReagentValve_Click(sender, e);
            if (VFlushFluid.State == ValveStates.OFF)
                FlushValve_Click(sender, e);
            if (VCellFluid.State == ValveStates.ON)
                CellValve_Click(sender, e);

            if (VGrayValve.State == ValveStates.ON)
                GrayValve_Click(sender, e);
            if (VBlueValve.State == ValveStates.ON)
                BlueValve1_Click(sender, e);
            if (VGreenValve.State == ValveStates.OFF)
                GreenValve_Click(sender, e);
            if (VRedValve.State == ValveStates.ON)
                RedValve2_Click(sender, e);
            if (VYellowValve.State == ValveStates.OFF)
                YellowButton1_Click(sender, e);
            if (VDrainValve.State == ValveStates.ON)
                DrainValve_Click(sender, e);
            redAni2.Visible = true;
            pictureBox6.Visible = true;
        }

        private void ezLockdown_Click(object sender, EventArgs e)
        {
            ezFlowCells.BackColor = Color.Transparent;
            ezFlowReagents.BackColor = Color.Transparent;
            ezFlowFlush.BackColor = Color.Transparent;
            ezLockdown.BackColor = Color.Green;
            ezOpen.BackColor = Color.Transparent;

            if (VReagentFluid.State == ValveStates.ON)
                ReagentValve_Click(sender, e);
            if (VFlushFluid.State == ValveStates.ON)
                FlushValve_Click(sender, e);
            if (VCellFluid.State == ValveStates.ON)
                CellValve_Click(sender, e);

            if (VGrayValve.State == ValveStates.OFF)
                GrayValve_Click(sender, e);
            if (VBlueValve.State == ValveStates.OFF)
                BlueValve1_Click(sender, e);
            if (VGreenValve.State == ValveStates.OFF)
                GreenValve_Click(sender, e);
            if (VRedValve.State == ValveStates.OFF)
                RedValve2_Click(sender, e);
            if (VYellowValve.State == ValveStates.OFF)
                YellowButton1_Click(sender, e);
            if (VDrainValve.State == ValveStates.OFF)
                DrainValve_Click(sender, e);
        }

        private void ezOpen_Click(object sender, EventArgs e)
        {
            ezFlowCells.BackColor = Color.Transparent;
            ezFlowReagents.BackColor = Color.Transparent;
            ezFlowFlush.BackColor = Color.Transparent;
            ezLockdown.BackColor = Color.Transparent;
            ezOpen.BackColor = Color.Green;

            if (VReagentFluid.State == ValveStates.ON)
                ReagentValve_Click(sender, e);
            if (VFlushFluid.State == ValveStates.ON)
                FlushValve_Click(sender, e);
            if (VCellFluid.State == ValveStates.ON)
                CellValve_Click(sender, e);

            if (VGrayValve.State == ValveStates.ON)
                GrayValve_Click(sender, e);
            if (VBlueValve.State == ValveStates.ON)
                BlueValve1_Click(sender, e);
            if (VGreenValve.State == ValveStates.ON)
                GreenValve_Click(sender, e);
            if (VRedValve.State == ValveStates.ON)
                RedValve2_Click(sender, e);
            if (VYellowValve.State == ValveStates.ON)
                YellowButton1_Click(sender, e);
            if (VDrainValve.State == ValveStates.ON)
                DrainValve_Click(sender, e);
        }
    }
}
