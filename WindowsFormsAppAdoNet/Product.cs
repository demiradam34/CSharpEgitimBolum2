using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppAdoNet
{
    public class Product
    {
        public int Id { get; set; }
        public string UrunuAdi { get; set; }    
        public decimal UrunFiyati { get; set; }
        public int StokMiktari { get; set; }

        internal object GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
