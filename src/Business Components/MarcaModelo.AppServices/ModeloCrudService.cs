using System;
using System.Collections.Generic;
using MarcaModelo.Entities;
using MarcaModelo.DataAccess;
using MarcaModelo.DataAccess.Queries;


namespace MarcaModelo.AppServices
{
    public class ModeloCrudService : BusinessServiceBase<Modelo>, IModeloCrudService
    {
        private readonly IDaoFactory _daoFactory;
        private readonly IEntityDao<Modelo> _modeloDao;

        public ModeloCrudService(IDaoFactory daoFactory, IEntityValidator entityValidator)
            : this(daoFactory.GetDao<IEntityDao<Modelo>>(), entityValidator)
        {
            _daoFactory = daoFactory;
        }

        public ModeloCrudService(IEntityDao<Modelo> modeloaDao, IEntityValidator entityValidator)
            : base(entityValidator)
        {
            _modeloDao = modeloaDao;
        }

        public IEnumerable<Modelo> GetAll(int idMarca, int pageNumber, int pageSize)
        {
            //return _daoFactory.GetDao<IEntityDao<Modelo>>().GetAll(IdMarca, pageSize, pageNumber);
            throw new NotImplementedException();
        }

        public Modelo Get(int idModelo)
        {
            return _modeloDao.Get(idModelo);
        }

        public void Remove(int idModelo)
        {
            var saved = _modeloDao.Get(idModelo);
            if (saved != null)
            {
                _modeloDao.MakeTransient(saved);
            }
        }

        public string Save(Modelo modelo)
        {
            if (modelo == null) throw new ArgumentNullException("Modelo");

            var invalidValues = GetInvalidValues(modelo);
            if (!string.IsNullOrEmpty(invalidValues))
            {
                return invalidValues;
            }

            if (modelo.Id == 0 && _modeloDao.Get(modelo.IdModelo) != null)
            {
                return string.Format("The Modelo '{0}' exists. (Duplicated)", modelo.Descripcion);
            }
            _modeloDao.MakePersistent(modelo);
            return null;
        }

        public Marca GetMarca(string nameTemplate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Modelo> GetAll(int idMarca)
        {
            throw new NotImplementedException();
        }
    }
}
