using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Diagnostics;

namespace yt_processor
{
    public partial class Form1 : Form
    {
        String img_id;
        String path = "";

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "";
        }

        private void verify_Click(object sender, EventArgs e)
        {
            var url = yturl.Text;
            var uri = new Uri(url);
            var query = HttpUtility.ParseQueryString(uri.Query);
            var vid_id = string.Empty;
            if (query.AllKeys.Contains("v"))
            {
                vid_id = query["v"];
            }
            else
            {
                vid_id = uri.Segments.Last();
            }
            img_id = "http://img.youtube.com/vi/" + vid_id + "/maxresdefault.jpg";
            thumbnail.Load(img_id);
            if (path != "")
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = @"youtube-dl.exe";
                string args = " -f bestaudio" + " -o " + @"dl\output.webm" + " " + url;
                startInfo.Arguments = args;
                label1.Text = args;
                Process.Start(startInfo);
            }
            else
                MessageBox.Show("Choose a path!");
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                path = folderBrowserDialog1.SelectedPath;
                path = '\u0022' + path + @"\output.webm" + '\u0022';

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            path = textBox1.Text;
            path = '\u0022' + path + @"\output.webm" + '\u0022';
        }

        private void yturl_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var url = yturl.Text;
            var uri = new Uri(url);
            var query = HttpUtility.ParseQueryString(uri.Query);
            var vid_id = string.Empty;
            if (query.AllKeys.Contains("v"))
            {
                vid_id = query["v"];
            }
            else
            {
                vid_id = uri.Segments.Last();
            }
            img_id = "http://img.youtube.com/vi/" + vid_id + "/maxresdefault.jpg";
            thumbnail.Load(img_id);
        }

    }
}
