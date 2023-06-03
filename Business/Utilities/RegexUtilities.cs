using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RegistroUsuarios
{
    public class RegexUtilities
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsValidPassword(string password)
        {
            // Al menos una mayúscula
            if (!Regex.IsMatch(password, "[A-Z]"))
                return false;

            // Al menos una minúscula
            if (!Regex.IsMatch(password, "[a-z]"))
                return false;

            // Al menos un símbolo
            if (!Regex.IsMatch(password, "[!@#$%^&*()]"))
                return false;

            // Al menos un número
            if (!Regex.IsMatch(password, "[0-9]"))
                return false;

            // Longitud mínima de 10 caracteres
            if (password.Length < 10)
                return false;

            return true;
        }
    }
}