using GymManager.Core.Staff;
using GymManager.DataAccess.Reports;
using GymManagerApplicationServices.ReportStaff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Reporting.NETCore;
using Wkhtmltopdf.NetCore;

namespace GymManager.Web.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IGeneratePdf _generatePdf;
        private readonly IWebHostEnvironment _environment;
        private readonly IStaffAttendanceAppServices _staffAttendanceAppServices;
        public ReportsController(IWebHostEnvironment environment, IGeneratePdf generatePdf, IStaffAttendanceAppServices staffAttendanceAppServices)
        {
            _generatePdf = generatePdf;
            _environment = environment;
            _staffAttendanceAppServices = staffAttendanceAppServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewMembers()
        {
            string path = System.IO.Path.Combine(_environment.ContentRootPath, "Reports\\NewMembers.rdlc");
            Stream reportDefinition = System.IO.File.OpenRead(path);

            LocalReport report = new LocalReport();
            report.EnableExternalImages = true;
            report.LoadReportDefinition(reportDefinition);

            MembersDataSet dataSet = new MembersDataSet();
            Random random = new Random();
            string[] membershipTypes = new string[] { "Basic", "Family", "Gold" };
            for (int i = 0; i < 28; i++)
            {
                MembersDataSet.MemberRow row = dataSet.Member.NewMemberRow();
                row.Name = $"Member Perez {i}";
                int day = random.Next(1, 10) * -1;
                int membershipIndex = random.Next(0, 2);

                row.RegisteredOn = DateTime.Today.AddDays(day);
                row.MembershipType = membershipTypes[membershipIndex];

                dataSet.Member.Rows.Add(row);
            }

            byte[] streamBytes = null;
            string mimeType = "";
            string encoding = "";
            string filenameExtension = "";
            string reportName = "NewMembers";
            string[] streamids = null;
            Warning[] warnings = null;

            report.SetParameters(new ReportParameter[] { 
             new ReportParameter("DateFrom", DateTime.Today.AddDays(-10).ToString()),
             new ReportParameter("DateTo", DateTime.Today.ToString())});
           

            report.DataSources.Add(new ReportDataSource("Members", (System.Data.DataTable)dataSet.Member));

            streamBytes = report.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids,out warnings);

            return File(streamBytes,mimeType,$"{reportName}.{filenameExtension}");
        }
        public async Task<IActionResult> Attendance()
        {
            string path = System.IO.Path.Combine(_environment.ContentRootPath, "Reports\\StaffAttendance.rdlc");
            Stream reportDefinition = System.IO.File.OpenRead(path);

            LocalReport report = new LocalReport();
            report.EnableExternalImages = true;
            report.LoadReportDefinition(reportDefinition);

            List<StaffAttendance> attendances = await _staffAttendanceAppServices.StaffAttendances();
            StaffDataSet dataSet = new StaffDataSet();

            foreach (var attendance in attendances)
            {
                StaffDataSet.staffattendancesRow row = dataSet.staffattendances.NewstaffattendancesRow();
                row.AttendanceId = attendance.AttendanceId;
                row.StaffName = attendance.StaffName;
                row.Monday = attendance.Monday;
                row.Tuesday = attendance.Tuesday;
                row.Wednesday = attendance.Wednesday;
                row.Thursday = attendance.Thursday;
                row.Friday = attendance.Friday;
                row.TotalAttendance = attendance.TotalAttendance;
                dataSet.staffattendances.Rows.Add(row);
            }
           

            byte[] streamBytes = null;
            string mimeType = "";
            string encoding = "";
            string filenameExtension = "";
            string reportName = "StaffAttendance";
            string[] streamids = null;
            Warning[] warnings = null;

            report.DataSources.Add(new ReportDataSource("staffattendances",(System.Data.DataTable)dataSet.staffattendances));
            streamBytes = report.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            return File(streamBytes, mimeType, $"{reportName}.{filenameExtension}");
        }
    }
}
