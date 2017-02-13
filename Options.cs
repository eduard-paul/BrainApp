using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Threading;

namespace BrainApp
{
    public partial class Options : Form
    {
        ArrayList centers;

        public Options(ref ArrayList a)
        {
            InitializeComponent();

            centers = a;

            foreach (Point3D p in a) {
                checkedListBox1.Items.Add(p.ToString());
                checkedListBox1.SetItemChecked(checkedListBox1.Items.Count-1, true);
            }
            if (!checkedListBox1.Items.Contains("340 210 150"))
                checkedListBox1.Items.Add("340 210 150"); //Left temporal lobe
            if (!checkedListBox1.Items.Contains("160 210 150"))
                checkedListBox1.Items.Add("160 210 150"); //Right temporal lobe
            if (!checkedListBox1.Items.Contains("250 160 250"))
                checkedListBox1.Items.Add("250 160 250"); //Frontal lobe
        }

        private void button1_Click(object sender, EventArgs e)
        {
            centers.Clear();
            foreach (Object o in checkedListBox1.CheckedItems)
            {
                centers.Add(new Point3D(o.ToString()));
            }
        }

        private void checkedListBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                checkedListBox1.Items.Remove(checkedListBox1.SelectedItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String s = tbX.Text + " " + tbY.Text + " " + tbZ.Text;
            if (!checkedListBox1.Items.Contains(s))
                checkedListBox1.Items.Add(s);
        }
    }
}
