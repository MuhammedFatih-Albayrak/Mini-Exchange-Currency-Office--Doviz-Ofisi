using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Foreign_Currency_Office_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);

            //DOLAR
            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            //SelectSingleNode=Tek bir sütun seç.  innerXml=Seçilenleri xml olarak dolaralis a kaydet.
            LblDolarAl.Text = dolaralis;

            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            LblDolarSat.Text = dolarsatis;


            //EURO
            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            LblEuroAl.Text = euroalis;

            string eurosatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            LblEuroSat.Text = eurosatis;


            //STERLIN
            string sterlinalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteBuying").InnerXml;
            LblSterlinAl.Text = sterlinalis;

            string sterlinsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            LblSterlinSat.Text = sterlinsatis;



        }

        private void BtnDolarAl_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblDolarAl.Text;
        }

        private void BtnDolarSat_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblDolarSat.Text;
        }

        private void BtnEuroAl_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblEuroAl.Text;
        }

        private void BtnEuroSat_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblEuroSat.Text;
        }

        private void BtnSterlinAl_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblSterlinAl.Text;
        }

        private void BtnSterlinSat_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblSterlinSat.Text;
        }

        private void İşlem1_Click(object sender, EventArgs e)
        {
            
            double kur, miktar, tutar;
            kur = Convert.ToDouble(TxtKur.Text);
            miktar = Convert.ToDouble(TxtMiktar.Text);
            tutar = miktar * kur;
            TxtTutar.Text = tutar.ToString();
        }

        private void TxtKur_TextChanged(object sender, EventArgs e)
        {
            TxtKur.Text = TxtKur.Text.Replace(".", ",");
        }

        private void İşlem2_Click(object sender, EventArgs e)
        {
            // PARASI KADAR
            double kur = Convert.ToDouble(TxtKur.Text);
            int miktar = Convert.ToInt32(TxtMiktar.Text);
            int tutar = Convert.ToInt32(miktar / kur);
            TxtTutar.Text = tutar.ToString();
            double kalan = Convert.ToDouble(miktar % kur);
            TxtKalan.Text = kalan.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtKur.Text = "";
            TxtMiktar.Text = "";
            TxtTutar.Text = "";
            TxtKalan.Text = "";
            TxtKur.Focus();
        }
    }
}
