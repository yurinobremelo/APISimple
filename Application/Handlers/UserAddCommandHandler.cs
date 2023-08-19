using Application.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    public class UserAddCommandHandler: IRequestHandler<UserAddCommand,Unit>
    {
        private readonly IUserService _service;
        public UserAddCommandHandler(IUserService service)
        {
            _service = service;
        }
        public Task<Unit> Handle(UserAddCommand command, CancellationToken cancellationToken)
        {
            //Precisa implementar mapper
            User user = new()
            {
               Nome = command.Nome,
               Endereco= command.Endereco,
               Numero= command.Numero

            };

            var result = _service.CreateUser(user);
                      
            return Task.FromResult(Unit.Value);

        }

    }
}
