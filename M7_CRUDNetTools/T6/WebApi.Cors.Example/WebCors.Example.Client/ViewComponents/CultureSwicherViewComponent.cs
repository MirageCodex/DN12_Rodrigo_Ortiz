using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebCors.Example.Client.Models;

namespace WebCors.Example.Client.ViewComponents
{
    public class CultureSwicherViewComponent:ViewComponent
    {
        private readonly IOptions<RequestLocalizationOptions> localizationOptions;

        public CultureSwicherViewComponent(IOptions<RequestLocalizationOptions> localizationOptions)
        {
            this.localizationOptions = localizationOptions;
        }
        public IViewComponentResult Invoke()
        {
            var cultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var model = new CultureSwicherModel
            {
                SupportedCultures = localizationOptions.Value.SupportedUICultures.ToList(),
                CurrentUICulture = cultureFeature.RequestCulture.UICulture
            };
            return View(model);
        }
    }
}
