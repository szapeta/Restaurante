using RestauranteMODEL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    
namespace RestauranteDATA
{
    public class ProductoDB : Access
    {
        public string ProductoDB_err { get; set; }
        public ProductoMDL prodModel = new ProductoMDL();
        public int op;


        public ProductoDB(ProductoMDL objProductoMDL)
        {
            prodModel = objProductoMDL;
        }

        public DataSet TODO(ref string errores)
        {
            DataSet resp = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RA_Producto_TODO";
                resp = Getds(cmd);
                if (!string.IsNullOrEmpty(strError))
                {
                    throw new Exception(strError);
                }
            }
            catch (Exception ex)
            {
                errores = ex.Message;
                ProductoDB_err = ex.Message;
                resp = null;
                throw;
            }
            return resp;
        }

        public bool AGREGAR_ACTUALIZAR(ref string errores)
        {
            bool resp = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RA_Producto_AGREGAR_ACTUALIZAR";
                cmd.Parameters.Add("@pTipoOP", SqlDbType.Int).Value = op;
                cmd.Parameters.Add("@pNombre", SqlDbType.VarChar, 50).Value = prodModel.Nombre;
                cmd.Parameters.Add("@pDescripcion", SqlDbType.VarChar, 200).Value = prodModel.Descripcion;
                cmd.Parameters.Add("@pPrecio", SqlDbType.Decimal).Value = prodModel.Precio;
                cmd.Parameters.Add("@pEstado", SqlDbType.Bit).Value = prodModel.Estado;
                cmd.Parameters.Add("@pDescuento", SqlDbType.Int).Value = prodModel.Descuento;
                cmd.Parameters.Add("@pFechaCreacion", SqlDbType.DateTime).Value = prodModel.FechaCreacion;
                cmd.Parameters.Add("@pidCategoria", SqlDbType.Int).Value = prodModel.idCategoria;
                cmd.Parameters.Add("@pPathImagen", SqlDbType.VarChar).Value = prodModel.PathImagen;

                resp = Exec(cmd);
                if (!string.IsNullOrEmpty(strError))
                {
                    throw new Exception(strError);
                }
            }
            catch (Exception ex)
            {
                errores = ex.Message;
                ProductoDB_err = ex.Message;
                resp = false;
                throw;
            }
            return resp;
        }

        
    }
}
