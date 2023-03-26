using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTesting.BL.Services.Abstractions;
using WebTesting.Domain.DataTransferObjects;
using WebTesting.Domain.Entities;
using WebTesting.Domain.Enums;

namespace WebTesting.BL.Behaviors.Authorization.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, TokenDTO>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJWTService _jwtService;

        public RegisterHandler(UserManager<User> userManager, SignInManager<User> signInManager, IJWTService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }
        public async Task<TokenDTO> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if(await _userManager.FindByEmailAsync(request.Email) is not null)
            {
                throw new Exception("User already exists");
            }
            var user = new User
            {
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Role = Role.SimpleUser
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                var loginUser = await _userManager.FindByEmailAsync(request.Email);

                if (loginUser is not null)
                {
                    var loginResult = await _signInManager.CheckPasswordSignInAsync(loginUser, request.Password, false);

                    if (loginResult.Succeeded)
                    {
                        var token = _jwtService.GenerateToken(loginUser, cancellationToken);

                        return token;
                    }
                }
            }

            throw new Exception(result.Errors.ToArray()[0].Description.ToString());
        }
    }
}
