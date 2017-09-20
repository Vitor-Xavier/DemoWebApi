using Microsoft.Owin.Security.OAuth;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DemoWebApi.Providers
{
    /// <summary>
    /// Classe que gerencia a geração e validação de tokens.
    /// </summary>
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// Valida autenticação do cliente.
        /// </summary>
        /// <param name="c">COntexto da autenticação.</param>
        /// <returns></returns>
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext c)
        {
            string userId = c.Parameters.Where(f => f.Key == "user_id").Select(f => f.Value).SingleOrDefault()[0];
            c.OwinContext.Set<string>("userId", userId);
            c.Validated();

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Da permissões ao dono da credencial caso sua autenticação seja aprovada.
        /// </summary>
        /// <param name="c">Credenciais da requisição.</param>
        /// <returns></returns>
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext c)
        {
            string uid = c.OwinContext.Get<string>("userId");
            if (ValidateUser(c.UserName, c.Password, uid))
            {
                Claim claim1 = new Claim(ClaimTypes.Name, c.UserName);
                Claim[] claims = new Claim[] { claim1 };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(
                    claims, OAuthDefaults.AuthenticationType);
                c.Validated(claimsIdentity);
            }

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Verifica as crdenciais informadas.
        /// </summary>
        /// <param name="user">Nome de usuário do solicitante.</param>
        /// <param name="pass">Senha do usuário do solicitante.</param>
        /// <returns></returns>
        public bool ValidateUser(string user, string pass, string uid)
        {
            if (user.Equals("tst") && pass.Equals("tst") && uid.Equals("32"))
                return true;
            if (user.Equals("user1") && pass.Equals("pass1") && uid.Equals("15"))
                return true;
            if (user.Equals("testUser") && pass.Equals("1231234") && uid.Equals("78"))
                return true;
            return false;
        }

    }
}