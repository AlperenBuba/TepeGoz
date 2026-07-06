using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TepeGoz
{
    public partial class Form1 : Form
    {
        private int _originalWidth;
        public Form1()
        {
            InitializeComponent();
            sonuclarLB.DoubleClick += SonuclarLB_DoubleClick;
            _originalWidth = this.Width; // 624
            this.Resize += Form1_Resize;
        }

        // Tüm platformlar
        private readonly Dictionary<string, string> _sites = new Dictionary<string, string>
        {
            // Sosyal Medya
            { "Facebook", "https://www.facebook.com/{user}" },
            { "Instagram", "https://www.instagram.com/{user}/" },
            { "Twitter", "https://twitter.com/{user}" },
            { "TikTok", "https://www.tiktok.com/@{user}" },
            { "LinkedIn", "https://www.linkedin.com/in/{user}" },
            { "Pinterest", "https://www.pinterest.com/{user}/" },
            { "Tumblr", "https://{user}.tumblr.com" },
            { "Snapchat", "https://www.snapchat.com/add/{user}" },
            { "Telegram", "https://t.me/{user}" },
            { "Discord", "https://discord.com/users/{user}" },
            { "Reddit", "https://www.reddit.com/user/{user}" },
            { "Twitch", "https://www.twitch.tv/{user}" },
            { "YouTube", "https://www.youtube.com/@{user}" },
            { "Vimeo", "https://vimeo.com/{user}" },
            { "Flickr", "https://www.flickr.com/people/{user}/" },
            { "DeviantArt", "https://www.deviantart.com/{user}" },
            { "Behance", "https://www.behance.net/{user}" },
            { "Dribbble", "https://dribbble.com/{user}" },
            { "Medium", "https://medium.com/@{user}" },
            { "VK", "https://vk.com/{user}" },

            // Kodlama / Teknoloji
            { "GitHub", "https://github.com/{user}" },
            { "GitLab", "https://gitlab.com/{user}" },
            { "Bitbucket", "https://bitbucket.org/{user}/" },
            { "Stack Overflow", "https://stackoverflow.com/users/{user}" },
            { "Dev.to", "https://dev.to/{user}" },
            { "HackerRank", "https://www.hackerrank.com/{user}" },
            { "LeetCode", "https://leetcode.com/{user}/" },
            { "CodeWars", "https://www.codewars.com/users/{user}" },
            { "Docker Hub", "https://hub.docker.com/u/{user}" },
            { "PyPI", "https://pypi.org/user/{user}/" },
            { "NPM", "https://www.npmjs.com/~{user}" },
            { "RubyGems", "https://rubygems.org/profiles/{user}" },
            { "CodePen", "https://codepen.io/{user}" },
            { "Replit", "https://replit.com/@{user}" },

            // Oyun
            { "Steam", "https://steamcommunity.com/id/{user}" },
            { "Xbox", "https://xboxgamertag.com/search/{user}" },
            { "PlayStation", "https://psnprofiles.com/{user}" },
            { "Nintendo", "https://nintendo-master.com/profile/{user}" },
            { "Epic Games", "https://www.epicgames.com/id/{user}" },
            { "Roblox", "https://www.roblox.com/user.aspx?username={user}" },
            { "Minecraft", "https://namemc.com/profile/{user}" },

            // Forum / Topluluk
            { "Patreon", "https://www.patreon.com/{user}" },
            { "Gumroad", "https://gumroad.com/{user}" },
            { "Product Hunt", "https://www.producthunt.com/@{user}" },
            { "Keybase", "https://keybase.io/{user}" },
            { "Gravatar", "https://en.gravatar.com/{user}" },
            { "Pastebin", "https://pastebin.com/u/{user}" },
            { "HackerOne", "https://hackerone.com/{user}" },
            { "Bugcrowd", "https://bugcrowd.com/{user}" },

            // Profesyonel / İş
            { "AngelList", "https://angel.co/u/{user}" },
            { "Crunchbase", "https://www.crunchbase.com/person/{user}" },
            { "Xing", "https://www.xing.com/profile/{user}" },

            // Bloglar / Yazı
            { "WordPress", "https://{user}.wordpress.com" },
            { "Blogger", "https://{user}.blogspot.com" },
            { "Ghost", "https://{user}.ghost.io" },
            { "Write.as", "https://write.as/{user}" },
            { "Substack", "https://{user}.substack.com" },

            // Müzik / Sanat
            { "SoundCloud", "https://soundcloud.com/{user}" },
            { "Mixcloud", "https://www.mixcloud.com/{user}/" },
            { "Bandcamp", "https://bandcamp.com/{user}" },
            { "Spotify", "https://open.spotify.com/user/{user}" },
            { "Shazam", "https://www.shazam.com/artist/{user}" },
            { "Last.fm", "https://www.last.fm/user/{user}" },

            // Diğer Popüler
            { "About.me", "https://about.me/{user}" },
            { "RebelMouse", "https://www.rebelmouse.com/{user}" },
            { "Scribd", "https://www.scribd.com/{user}" },
            { "Slideshare", "https://www.slideshare.net/{user}" },
            { "Imgur", "https://imgur.com/user/{user}" },
            { "Giphy", "https://giphy.com/{user}" },
            { "Couchsurfing", "https://www.couchsurfing.com/people/{user}" },
            { "HubPages", "https://hubpages.com/@{user}" },
            { "Quora", "https://www.quora.com/profile/{user}" },
            { "Voat", "https://voat.co/user/{user}" },
            { "8kun", "https://8kun.top/{user}" },

            // Türkiye / Yerel
            { "Ekşi Sözlük", "https://eksisozluk.com/biri/{user}" },
            { "DonanımHaber", "https://forum.donanimhaber.com/m_anasayfa?user={user}" },
            { "KizlarSoruyor", "https://www.kizlarsoruyor.com/kisi/{user}" },

            // Web 3 / Kripto
            { "OpenSea", "https://opensea.io/{user}" },
            { "Rarible", "https://rarible.com/{user}" },

            // Bilim / Akademik
            { "ResearchGate", "https://www.researchgate.net/profile/{user}" },
            { "Academia", "https://independent.academia.edu/{user}" },
            { "ORCID", "https://orcid.org/{user}" },
        };

        bool uyari = true;

        private async void bulBtn_Click(object sender, EventArgs e)
        {
            string input = usernameTxt.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Lütfen bir kullanıcı adı girin.");
                return;
            }

            sonuclarLB.Items.Clear();
            progressBar1.Value = 0;
            bulBtn.Enabled = false;

            // Varyasyonları hazırla (boşluksuz, alt çizgi, nokta)
            List<string> variations = new List<string>();
            if (input.Contains(" "))
            {
                string[] separators = { "", "_", "." };
                foreach (string sep in separators)
                {
                    variations.Add(string.Join(sep, input.Split(' ')));
                }
            }
            else
            {
                variations.Add(input);
            }

            // Parçaları hazırla (eğer boşluk varsa)
            string[] parts = input.Contains(" ") ? input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries) : new string[] { };

            int totalSites = _sites.Count;
            int totalChecks = (variations.Count * totalSites) + (parts.Length * totalSites);
            int current = 0;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.TryParseAdd(
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36"
                );
                client.Timeout = TimeSpan.FromSeconds(10);

                foreach (var site in _sites)
                {
                    bool anyFound = false; // parçalara geçiş için

                    // 1. TÜM VARYASYONLARI DENE (break yok, hepsini dene)
                    foreach (string variant in variations)
                    {
                        string url = site.Value.Replace("{user}", variant);
                        bool exists = await CheckSiteAsync(client, site.Key, url);
                        current++;
                        progressBar1.Value = (current * 100) / totalChecks;

                        if (exists)
                        {
                            sonuclarLB.Items.Add($"{site.Key}: {url}");
                            anyFound = true; // en az biri bulundu
                        }
                    }

                    // 2. Eğer hiçbir varyasyon bulunamadıysa, parçaları dene
                    if (!anyFound && parts.Length > 0)
                    {
                        foreach (string part in parts)
                        {
                            if (string.IsNullOrWhiteSpace(part) || part.Length < 2) continue;
                            string url = site.Value.Replace("{user}", part);
                            bool exists = await CheckSiteAsync(client, site.Key, url);
                            current++;
                            progressBar1.Value = (current * 100) / totalChecks;

                            if (exists)
                            {
                                sonuclarLB.Items.Add($"{site.Key}: {url}");
                            }
                        }
                    }
                }
            }

            bulBtn.Enabled = true;
            MessageBox.Show("Tarama tamamlandı");
            if (uyari)
            {
                MessageBox.Show("Kutudaki öğelere tıklayarak hesapları kontrol edebilirsiniz...");
                uyari = false;
            }
            progressBar1.Value = 100;
        }

        // Yardımcı metot: siteyi kontrol et
        private async Task<bool> CheckSiteAsync(HttpClient client, string siteName, string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                // Instagram özel: 200, 301, 302, 303, 307, 308 kabul et
                if (siteName == "Instagram")
                {
                    var status = response.StatusCode;
                    if (status == HttpStatusCode.OK ||
                        status == HttpStatusCode.MovedPermanently ||
                        status == HttpStatusCode.Redirect ||
                        status == HttpStatusCode.RedirectMethod ||
                        status == HttpStatusCode.TemporaryRedirect ||
                        (int)status == 308) // PermanentRedirect
                    {
                        return true;
                    }
                    return false;
                }

                // Diğer siteler için: sadece 200 OK ve içerik kontrolü
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    string contentLower = content.ToLowerInvariant();

                    bool notFound = false;
                    if (contentLower.Contains("page not found") ||
                        contentLower.Contains("couldn't find") ||
                        contentLower.Contains("not found") ||
                        contentLower.Contains("no user") ||
                        contentLower.Contains("bu sayfa mevcut değil") ||
                        contentLower.Contains("kullanıcı bulunamadı") ||
                        contentLower.Contains("sorry, this page isn't available") ||
                        contentLower.Contains("üzgünüz, bu sayfaya ulaşılamıyor") ||
                        contentLower.Contains("this account doesn’t exist") ||
                        contentLower.Contains("user not found") ||
                        contentLower.Contains("sayfa bulunamadı") ||
                        contentLower.Contains("ne yazık ki reddit’teki kimse bu adı kullanmıyor") ||
                        contentLower.Contains("we could not find the page"))
                    {
                        notFound = true;
                    }

                    return !notFound;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        // ListBox çift tıklama
        private void SonuclarLB_DoubleClick(object sender, EventArgs e)
        {
            if (sonuclarLB.SelectedItem != null)
            {
                string item = sonuclarLB.SelectedItem.ToString();
                int colonIndex = item.IndexOf(':');
                if (colonIndex != -1 && colonIndex < item.Length - 1)
                {
                    string url = item.Substring(colonIndex + 1).Trim();
                    if (!string.IsNullOrEmpty(url))
                    {
                        Process.Start(url);
                    }
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.Width != _originalWidth)
                this.Width = _originalWidth;
        }
    }
}