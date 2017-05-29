using System.Collections.Generic;
using System.Text;

namespace MarcaModelo.AppServices
{
    public class BusinessServiceBase<T>
    {
        private readonly IEntityValidator _entityValidator;

        public BusinessServiceBase(IEntityValidator entityValidator)
        {
            _entityValidator = entityValidator;
        }

        protected string GetInvalidValues(T entity)
        {
            var invalidValues = _entityValidator.Validate(entity);
            if (invalidValues.Count > 0)
            {
                var result = new StringBuilder(500);
                foreach (var invalidValueInfo in invalidValues)
                {
                    result.AppendLine(invalidValueInfo.Message);
                }
                return result.ToString().Trim();
            }
            return string.Empty;
        }

        protected IEnumerable<IInvalidValueInfo> GetInvalidValuesDetails(T entity)
        {
            return _entityValidator.Validate(entity);
        }

    }
}
