﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sm.Crm.Application.DTOs.Users;
using Sm.Crm.Application.Exceptionss;
using Sm.Crm.Application.Services.Authencation;
using Sm.Crm.Application.Services.Email;
using Sm.Crm.Application.Services.Users;
using Sm.Crm.Application.Tokens;
using Sm.Crm.Domain.Entities;
using System.Text;

namespace Sm.Crm.Infrastructure.Persistence.Services.Authencation
{
    public class AuthService : IAuthService
    {
        readonly HttpClient _httpClient;
        readonly UserManager<User> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly IConfiguration _configuration;
        readonly SignInManager<User> _signInManager;
        readonly IUserService _userService;
        readonly IEmailService _emailService;

        public AuthService(HttpClient httpClient, UserManager<User> userManager, ITokenHandler tokenHandler, IConfiguration configuration, SignInManager<User> signInManager, IUserService userService, IEmailService emailService)
        {
            _httpClient = httpClient;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
            _signInManager = signInManager;
            _userService = userService;
            _emailService = emailService;
        }

        public async Task<Token> LoginAsync(string userNameOrEmail, string password, int accessTokenLifeTime)
        {
            User? user = await _userManager.FindByNameAsync(userNameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(userNameOrEmail);

            if (user == null)
                throw new NotFoundUserExceptions();
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {

                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 5 * 60);
                return token;

            }
            throw new AuthenticationErrorExceptions();
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            User? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(15 * 60, user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 5 * 60);
                return token;
            }
            else
                throw new NotFoundUserExceptions();
        }

        public async Task ResetPasswordAsync(string email)
        {
            User? user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                byte[] tokenBytes = Encoding.UTF8.GetBytes(resetToken);
                resetToken = WebEncoders.Base64UrlEncode(tokenBytes);
                await _emailService.SendPasswordResetMailAsync(email, user.Id.ToString(), resetToken);

            }

         
        }
    }
}
