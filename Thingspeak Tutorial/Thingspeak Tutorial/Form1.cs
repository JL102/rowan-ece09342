using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thingspeak_Tutorial
{
    public partial class Form1 : Form
    {
        int startflag = 0;
        int flag_sensor;
        string RxString;
        string temp = "30";
        // for rolling averages
        const int averagesSize = 10;
        bool averagesInitialized = false;
        int thisRollingIdx = 0;
        int[] rollingTemps = new int[averagesSize];
        int[] rollingLightLevel = new int[averagesSize];
        int avgLight, avgTemp;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();

            serialPort1.PortName = "COM6";
            serialPort1.BaudRate = 9600;
        }

        private void currentDataText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void read_channel_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();

            //ThingSpeakData.Text = client.DownloadString("http://api.thingspeak.com/channels/1563511/feed.json");

            tsChannelOutput1.Text = client.DownloadString("http://api.thingspeak.com/channels/1563511/field/field1/last.text");
            tsChannelOutput2.Text = client.DownloadString("http://api.thingspeak.com/channels/1563511/field/field2/last.text");

        }

        private void serial_start_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen) return;

            string text = ComInput.Text;

            if (!text.StartsWith("COM"))
            {
                try
                {
                    int num = int.Parse(text);
                    text = "COM" + num;
                    ComInput.Text = text;
                }
                catch (Exception err)
                {
                    string message;
                    if (text.Length == 0)
                    {
                        message = "Please enter a COM port.";
                    }
                    else
                    {
                        message = "Unable to parse number from " + text;
                    }
                    MessageBox.Show(message, "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }

            serialPort1.PortName = text;
            serialPort1.BaudRate = 9600;

            try
            {
                serialPort1.Open();
                if (serialPort1.IsOpen)
                {
                    serial_start.Enabled = false;
                    serial_end.Enabled = true;

                    current_data_text.ReadOnly = false;
                }
            }
            catch (Exception err)
            {
                var result = MessageBox.Show(err.Message, "Error",
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Error);
            }

        }

        private void serial_end_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            serial_start.Enabled = true;
            serial_end.Enabled = false;

            current_data_text.ReadOnly = true;
        }

        private void currentData_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            if (!string.Equals(current_data_text.Text, ""))
            {
                if (serialPort1.IsOpen) serialPort1.Close();
                try
                {

                    const string WRITEKEY = "1CTBYY4WS2GLKJF2";
                    string strUpdateBase = "http://api.thingspeak.com/update";


                    string strUpdateURI = strUpdateBase + "?api_key=" + WRITEKEY;
                    string strField1 = avgLight.ToString();
                    string strField2 = avgTemp.ToString();


                    // string strField2 = "42";
                    HttpWebRequest ThingsSpeakReq;
                    HttpWebResponse ThingsSpeakResp;


                    strUpdateURI += "&field1=" + strField1 + "&field2=" + strField2;
                    /*if (flag_sensor == 11)
                    {
                        strUpdateURI += "&field1=" + strField1;


                    }
                    else if (flag_sensor == 12)
                    {
                        strUpdateURI += "&field2=" + strField1;

                    }
                    else if (flag_sensor == 13)
                    {
                        strUpdateURI += "&field3=" + strField1;

                    }
                    else if (flag_sensor == 14)
                    {
                        strUpdateURI += "&field4=" + strField1;

                    }
                    else
                    {

                    }*/


                    flag_sensor++;
                    ThingsSpeakReq = (HttpWebRequest)WebRequest.Create(strUpdateURI);

                    ThingsSpeakResp = (HttpWebResponse)ThingsSpeakReq.GetResponse();
                    ThingsSpeakResp.Close();

                    if (!(string.Equals(ThingsSpeakResp.StatusDescription, "OK")))
                    {
                        Exception exData = new Exception(ThingsSpeakResp.StatusDescription);
                        throw exData;
                    }

                }
                catch (Exception ex)
                {

                }
                current_data_text.Text = "";


                serialPort1.Open();
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            RxString = serialPort1.ReadExisting();

            if (RxString.Length > 0)
            {
                current_data_text.Clear();
                current_data_text.AppendText(RxString.Substring(0, RxString.IndexOf('\r')));

                string[] strs = current_data_text.Text.Split(',');
                int thisLight, thisTemp;

                thisLight = int.Parse(strs[0]);
                thisTemp = int.Parse(strs[1]);

                // calculate averages 


                calculateAverages(thisLight, thisTemp);
            }
        }

        private void calculateAverages(int light, int temp)
        {
            // initialize at the first value so we don't get garbage for the first 10
            if (!averagesInitialized)
            {
                for (int i = 0; i < averagesSize; i++)
                {
                    rollingLightLevel[i] = light;
                    rollingTemps[i] = temp;
                }
                averagesInitialized = true;
            }

            // update the rolling avg arrays
            rollingLightLevel[thisRollingIdx] = light;
            rollingTemps[thisRollingIdx] = temp;
            thisRollingIdx++;
            if (thisRollingIdx >= averagesSize) thisRollingIdx = 0;

            int sumLight = 0, sumTemp = 0;

            for (int i = 0; i < averagesSize; i++)
            {
                sumLight += rollingLightLevel[i];
                sumTemp += rollingTemps[i];
            }

            avgLight = sumLight / averagesSize;
            avgTemp = sumTemp / averagesSize;

            // update the labels
            if (thisRollingIdx % 2 == 0)
            {
                currentAverageLight.Text = avgLight.ToString();
                currentAverageTemp.Text = avgTemp.ToString();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
