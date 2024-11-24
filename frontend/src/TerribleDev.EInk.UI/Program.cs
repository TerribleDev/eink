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
        await Parser.Default.ParseArguments<Options>(args)
            .WithParsedAsync<Options>(async o =>
            {
                var paperVersion = o.Version == "2"
                    ? EPaperDisplayType.WaveShare7In5_V2
                    : EPaperDisplayType.WaveShare7In5Bc;
                var dir = Assembly.GetExecutingAssembly().Location;
                var directory = Path.GetDirectoryName(dir);
                var img = "axe.bmp";
                var imgPath = Path.Combine(directory, img);
                using var bitmap = new Bitmap(Image.FromFile(imgPath, true));

                using var ePaperDisplay = EPaperDisplay.Create(EPaperDisplayType.WaveShare7In5Bc);
  
                ePaperDisplay.Clear();
                ePaperDisplay.WaitUntilReady();
                ePaperDisplay.DisplayImage(bitmap);
            });
    }
}
