using Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests
{
    public class UserRequest : IRequest<UserResponse>
    {
        public string? nome { get; set; }
        public string? endereco { get; set; }
        public string? numero { get; set; }


    }
}
