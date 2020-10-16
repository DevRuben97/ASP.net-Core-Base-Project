using Domain.DTOs.Security;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers.Validations
{
    public class AuthValidator: AbstractValidator<LoginUserDto>
    {
        public AuthValidator()
        {
            RuleFor(s => s.UserName).NotEmpty().WithMessage("El Usuario o correo es requerido");
            RuleFor(s => s.Password).NotEmpty().WithMessage("La contraseña es requerida");
        }
    }
}
