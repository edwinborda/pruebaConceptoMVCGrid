using FluentValidation;
using Newtonsoft.Json;
using PruebaConcepto.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaConcepto.Validations.Implements
{
    public class FormUserValidate : AbstractValidator<UserModel>, IGenericValidate<UserModel>
    {
        private readonly RestClient clientZero;
        private readonly RestClient clientServi;
        const string Z_PRIVATE_KEY = "275db45a6e09434e9202ac1bafe8a478";
        const string S_TOKEN = "Token UV4U0NQDY7U5YFTKGSLJY250FBJHGD";
        public FormUserValidate()
        {
            clientZero = new RestClient("https://api.zerobounce.net/v2");
            clientServi = new RestClient("https://sitidata-stdr.appspot.com/api");
            RuleFor(m => m.Email).Must(IsEmailValidated).WithMessage("Correo no validado!!!!");
            RuleFor(m => m.Address).Must((m, Address) => {
                return IsAddressValidated(Address, m.City);
            }).WithMessage("Direccion no georeferenciada!!!!");
        }

        private bool IsEmailValidated(string email)
        {
            var request = new RestRequest("/validate", Method.GET);
            request.AddParameter("api_key", Z_PRIVATE_KEY);
            request.AddParameter("email", email);
            request.AddParameter("ip_address", string.Empty);

            IRestResponse response = clientZero.Execute(request);
            var content = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);

            return content["status"] == "valid";
        }

        private bool IsAddressValidated(string address, string city)
        {
            var request_ = new RestRequest("/multizonificador/geocoder/", Method.POST);
            var serviBody = new Dictionary<string, string>()
            {
                {"city",  city},
                {"address", address}
            };
            request_.AddHeader("Authorization", S_TOKEN);
            request_.AddHeader("Content-Type", "application/json");
            request_.AddParameter("application/json", JsonConvert.SerializeObject(serviBody), ParameterType.RequestBody);

            IRestResponse response = clientServi.Execute(request_);
            var content = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(response.Content);

            return content["data"]["estado"]?.Value?.IndexOfAny(new[] { 'A', 'B' }) > 1;
        }

        public bool validating(UserModel model, out string errors)
        {
            var result = Validate(model);
            var isValid = result.IsValid;
            errors = string.Join(",", result.Errors);

            return result.IsValid;
        }
    }
}
