using Application.Commands;
using Application.Interfaces;
using Application.Models;
using Application.Queries;
using Application.Responses;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class UserGetByIdQueryHandler : IRequestHandler<UserGetByIdQuery,UserGetByIdViewModel>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserGetByIdQueryHandler(IUserService uservice, IMapper mapper) { 
            _userService = uservice;
            _mapper = mapper;
        }
       
        public Task<UserGetByIdViewModel> Handle(UserGetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _userService.GetUserById(request.Id);

           // UserGetByIdViewModel userGetByIdViewModel = _mapper.Map<UserGetByIdViewModel>(result);
           
            return Task.FromResult(_mapper.Map<UserGetByIdViewModel>(result));
        }
    }
}
