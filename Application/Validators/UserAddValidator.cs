using Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Validators
{
    public class UserAddValidator: AbstractValidator<UserAddCommand>
    {
        public UserAddValidator() {
            RuleFor(u => u.Nome)
                .NotEmpty()
                .WithMessage("Campo Nome é Obrigatório");

            RuleFor(u => u.Endereco)
                .NotEmpty()
                 .WithMessage("Campo Endereço é Obrigatório");
        }
    }
}
