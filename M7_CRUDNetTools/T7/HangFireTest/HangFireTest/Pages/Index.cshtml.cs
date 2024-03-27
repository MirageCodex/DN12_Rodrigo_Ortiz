using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HangFireTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public void OnPost() 
        {
            var jobId = BackgroundJob.Enqueue(
                () => Helper.DBHelper.Process(30000,"Proceso en fila"));
            var job2 = BackgroundJob.ContinueJobWith(jobId,
                () => Helper.DBHelper.Process(10000, "Proceso en fila 2"));
            BackgroundJob.Enqueue(
                () => Helper.DBHelper.Process(1000, "Proceso en fila 3"));

        }
    }
}
