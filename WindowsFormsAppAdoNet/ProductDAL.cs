using System;
using System.Collections.Generic;
using System.Linq;
using System.Data; // Veritabanı işlemleri için gerekli
using System.Data.SqlClient; // adonet kütüphaneleri

namespace WindowsFormsAppAdoNet
{
    public class ProductDAL
    {
        SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; database=UrunYonetimiAdoNet; integrated security=true"); // SqlConnection veritabanına bağlamak için kullandığımız ado net sınıfıdır. Parametre olarak kendisine verilen bilgilerdeki veritabanına bağlanır.
        void ConnectionKontrol() // void = tek
        {
            if (connection.State == ConnectionState.Closed) // eğer yukarda tanımladığımız veritabanı bağlantısı kapalıysa
            {
                connection.Open(); // bağlantıyı aç

            }
        }
        public List<Product> GetAll() // bu metodun geri dönüş değeri List<Product> yani ürün listesidir
        {
            ConnectionKontrol(); // metot çalıştığı anda bağlantıyı kontrol et
            List<Product> urunListesi = new List<Product>(); // geriye döndüreceğimiz LİST<Product> nesnesini oluşturduk

            SqlCommand command = new SqlCommand("select * from Products", connection); // sqlCommand sql komutlarını çalıştırabilmemizi sağlayan ado net sınıfı. Tırnaklar içerisine sql komutumuzu, sonraki parametrede de bu komutun çalıştırılacağı connection nesnesini belirtiyoruz.
            SqlDataReader reander = command.ExecuteReader(); // sqlDataReader Sql veri okuyucu sınıfıdır, bu sınıfa üstteki command nesnesini ExecuteReader metoduyla çalıştırmasını söyledik.
            while (reader.Read()) // reader db de okuyacak kayıt bulduğu sürece
            {
                Product product = new Product();
                {
                    IDataAdapter = Convert.ToInt32(DataTableReader["Id"]),;
                    Id = Convert.ToInt32(reader["Id"]),
                        UrunAdi = DataTableReader["UrunAdi"].ToString(),
                        StokMiktari = Convert.ToInt32(Reader["StokMiktari"]),
                        UrunFiyati = Convert.ToDecimal(reader["UrunFiyati"])
                };
                urunListesi.Add(product); // içi doldurulan produst nesnesini yukarda oluşturduğumuz products listesine ekliyoruz
            }
            DataTableReader.ReferenceEqualsClose(); 
            return products;
        }
    }
}
