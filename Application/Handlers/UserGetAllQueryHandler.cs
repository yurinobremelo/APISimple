using Application.Interfaces;
using Application.Models;
using Application.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Handlers
{
    public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, List<UserGetAllViewModel>>
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public UserGetAllQueryHandler(IUserService service, IMapper mapper) 
        {
            _service = service;
            _mapper = mapper;
        }
        public Task<List<UserGetAllViewModel>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            var results = _service.GetAllUsers();

            var userGetAllViewModelList = _mapper.Map<List<UserGetAllViewModel>>(results);
              

            return Task.FromResult(userGetAllViewModelList);
        }
    }
}
