using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MarcaModelo.WinForm.Common
{
    public static class DataErrorInfoExtensions
    {
        public static IEnumerable<ValidationResult> ValidateProperty(this IDataErrorInfo source, ValidationContext validationContext, string propertyName)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            var validationResults = new List<ValidationResult>();
            var properties = TypeDescriptor.GetProperties(source);
            var propertyValue = properties[propertyName].GetValue(source);
            var propertyValidationContext = new ValidationContext(source, validationContext, validationContext?.Items)
            {
                MemberName = propertyName
            };
            return !Validator.TryValidateProperty(propertyValue, propertyValidationContext, validationResults)
                ? validationResults
                : Enumerable.Empty<ValidationResult>();
        }

        public static bool IsOnlyForProperty(this ValidationContext context, string propertyName)
        {
            return context.MemberName != null && context.MemberName.Equals(propertyName);
        }

        public static bool IsForModel(this ValidationContext context)
        {
            return string.IsNullOrEmpty(context.MemberName);
        }

        public static bool IsForModelOrForProperty(this ValidationContext context, string propertyName)
        {
            return IsForModel(context) || IsOnlyForProperty(context, propertyName);
        }

        public static bool IsForSpecificProperty(this ValidationContext context)
        {
            return !string.IsNullOrEmpty(context.MemberName);
        }

        public static string PropertyError(this IDataErrorInfo source, ValidationContext validationContext, string propertyName)
        {
            var errors = ValidateProperty(source, validationContext, propertyName)
                .Concat(ValidateValidatableObjectForProperty(source, validationContext, propertyName))
                .Select(x => x.ErrorMessage);
            return string.Join(Environment.NewLine, errors);
        }

        public static string PropertyError(this IDataErrorInfo source, string propertyName)
        {
            var errors = ValidateProperty(source, null, propertyName)
                .Concat(ValidateValidatableObjectForProperty(source, null, propertyName))
                .Select(x => x.ErrorMessage);
            return string.Join(Environment.NewLine, errors);
        }

        private static IEnumerable<ValidationResult> ValidateValidatableObjectForProperty(IDataErrorInfo source, ValidationContext validationContext, string propertyName)
        {
            var validatableObject = source as IValidatableObject;
            if (validatableObject == null)
            {
                return Enumerable.Empty<ValidationResult>();
            }
            var propertyValidationContext = new ValidationContext(source, validationContext, validationContext?.Items)
            {
                MemberName = propertyName
            };
            return validatableObject.Validate(propertyValidationContext).Where(vr => vr.MemberNames.Contains(propertyName));
        }

        public static bool IsValid(this IDataErrorInfo source, ValidationContext validationContext = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return Validator.TryValidateObject(source, validationContext ?? new ValidationContext(source, null, null), null);
        }

        public static IEnumerable<ValidationResult> ValidateModel(this IDataErrorInfo source, ValidationContext validationContext)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            var validationResults = new List<ValidationResult>();
            return !Validator.TryValidateObject(source, validationContext, validationResults)
                ? validationResults
                : Enumerable.Empty<ValidationResult>();
        }

        public static string ModelError(this IDataErrorInfo source, ValidationContext validationContext, bool excludeProperties = true)
        {
            var values = ValidateModel(source, validationContext).Where(x => !excludeProperties || !x.MemberNames.Any()).Select(x => x.ErrorMessage);
            return string.Join(Environment.NewLine, values);
        }

        public static void SetModelErrors<T>(this T source, ValidationContext validationContext
            , Expression<Func<T, string>> errorProperty) where T : IDataErrorInfo
        {
            var expr = (MemberExpression)errorProperty.Body;
            var prop = (PropertyInfo)expr.Member;
            var setter = prop.GetSetMethod(true);
            if (setter != null)
            {
                var modelError = ModelError(source, validationContext);
                setter.Invoke(source, new[] { modelError });
            }
        }
    }
}
