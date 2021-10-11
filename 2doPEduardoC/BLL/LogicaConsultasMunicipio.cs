using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;
using DAL;

namespace BLL
{
    public class LogicaConsultasMunicipio
    {
        public DataTable Listar()
        {
            ClassConsultas muestra = new ClassConsultas();
            string sql = "SELECT municipio.MunicipioId, municipio.nombre_municipio, departamento.nombre_departamento FROM municipio INNER JOIN departamento ON departamento.DepartamentoId = municipio.DepartamentoId;";
            DataTable Tabla = muestra.Consulta(sql, null);
            return Tabla;
        }
        public DataTable Buscar(string busca)
        {
            ClassConsultas Consul = new ClassConsultas();
            MySqlParameter[] parametros = new[]
            {
                new MySqlParameter("@busca", busca)
            };
            string sql = "SELECT municipio.MunicipioId, municipio.nombre_municipio, departamento.nombre_departamento FROM municipio INNER JOIN departamento ON departamento.DepartamentoId = municipio.DepartamentoId WHERE nombre_municipio =  @busca OR nombre_departamento = @busca;";
            DataTable Tabla = Consul.Consulta(sql, parametros);
            return Tabla;
        }

        public string Registrar(string nombre, string Departamento)
        {
            string resultado, sql;
            ClassConsultas Accion = new ClassConsultas();
            sql = "Insert Into municipio (nombre_municipio, DepartamentoId) Values (@nombre, @Departamento)";
            MySqlParameter[] parametros = new[]
            {
                    new MySqlParameter("@nombre", nombre),
                    new MySqlParameter("@Departamento", Departamento)

            };
            resultado = Accion.Acciones(sql, parametros);
            return resultado;
        }
        public string Editar(string id, string nombre, string idDepartamento)
        {
            string resultado, sql;
            ClassConsultas Accion = new ClassConsultas();
            sql = "UPDATE municipio SET nombre_municipio = @nombre, DepartamentoId = @DepartamentoId Where MunicipioId = @id";

            MySqlParameter[] parametros = new[]
            {
                    new MySqlParameter("@id", id),
                    new MySqlParameter("@nombre", nombre),
                    new MySqlParameter("@DepartamentoId", idDepartamento),
            };
            resultado = Accion.Acciones(sql, parametros);
            return resultado;
        }

        public string Eliminar(string id)
        {
            string resultado, sql;
            ClassConsultas Accion = new ClassConsultas();
            sql = "DELETE FROM municipio where MunicipioId = @id";
            MySqlParameter[] parametros = new[]
            {
                    new MySqlParameter("@id", id),
            };
            resultado = Accion.Acciones(sql, parametros);
            return resultado;
        }

        public void EliminarMunicipios(string id)
        {
            string sql;
            ClassConsultas Accion = new ClassConsultas();
            sql = "DELETE FROM municipio where DepartamentoId = @id;";
            MySqlParameter[] parametros = new[]
            {
                    new MySqlParameter("@id", id),
            };
            Accion.Acciones(sql, parametros);
        }
    }
}
