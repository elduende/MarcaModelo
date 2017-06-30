using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace MarcaModelo.Data
{
    public class Modelo : BaseEntity, IModeloRepository
    {
        //private Marca marca { get; set; }

        //TODO - Le tuve que sacar el constructor que recibe Marca como parámetro
        public Modelo(Marca pMarca)
        {
            //marca = pMarca;
            IdMarca = pMarca.IdMarca;
        }
        public Modelo()
        {

        }

        public virtual int IdModelo { get; set; }
        public virtual int IdMarca { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual string Estado { get; set; }
        //public virtual Marca Marca { get; set; }

        //Marca IModeloRepository.Marca
        //{
        //    get
        //    {
        //        return marca;
        //    }

        //    set
        //    {
        //        marca = marca;
        //    }
        //}

        public virtual bool Equals(Modelo that)
        {
            if (base.Equals(that))
            {
                return true;
            }
            if (ReferenceEquals(null, that)) return false;
            return Equals(that.IdMarca, IdMarca) && Equals(that.Descripcion, Descripcion);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Modelo);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Descripcion != null ? Descripcion.GetHashCode() : 0);
                return result;
            }
        }

        Modelo IModeloRepository.GetById(int idModelo)
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
            {
                connection.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@IDModelo", idModelo);
                return SqlMapper.Query<Modelo>(connection,
                    "ModeloTraer",
                    param,
                    commandType: CommandType.StoredProcedure).First();
            }
        }

        //IEnumerable<Modelo> IModeloRepository.GetModelos()
        public IEnumerable<Modelo> GetModelos()
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
            {
                connection.Open();
                //return SqlMapper.Query<Modelo>(connection,
                //                               string.Format("ModeloTraer @IDMarca = {0}", IdMarca),
                //                               commandType: CommandType.StoredProcedure);
                DynamicParameters param = new DynamicParameters();
                param.Add("@IDMarca", IdMarca);
                return SqlMapper.Query<Modelo>(connection,
                    "ModeloTraer",
                    param,
                    commandType: CommandType.StoredProcedure);

            }
        }

        IEnumerable<Modelo> IModeloRepository.GetModelos(int pPagina, int pTamanoPagina, string pBuscar)
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
            {
                connection.Open();
                return SqlMapper.Query<Modelo>(connection,
                                               string.Format("ModeloTraer @IDMarca = {0}", IdMarca),
                                               commandType: CommandType.StoredProcedure)
                                               .Skip((pPagina - 1) * pTamanoPagina)
                                               .Take(pTamanoPagina)
                                               .Where(m => m.Descripcion.ToLower().Contains(pBuscar.ToLower()));
            }
        }

        IEnumerable<Modelo> IModeloRepository.GetModelosInactivos()
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
            {
                connection.Open();
                return SqlMapper.Query<Modelo>(connection,
                                               string.Format("ModeloInactivoTraer @IDMarca = {0}", IdMarca), 
                                               commandType: CommandType.StoredProcedure);
            }
        }

        IEnumerable<Modelo> IModeloRepository.GetModelosInactivos(int pPagina, int pTamanoPagina, string pBuscar)
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
            {
                connection.Open();
                return SqlMapper.Query<Modelo>(connection,
                                               string.Format("ModeloInactivoTraer @IDMarca = {0}", IdMarca),
                                               commandType: CommandType.StoredProcedure)
                                               .Skip((pPagina - 1) * pTamanoPagina)
                                               .Take(pTamanoPagina)
                                               .Where(m => m.Descripcion.ToLower().Contains(pBuscar.ToLower()));
            }
        }

        int IModeloRepository.GetModelosCantidad(int pIdMarca)
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
            {
                connection.Open();
                return connection.ExecuteScalar<int>(string.Format("SELECT COUNT(*) AS Cantidad FROM Modelo WHERE Estado = 'A' AND IDMarca = {0}", pIdMarca),
                    commandType: CommandType.Text);
            }
        }

        int IModeloRepository.GetModelosInactivosCantidad(int pIdMarca)
        {
            IDbConnection connection;
            using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString].ConnectionString))
            {
                connection.Open();
                return connection.ExecuteScalar<int>(string.Format("SELECT COUNT(*) AS Cantidad FROM Modelo WHERE Estado = 'B' AND IDMarca = {0}", pIdMarca),
                    commandType: CommandType.Text);
            }
        }

        void IModeloRepository.AddComponente(object componente)
        {
            throw new NotImplementedException();
        }

        void IModeloRepository.RemoveComponente(object componente)
        {
            throw new NotImplementedException();
        }

        void IModeloRepository.Activate(int idMarca)
        {
            throw new NotImplementedException();
        }

        void IModeloRepository.Inactivate(int iDMarca)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> Componentes()
        {
            throw new NotImplementedException();
        }
    }
}
