using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace DistroGuide.Presentation.Api.Configuration
{
    public static class CultureConfiguration
    {
        public static void UseCustomRequestLocalization(this IApplicationBuilder app, IConfiguration configuration)
        {
            var supportedUICultures = configuration
                .GetSection("SupportedUICultures")
                .AsEnumerable()
                .Where(s => s.Value != null)
                .Select(s => s.Value)
                .Distinct()
                .ToArray();

            var defaultUICulture = configuration["DefaultUICulture"];

            app.UseRequestLocalization(opt =>
            {
                opt.AddSupportedUICultures(supportedUICultures);
                opt.DefaultRequestCulture = new RequestCulture(defaultUICulture);
            });
        }
    }
}
