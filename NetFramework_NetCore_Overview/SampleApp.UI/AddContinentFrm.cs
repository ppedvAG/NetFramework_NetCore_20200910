using SampleApp.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleApp.UI
{
    public partial class AddContinentFrm : Form
    {
        public AddContinentFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (GeoDBContext ctx = new GeoDBContext())
            {
                Continent continent = new Continent();
                continent.Id = Guid.NewGuid();
                continent.Name = textBox1.Text;

                ctx.Continents.Add(continent); // alles auf Hald (das gleich bei löschungen und bearbeitungen von Datensätzen) 

                ctx.SaveChanges(); // Ab hier fliegt SQL zum Server


                this.Close();
            }
        }
    }
}
