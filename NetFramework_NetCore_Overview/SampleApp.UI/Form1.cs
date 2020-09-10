using SampleApp.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleApp.UI
{
    public partial class Form1 : Form
    {
        private GeoDBContext context = new GeoDBContext();
        
        public Form1()
        {
            InitializeComponent();
        }


        IList<Continent> LoadContinents ()
        {
            return context.Continents.ToList();
        }

        void LoadContries (Continent continent)
        {

            if (continent.Countries.Count != 0)
            {
                bsCountries.DataSource = continent.Countries.ToList();
                dgvCountries.DataSource = bsCountries;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvCountries.AutoGenerateColumns = true;

            this.bsContinents.DataSource = LoadContinents();
            this.comboBox1.DataSource = bsContinents;
            this.comboBox1.DisplayMember = "Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddContinentFrm frm = new AddContinentFrm();
            frm.ShowDialog();


            LoadContinents();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Continent continent1 = (Continent)comboBox1.SelectedItem;

            LoadContries(continent1);
        }

        private void countryHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Continent continent = (Continent)comboBox1.SelectedItem;

            AddCountryFrm addCountryFrm = new AddCountryFrm();
            addCountryFrm.SelectedContinent = continent;

            addCountryFrm.ShowDialog();

            context = new GeoDBContext();
            
            
            LoadContries(context.Continents.Find(continent.Id));
        }
    }
}
