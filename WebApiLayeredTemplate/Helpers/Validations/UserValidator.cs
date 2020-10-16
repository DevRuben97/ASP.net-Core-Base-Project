using Domain.DTOs.Security;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.Validations
{
    public class UserValidator: AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(s => s.Nombre).NotEmpty().WithMessage("El nombre  es requerido");
            RuleFor(s => s.Apellido).NotEmpty().WithMessage("El apellido es requerido");
            RuleFor(s => s.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Must(pass => ValidatePassword(pass))
                 .WithMessage("La contraseña es invalida");
        }

        private bool ValidatePassword(string pass)
        {
            var chars = pass.ToCharArray();
            var count = 0;

            foreach(char item in chars)
            {
                if (char.IsUpper(item) && char.IsLower(item))
                {
                    count++;
                }
            }

            return count > 0;
        }
    }
}
