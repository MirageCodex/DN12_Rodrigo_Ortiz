using Hangfire.Server;

namespace HangFireTest.Jobs
{
    public class TestProcess : IBackgroundProcess
    {
        public void Execute(BackgroundProcessContext context) 
        {
            CleanData();
            context.Wait(TimeSpan.FromDays(1));
        }
        private void CleanData() 
        {
            //Limpiar Datos
        }
    }
}
