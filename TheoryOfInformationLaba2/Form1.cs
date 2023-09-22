using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TheoryOfInformationLaba2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AutoScroll = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double fc = (Convert.ToDouble(textBoxfc.Text));
            int K = Convert.ToInt16(textBoxK.Text);
            double[] fArray = new double[K];
            TextBox[] textboxArray = new TextBox[6];
            textboxArray[0] = textBoxT0;
            textboxArray[1] = textBoxT1;
            textboxArray[2] = textBoxT2;
            textboxArray[3] = textBoxT3;
            textboxArray[4] = textBoxT4;
            textboxArray[5] = textBoxT5;
            double max = double.MinValue;
            for (int i = 0; i < K; i++)
            {
                fArray[i] = Convert.ToDouble(textboxArray[i].Text);
                if (fArray[i]>max)
                {
                    max = fArray[i];
                }
            }
           
            double Wc = 2 * Math.PI * fc;
            chart1.Series["Graph"].Points.Clear();
            double t = 0.0, b = 1.0 / 400.0, h = (b - t) / 100.0, y;
            double A;
            Chart[] chartArray = new Chart[6];
            chartArray[0] = chart1;
            chartArray[1] = chart2;
            chartArray[2] = chart3;
            chartArray[3] = chart4;
            chartArray[4] = chart5;
            chartArray[5] = chart6;
            for (int i = 1; i < K+1; i++)
            {
                t = 0;
                double t0 = i / (2 * fc);
                while (t <= b)
                {
                    A = Wc * (t - t0);
                    y = fArray[i-1] * (Math.Sin(A) / A);
                    //chartArray[i - 1].Series["Graph"].Points.LegendText = $"F({i-1}";
                    chartArray[i - 1].ChartAreas["ChartArea1"].AxisY.Interval = 1;
                    chartArray[i - 1].ChartAreas["ChartArea1"].AxisY.Maximum = 0;
                    chartArray[i - 1].ChartAreas["ChartArea1"].AxisY.Maximum = max+2;
                    chartArray[i-1].Series["Graph"].Points.AddXY(t, y);
                    t += h;
                }
            }
            t = 0;
            
            while (t <= b)
            {
                y = 0;
                for (int i = 1; i < K+1; i++)
                {
                    y += fArray[i-1] * (Math.Sin((Wc * (t - (i / (2 * fc))))) / (Wc * (t - (i / (2 * fc)))));
                }

                chart7.Series["Graph"].Points.AddXY(t, y);
                t += h;
            }
        }
    }
}
