using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SalesOfPharmacy
{
    public partial class fWait : Form
    {
        public fWait(String message)
        {
            InitializeComponent();
            lblWait.Text = message;
        }

        public void Do (Action act)
        {
            TimeSpan startTime = DateTime.Now.TimeOfDay;
            Thread oThread = new Thread(new ThreadStart(act));
            oThread.Start();
            while (!oThread.IsAlive) { this.Refresh(); };
            while (oThread.IsAlive) { this.Refresh(); };
            TimeSpan endTime = DateTime.Now.TimeOfDay;

            int workTime = int.Parse((endTime - startTime).Milliseconds.ToString());
            while (workTime <= 700)
            {
                this.Refresh();
                workTime++;
            }
        }
    }
}
