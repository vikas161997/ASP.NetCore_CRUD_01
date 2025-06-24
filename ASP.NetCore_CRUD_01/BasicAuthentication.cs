using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace ASP.NetCore_CRUD_01
{
    public class BasicAuthentication : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthentication(IOptionsMonitor<AuthenticationSchemeOptions>
            options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) 
            : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Authorization header not found.");
            }

            try
            {
                var AuthHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialsBytes = Convert.FromBase64String(AuthHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialsBytes).Split(":");


                var Username = credentials[0];
                var Password = credentials[1];


                if (Username == "vikas" && Password == "0909")
                {
                    var claim = new[] { new Claim(ClaimTypes.Name, Username) };
                    var identity = new ClaimsIdentity(claim, Scheme.Name);
                    var principle = new ClaimsPrincipal(identity);

                    var Ticket = new AuthenticationTicket(principle, Scheme.Name)
    ;
                    return AuthenticateResult.Success(Ticket);
                }
                else
                {
                    return AuthenticateResult.Fail("Invalid Username and Password.");
                }
            }
            catch (Exception ex)
            {
                return AuthenticateResult.Fail("Authentication fail :" + ex.Message);
            }


            
        }

    }
}