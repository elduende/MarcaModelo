using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using Iesi.Collections.Generic;
using Dapper;

namespace MarcaModelo.Data
{
    public class Marca : BaseEntity, IMarcaRepository
    {
        private Iesi.Collections.Generic.ISet<Modelo> _modelos;

        public Marca()
        {
            _modelos = new HashedSet<Modelo>();
        }

        public virtual int IdMarca { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Estado { get; set; }
        public virtual IEnumerable<Modelo> Modelos
        {
            //get
            //{
            //    IDbConnection connection;
            //    using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString.ToString()].ConnectionString.ToString()))
            //    {
            //        connection.Open();
            //        modelos = (Iesi.Collections.Generic.ISet<Modelo>)SqlMapper.Query<Modelo>(connection,
            //                                          "ModeloTraer",
            //                                          new { IDMarca },
            //                                          commandType: CommandType.StoredProcedure).ToList();
            //        return modelos;
            //    }
            //}
            get { return _modelos; }
        }

        public virtual void AddModelo(Modelo modelo)
        {
            if (modelo.Marca != null && !Equals(modelo.Marca, this))
            {
                modelo.Marca.RemoveModelo(modelo);
            }

            modelo.Marca = this;
            _modelos.Add(modelo);
        }

        public virtual void RemoveModelo(Modelo modelo)
        {
            if (modelo.Marca != null && Equals(modelo.Marca, this))
            {
                _modelos.Remove(modelo);
                modelo.Marca = null;
            }
        }

        Marca IMarcaRepository.GetById(int idMarca)
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
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

        IEnumerable<Marca> IMarcaRepository.GetMarcas(int pPagina, int pTamanoPagina, string pBuscar)
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
            {
                connection.Open();
                return SqlMapper.Query<Marca>(connection,
                                              "MarcaTraer",
                                              commandType: CommandType.StoredProcedure)
                                              .Skip((pPagina - 1) * pTamanoPagina)
                                              .Take(pTamanoPagina)
                                              .Where(m => m.Descripcion.ToLower().Contains(pBuscar.ToLower()));
            }
        }

        IEnumerable<Marca> IMarcaRepository.GetMarcasInactivas(int pPagina, int pTamanoPagina, string pBuscar)
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
            {
                connection.Open();
                return SqlMapper.Query<Marca>(connection,
                                              "MarcaInactivaTraer",
                                              commandType: CommandType.StoredProcedure)
                                              .Skip((pPagina - 1) * pTamanoPagina)
                                              .Take(pTamanoPagina)
                                              .Where(m => m.Descripcion.ToLower().Contains(pBuscar.ToLower()));
            }
        }

        IEnumerable<Marca> IMarcaRepository.GetMarcas()
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
            {
                connection.Open();
                return SqlMapper.Query<Marca>(connection,
                                              "MarcaTraer",
                                              commandType: CommandType.StoredProcedure);
            }
        }

        IEnumerable<Marca> IMarcaRepository.GetMarcasInactivas()
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
            {
                connection.Open();
                return SqlMapper.Query<Marca>(connection,
                    "MarcaInactivaTraer",
                    commandType: CommandType.StoredProcedure);
            }
        }

        int IMarcaRepository.GetMarcasCantidad()
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
            {
                connection.Open();
                return connection.ExecuteScalar<int>("SELECT COUNT(*) AS Cantidad FROM Marca WHERE Estado = 'A'",
                    commandType: CommandType.Text);
            }
        }

        int IMarcaRepository.GetMarcasInactivasCantidad()
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
            {
                connection.Open();
                return connection.ExecuteScalar<int>("SELECT COUNT(*) AS Cantidad FROM Marca WHERE Estado = 'B'",
                    commandType: CommandType.Text);
            }
        }

        void IMarcaRepository.Persist(Marca marca)
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
            {
                connection.Open();
                if (marca.IdMarca == 0)
                    SqlMapper.Query<Marca>(connection, 
                                           "MarcaAgregar", 
                                           new { marca.Descripcion }, 
                                           commandType: CommandType.StoredProcedure);
                else
                    SqlMapper.Query<Marca>(connection,
                                           "MarcaModificar",
                                           new { IDMarca = marca.IdMarca, marca.Descripcion },
                                           commandType: CommandType.StoredProcedure);
            }
        }

        IEnumerable<Modelo> IMarcaRepository.Modelos()
        {
            return _modelos;
        }

        public virtual void Inactivate(int iDMarca)
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
            {
                connection.Open();
                SqlMapper.Query<Marca>(connection,
                                       "MarcaEliminar",
                                       new { iDMarca },
                                       commandType: CommandType.StoredProcedure);
            }
        }

        public virtual void Activate(int iDMarca)
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
            {
                connection.Open();
                SqlMapper.Query<Marca>(connection,
                                       "MarcaActivar",
                                       new { iDMarca },
                                       commandType: CommandType.StoredProcedure);
            }
        }

        public virtual bool Equals(Marca that)
        {
            if (base.Equals(that))
            {
                return true;
            }
            if (ReferenceEquals(null, that)) return false;
            return Equals(that.Descripcion, Descripcion);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Marca);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Descripcion != null ? Descripcion.GetHashCode() : 0);
                return result;
            }
        }
    }
}
