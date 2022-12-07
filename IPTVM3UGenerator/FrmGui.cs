using HtmlAgilityPack;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace IPTVM3UGenerator
{
    public partial class FrmGui : Form
    {
        private const string FLAGS_DIR = "Flags";
        private const string OUTPUT_DIR = "Output";

        private string sSelectedCountry;

        public FrmGui()
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            this.BtnGen.Visible = false;
            this.LblGen.Visible = false;
            this.LvCountries.Enabled = false;
        }

        private void GetCountries()
        {
            MyHtmlWeb w = new MyHtmlWeb();
            HtmlAgilityPack.HtmlDocument d = w.Load("https://iptvcat.com/");

            HtmlNodeCollection flags = d.DocumentNode.SelectNodes("//td[@style='padding-left:45px;']//td[@class='no-padding-right pl-5 flag']//img");
            HtmlNodeCollection countries = d.DocumentNode.SelectNodes("//td[@style='padding-left:45px;']//td[@class='pl-5']");

            this.Invoke((MethodInvoker)delegate
           {
               this.Pb.Minimum = 0;
               this.Pb.Maximum = countries.Count - 1;
               this.Pb.Value = 0;
               this.Pb.Visible = true;

               this.LvCountries.BeginUpdate();
               if (this.LvCountries.SmallImageList == null)
                   this.LvCountries.SmallImageList = new ImageList();
               else
                   this.LvCountries.SmallImageList.Images.Clear();
           });

            for (int i = 0; i < countries.Count; i++)
            {
                string countryCode = flags[i].Attributes["src"].Value.Replace("assets/images/flags/", "").Replace(".png", "");
                string filename = string.Format(@"{0}\{1}.png", FLAGS_DIR, countryCode);

                DirectoryInfo di = new DirectoryInfo(OUTPUT_DIR);
                if (!di.Exists)
                    di.Create();

                di = new DirectoryInfo(FLAGS_DIR);
                if (!di.Exists)
                    di.Create();

                if (!File.Exists(filename))
                {
                    using (MyWebClient wc = new MyWebClient())
                    {
                        byte[] buf = wc.DownloadData(string.Concat("https://countryflagsapi.com/png/", countryCode));
                        using (MemoryStream ms = new MemoryStream(buf, 0, buf.Length))
                        {
                            ms.Write(buf, 0, buf.Length);

                            using (Image img = Image.FromStream(ms, true))
                            {
                                int width = 24;
                                int height;
                                double ratio = (double)width / img.Width;

                                height = (int)Math.Ceiling(img.Height * ratio);

                                using (Bitmap bmp = new Bitmap(width, height))
                                {

                                    Graphics.FromImage(bmp).DrawImage(img, 0, 0, width, height);

                                    bmp.Save(filename, ImageFormat.Png);
                                }
                            }
                        }
                    }
                }

                this.Invoke((MethodInvoker)delegate
               {
                   this.LvCountries.SmallImageList.Images.Add(Image.FromFile(filename));
                   this.LvCountries.Items.Add(countries[i].InnerText, i);

                   this.Pb.Value = i;
               });
            }

            this.Invoke((MethodInvoker)delegate
           {
               this.LvCountries.Sort();
               this.LvCountries.EndUpdate();

               this.Pb.Visible = false;
               this.BtnGen.Visible = true;
               this.LblGen.Visible = true;
               this.LvCountries.Enabled = true;
           });
        }

        private void BtnGen_Click(object sender, EventArgs e)
        {
            this.BtnGen.Visible = false;
            this.LblGen.Visible = false;

            this.Pb.Minimum = 0;
            this.Pb.Maximum = this.LvCountries.CheckedItems.Count;
            this.Pb.Value = 0;
            this.Pb.Visible = true;


            for (int i = 0; i < this.LvCountries.CheckedItems.Count; i++)
            {
                Application.DoEvents();

                ListViewItem item = this.LvCountries.CheckedItems[i];

                this.sSelectedCountry = item.Text.Replace(" ", "_");
                this.GetChannels(this.sSelectedCountry);
            }

            this.Pb.Visible = false;
            this.BtnGen.Visible = true;
            this.LblGen.Visible = true;
        }

        private void GetChannels(string _countryCode, bool _nextPage = false)
        {
            MyHtmlWeb w = new MyHtmlWeb();
            HtmlAgilityPack.HtmlDocument d = w.Load(string.Concat("https://iptvcat.com/", _countryCode));

            HtmlNodeCollection m3u8 = d.DocumentNode.SelectNodes("//span[@class='label label-flat border-info text-info-600 get_vlc y']");
            HtmlNodeCollection onlines = d.DocumentNode.SelectNodes("//tbody//tr//td[4]//div");

            if (m3u8 != null && onlines != null)
            {
                string filename = string.Format(@"{0}\{1}.m3u", OUTPUT_DIR, this.sSelectedCountry);

                StringBuilder sb = new StringBuilder();
                if (File.Exists(filename))
                    _ = sb.AppendLine(File.ReadAllText(filename));
                else
                _ = sb.AppendLine("#EXTM3U");

                for (int i = 0; i < m3u8.Count; i++)
                {
                    if (onlines[i].InnerText.Equals("-"))
                        continue;

                    using (MyWebClient wc = new MyWebClient())
                    {
                        string s = wc.DownloadString(m3u8[i].Attributes["data-clipboard-text"].Value).Replace("#EXTM3U\n", "");

                        _ = sb.Append(s);
                    }

                    Application.DoEvents();
                }

                File.WriteAllText(filename, sb.ToString());

                HtmlNodeCollection buttons = d.DocumentNode.SelectNodes("//li//a");
                if (buttons != null)
                {
                    foreach (var button in buttons)
                    {
                        if (button.InnerHtml.Equals("<i class=\"icon-arrow-right5\"></i>"))
                        {
                            if (button.Attributes.Count == 3 && button.Attributes[0].Name.Equals("href"))
                            {
                                GetChannels(button.Attributes[0].Value, true);

                                break;
                            }
                        }
                    }
                }
            }

            if (!_nextPage)
                this.Pb.Value++;
        }

        private void FrmGui_Shown(object _sender, EventArgs _e)
        {
            Thread thd = new Thread(GetCountries);
            thd.Start();
        }

        private void LvCountries_SelectedIndexChanged(object _sender, EventArgs _e)
        {
            foreach (ListViewItem i in this.LvCountries.SelectedItems)
            {
                i.Checked = !i.Checked;
                i.Focused = false;
            }
        }
    }
}
