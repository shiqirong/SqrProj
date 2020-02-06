﻿using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Sqr.Common.Utils
{
    public static class ConfigUtil
    {
        private static  IConfiguration _config;

        public static IConfiguration Configuration
        {
            get
            {
                if (_config != null) return _config;

                _config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .Add(new JsonConfigurationSource
                    {
                        Path = "appsettings.json",
                        ReloadOnChange = true
                    }).Build();
                return _config;
            }
            set => _config = value;
        }

        /// <summary>
        ///     Gets a configuration sub-section with the specified key.
        /// </summary>
        /// <param name="key">The key of the configuration section.</param>
        /// <returns>The <see cref="T:Microsoft.Extensions.Configuration.IConfigurationSection" />.</returns>
        /// <remarks>
        ///     This method will never return <c>null</c>. If no matching sub-section is found with the specified key,
        ///     an empty <see cref="T:Microsoft.Extensions.Configuration.IConfigurationSection" /> will be returned.
        /// </remarks>
        public static IConfigurationSection GetSection(string key)
        {
            return Configuration?.GetSection(key);
        }


        public static string GetConnectionString(string name)
        {
            return Configuration.GetConnectionString(name);
        }

        /// <summary>
        ///     Gets the immediate descendant configuration sub-sections.
        /// </summary>
        /// <returns>The configuration sub-sections.</returns>
        public static IEnumerable<IConfigurationSection> GetChildren()
        {
            return Configuration?.GetChildren();
        }
    }
}
