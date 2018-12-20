using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 链家爬虫
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
            btnStart.Enabled = false;
            btnOpen.Enabled = false;
        }


        private async void btnDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.Description = "请选择Txt所在文件夹";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (string.IsNullOrEmpty(dialog.SelectedPath))
                    {
                        MessageBox.Show(this, "文件夹路径不能为空", "提示");
                        return;
                    }
                    else
                    {
                        lblFileDirectory.Text = dialog.SelectedPath;
                        btnStart.Enabled = true;
                        btnOpen.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                btnStart.Enabled = false;
                btnDirectory.Enabled = false;
                if (string.IsNullOrEmpty(txtUrl.Text))
                {
                    MessageBox.Show(this, "网址不能为空", "提示");
                }
                if (string.IsNullOrEmpty(lblFileDirectory.Text))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                }
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.110 Safari/537.36");
                var contentResult = await httpClient.GetStringAsync(txtUrl.Text);
                Regex regex = new Regex("https://image1.ljcdn.com/hdic-resblock/[^!]+![^,]+,w_1000");
                MatchCollection matches = regex.Matches(contentResult);

                //Parallel.For(0, matches.Count, async i =>
                //{
                //    using (HttpClient client = new HttpClient())
                //    {
                //        client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.110 Safari/537.36");
                //        var picUrl = matches[i].Value;
                //        var pic_Stream = await client.GetByteArrayAsync(picUrl);
                //        var filePath = Path.Combine(lblFileDirectory.Text, $"{i}.png");
                //        File.WriteAllBytes(filePath, pic_Stream);
                //    }
                //});
                btnStart.Text = "正在下载中";
                for (int i = 0; i < matches.Count; i++)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.110 Safari/537.36");
                        var picUrl = matches[i].Value;
                        var pic_Stream = await client.GetByteArrayAsync(picUrl);
                        var filePath = Path.Combine(lblFileDirectory.Text, $"{i}.png");
                        File.WriteAllBytes(filePath, pic_Stream);
                    }

                }

                btnStart.Text = "开始下载";
                btnStart.Enabled = true;
                btnDirectory.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private async void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lblFileDirectory.Text))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                }
                System.Diagnostics.Process.Start("explorer.exe", lblFileDirectory.Text);
            }
            catch (Exception ex)
            {
            }
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
