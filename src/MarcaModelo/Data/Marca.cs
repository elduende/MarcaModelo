using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Collections.Generic;

namespace MarcaModelo.Data
{
    public class Marca: IMarcaRepository
    {
        private List<Modelo> modelos = new List<Modelo>();

        public int IDMarca { get; set; }
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
            using (connection = new SqlConnection(@"Data Source=REGULUS\SQLEXPRESS;Initial Catalog=MarcaModelo;User Id=sa;Password=cms;"))
            {
                connection.Open();
                return SqlMapper.Query<Marca>(connection, "Select * From Marca Where Estado = 'A'");
            }
        }
        void IMarcaRepository.Persist(Marca marca)
        {
            throw new NotImplementedException();
        }

        IList<Modelo> IMarcaRepository.Modelos()
        {
            return modelos;
        }
    }
}
