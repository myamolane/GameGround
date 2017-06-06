using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class ValidationProvider
    {
        private static readonly Dictionary<string, IValidator> Validators = new Dictionary<string, IValidator>();

        public static void Validate<T>(T model)
            where T : class
        {
            var type = typeof(T);
            var key = type.FullName;
            if (!Validators.ContainsKey(key))
            {
                var attribute = (ValidatorAttribute)Attribute.GetCustomAttribute(type, typeof(ValidatorAttribute));
                if (attribute == null) throw new ArgumentNullException("Validator");
                Validators[key] = (IValidator)Activator.CreateInstance(attribute.ValidatorType);
            }

            var validator = Validators[key];

            var result = validator.Validate(model);
            if (result.IsValid) return;

            var error = result.Errors.First();
            throw new LocalizedFormatException(error.PropertyName, error.ErrorMessage);
        }
    }
}
