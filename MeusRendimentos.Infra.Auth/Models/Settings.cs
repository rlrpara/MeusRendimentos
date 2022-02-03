using System;

namespace MeusRendimentos.Infra.Auth.Models
{
    public static class Settings
    {
        public static string Secret = Environment.GetEnvironmentVariable("Secret");
    }
}
