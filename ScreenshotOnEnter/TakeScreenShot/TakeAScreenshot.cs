using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ScreenshotOnEnter.TakeScreenShot
{
    public class TakeAScreenshot
    {
        public static void Capture(string filePath)
        { 
            Rectangle bounds = Screen.PrimaryScreen.Bounds;

            using Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
                
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
            }

            bitmap.Save(filePath, ImageFormat.Png);
        }
    }
}  