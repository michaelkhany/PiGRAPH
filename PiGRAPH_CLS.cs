using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiGRAPH
{
    class PiGRAPH_CLS
    {
        public Bitmap Generate_Grph(string input, Graph_map g)
        {
            Rectangle rect = new Rectangle(0, 0, g.width, g.height);//Screen.PrimaryScreen.Bounds;
            int color = Screen.PrimaryScreen.BitsPerPixel;
            PixelFormat pf;
            pf = PixelFormat.Format32bppArgb;
            Bitmap BM = new Bitmap(rect.Width, rect.Height, pf);

            //Parallel.For(0,BM.Width,i => {
            for (int i = 0; i < BM.Width; i++)
                //Parallel.For(0, BM.Height, j => {
                for (int j = 0; j < BM.Height; j++)
                    BM.SetPixel(i, j, g.BG_color);
            //});
            //});
            BM =Grphesize(Consts.DPi_f, g, BM);

            return BM;
        }

        private Bitmap Grphesize(string input, Graph_map g, Bitmap x)
        {
            int[] Wposes = { 1, 10, 20, 30, 40, 50, 60, 70, 80, 90, 99 };
            for (int i=0;i<Wposes.Length;i++)
                Wposes[i] =i*(x.Width/10);

            int t =Math.Min(x.Height,input.Length);
            for (int i = 0; i < t; i++)
                x.SetPixel(Wposes[Convert.ToInt32(input[i].ToString())], i, g.FG_color);

            return x;
        }

    }

}
