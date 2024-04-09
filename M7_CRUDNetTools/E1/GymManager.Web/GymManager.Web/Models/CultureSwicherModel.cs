using System.Globalization;

namespace GymManager.Web.Models
{
    public class CultureSwicherModel
    {
        public CultureInfo CurrentUICulture { get; set; }
        public List<CultureInfo> SupportedCultures { get; set; }
    }
}
