using Microsoft.AspNetCore.Identity;
using Sm.Crm.Application.DTOs.Users;
using Sm.Crm.Application.Services.Users;
using Sm.Crm.Domain.Entities;
using Sm.Crm.Application.Features.Commands.Users.CreateUser;
using Sm.Crm.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Sm.Crm.Application.Repositories.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Sm.Crm.Application.DTOs.Customers;

namespace Sm.Crm.Infrastructure.Persistence.Services.Users
{
    public class UserService : IUserService
    {


        readonly UserManager<User> _userManager;      
        readonly IMapper _mapper;
        readonly IUserCommandRepository _commandRepository;
        readonly IUserQueryRepository _userQueryRepository;
              

        public UserService(UserManager<User> userManager,IMapper mapper, IUserCommandRepository commandRepository, IUserQueryRepository userQueryRepository)
        {
            _userManager = userManager;            
            _mapper = mapper;
            _commandRepository = commandRepository;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<CreateUserCommandResponse> CreateUserAsync(UserCreateDto userCreate)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                //Id = new(),
                Name= userCreate.Name,
                Surname = userCreate.Surname,
                UserName = userCreate.UserName,
                PhoneNumber = userCreate.PhoneNumber,
                Email = userCreate.Email

            }, userCreate.Password);
            CreateUserCommandResponse response = new() { Succeeded = result.Succeeded };
            if (result.Succeeded)
                response.Message = "Yeni kullanıcı kaydı başarılı bir şekilde gerçekleşti.";
            else
            {
                foreach(var error in result.Errors)
                {
                    response.Message += $"{error.Description} - {error.Code}<br>";
                }
            }
            return response;
                    

        }

        public async Task<UserReadDto> GetUserByIdAsync( int userId)
        {
            var result = await _userQueryRepository.GetById(userId);
            var map = _mapper.Map<UserReadDto>(result);
            return map;
        }

        public async Task<List<UserReadDto>> GetUserAllAsync()
        {
            //List<Customer> customers = await _customerQueryRepository.GetAll();
            //List<ReadCustomerDto> result = new List<ReadCustomerDto>();
            //foreach (var customer in customers)
            //{
            //    result.Add(_mapper.Map<ReadCustomerDto>(customer));
            //}
            //return result;
            List<User> users = await _userQueryRepository.GetAll();
            List<UserReadDto> result = new List<UserReadDto>();
            foreach(var user in users.ToList())
            {
                result.Add(_mapper.Map<UserReadDto>(user));
            }
            return result;
            //var users = await _userQueryRepository.GetAll();            
            //var map = _mapper.Map<List<UserReadDto>>(users);         
            //return map;
           

        }
        public async Task<IdentityResult> UpdateUserAsync(UserUpdateDto userCreate)
        {
            User? user = await _userQueryRepository.GetById(userCreate.Id);
            
           
                user.Name = userCreate.Name;
                user.Surname = userCreate.Surname;
                user.UserName = userCreate.UserName;
                user.Email = userCreate.Email;
                user.PhoneNumber = userCreate.PhoneNumber;
                //await _commandRepository.Update(user);
                //user.PasswordHash = userCreate.Password;
                var result = await _userManager.UpdateAsync(user);
                return result;
           
            


        
        }

        //public Task<string> GetUserRoleAsync(UserReadDto user)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
