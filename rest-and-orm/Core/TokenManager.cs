using DataAccessLayer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace rest_and_orm.Core
{
    public class TokenManager
    {
        private readonly OurContext _context;

        public TokenManager(OurContext context)
        {
            _context = context;
        }

        public string MakeToken(string usernameFromRequest)
        {
            // Korisnik koji zahteva token
            var user = _context.users.Where(user => user.Username == usernameFromRequest).FirstOrDefault();

            // Ako ne postoji u bazi => ne pravimo token
            if (user == null)
                return null;

            // U suprotnom dodajemo Claimove -> hesirana (kljuc => vrednost) struktura 
            // ** Token se sastoji od niza Calimova
            var issuer = "asp_api";
            var secretKey = "nasTajniKljucKojiSluziZaDesifrovanje";
            var claims = new List<Claim> // Jti : "", 
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iss, issuer, ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                new Claim("UserId", user.Id.ToString(), ClaimValueTypes.String, issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(user), ClaimValueTypes.String, issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;


            // Pravimo i konfigurisemo token 
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
