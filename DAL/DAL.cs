using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration; //extrae cadena de conexion

namespace DAL


{
    public struct ParamStruct
    {
        public string Nombre_Parametro;
        public SqlDbType Tipo_Dato;
        public Object Valor_Parametro;
    }

    public static class cls_DAL
    {
      

        public static SqlConnection trae_conexion(string nombre_conexion, ref string mensaje_error, ref int numero_error)
        {
            SqlConnection cnn;
            try
            {
                string cadena_conexion = "";

                cadena_conexion = ConfigurationManager.ConnectionStrings[nombre_conexion].ToString();

                cnn = new SqlConnection(cadena_conexion);
                mensaje_error = String.Empty;
                numero_error = 0;
                return cnn;
            }
            catch (NullReferenceException ex)
            {
                mensaje_error = "No se encontro el nombre de cadena de conexion: " + nombre_conexion + ". Información adicional: " + ex.Message;
                numero_error = -1;
                return null;
            }
            catch (ConfigurationException ex)
            {
                mensaje_error = "Error, información adicional: " + ex.Message;
                numero_error = -2;
                return null;
            }

        }

        

        public static void conectar(SqlConnection conexion, ref string mensaje_error, ref int numero_error)
        {
            try
            {
                conexion.Open();
                mensaje_error = "ok";
                numero_error = 0;
            }
            catch (SqlException ex)
            {
                mensaje_error = "Error de conexion hacia el servidor de base de datos, informacion adicional: " + ex.Message;
                numero_error = ex.Number;
            }
        }

     
        public static void desconectar(SqlConnection conexion, ref string mensaje_error, ref int numero_error)
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    mensaje_error = "cerrada";
                    numero_error = 0;
                }
                else
                {
                    conexion.Close();
                    mensaje_error = "ok";
                }
            }
            catch (SqlException ex)
            {
                mensaje_error = "Error de conexion hacia el servidor de base de datos, informacion adicional: " + ex.Message;
                numero_error = ex.Number;
            }
        }
     
        
        public static DataSet ejecuta_dataset(SqlConnection conexion, string sql, bool es_procedimiento_almacenado, ref string mensaje_error, ref int numero_error)
        {
            SqlDataAdapter sql_data_adapter;
            DataSet dataset = new DataSet();
            try
            {
                sql_data_adapter = new SqlDataAdapter(sql, conexion);
                if (es_procedimiento_almacenado)
                {
                    sql_data_adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                }
                sql_data_adapter.Fill(dataset);
                numero_error = 0;
                mensaje_error = "ok";
                return dataset;
            }
            catch (SqlException ex)
            {
                numero_error = ex.Number;
                mensaje_error = ex.Message;
                return null;
            }
        }

       
        public static DataSet ejecuta_dataset(SqlConnection conexion, string sql, bool es_procedimiento_almacenado, ParamStruct[] parametros, ref string mensaje_error, ref int numero_error)
        {
            SqlDataAdapter sql_data_adapter;
            DataSet dataset = new DataSet();
            try
            {
                sql_data_adapter = new SqlDataAdapter(sql, conexion);
                if (es_procedimiento_almacenado)
                {
                    sql_data_adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                }
                foreach (ParamStruct var in parametros)
                {
                    Agrega_parametro(ref sql_data_adapter, var.Nombre_Parametro, var.Valor_Parametro.ToString(), var.Tipo_Dato);
                }
                sql_data_adapter.Fill(dataset);
                numero_error = 0;
                mensaje_error = "ok";
                return dataset;
            }
            catch (SqlException ex)
            {
                numero_error = ex.Number;
                mensaje_error = ex.Message;
                return null;
            }
        }
       
        public static void ejecuta_datareader(ref SqlDataReader sql_data_reader, SqlCommand sql_command, ref string mensaje_error, ref int numero_error)
        {
            try
            {
                sql_data_reader = sql_command.ExecuteReader(CommandBehavior.CloseConnection);
                numero_error = 0;
                mensaje_error = "ok";
            }
            catch (SqlException ex)
            {
                numero_error = ex.Number;
                mensaje_error = ex.Message;
            }
        }
       
        
        public static void ejecuta_sqlcommand(SqlConnection conexion, string sql, bool es_procedimiento_almacenado, ref string mensaje_error, ref int numero_error)
        {
            SqlCommand sql_command;
            try
            {
                sql_command = new SqlCommand(sql, conexion);
                if (es_procedimiento_almacenado)
                {
                    sql_command.CommandType = CommandType.StoredProcedure;
                }
                int resultado = 0;
                resultado = sql_command.ExecuteNonQuery();
                mensaje_error = "ok";
                numero_error = 0;
            }
            catch (SqlException ex)
            {
                mensaje_error = "Error al ejecutar la sentencia sql, información adicional: " + ex.Message;
                numero_error = ex.Number;
            }
        }
   

        public static void ejecuta_sqlcommand(SqlConnection conexion, string sql, bool es_procedimiento_almacenado, ParamStruct[] parametros, ref string mensaje_error, ref int numero_error)
        {
            SqlCommand sql_command;
            try
            {
                int resultado = 0;
                sql_command = new SqlCommand(sql, conexion);
                if (es_procedimiento_almacenado)
                {
                    sql_command.CommandType = CommandType.StoredProcedure;
                }
                foreach (ParamStruct var in parametros)
                {
                    Agrega_parametro(ref sql_command, var.Nombre_Parametro, var.Valor_Parametro.ToString(), var.Tipo_Dato);
                }
                resultado = sql_command.ExecuteNonQuery();
                mensaje_error = "ok";
                numero_error = 0;
            }
            catch (SqlException ex)
            {
                if (ex is SqlException)
                {
                    System.Diagnostics.Trace.WriteLine(ex);
                }
                else
                {
                    Console.WriteLine(ex);
                }
                mensaje_error = "Error al ejecutar la sentencia sql, informacion adicional: " + ex.Message;
                numero_error = ex.Number;

            }
        }

        public static void Agrega_parametro(ref SqlCommand sql_command, string nombre_parametro, string valor_parametro, SqlDbType tipo_dato)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = nombre_parametro;
            param.Value = valor_parametro;
            param.SqlDbType = tipo_dato;
            sql_command.Parameters.Add(param);
        }

        public static void Agrega_parametro(ref SqlDataAdapter sql_data_adapter, string nombre_parametro, string valor_parametro, SqlDbType tipo_dato)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = nombre_parametro;
            param.Value = valor_parametro;
            param.SqlDbType = tipo_dato;
            sql_data_adapter.SelectCommand.Parameters.Add(param);
        }

        public static void agregar_datos_estructura_parametros(ref ParamStruct[] parametros, int posicion, string nombre_parametro, SqlDbType tipo_dato_parametro, object valor_parametro)
        {
            parametros[posicion].Nombre_Parametro = nombre_parametro.ToString();
            parametros[posicion].Tipo_Dato = tipo_dato_parametro;
            parametros[posicion].Valor_Parametro = valor_parametro;
        }
    }
}
