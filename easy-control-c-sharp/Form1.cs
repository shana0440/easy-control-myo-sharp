using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace easy_control_c_sharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MyoController controller = new MyoController();
        }
    }
}
