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
    public class Cliente
    {
        #region propiedades

        private string _id_consecutivo;

        public string id_consecutivo
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

        private string _apellido1;

        public string apellido1
        {
            get { return _apellido1; }
            set { _apellido1 = value; }
        }

        private string _apellido2;

        public string apellido2
        {
            get { return _apellido2; }
            set { _apellido2 = value; }
        }


        private string _correo;

        public string correo
        {
            get { return _correo; }
            set { _correo = value; }
        }


        private string _password;

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }


        private string _telefono;

        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }


        private string _activo;

        public string activo
        {
            get { return _activo; }
            set { _activo = value; }
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
        public DataSet lista_clientes()
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
                sql = "usp_consulta_clientes";
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

        public void datos_cliente(int ID)
        {
            conexion = cls_DAL.trae_conexion("H-Mandiola", ref mensaje_error, ref numero_error);
            if (conexion == null)
            {
                //insertar en la table de errores
                HttpContext.Current.Response.Redirect("Error.aspx?error=" + numero_error.ToString() + "&men=" + mensaje_error);
            }
            else
            {
                sql = "usp_info_cliente";
                ParamStruct[] parametros = new ParamStruct[1];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@ID_Consecutivo", SqlDbType.Int, ID);
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
                     
                        _id_consecutivo = ds.Tables[0].Rows[0]["ID_Consecutivo"].ToString();
                        _nombre = ds.Tables[0].Rows[0]["Nombre"].ToString();
                        _apellido1 = ds.Tables[0].Rows[0]["Apellido1"].ToString();
                        _apellido2 = ds.Tables[0].Rows[0]["Apellido2"].ToString();
                        _correo = ds.Tables[0].Rows[0]["Correo"].ToString();
                        _password = ds.Tables[0].Rows[0]["Password"].ToString();
                        _telefono = ds.Tables[0].Rows[0]["Telefono"].ToString();
                        _activo = ds.Tables[0].Rows[0]["Activo"].ToString();

                    }
                    else
                    {
                        _num_error = numero_error;
                        _mensaje = mensaje_error;
                    }
                }
            }
        }

        public void agregar_cliente()
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
              
                ParamStruct[] parametros = new ParamStruct[8];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@ID_Consecutivo", SqlDbType.VarChar, _id_consecutivo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nombre", SqlDbType.VarChar, _nombre);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Apellido1", SqlDbType.VarChar, _apellido1);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Apellido2", SqlDbType.VarChar, _apellido2);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Correo", SqlDbType.VarChar, _correo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Password", SqlDbType.VarChar, _password);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Telefono", SqlDbType.VarChar, _telefono);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Activo", SqlDbType.VarChar, _activo);

                cls_DAL.conectar(conexion, ref mensaje_error, ref numero_error);
                cls_DAL.ejecuta_sqlcommand(conexion, sql, true, parametros, ref mensaje_error, ref numero_error);
              
            }
        }

        public void modifica_cliente()
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
               
             
                ParamStruct[] parametros = new ParamStruct[8];
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 0, "@ID_Consecutivo", SqlDbType.VarChar, _id_consecutivo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 1, "@Nombre", SqlDbType.VarChar, _nombre);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 2, "@Apellido1", SqlDbType.VarChar, _apellido1);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 3, "@Apellido2", SqlDbType.VarChar, _apellido2);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 4, "@Correo", SqlDbType.VarChar, _correo);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 5, "@Password", SqlDbType.VarChar, _password);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 6, "@Telefono", SqlDbType.VarChar, _telefono);
                cls_DAL.agregar_datos_estructura_parametros(ref parametros, 7, "@Activo", SqlDbType.VarChar, _activo);
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
                    bitacora.descripcion = "Se actualizó un elemento en la tabla Consecutivo con ID: "+_id_consecutivo;
                    bitacora.detalle = "Datos insertados, Consecutivo: ";
                    bitacora.agregar_bitacora();
                    cls_DAL.desconectar(conexion, ref mensaje_error, ref numero_error);
                
                }
            }
        }


        #endregion
    }
}
