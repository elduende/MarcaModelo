using System;
using System.Collections.Generic;
using MarcaModelo.Entities;
using MarcaModelo.DataAccess;
using MarcaModelo.DataAccess.Queries;

namespace MarcaModelo.AppServices
{
    public class MarcaCrudService : BusinessServiceBase<Marca>, IMarcaCrudService
    {
        private readonly IDaoFactory _daoFactory;
        private readonly IEntityDao<Marca> _marcaDao;

        public MarcaCrudService(IDaoFactory daoFactory, IEntityValidator entityValidator)
            : this(daoFactory.GetDao<IEntityDao<Marca>>(), entityValidator)
        {
            _daoFactory = daoFactory;
        }

        public MarcaCrudService(IEntityDao<Marca> marcaDao, IEntityValidator entityValidator)
            : base(entityValidator)
        {
            _marcaDao = marcaDao;
        }

        public IEnumerable<Marca> GetAll(string nameTemplate, int pageNumber, int pageSize)
        {
            if (!string.IsNullOrEmpty(nameTemplate))
            {
                var query = _daoFactory.GetQuery<IMarcaByDescripcionTemplateQuery>();
                query.DescripcionTemplate = nameTemplate;
                return query.GetResults(pageSize, pageNumber).Results;
            }
            return _marcaDao.GetAll(pageSize, pageNumber).Results;
        }

        public Marca Get(int id)
        {
            return _marcaDao.Get(id);
        }

        public void Remove(int marcaId)
        {
            // Note (con Fabio): Antes de llamar al borrado, controla si todavia hay una instancia en el DB. Si está la borra.
            var entity = _marcaDao.Get(marcaId);
            if (entity != null)
            {
                _marcaDao.MakeTransient(entity);
            }
        }

        public string Save(Marca marca)
        {
            if (marca == null) throw new ArgumentNullException("Marca");

            var invalidValues = GetInvalidValues(marca);
            if (!string.IsNullOrEmpty(invalidValues))
            {
                return invalidValues;
            }

            var query = _daoFactory.GetQuery<IMarcaByDescripcionTemplateQuery>();
            query.DescripcionTemplate = marca.Descripcion;
            if (marca.Id == 0 && query.GetResults(1, 1).Count > 0)
            {
                return string.Format("The Marca '{0}' exists. (Duplicated)", marca.Descripcion);
            }
            _marcaDao.MakePersistent(marca);
            return null;
        }
    }
}
