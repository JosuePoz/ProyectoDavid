using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;
using DAL;

namespace BLL
{
    public class LogicaConsultasExamen3
    {
        public DataTable ListarPaquetes()
        {
            ClassConsultas muestra = new ClassConsultas();
            string sql = "SELECT paquete.PaqueteId, municipio.nombre_municipio, paquete.descripcion, paquete.peso_libras, paquete.nombre_destinatario, paquete.direccion_destino FROM paquete INNER JOIN municipio ON municipio.MunicipioId = paquete.MunicipioId;";
            DataTable Tabla = muestra.Consulta(sql, null);
            return Tabla;
        }

        public DataTable BuscarPaquetes(string busca)
        {
            ClassConsultas Consul = new ClassConsultas();
            MySqlParameter[] parametros = new[]
            {
                new MySqlParameter("@nombre", busca)
            };
            string sql = "SELECT paquete.PaqueteId, municipio.nombre_municipio, paquete.descripcion, paquete.peso_libras, paquete.nombre_destinatario, paquete.direccion_destino FROM paquete INNER JOIN municipio ON municipio.MunicipioId = paquete.MunicipioId WHERE nombre_destinatario = @nombre";
            DataTable Tabla = Consul.Consulta(sql, parametros);
            return Tabla;
        }//Fin 
        public string GuardarPaquetes(string Municipio, string descripcion, string destinatario, string direccion, string peso)
        {
            string resultado, sql;
            ClassConsultas Accion = new ClassConsultas();
            sql = "Insert Into paquete (MunicipioId, descripcion, nombre_destinatario, direccion_destino, peso_libras) Values (@MunicipioId, @descripcion, @nombre_destinatario, @direccion_destino, @peso_libras)";
            MySqlParameter[] parametros = new[]
            {
                    new MySqlParameter("@MunicipioId", Municipio),
                    new MySqlParameter("@descripcion", descripcion),
                    new MySqlParameter("@nombre_destinatario", destinatario),
                    new MySqlParameter("@direccion_destino", direccion),
                    new MySqlParameter("@peso_libras", peso)
            };
            resultado = Accion.Acciones(sql, parametros);
            return resultado;
        }//fin GuardarCliente

        public string EditarPaquetes(int id, string Municipio , string descripcion, string destinatario, string direccion, string peso)
        {
            string resultado, sql;
            ClassConsultas Accion = new ClassConsultas();
            sql = "UPDATE paquete SET MunicipioId = @MunicipioId, descripcion = @descripcion, nombre_destinatario = @nombre_destinatario, direccion_destino = @direccion_destino, peso_libras = @peso_libras  Where PaqueteId = @id";

            MySqlParameter[] parametros = new[]
            {
                    new MySqlParameter("@id", id.ToString()),
                    new MySqlParameter("@MunicipioId", Municipio),
                    new MySqlParameter("@descripcion", descripcion),
                    new MySqlParameter("@nombre_destinatario", destinatario),
                    new MySqlParameter("@direccion_destino", direccion),
                    new MySqlParameter("@peso_libras", peso)
            };
            resultado = Accion.Acciones(sql, parametros);
            return resultado;
        }

        public DataTable ListarEnvios()
        {
            ClassConsultas muestra = new ClassConsultas();
            string sql = "SELECT envio.EnvioId, cliente.nombre_completo, paquete.nombre_destinatario, envio.fecha_envio, envio.valor_envio, envio.estado FROM envio INNER JOIN cliente ON cliente.ClienteId = envio.ClienteId INNER JOIN paquete ON paquete.PaqueteId = envio.PaqueteId;";
            DataTable Tabla = muestra.Consulta(sql, null);
            return Tabla;
        }

        public DataTable BuscarEnvios(string cliente, string destinatario)
        {
            ClassConsultas Consul = new ClassConsultas();
            MySqlParameter[] parametros = new[]
            {
                new MySqlParameter("@nombre_completo", cliente),
                new MySqlParameter("@nombre_destinatario", destinatario)
            };
            string sql = "SELECT envio.EnvioId, cliente.nombre_completo, paquete.nombre_destinatario, envio.fecha_envio, envio.valor_envio, envio.estado FROM envio INNER JOIN cliente ON cliente.ClienteId = envio.ClienteId INNER JOIN paquete ON paquete.PaqueteId = envio.PaqueteId WHERE  (nombre_completo = @nombre_completo OR @nombre_completo IS NULL) AND (nombre_destinatario = @nombre_destinatario OR @nombre_destinatario IS NULL);";
            DataTable Tabla = Consul.Consulta(sql, parametros);
            return Tabla;
        }//Fin 
        public string GuardarEnvios(string ClienteId, string PaqueteId, string fecha, string valor, string estado)
        {
            string resultado, sql;
            ClassConsultas Accion = new ClassConsultas();
            sql = "Insert Into envio (ClienteId, PaqueteId, fecha_envio, valor_envio, estado) Values (@ClienteId, @PaqueteId, @fecha_envio, @valor_envio, @estado)";
            MySqlParameter[] parametros = new[]
            {
                    new MySqlParameter("@ClienteId", ClienteId),
                    new MySqlParameter("@PaqueteId", PaqueteId),
                    new MySqlParameter("@fecha_envio", fecha),
                    new MySqlParameter("@valor_envio", valor),
                    new MySqlParameter("@estado", estado)
            };
            resultado = Accion.Acciones(sql, parametros);
            return resultado;
        }//fin GuardarCliente

        public string EditarEnvios(int id, string ClienteId, string PaqueteId, string fecha, string valor, string estado)
        {
            string resultado, sql;
            ClassConsultas Accion = new ClassConsultas();
            sql = "UPDATE envio SET ClienteId = @ClienteId, PaqueteId = @PaqueteId, fecha_envio = @fecha_envio, valor_envio = @valor_envio, estado = @estado  Where EnvioId = @id";
            MySqlParameter[] parametros = new[]
            {
                    new MySqlParameter("@id", id.ToString()),
                    new MySqlParameter("@ClienteId", ClienteId),
                    new MySqlParameter("@PaqueteId", PaqueteId),
                    new MySqlParameter("@fecha_envio", fecha),
                    new MySqlParameter("@valor_envio", valor),
                    new MySqlParameter("@estado", estado)
            };
            resultado = Accion.Acciones(sql, parametros);
            return resultado;
        }
    }
}
