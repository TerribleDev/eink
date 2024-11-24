using System.Drawing;
using System.Reflection;
using CommandLine;
using Waveshare;
using Waveshare.Devices;

namespace TerribleDev.EInk.UI;

class Program
{
    public class Options
    {
        [Option('v', "version", Required = false, HelpText = "Version of eink display")]
        public string Version { get; set; }
    }
    static async Task Main(string[] args)
    {
        string currentTime = DateTime.Now.ToString("hh:mm:ss tt"); // Format as needed

        // 2. Create Bitmap
        int width = 800;
        int height = 480;
        Bitmap bmp = new Bitmap(width, height);

        // 3. Draw Time on Bitmap
        using (Graphics g = Graphics.FromImage(bmp))
        {
            Console.WriteLine("Welcome to TerribleDev.EInk!");
            g.Clear(Color.White);
            Font font = new Font("Arial", 12, FontStyle.Regular);
            Brush brush = Brushes.Black;
            g.DrawString(currentTime, font, brush, 200, 400);
            Console.WriteLine("Initializing display...");
            using var ePaperDisplay = EPaperDisplay.Create(EPaperDisplayType.WaveShare7In5Bc);
            Console.WriteLine("Drawing image");
            g.DrawImageUnscaled(bmp, 0, 0);
            ePaperDisplay.Clear();
            ePaperDisplay.WaitUntilReady();
            ePaperDisplay.DisplayImage(bmp);
            
        }



        
    }
}
