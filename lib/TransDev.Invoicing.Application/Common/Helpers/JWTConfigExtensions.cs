namespace TransDev.Invoicing.Application.Common.Helpers;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System.Text;

public static class JWTConfigExtensions
{
    public static SymmetricSecurityKey JWTKey(this IConfiguration config) => new SymmetricSecurityKey(JWTKeyBytes(config));

    private static byte[] JWTKeyBytes(this IConfiguration config) => Encoding.UTF8.GetBytes(config["JWT:Key"]);

    public static string JWTIssuer(this IConfiguration config) => config["JWT:Issuer"];

    public static int JWTExpiresAfterXMinutes(this IConfiguration config) => int.Parse(config["JWT:ExpiresAfterXMinutes"]);
}
