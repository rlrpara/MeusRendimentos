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
            return !string.IsNullOrEmpty(valor) ? new Regex(@"[^0-9]").Replace(valor, "").ToString() : valor ;
        }

        public static string ApenasTexto(this string valor)
        {
            return string.Join("", Regex.Split(valor.RemoveAcentos(), @"[^\w ]"));
        }

        public static string EncodeBase64(this string value)
        {
            return !string.IsNullOrEmpty(value) ? Convert.ToBase64String(Encoding.UTF8.GetBytes(value)) : value;
        }

        public static string DecodeBase64(this string value)
        {
            return !string.IsNullOrEmpty(value) ? Encoding.UTF8.GetString(Convert.FromBase64String(value)) : value;
        }

        public static string ToUrl(this string value)
        {
            return Regex.Replace(value.ApenasTexto(), @"\s+", "-")
                .ToLower();
        }
    }
}
