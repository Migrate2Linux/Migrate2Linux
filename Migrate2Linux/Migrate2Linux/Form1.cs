using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migrate2Linux
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Programs progs = new Programs();
            progs.getInstalledProgs(ProgramBox);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
