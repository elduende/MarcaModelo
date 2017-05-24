using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using Iesi.Collections.Generic;
using Dapper;
using MarcaModelo.Data;

namespace MarcaModelo.AppServices
{
    public class MarcaCrudService : BusinessServiceBase<Marca>, IMarcaCrudService
    {
        private Iesi.Collections.Generic.ISet<Modelo> modelos;

        public MarcaCrudService(IEntityValidator entityValidator) : base(entityValidator)
        {

        }

        public void Activar(int IDMarca)
        {
            throw new NotImplementedException();
        }

        public void Desactivar(int IDMarca)
        {
            throw new NotImplementedException();
        }

        public Marca GetById(int IDMarca)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Marca> GetMarcas()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Marca> GetMarcasInactivas()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Modelo> Modelos
        {
            get
            {
                IDbConnection connection;
                using (connection = new SqlConnection(ConfigurationManager.ConnectionStrings[Properties.Settings.Default.ConnectionString.ToString()].ConnectionString.ToString()))
                {
                    connection.Open();
                    modelos = (Iesi.Collections.Generic.ISet<Modelo>)SqlMapper.Query<Modelo>(connection,
                                                      "ModeloTraer",
                                                      new { IDMarca },
                                                      commandType: CommandType.StoredProcedure).ToList();
                    return modelos;
                }
            }
        }







        public IEnumerable<IInvalidValueInfo> Persist(Marca marca)
        {
            throw new NotImplementedException();
        }
    }
}
