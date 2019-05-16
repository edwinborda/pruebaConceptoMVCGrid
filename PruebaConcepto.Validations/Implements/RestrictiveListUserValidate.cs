using FluentValidation;
using PruebaConcepto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaConcepto.Validations.Implements
{
    public class RestrictiveListUserValidate : AbstractValidator<UserModel>, IGenericValidate<UserModel>
    {
        public RestrictiveListUserValidate()
        {
            RuleFor(m => m.DocumentNumber).Must(NotBeInRestrictiveList).WithMessage("No es posible seguir con el flujo, aparece en listas restrictivas");
        }

        private bool NotBeInRestrictiveList(int document)
        {
            var RestrictiveList = new List<string>()
            {
                {"1015408627"},
                {"1110559833"},
                {"1023828392"},
                {"2132312213"},
                {"1232198797"},
            };

            return !RestrictiveList.Any(it => it == document.ToString());
        }

        public bool validating(UserModel model, out string errors)
        {
            var result = Validate(model);
            var isValid = result.IsValid;
            errors = string.Join("-", result.Errors);

            return result.IsValid;
        }
    }
}
