using PruebaConcepto.Validations.Implements;
using PruebaConcepto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PruebaConcepto.Validations
{
    public class Validate<TModel> : IValidate<TModel> where TModel : class
    {
        /// <summary>
        /// Validate flow
        /// </summary>
        /// <param name="model"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public bool RunValidate(TModel model, out string errors)
        {
            var errors_ = string.Empty;
            var a = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                    .Where(x => typeof(IGenericValidate<TModel>).IsAssignableFrom(x))
                    .Select(x => $"{x.Namespace}.{x.Name}");

            foreach (var class_ in a)
            {
                Type type = Type.GetType(class_);
                var b = Activator.CreateInstance(type) as IGenericValidate<TModel>;
                b.validating(model, out var error);
                errors_ += error;
            }

            errors = errors_;

            return string.IsNullOrEmpty(errors_);
        }
    }
}
