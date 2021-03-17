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
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public decimal Precio { get; set; }
        [DataMember]
        public Int16 Estado { get; set; }
        [DataMember]
        public int Descuento { get; set; }
        [DataMember]
        public DateTime FechaCreacion { get; set; }
        [DataMember]
        public int idCategoria { get; set; }
        [DataMember]
        public string PathImagen { get; set; }
    }
}
