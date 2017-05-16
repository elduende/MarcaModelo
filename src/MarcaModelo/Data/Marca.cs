using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using Dapper;

namespace MarcaModelo.Data
{
    public class Marca : IMarcaRepository
    {
        private List<Modelo> modelos = new List<Modelo>();
        
        public int? IDMarca { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public IList<Modelo> Modelos
        {
            get { return modelos.ToList(); }
        }
        public void Add(Modelo modelo)
        {
            if (modelo == null)
            {
                return;
            }
            modelos.Add(modelo);
        }
        Marca IMarcaRepository.GetById(int idMarca)
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString.ToString()].ConnectionString.ToString()))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@IDMarca", idMarca);
                return SqlMapper.Query<Marca>(connection,
                                              "MarcaTraer",
                                              param,
                                              commandType: CommandType.StoredProcedure).First();
            }
        }
        IEnumerable<Marca> IMarcaRepository.GetMarcas()
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString.ToString()].ConnectionString.ToString()))
            {
                connection.Open();
                return SqlMapper.Query<Marca>(connection,
                                              "MarcaTraer",
                                              commandType: CommandType.StoredProcedure);
            }
        }
        void IMarcaRepository.Persist(Marca marca)
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString.ToString()].ConnectionString.ToString()))
            {
                connection.Open();
                if (marca.IDMarca == null)
                    SqlMapper.Query<Marca>(connection, 
                                           "MarcaAgregar", 
                                           new { marca.Descripcion }, 
                                           commandType: CommandType.StoredProcedure);
                else
                    SqlMapper.Query<Marca>(connection,
                                           "MarcaModificar",
                                           new { marca.IDMarca, marca.Descripcion },
                                           commandType: CommandType.StoredProcedure);
            }
        }

        IList<Modelo> IMarcaRepository.Modelos()
        {
            return modelos;
        }

        public void Inactivate(int? iDMarca)
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString.ToString()].ConnectionString.ToString()))
            {
                connection.Open();
                SqlMapper.Query<Marca>(connection,
                                       "MarcaEliminar",
                                       new { iDMarca },
                                       commandType: CommandType.StoredProcedure);
            }
        }

        public void Activate(int? iDMarca)
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString.ToString()].ConnectionString.ToString()))
            {
                connection.Open();
                SqlMapper.Query<Marca>(connection,
                                       "MarcaActivar",
                                       new { iDMarca },
                                       commandType: CommandType.StoredProcedure);
            }
        }
    }
}
