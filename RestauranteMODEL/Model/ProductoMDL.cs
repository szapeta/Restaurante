using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RestauranteMODEL.Model
{
    [DataContract]
    [Serializable]
    public class ProductoMDL
    {
        [DataMember]
        public Int32 idProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public Int16 Estado { get; set; }
        public int Descuento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int idCategoria { get; set; }
        public string PathImagen { get; set; }
    }
}
