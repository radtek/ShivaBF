using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.PrintingMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.printBarcodes();
        }

        /// <summary>
        /// https://www.codeproject.com/Questions/694097/How-to-Generate-a-Bar-Code-for-Items-and-Print-usi
        /// </summary>
        /// <param name="parameters"></param>
        public void printBarcodes(dynamic parameters = null)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                // Set the printer name. 
                //pd.PrinterSettings.PrinterName = "file://ns5/hpoffice";
                //pd.PrinterSettings.PrinterName = "Zebra New GK420t"               
                pd.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            // Create a private font collection
            PrivateFontCollection pfc = new PrivateFontCollection();

            // Load in the temporary barcode font     
            string current_path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var delmon_folder = System.IO.Path.GetDirectoryName(current_path);
            var base_path = System.IO.Path.Combine(delmon_folder, "fonts");

            pfc.AddFontFile(System.IO.Path.Combine(base_path, "code128.ttf"));
            pfc.AddFontFile(System.IO.Path.Combine(base_path, "free3of9.ttf"));
            pfc.AddFontFile(System.IO.Path.Combine(base_path, "fre3of9x.ttf"));
            pfc.AddFontFile(System.IO.Path.Combine(base_path, "IDAutomationHC39M.ttf"));


            // Select the font family to use
            var families = pfc.Families;

            FontFamily family_Code128 = new FontFamily("Code 128", pfc);
            FontFamily family_Free3of9 = new FontFamily("Free 3 of 9", pfc);
            FontFamily family_Free3of9Extended = new FontFamily("Free 3 of 9 Extended", pfc);
            FontFamily family_IDAutomationHC39M = new FontFamily("IDAutomationHC39M", pfc);


            // Create the font object with size 30
            Font f128 = new Font(family_Code128, 30);
            Font f3of9 = new Font(family_Free3of9, 30);
            Font f3of9ex = new Font(family_Free3of9Extended, 30);
            Font f39m = new Font(family_IDAutomationHC39M, 20);

            //With this easy way, you get a font object mapp
            SolidBrush br = new SolidBrush(Color.Black);


            for (int i = 0; i < 1; i++)
            {
                var lintCollection = GetRandomInteger(10);
                var barcode = string.Join("", lintCollection);

                ev.Graphics.DrawString("*" + barcode + "*", f39m, br, 10, 85);
            }


        }

        private static IEnumerable<int> GetRandomInteger(int count = 1)
        {
            List<int> collection = new List<int>();

            for (int i = 0; i < count; i++)
            {
                start:
                Random randm = new Random();
                int randDigit = randm.Next(0, 9);
                if (!collection.Contains(randDigit))
                {
                    collection.Add(randDigit);
                }
                else
                {
                    goto start;
                }
            }
            return collection;
        }
    }
}
