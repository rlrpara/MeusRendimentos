using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MeusRendimentos.Infra.Utilities.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string RemoveAcentos(this string valor)
        {
            return !string.IsNullOrEmpty(valor) ? new string(valor.Normalize(NormalizationForm.FormD).Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark).ToArray()).ToUpper() : valor;
        }

        public static string ApenasNumeros(this string valor)
        {
            return !string.IsNullOrEmpty(valor) ? new Regex(@"[^0-9a]").Replace(valor, "").ToString() : valor ;
        }

        public static DateTime AjustaData(this DateTime valor)
        {
            if (DateTime.TryParse(valor.ToString(), out _))
                return Convert.ToDateTime(valor.ToString("yyyy-MM-dd HH:mm:ss"));

            return valor;
        }

        public static string EncodeBase64(this string value)
        {
            return !string.IsNullOrEmpty(value) ? Convert.ToBase64String(Encoding.UTF8.GetBytes(value)) : value;
        }

        public static string DecodeBase64(this string value)
        {
            return !string.IsNullOrEmpty(value) ? Encoding.UTF8.GetString(Convert.FromBase64String(value)) : value;
        }
    }
}
