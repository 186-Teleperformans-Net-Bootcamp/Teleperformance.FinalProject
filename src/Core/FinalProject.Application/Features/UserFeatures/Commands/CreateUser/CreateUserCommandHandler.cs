﻿using FinalProject.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.UserFeatures.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public CreateUserCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser NewUser = new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.Username,
                FirstName = request.Firstname,
                LastName = request.Lastname,
                Email = request.Email,
                RegistrationDate = DateTime.Now,
                isdeleted = false,
            };
            //if(request.IsAdmin)
            //{
            //    await _userManager.AddToRoleAsync(NewUser, "Admin");
            //}
            await _userManager.AddToRoleAsync(NewUser, "User");
            IdentityResult result = await _userManager.CreateAsync(NewUser, request.Password);

            CreateUserCommandResponse response = new() { Success = result.Succeeded };

            if (result.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }
    }
}
