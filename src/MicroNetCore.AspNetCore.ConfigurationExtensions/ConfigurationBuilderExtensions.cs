using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace MicroNetCore.AspNetCore.ConfigurationExtensions
{
    /// <summary>
    ///     <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" /> extension methods.
    /// </summary>
    public static class ConfigurationBuilderExtensions
    {
        private const string SettingsFolder = "Settings";

        private const string JsonExtension = "json";
        private const string XmlExtension = "xml";

        /// <summary>
        ///     Adds JSON and XML configuration sources at <paramref name="path" /> to <paramref name="builder" />.
        /// </summary>
        /// <param name="builder">The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" /> to add to.</param>
        /// <param name="path">
        ///     Path relative to the base path stored in
        ///     <see cref="P:Microsoft.Extensions.Configuration.IConfigurationBuilder.Properties" /> of <paramref name="builder" />.
        /// </param>
        /// <param name="optional">Whether the file is optional.</param>
        /// <param name="reloadOnChange">Whether the configuration should be reloaded if the file changes.</param>
        /// <returns>The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationBuilder" />.</returns>
        public static IConfigurationBuilder AddSettingsFolder(
            this IConfigurationBuilder builder,
            string path = SettingsFolder,
            bool optional = false, bool reloadOnChange = false)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException(nameof(path));

            builder.AddJsonFiles(path, optional, reloadOnChange);
            builder.AddXmlFiles(path, optional, reloadOnChange);

            return builder;
        }

        #region Providers

        private static void AddJsonFiles(this IConfigurationBuilder builder,
            string path, bool optional, bool reloadOnChange)
        {
            var files = Directory
                .GetFiles($"{Directory.GetCurrentDirectory()}\\{path}")
                .GetFileNames()
                .WhereJson(JsonExtension);

            foreach (var jsonFile in files)
                builder.AddJsonFile($"{path}\\{jsonFile}", optional, reloadOnChange);
        }

        private static void AddXmlFiles(this IConfigurationBuilder builder,
            string path, bool optional, bool reloadOnChange)
        {
            var files = Directory
                .GetFiles($"{Directory.GetCurrentDirectory()}\\{path}")
                .GetFileNames()
                .WhereJson(XmlExtension);

            foreach (var jsonFile in files)
                builder.AddXmlFile($"{path}\\{jsonFile}", optional, reloadOnChange);
        }

        #endregion

        #region Helpers

        private static IEnumerable<string> GetFileNames(this IEnumerable<string> files)
        {
            return files.Select(f => f.Split('\\').LastOrDefault());
        }

        private static IEnumerable<string> WhereJson(this IEnumerable<string> fileNames, string extension)
        {
            return fileNames.Where(f => f.HasExtension(extension));
        }

        private static bool HasExtension(this string fileName, string extension)
        {
            var fileExtension = fileName.Split('.').Last();
            return fileExtension.Equals(extension, StringComparison.InvariantCultureIgnoreCase);
        }

        #endregion
    }
}