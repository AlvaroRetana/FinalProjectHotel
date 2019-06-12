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
    public class Habitacion
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

        private string _nombre;

        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private int _numero;

        public int numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        private string _descripcion;

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _imagen;

        public string imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }

        private string _disponibilidad;

        public string disponibilidad
        {
            get { return _disponibilidad; }
            set { _disponibilidad = value; }
        }

        private int _id_precio;

        public int id_precio
        {
            get { return _id_precio; }
            set { _id_precio = value; }
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
        public DataSet lista_habitaciones()
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
                sql = "usp_consulta_habitaciones";
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

        public void datos_habitacion(int ID)
        {
            conexion = cls_DAL.trae_conexion("H-Mandiola", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
            }
            else
            {
                sql = "usp_info_habitacion";
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
                        _nombre = ds.Tables[0].Rows[0]["Nombre"].ToString();
                        _numero = Convert.ToInt32(ds.Tables[0].Rows[0]["Numero"]);
                        _descripcion = ds.Tables[0].Rows[0]["Descripcion"].ToString();
                        _imagen= ds.Tables[0].Rows[0]["Imagen"].ToString();
                        _disponibilidad = ds.Tables[0].Rows[0]["Disponibilidad"].ToString();
                        _id_precio = Convert.ToInt32(ds.Tables[0].Rows[0]["ID_Precio"]);
                    }
                    else
                    {
                        _descripcion = "Error";
                        _num_error = numero_error;
                        _mensaje = mensaje_error;
                    }
                }
            }
        }


        public void agregar_habitacion()
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
              
                ParamStruct[] parametros = new ParamStruct[7];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@ID_Consecutivo", SqlDbType.Int, _id_consecutivo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nombre", SqlDbType.VarChar, _nombre);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Numero", SqlDbType.Int, _numero);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Descripcion", SqlDbType.VarChar, _descripcion);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Imagen", SqlDbType.VarChar, _imagen);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Disponibilidad", SqlDbType.VarChar, _disponibilidad);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@ID_Precio", SqlDbType.Int, _id_precio);

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
                    bitacora.descripcion = "Se insertó un nuevo elemento en la tabla Habitacion";
                    bitacora.detalle = "Datos insertados, ID Consecutivo: " +id_consecutivo+", Nombre: "+nombre+", Número: "+numero+", Descripción: "+descripcion + ", Imagen: " +imagen + ", Disponibilidad: " +disponibilidad + ", ID Precio: " +id_precio;
                    bitacora.agregar_bitacora();
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                    
                }
            }
        }

        public void modifica_habitacion()
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
               
             
                ParamStruct[] parametros = new ParamStruct[8];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@ID", SqlDbType.Int, _id);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@ID_Consecutivo", SqlDbType.Int, _id_consecutivo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Nombre", SqlDbType.VarChar, _nombre);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Numero", SqlDbType.Int, _numero);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Descripcion", SqlDbType.VarChar, _descripcion);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Imagen", SqlDbType.VarChar, _imagen);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Disponibilidad", SqlDbType.VarChar, _disponibilidad);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@ID_Precio", SqlDbType.Int, _id_precio);
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
                    bitacora.descripcion = "Se actualizó un elemento en la tabla Habitacion con ID: "+_id;
                    bitacora.detalle = "Datos insertados, ID Consecutivo: " + id_consecutivo + ", Nombre: " + nombre + ", Número: " + numero + ", Descripción: " + descripcion + ", Imagen: " + imagen + ", Disponibilidad: " + disponibilidad + ", ID Precio: " + id_precio;
                    bitacora.agregar_bitacora();
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                
                }
            }
        }


        #endregion
    }
}
