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

namespace WebTesting.BL.Behaviors.Authorization.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, TokenDTO>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJWTService _jwtService;

        public LoginHandler(SignInManager<User> signInManager, IJWTService jwtService, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _jwtService = jwtService;
            _userManager = userManager;
        }

        public async Task<TokenDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
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

                throw new Exception("Wrong password");
            }

            throw new Exception("User not found");
        }
    }
}
