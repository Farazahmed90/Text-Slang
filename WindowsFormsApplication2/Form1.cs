using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.IO;
namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "100";
        }
        SpeechSynthesizer s = new SpeechSynthesizer();
        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "")
            {
                if (comboBox1.Text == "Male")
                {
                    s.SelectVoiceByHints(VoiceGender.Male);
                    s.Volume = trackBar1.Value;
                    s.Dispose();
                    s = new SpeechSynthesizer();
                    s.SpeakAsync(richTextBox1.Text);
                }
                if (comboBox1.Text == "Female")
                {
                    s.SelectVoiceByHints(VoiceGender.Female);
                    s.SpeakAsync(richTextBox1.Text);
                }
            }
            else
            {
                MessageBox.Show("Enter some text");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 100;
            trackBar1.TickStyle = TickStyle.BottomRight;
            trackBar1.TickFrequency = 10;
            trackBar1.Value = 100;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (s.State == SynthesizerState.Paused)
            {
                s.Resume();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
                if (s.State == SynthesizerState.Speaking)
                {
                    s.Pause();
                }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (s.State == SynthesizerState.Speaking)
            {
                s.Dispose();
            }
        }
    }
}
