 using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;


namespace BLL
{
    public class Precio
    {
        #region propiedades
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _id_consecutivo;

        public int id_consecutivo
        {
            get { return _id_consecutivo; }
            set { _id_consecutivo = value; }
        }

        private string _tipo;

        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private int _precio;

        public int precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        private string _mensaje;

        public string mensaje
        {
            get { return _mensaje; }
            set { _mensaje = value; }
        }

        private int _num_error;

        public int num_error
        {
            get { return _num_error; }
            set { _num_error = value; }
        }
        #endregion

        #region variables privadas
        SqlConnection conexion;
        string mensaje_error;
        int numero_error;
        string sql;
        DataSet ds;
        #endregion

        #region metodos
        public DataSet lista_precios()
        {
            conexion = cls_DAL.trae_conexion("H-Mandiola", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                return null;
            }
            else
            {
                sql = "usp_consulta_precios";
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                    return null;
                }
                else
                {
                    return ds;
                }
            }

        }

        public void datos_precio(int ID)
        {
            conexion = cls_DAL.trae_conexion("H-Mandiola", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
            }
            else
            {
                sql = "usp_info_precio";
                ParamStruct[] parametros = new ParamStruct[1];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@ID", SqlDbType.Int, ID);
                ds = cls_DAL.ejecuta_dataset(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        _id = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
                        _id_consecutivo= Convert.ToInt32(ds.Tables[0].Rows[0]["ID_Consecutivo"]);
                        _tipo = ds.Tables[0].Rows[0]["Tipo"].ToString();
                        _precio = Convert.ToInt32(ds.Tables[0].Rows[0]["Precio"]);
                 
                    }
                    else
                    {
                        _num_error = numero_error;
                        _mensaje = mensaje_error;
                    }
                }
            }
        }


        public void agregar_precio()
        {
            conexion = cls_DAL.trae_conexion("H-Mandiola", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
               
            }
            else
            {
                    sql = "usp_inserta_habitacion";
              
                ParamStruct[] parametros = new ParamStruct[3];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@ID_Consecutivo", SqlDbType.Int, _id_consecutivo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Tipo", SqlDbType.VarChar, _tipo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Precio", SqlDbType.Int, _precio);


                cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
                cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
                if (numero_error != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                 
                }
                else
                {
                    Bitacora bitacora = new Bitacora();
                    bitacora.usuario = System.Web.HttpContext.Current.User.Identity.Name;
                    bitacora.codigo_registro = 1;
                    bitacora.tipo = "Agregar";
                    bitacora.descripcion = "Se insertó un nuevo elemento en la tabla Precio";
                    bitacora.detalle = "Datos insertados, ID Consecutivo: " + id_consecutivo + ", Tipo: " + tipo + ", Precio: " + precio;
                    bitacora.agregar_bitacora();
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    
                }
            }
        }

        public void modifica_precio()
        {
            conexion = cls_DAL.trae_conexion("H-Mandiola", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
               
            }
            else
            {
                    sql = "usp_modifica_habitacion";
               
             
                ParamStruct[] parametros = new ParamStruct[4];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@ID", SqlDbType.Int, _id);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@ID_Consecutivo", SqlDbType.Int, _id_consecutivo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Tipo", SqlDbType.VarChar, _tipo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Precio", SqlDbType.Int, _precio);
                cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
                cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);

                if (numero_error != 0)
                {
                    //insertar en la table de errores
                    HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                  
                }
                else
                {
                    Bitacora bitacora = new Bitacora();
                    bitacora.usuario = System.Web.HttpContext.Current.User.Identity.Name;
                    bitacora.codigo_registro = 1;
                    bitacora.tipo = "Modificar";
                    bitacora.descripcion = "Se actualizó un elemento en la tabla Precio con ID: "+_id;
                    bitacora.detalle = "Datos insertados, ID Consecutivo: " + id_consecutivo + ", Tipo: " + tipo + ", Precio: " + precio;
                    bitacora.agregar_bitacora();
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                
                }
            }
        }


        #endregion
    }
}
