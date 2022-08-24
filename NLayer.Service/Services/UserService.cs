using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NLayer.Core.DTOs;
using NLayer.Core.EntityModels;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWork;
using NLayer.Service.Mapping;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class UserService : Service<UserApp>,IUserService
    {
        private readonly UserManager<UserApp> _userManager;

        public UserService(UserManager<UserApp> userManager,IGenericRepository<UserApp> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(CreateUserDto createUserDto)
        {
            var User = new UserApp() { Email = createUserDto.Email, UserName = createUserDto.UserName };
            var Result = await _userManager.CreateAsync(User, createUserDto.Password);
            return Result;
            
        }


        async Task<CustomResponseDto<UserDto>> IUserService.GetUserByNameAsync(string username)
        {
            var User = await _userManager.FindByNameAsync(username);
            if (User == null)
            {
                return CustomResponseDto<UserDto>.Fail(404, "User name not found");
            }
            return CustomResponseDto<UserDto>.Success(200, ObjectMapper.Mapper.Map<UserDto>(User));
        }
        
    }
}
