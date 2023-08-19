using Application.Commands;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand>
    {
        private readonly IUserService _service;
        public UserDeleteCommandHandler(IUserService userService) { 
            _service = userService;
        
        }

        public Task Handle(UserDeleteCommand command, CancellationToken cancellationToken)
        {
            
            _service.DeleteUser(command.Id);

            return Task.CompletedTask;


        }
    }
}
