using Duende.IdentityServer.Models;
using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.Model;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace GeekShopping.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly SqlServerContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(SqlServerContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(IdentityConfiguration.ADMIN).Result != null) return;

            _roleManager.CreateAsync(new IdentityRole(IdentityConfiguration.ADMIN)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(IdentityConfiguration.CLIENT)).GetAwaiter().GetResult();

            ApplicationUser admin = new()
            {
                UserName = "guilherme-admin",
                Email = "guilherme@email.com.br",
                EmailConfirmed = true,
                PhoneNumber = "5599999999999",
                FirstName = "Guilherme",
                LastName = "Ferrari"
            };

            _userManager.CreateAsync(admin, "Abc123@").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(admin, IdentityConfiguration.ADMIN).GetAwaiter().GetResult();

            var adminClaims = _userManager.AddClaimsAsync(admin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.ADMIN)
            }).Result;

            ApplicationUser client = new()
            {
                UserName = "guilherme-client",
                Email = "guilherme@email.com.br",
                EmailConfirmed = true,
                PhoneNumber = "5599999999999",
                FirstName = "Guilherme",
                LastName = "Ferrari"
            };

            _userManager.CreateAsync(client, "Abc123@").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(client, IdentityConfiguration.CLIENT).GetAwaiter().GetResult();

            var clientClaims = _userManager.AddClaimsAsync(client, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                new Claim(JwtClaimTypes.GivenName, client.FirstName),
                new Claim(JwtClaimTypes.FamilyName, client.LastName),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.CLIENT)
            }).Result;
        }
    }
}
