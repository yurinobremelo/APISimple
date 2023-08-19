using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class UserModifyCommand : IRequest<UserModifyViewModel>
    {
        public Guid Id { get; set; }
        public string? Endereco { get; set; }
        public string? Numero { get; set; }
    }
}
