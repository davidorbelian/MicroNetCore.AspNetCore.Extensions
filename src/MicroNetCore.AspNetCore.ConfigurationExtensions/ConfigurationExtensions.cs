using Microsoft.Extensions.Configuration;

namespace MicroNetCore.AspNetCore.ConfigurationExtensions
{
    /// <summary>
    ///     <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> extension methods.
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        ///     Gets "Default" connection string from <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" />.
        /// </summary>
        /// <param name="configuration">
        ///     <see cref="T:Microsoft.Extensions.Configuration.IConfiguration" /> to get the connection
        ///     string from.
        /// </param>
        /// <returns>The "Default" connection string.</returns>
        public static string GetConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("Default");
        }
    }
}