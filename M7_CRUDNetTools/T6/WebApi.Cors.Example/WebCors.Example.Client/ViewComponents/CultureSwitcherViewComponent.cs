using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebCors.Example.Client.Models;

namespace WebCors.Example.Client.ViewComponents
{
    public class CultureSwitcherViewComponent : ViewComponent
    {
        private readonly IOptions<RequestLocalizationOptions> localizateOptions;

        public CultureSwitcherViewComponent(IOptions<RequestLocalizationOptions> localizateOptions)
        {
            this.localizateOptions = localizateOptions;
        }

        public IViewComponentResult Invoke()
        {
            var cultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var model = new CultureSwitcherModel
            {
                SupportedCultures = localizateOptions.Value.SupportedUICultures.ToList(),
                CurrentUICulture = cultureFeature.RequestCulture.UICulture
            };
            return View(model);
        }
    }
}
