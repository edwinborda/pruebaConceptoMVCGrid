using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaConcepto.Validations.Implements
{
    public abstract class GenericValidate<TModel> : AbstractValidator<TModel>, IValidate<TModel> where TModel : class
    {
        public abstract bool validate(TModel model, out string errors);
    }
}
