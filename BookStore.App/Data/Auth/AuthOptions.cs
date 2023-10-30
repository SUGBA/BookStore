using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookStore.App.Data.Auth
{
    public class AuthOptions
    {
        public string? ISSUER; // издатель токена

        public string? AUDIENCE; // потребитель токена

        private string? KEY;   // ключ для шифрации

        public bool ValidateIssuer;

        public bool ValidateAudience;

        public bool ValidateLifetime;

        public bool ValidateIssuerSigningKey;

        public SymmetricSecurityKey SigningCredentials
        {
            get { return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY!)); }
        }
    }
}
