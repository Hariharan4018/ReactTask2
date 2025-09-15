using AutoMapper;
using Ecommerce.DAL;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Interfaces;
using Ecommerce.Service.DTOs.RequestDTOs;
using Ecommerce.Service.DTOs.ResponceDTOs;
using Ecommerce.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class AuthServices : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthDAL _authDAL;
        private readonly IMapper _mapper;
        public AuthServices(IAuthDAL authDAL, IMapper mapper, IConfiguration configuration)
        {
            _authDAL = authDAL;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<GenericApiResponceDTO<ResponseDTO>> UserRegister(CustomerRegisterDTO customerData)
        {
            var data = await _authDAL.UserRegister(_mapper.Map<Customer>(customerData));
            return new GenericApiResponceDTO<ResponseDTO>
            {
                Message = "Response Success",
                Success = true,
                Data = _mapper.Map<ResponseDTO>(data)
            };
        }
        public async Task<GenericApiResponceDTO<LoginResponceDTO?>> Login(LoginCredentialsDTO loginCredentials)
        {
            var data = await _authDAL.Login<Customer>(loginCredentials.Email, loginCredentials.PasswordHash);
            if (data != null)
            {
                return new GenericApiResponceDTO<LoginResponceDTO?>
                {
                    Message = "Response Success",
                    Success = true,
                    Data = new LoginResponceDTO
                    {
                        AccessToken = GenerateAccessToken(data),
                        RefreshToken = GenerateRefreshToken(data)
                    },
                };
            }
            return new GenericApiResponceDTO<LoginResponceDTO?>
            {
                Message = "No User found",
                Success = false,
                Data = null
            };
        }

        public async Task<GenericApiResponceDTO<LoginResponceDTO?>> AdminLogin(LoginCredentialsDTO loginCredentials)
        {
            var data = await _authDAL.Login<Admin>(loginCredentials.Email, loginCredentials.PasswordHash);
            if (data != null)
            {
                return new GenericApiResponceDTO<LoginResponceDTO?>
                {
                    Message = "Response Success",
                    Success = true,
                    Data = new LoginResponceDTO
                    {
                        AccessToken = GenerateAccessToken(data),
                        RefreshToken = GenerateRefreshToken(data)
                    },
                };
            }
            return new GenericApiResponceDTO<LoginResponceDTO?>
            {
                Message = "No User found",
                Success = false,
                Data = null
            };
        }
        public string GenerateAccessToken(Customer customer)
        {
            return GenerateJwtToken(customer.Name, nameof(Customer), Convert.ToInt32(_configuration["Jwt:AccessTokenExpiryTime"]));
        }
        public string GenerateRefreshToken(Customer customer)
        {
            return GenerateJwtToken(customer.Name, nameof(Customer), Convert.ToInt32(_configuration["Jwt:RefereshTokenExpiryTime"]));
        }
        public string GenerateAccessToken(Admin customer)
        {
            return GenerateJwtToken(customer.Name, nameof(Admin), Convert.ToInt32(_configuration["Jwt:AccessTokenExpiryTime"]));
        }
        public string GenerateRefreshToken(Admin customer)
        {
            return GenerateJwtToken(customer.Name, nameof(Admin), Convert.ToInt32(_configuration["Jwt:RefereshTokenExpiryTime"]));
        }
        public string GenerateJwtToken(string UserName, string Role, int ExpirationTime)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,"token"),
                new Claim(JwtRegisteredClaimNames.Jti,"asd")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(ExpirationTime),
                signingCredentials: creds
             );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
