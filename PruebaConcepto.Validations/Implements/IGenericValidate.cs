using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaConcepto.Validations.Implements
{
    public interface IGenericValidate<TModel> where TModel : class
    {
        bool validating(TModel model, out string errors);
    }
}
