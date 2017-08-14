using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PiGRAPH
{   
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PiGRAPH_CLS x = new PiGRAPH_CLS();
            Graph_map g = new Graph_map();
                g.width = Convert.ToInt32(numericUpDown1.Value); g.height = Convert.ToInt32(numericUpDown2.Value);
                g.text = textBox1.Text;
                if (! Local.gm.BG_color.IsEmpty) g.BG_color = Local.gm.BG_color; else g.BG_color = Color.Gray;
                if (! Local.gm.FG_color.IsEmpty) g.FG_color = Local.gm.FG_color; else g.FG_color = Color.DarkBlue;
            pictureBox1.Image = x.Generate_Grph("PiGRAPH v.1.201708xx Developed by Michael B.Khany",g);
            Form1.ActiveForm.Text += "|";
            //MessageBox.Show("Completed.");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Local.gm.FG_color = colorDialog1.Color;
                panel1.BackColor = Local.gm.FG_color;
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Local.gm.BG_color = colorDialog1.Color;
                panel2.BackColor = Local.gm.BG_color;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
        }
    }

    static class Local
    {
        public static Graph_map gm = new Graph_map();
    }
}
