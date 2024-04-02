using System.Globalization;

namespace WebCors.Example.Client.Models
{
    public class CultureSwitcherModel
    {
        public CultureInfo CurrentUICulture { get; set; }

        public List<CultureInfo> SupportedCultures { get; set; }
    }
}
