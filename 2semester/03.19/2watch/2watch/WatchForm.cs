using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2watch
{
    public partial class WatchForm : Form
    {
        public WatchForm()
        {
            InitializeComponent();
        }

        private void TimerTick(object sender, EventArgs e)
        {
              this.label1.Text = string.Format("{0:H:mm:ss}", DateTime.Now);
        }

        private void WatchForm_Load(object sender, EventArgs e)
        {

        }
    }
}
