using Application.Models;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class UserGetByIdQuery : IRequest<UserGetByIdViewModel>
    {
        public Guid Id { get; set; }
    }
}
