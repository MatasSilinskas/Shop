using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace Shop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            var testImagePath = @"..\..\iki.jpg";

            try
            {
                using (var engine = new TesseractEngine(@"..\..\..\", "lit", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(testImagePath))
                    {
                        using (var page = engine.Process(img))
                        {
                            var text = page.GetText();
                            textBox1.Text = text;
                        }
                    }
                }
            }
            catch (Exception e)
            {
              //  Trace.TraceError(e.ToString());
               // Console.WriteLine("Unexpected Error: " + e.Message);
             //   Console.WriteLine("Details: ");
              //  Console.WriteLine(e.ToString());
            }
            //Console.Write("Press any key to continue . . . ");
            //Console.ReadKey(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
