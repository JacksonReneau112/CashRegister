using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace CashRegister
{
    public partial class Form1 : Form
    {
        //Global Variables
        double gpuPrice = 350;
        double cpuPrice = 250;
        double memoryPrice = 80;

        int numOfGpu = 0;
        int numOfCpu = 0;
        int numOfMemory = 0;

        double gpuTotal = 0;
        double cpuTotal = 0;
        double memoryTotal = 0;

        double taxRate = 0.13;
        double subtotal = 0;
        double taxAmount = 0;
        double totalPrice = 0;
        double tendered = 0;
        double change = 0;

        SoundPlayer clickSound = new SoundPlayer(Properties.Resources.click);
        SoundPlayer recieptSound = new SoundPlayer(Properties.Resources.receiptPrinting);
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateTotalButton_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            try
            {
                numOfGpu = Convert.ToInt32(gpuInput.Text);
                numOfCpu = Convert.ToInt32(cpuInput.Text);
                numOfMemory = Convert.ToInt32(memoryInput.Text);

                gpuTotal = numOfGpu * gpuPrice;
                cpuTotal = numOfCpu * cpuPrice;
                memoryTotal = numOfMemory * memoryPrice;

                subtotal = gpuTotal + cpuTotal + memoryTotal;
                taxAmount = subtotal * taxRate;
                totalPrice = subtotal + taxAmount;

                subtotalOutput.Text = $"{subtotal.ToString("C")}";
                taxAmountOutput.Text = $"{taxAmount.ToString("C")}";
                totalPriceOutput.Text = $"{totalPrice.ToString("C")}";

                calculateChangeButton.Enabled = true;
                calculateTotalButton.Enabled = false;
            }

            catch
            {
                subtotalOutput.Text = "ERROR";
            }

        }

        private void calculateChangeButton_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            try
            {
                tendered = Convert.ToDouble(tenderedInput.Text);

                change = tendered - totalPrice;

                changeOutput.Text = $"{change.ToString("C")}";

                recieptButton.Enabled = true;
                calculateChangeButton.Enabled = false;
            }

            catch
            {
                changeOutput.Text = "ERROR";
            }

        }

        private void recieptButton_Click(object sender, EventArgs e)
        {
            clickSound.Play();
            recieptSound.Play();

            recieptOutput.Text = "             Computer Shop Inc.";
            Thread.Sleep(500);
            Refresh();

            recieptOutput.Text += "\n\n     Order Number 99";
            Thread.Sleep(500);
            Refresh();

            recieptOutput.Text += "\n     Febuary 29th 2022";
            Thread.Sleep(500);
            Refresh();

            recieptOutput.Text += $"\n\n     Gpu's                 x{numOfGpu} @ 350.00";
            Thread.Sleep(500);
            Refresh();

            recieptOutput.Text += $"\n     Cpu's                 x{numOfCpu} @ 250.00";
            Thread.Sleep(500);
            Refresh();

            recieptOutput.Text += $"\n     Memory Sticks         x{numOfMemory} @  80.00";
            Thread.Sleep(500);
            Refresh();

            recieptOutput.Text += $"\n\n     Subtotal                  {subtotal.ToString("C")}";
            Thread.Sleep(500);
            Refresh();

            recieptOutput.Text += $"\n     Tax                       {taxAmount.ToString("$ 0.00")}";
            Thread.Sleep(500);
            Refresh();

            recieptOutput.Text += $"\n     Total                     {totalPrice.ToString("C")}";
            Thread.Sleep(500);
            Refresh();

            recieptOutput.Text += $"\n\n     Tendered                  {tendered.ToString("C")}";
            Thread.Sleep(500);
            Refresh();

            recieptOutput.Text += $"\n     Change                    {change.ToString("$ 00.00")}";
            Thread.Sleep(500);
            Refresh();

            recieptOutput.Text += $"\n\n     Have a Good Day!";
            Thread.Sleep(500);
            Refresh();

            recieptButton.Enabled = false;
            newOrderButton.Enabled = true;

        }

        private void newOrderButton_Click(object sender, EventArgs e)
        {
            clickSound.Play();

            subtotalOutput.Text = "";
            taxAmountOutput.Text = "";
            totalPriceOutput.Text = "";
            changeOutput.Text = "";
            recieptOutput.Text = "";

            gpuInput.Text = "";
            cpuInput.Text = "";
            memoryInput.Text = "";
            tenderedInput.Text = "";

            calculateTotalButton.Enabled = true;
            newOrderButton.Enabled = false;
        }
    }
}
