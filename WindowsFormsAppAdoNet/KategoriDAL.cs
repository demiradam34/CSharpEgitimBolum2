using System;
using System.Collections.Generic;
using System.Data; // Veritabanı işlemleri için gerekli
using System.Data.SqlClient; // Adonet kütüphaneleri

namespace WindowsFormsAppAdoNet
{
    public class KategoriDAL
    {
        SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB; database=UrunYonetimiAdoNet; integrated security=true");

        void ConnectionKontrol()
        {
            if (connection.State == ConnectionState.Closed) // Eğer yukarda tanımladığımız veritabanı bağlantısı kapalıysa
            {
                connection.Open();// bağlantıyı aç

            }

        }
        public DataTable GetAllDataTable()
        {
            ConnectionKontrol(); //bağlantıyı kontrol et
            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand("select * from Kategoriler", connection);
            SqlDataReader reader = command.ExecuteReader();
            dt.Load(reader); // dt tablosuna reader ile veritabanından okunan verileri yükle
            reader.Close(); // veri okuyuvuyu kapat
            command.Dispose(); // sql komut nesnesini kapat
            connection.Close(); // veritabanı bağlantısını kapat
            return dt; // metodun çağırıldığı yere dt(data tablosunu) gönder.

        }

        public int Add(Kategori kategori)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Insert into Kategoriler (KategoriAdi,Durum) values (@KategoriAdi, @Durum)", connection); // Sql komutu olarak bu sefer insert komutu yazdık
            command.Parameters.AddWithValue("@KategoriAdi", kategori.KategoriAdi);
            command.Parameters.AddWithValue("@Durum", kategori.Durum);
            
            int islemSonucu = command.ExecuteNonQuery(); // ExecuteNonQuery metodu geriye veritabanında etkilenen kayıt sayısını döner
            command.Dispose(); // SQL KOMUT NESNESİNİ KAPAT
            connection.Close(); // veritabanı bağlantısını kapat
            return islemSonucu; // Metodumuz geriye int döndüğü için islemSonucu değişkenını geri dönüyoruz 


        }

        public Kategori Get(string id)


        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("select * from Kategoriler where Id = " + id, connection);
            SqlDataReader reader = command.ExecuteReader();
            Kategori kategori = new Kategori();

            while (reader.Read())
            {
                kategori.Id = Convert.ToInt32(reader["Id"]);
                kategori.KategoriAdi = reader["KategoriAdi"].ToString();
                kategori.Durum = Convert.ToBoolean(reader["Durum"]);
            }

            reader.Close(); // Veri okuyucuyu kapat
            command.Dispose(); // sql komut nesnesini kapat
            connection.Close(); // veritabanı bağlanısını kapat


            return kategori;
        }
        public int Update(Kategori kategori)
        {
            ConnectionKontrol();
            SqlCommand command = new SqlCommand("Update Kategoriler set KategoriAdi= @KategoriAdi=@KategoriAdi, Durum=@Durum where Id=@id", connection); // Sql komutu olarak bu sefer insert komutu yazdık
            command.Parameters.AddWithValue("@KategoriAdi", kategori.KategoriAdi);
            command.Parameters.AddWithValue("@Durum", kategori.Durum);
            command.Parameters.AddWithValue("@id", kategori.Id);

            int islemSonucu = command.ExecuteNonQuery(); // ExecuteNonQuery metodu geriye veritabanında etkilenen kayıt sayısını döner
            command.Dispose(); // SQL KOMUT NESNESİNİ KAPAT
            connection.Close(); // veritabanı bağlantısını kapat
            return islemSonucu; // Metodumuz geriye int döndüğü için islemSonucu değişkenını geri dönüyoruz 


        }
        public int Delete(string id)
        {
            ConnectionKontrol();

            SqlCommand command = new SqlCommand("Delete from Kategoriler  where Id=@Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            int islemSonucu = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return islemSonucu;

        }


    }

}
