using FinalProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Interfaces.Services
{
    public interface IGenerateToken
    {
        Token CreateAccessToken(int minute, List<Claim> claims);
    }
}
