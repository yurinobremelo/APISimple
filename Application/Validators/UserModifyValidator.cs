using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands;
using FluentValidation;
namespace Application.Validators
{
    public class UserModifyValidator : AbstractValidator<UserModifyCommand>
    {
        public UserModifyValidator() {
           
            RuleFor(u => u.Endereco)
                .NotEmpty()
                 .WithMessage("Campo Endereço é Obrigatório");

        }
    }
}
