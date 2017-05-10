using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Collections.Generic;
using System.Configuration;

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
        Marca IMarcaRepository.GetById(int IDMarca)
        {
            throw new NotImplementedException();
        }
        IEnumerable<Marca> IMarcaRepository.GetMarcas()
        {
            IDbConnection connection;
            string connectionString = ConfigurationManager.ConnectionStrings["MarcaModelo"].ConnectionString.ToString();
            using (connection = new SqlConnection(connectionString))
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
            string connectionString = ConfigurationManager.ConnectionStrings["MarcaModelo"].ConnectionString.ToString();
            using (connection = new SqlConnection(connectionString))
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

        public Marca GetById(int IDMarca)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Marca> GetMarcas()
        {
            throw new NotImplementedException();
        }

        public void Persist(Marca marca)
        {
            throw new NotImplementedException();
        }

        public void Activate(int? IDMarca)
        {
            throw new NotImplementedException();
        }

        public void Inactivate(int? iDMarca)
        {
            IDbConnection connection;
            string connectionString = ConfigurationManager.ConnectionStrings["MarcaModelo"].ConnectionString.ToString();
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlMapper.Query<Marca>(connection,
                                       "MarcaEliminar",
                                       new { iDMarca },
                                       commandType: CommandType.StoredProcedure);
            }
        }
    }
}
