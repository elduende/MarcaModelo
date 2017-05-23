using System.Reflection;
using MarcaModelo.Data;

namespace MarcaModelo.TestDataBuilders
{
    public static class EntityExtensions
    {
        private const BindingFlags Flags =
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;

        private const string IdFieldName = "<Id>k__BackingField";

        private static readonly FieldInfo IntIdField = typeof(BaseEntity).GetField(IdFieldName, Flags);

        public static T SetId<T>(this T entity, int value) where T : AbstractEntity<int>
        {
            IntIdField.SetValue(entity, value);
            return entity;
        }
    }
}
