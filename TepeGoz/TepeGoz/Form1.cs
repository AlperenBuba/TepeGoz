using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace TepeGoz
{
    public partial class Form1 : Form
    {
        string filePath = "sites.json";

        // ListBox'ta hem isim hem link tutmak için yardımcı sınıf
        public class SiteItem
        {
            public string Name { get; set; }
            public string Url { get; set; }

            // ListBox'ta görünen metni burada formatlıyoruz
            public override string ToString()
            {
                return $"{Name} |  {Url}";
            }
        }

        public Form1()
        {
            InitializeComponent();
            CheckAndCreateJson();

            sonuclarLB.DoubleClick += sonuclarLB_DoubleClick;
        }

        private void CheckAndCreateJson()
        {
            if (!File.Exists(filePath))
            {
                string defaultData = "Instagram|https://www.instagram.com/{user}/\n" +
                     "GitHub|https://github.com/{user}\n" +
                     "Twitter|https://twitter.com/{user}\n" +
                     "YouTube|https://www.youtube.com/@{user}\n" +
                     "TikTok|https://www.tiktok.com/@{user}\n" +
                     "Twitch|https://www.twitch.tv/{user}\n" +
                     "Reddit|https://www.reddit.com/user/{user}";
                File.WriteAllText(filePath, defaultData);
            }
        }

        private async void bulBtn_Click(object sender, EventArgs e)
        {
            // 1. İnternet Kontrolü
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show("İnternet Bağlantısı Yok! Lütfen bağlantını kontrol et.");
                return;
            }

            string input = hesapAdiTxt.Text.Trim();
            if (string.IsNullOrEmpty(input)) return;

            sonuclarLB.Items.Clear();
            bulBtn.Enabled = false;
            progressBar1.Value = 0;

            // 2. Varyasyonları Hazırla
            List<string> birlesikVaryasyonlar = new List<string>();
            List<string> parcaliVaryasyonlar = new List<string>();

            if (input.Contains(" "))
            {
                birlesikVaryasyonlar.Add(input.Replace(" ", ""));
                birlesikVaryasyonlar.Add(input.Replace(" ", "_"));
                birlesikVaryasyonlar.Add(input.Replace(" ", "."));

                string[] parts = input.Split(' ');
                parcaliVaryasyonlar.AddRange(parts);
            }
            else
            {
                birlesikVaryasyonlar.Add(input);
            }

            string[] lines = File.ReadAllLines(filePath);
            progressBar1.Maximum = (birlesikVaryasyonlar.Count + parcaliVaryasyonlar.Count) * lines.Length;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");

                // ÖNCE BİRLEŞİK VARYASYONLARI TARA
                foreach (string username in birlesikVaryasyonlar)
                {
                    await TaramaYap(client, username, lines);
                }

                // EĞER HİÇBİR ŞEY BULAMADIYSA, PARÇALI VARYASYONLARA GEÇ
                if (sonuclarLB.Items.Count == 0 && parcaliVaryasyonlar.Count > 0)
                {
                    sonuclarLB.Items.Add("[*] Birleşik sonuç bulunamadı, parçalı aramaya geçiliyor...");
                    foreach (string username in parcaliVaryasyonlar)
                    {
                        await TaramaYap(client, username, lines);
                    }
                }
            }

            progressBar1.Value = progressBar1.Maximum;
            bulBtn.Enabled = true;
            MessageBox.Show("Tarama tamamlandı!");
        }

        // Tekrardan kurtulmak için tarama metodunu ayırdık
        private async Task TaramaYap(HttpClient client, string username, string[] lines)
        {
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                string[] parts = line.Split('|');
                string url = parts[1].Replace("{user}", username);

                try
                {
                    var response = await client.GetAsync(url);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        sonuclarLB.Items.Add(new SiteItem { Name = $"[+] {parts[0]} ({username})", Url = url });
                    }
                }
                catch { }

                // Burayı değiştirdik: Value'yu manuel artırmak yerine
                // Maksimum değerin içerisindeyken güvenli şekilde artırıyoruz
                if (progressBar1.Value < progressBar1.Maximum)
                {
                    progressBar1.Value++;
                }
            }
        }

        // Çift tıklama olayı
        private void sonuclarLB_DoubleClick(object sender, EventArgs e)
        {
            if (sonuclarLB.SelectedItem is SiteItem selectedSite)
            {
                Process.Start(selectedSite.Url); // Linki tarayıcıda aç
            }
        }

        private void bagisBtn_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/AlperenBuba");
        }

        private void bagisBtn_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://github.com/AlperenBuba");
        }
    }
}