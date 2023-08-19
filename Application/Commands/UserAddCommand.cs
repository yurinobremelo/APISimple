using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class UserAddCommand : IRequest<Unit>
    {
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Numero { get; set; }

    }
}
