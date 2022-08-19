using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppAdoNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDAL productDAL = new ProductDAL(); // veritabanı işlemlerinin olduğu sınıfı tanımladık
        private void dgvUrunler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //FromChildHandle ön yüzdeki 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //dgvUrunler.DataSource = productDAL.GetAll(); // form ön yüzdeki dggvUrunler 
            dgvUrunler.DataSource = productDAL.GetAllDataTable(); // data table ile yaptığımız veri cekme metodu
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Product product = new Product(); // boş bir product nesnesi oluşturduk
            product.StokMiktari = Convert.ToInt32(txtStokMiktari.Text);
            product.UrunAdi = txtUrunAdi.Text;
            product.UrunFiyati = Convert.ToDecimal(txtUrunFiyati.Text);
            var islemSonucu = productDAL.Add(product); // Add metoduna product ı eklemesi için gönderdik

            if (islemSonucu > 0)
            {
                dgvUrunler.DataSource = productDAL.GetAllDataTable(); // Data grid view da eklenen son kaydı da görebilmek için
                MessageBox.Show("Kayıt Başarılı");
            }
            else MessageBox.Show("Kayıt Başarısız");
        }
    }
}
