using FluentValidation;
using PruebaConcepto.Validations.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaConcepto.Validations
{
    public interface IValidate<TModel> where TModel : class
    {
        bool RunValidate(TModel model, out string errors);
    }
}
