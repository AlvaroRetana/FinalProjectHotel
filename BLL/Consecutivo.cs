 using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Diagnostics;


namespace BLL
{
    public class Consecutivo
    {
        #region propiedades
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _consecutivo;

        public int consecutivo
        {
            get { return _consecutivo; }
            set { _consecutivo = value; }
        }

        private string _descripcion;

        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _prefijo;

        public string prefijo
        {
            get { return _prefijo; }
            set { _prefijo = value; }
        }

        private int _rango_inicial;

        public int rango_inicial
        {
            get { return _rango_inicial; }
            set { _rango_inicial = value; }
        }

        private int _rango_final;

        public int rango_final
        {
            get { return _rango_final; }
            set { _rango_final = value; }
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
        public DataSet lista_consecutivos()
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
                sql = "usp_consulta_consecutivos";
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

        public void datos_consecutivo(int ID)
        {
            conexion = cls_DAL.trae_conexion("H-Mandiola", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
            }
            else
            {
                sql = "usp_info_consecutivo";
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
                        _consecutivo = Convert.ToInt32(ds.Tables[0].Rows[0]["Consecutivo"]);
                        _descripcion = ds.Tables[0].Rows[0]["Descripcion"].ToString();
                        _prefijo = ds.Tables[0].Rows[0]["Prefijo"].ToString();
                        _rango_inicial = Convert.ToInt32(ds.Tables[0].Rows[0]["Rango_inicial"]);
                        _rango_inicial = Convert.ToInt32(ds.Tables[0].Rows[0]["Rango_final"]);
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

        public void numero_consecutivo(int consecutivo)
        {
            conexion = cls_DAL.trae_conexion("H-Mandiola", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
            }
            else
            {
                sql = "usp_numero_consecutivo";
                ParamStruct[] parametros = new ParamStruct[1];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Consecutivo", SqlDbType.Int, consecutivo);
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
                        
                      
                  
                    }
                    else
                    {
                 
                        _num_error = numero_error;
                        _mensaje = mensaje_error;
                    }
                }
            }
        }

        public void agregar_consecutivo()
        {
            conexion = cls_DAL.trae_conexion("H-Mandiola", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
               
            }
            else
            {
                    sql = "usp_inserta_consecutivo";
              
                ParamStruct[] parametros = new ParamStruct[5];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@Consecutivo", SqlDbType.Int, _consecutivo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Descripcion", SqlDbType.VarChar, _descripcion);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Prefijo", SqlDbType.VarChar, _prefijo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Rango_inicial", SqlDbType.Int, _rango_inicial);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Rango_final", SqlDbType.Int, _rango_final);
                cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
                cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
              
            }
        }

        public void modifica_consecutivo()
        {
            conexion = cls_DAL.trae_conexion("H-Mandiola", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
               
            }
            else
            {
                    sql = "usp_modifica_consecutivo";
               
             
                ParamStruct[] parametros = new ParamStruct[6];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@ID", SqlDbType.Int, _id);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Consecutivo", SqlDbType.Int, _consecutivo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Descripcion", SqlDbType.VarChar, _descripcion);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Prefijo", SqlDbType.VarChar, _prefijo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Rango_inicial", SqlDbType.Int, _rango_inicial);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Rango_final", SqlDbType.Int, _rango_final);
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
                    bitacora.descripcion = "Se actualizó un elemento en la tabla Consecutivo con ID: "+_id;
                    bitacora.detalle = "Datos insertados, Consecutivo: " + consecutivo + ", Prefijo: " + prefijo + ", Rango inicial: " + rango_inicial + ", Rango final: " + rango_final;
                    bitacora.agregar_bitacora();
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                
                }
            }
        }


        #endregion
    }
}
