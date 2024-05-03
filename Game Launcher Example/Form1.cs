using Game_Launcher_Example.Properties;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Game_Launcher_Example
{
    public partial class Form1 : Form
    {
        Image[] imagesFirst = { Resources.robert_downey_jr_rdj };
        public Form1()
        {
            InitializeComponent();
        }

        // Addressen d�r alla filer laddas ner ifr�n
        // Till exempel baseUrl + "launchertest.manifest" laddar ner filen https://milice.se/tera-client/launchertest.manifst
        string baseUrl = "https://milice.se/tera-client/";

        // Dictionary som inneh�ller alla filer som kan laddas ner och deras SHA1 hash som kan anv�ndas f�r att verifiera all data i filen.
        // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-8.0
        Dictionary<string, string> manifest = new Dictionary<string, string>();

        // https://learn.microsoft.com/en-us/dotnet/api/system.net.webclient?view=net-8.0
        WebClient webClient = new WebClient();
        int downloaded = 0;
        int total = 0;
        void startDownload()
        {
            // Task.Run g�r s� att allt mellan () => {} k�rs i sin egen tr�d och inte avbryter saker som h�nder i f�nstret
            // Ofta vill man k�ra kod utanf�r f�nstrets tr�d s� att f�nstret inte laggar
            Task.Run(() =>
            {
                // Ladda ner launchertest manifest filen som inneh�ller filnamn och sha1 hashes
                string result = webClient.DownloadString(baseUrl + "launchertest.manifest");

                // Splitta upp stringen i rader
                string[] lines = result.Split('\n');

                // Loopa genom alla rader
                foreach (var line in lines)
                {
                    // Splitta upp varje rad i 2, filnamn i data[1] och sha1 hash i data[0]
                    // Om raden inte �r formaterad p� r�tt s�tt, hoppa �ver den.
                    string[] data = line.Split(':');
                    if (data.Length != 2)
                    {
                        continue;
                    }

                    // L�gg in filnamnet och hashen i en dictionary
                    manifest[data[1]] = data[0];
                }
                total = manifest.Count;
                webClient.DownloadFileCompleted += client_DownloadFileCompleted;
                webClient.DownloadProgressChanged += client_DownloadProgressChanged;
            

                // H�mta det f�rsta v�rdet fr�n en dictionary med namnet manifest
                // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.keyvaluepair-2?view=net-8.0

                KeyValuePair<string, string> file = manifest.First();
                
                string filename = file.Key;
                BeginInvoke((MethodInvoker)delegate
                {
                    labelFilename.Text = filename;
                    labelProgressTotal.Text = $"{downloaded} / {total}";
                    totalProgressBar.Maximum = total;
                });

              

                string directory = Path.GetDirectoryName(filename);
                if (directory != null && directory.Length > 0 && !Directory.Exists(filename))
                {
                    Directory.CreateDirectory(directory);
                }
                webClient.DownloadFileAsync(new Uri(baseUrl + filename), filename);
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startDownload();
            pictureBox1.Image = Resources.robert_downey_jr_rdj;
        }

        // Metod f�r att l�sa av hur mycket av en fil som har laddats ner
        // M�ste l�nkas till WebClient objektet f�r att fungera
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // BeginInvoke g�r s� att allt som k�rs innanf�r dess scope (mellan { och })
            // k�rs n�r f�nstret �r redo s� att programmet inte krashar n�r man f�rs�ker till exempel uppdatera en progressbar
            BeginInvoke((MethodInvoker)delegate
            {
                labelProgressFile.Text = $" {e.ProgressPercentage}%";
                barProgressFile.Value = e.ProgressPercentage;
            });
        }

        // Metod som k�rs n�r en fil har laddats ner
        // M�ste l�nkas till WebClient objektet f�r att fungera
        void client_DownloadFileCompleted(object? sender, AsyncCompletedEventArgs e)
        {
            // BeginInvoke g�r s� att allt som k�rs innanf�r dess scope (mellan { och })
            // k�rs n�r f�nstret �r redo s� att programmet inte krashar n�r man f�rs�ker till exempel uppdatera en progressbar
            BeginInvoke((MethodInvoker)delegate
            {
            manifest.Remove(manifest.First().Key);
                if (manifest.Count < 1)
                {
                    button1.Enabled = true;
                    labelFilename.Visible = false;
                    labelProgressFile.Visible = false;
                    labelProgressTotal.Visible = false;
                    barProgressFile.Visible = false;
                    totalProgressBar.Visible = false;
                    return;
                }
                KeyValuePair<string, string> file = manifest.First();

                string filename = file.Key;

                labelFilename.Text = filename;
                labelProgressTotal.Text = $"{++downloaded} / {total}";
                totalProgressBar.Value = downloaded;
                string directory = Path.GetDirectoryName(filename);
                if (directory != null && directory.Length > 0 && !Directory.Exists(filename))
                {
                    Directory.CreateDirectory(directory);
                }
                webClient.DownloadFileAsync(new Uri(baseUrl + filename), filename);
            });
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://www.google.com/search?sca_esv=f977441fd745688c&sxsrf=ACQVn0-jNlMHE0k3tsvlWwoDzlC-QIMT0w:1714657708078&q=grass&uds=AMwkrPtD2X8ne8wHcZUM2vdrxSzmLaMdxNSPQYf4TSU9lytPGjqfaq1d9MKjNv_Wxk3glucXiPLpDx5ly-4ite0r--Ac8lG9T3qQRk1o456i-Rsvpi5cO2HSUnb-GHKc5tHX2qCc6OCZq3VA9kw_0J4qdXgf7psTOeMTYO92WmKMHOnpBl7P3dXEYE5lJF_WW9-Q0AeqqhL8D3GdWdUl_a6ArD2kfsZL8uuiqi5VlDMdtuqAZmDt-XoFgXqryZ6VP17hdgH-pJZ9&udm=2&prmd=ivnbz&sa=X&ved=2ahUKEwjnu-fcje-FAxXsIxAIHWXaBDQQtKgLegQIEhAB&biw=1280&bih=559&dpr=1.5";

            // Start the default browser with the URL
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open the browser: {ex.Message}");
            }
        }

    }
}
