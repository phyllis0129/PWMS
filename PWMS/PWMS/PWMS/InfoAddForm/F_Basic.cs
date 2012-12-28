using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PWMS.InfoAddForm
{
    public partial class F_Basic : Form
    {
        public F_Basic()
        {
            InitializeComponent();
        }

        DataClass.MyMeans mymeans = new PWMS.DataClass.MyMeans();

    }
}
