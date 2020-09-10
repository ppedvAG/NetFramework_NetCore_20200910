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
    public partial class AddCountryFrm : Form
    {
        public Continent SelectedContinent = null;


        public AddCountryFrm()
        {
            

            InitializeComponent();
        }

        private void AddCountryFrm_Load(object sender, EventArgs e)
        {
            if (SelectedContinent == null)
                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (GeoDBContext ctx = new GeoDBContext())
            {


                Country country = new Country();
                country.Id = Guid.NewGuid();
                country.Name = textBox1.Text;

                country.ContinentId = SelectedContinent.Id;
                //country.Continent = SelectedContinent;

                ctx.Countries.Add(country);

                ctx.SaveChanges();

                
            }

            this.Close();
        }
    }
}
