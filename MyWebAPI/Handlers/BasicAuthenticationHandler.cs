using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace MyWebAPI.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly BookStoresDBContext _context;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> optionsMonitor, ILoggerFactory loggerFactory, UrlEncoder encoder, ISystemClock systemClock, BookStoresDBContext context) 
            : base(optionsMonitor, loggerFactory, encoder, systemClock)
        {
            _context = context;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Authorizatio header is not found");
            try
            {
                var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
                string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
                string userid = credentials[0];
                string password = credentials[1];

                User user = _context.Users.Where(user => user.UserId == userid && user.Password == password).FirstOrDefault();

                if(user == null)
                    AuthenticateResult.Fail("Invalid User id and Password");
                else
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, user.UserId) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }

            }
            catch (Exception e)
            {
                string msg = e.Message;
                return AuthenticateResult.Fail("Error has occured");
            }

           return AuthenticateResult.Fail("");
        }
    }
}
