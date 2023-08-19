using Application.Commands;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class UserModifyCommandHandler : IRequestHandler<UserModifyCommand,UserModifyViewModel>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserModifyCommandHandler(IUserService userService, IMapper mapper) {
            _userService = userService;
            _mapper = mapper;
        }

        public Task<UserModifyViewModel> Handle(UserModifyCommand command, CancellationToken cancellationToken)
        {

            User user = _mapper.Map<User>(command);
           
            var result = _userService.UpdateUser(user);
            UserModifyViewModel userModifyViewModel = _mapper.Map<UserModifyViewModel>(result);


            return Task.FromResult(userModifyViewModel);

        }
    }
}
