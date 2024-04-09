using GymManager.Core.EquipmentTypes;
using GymManager.Core.Members;
using GymManager.Core.MembershipType;
using GymManager.Core.Staff;
using GymManager.DataAccess;
using GymManager.DataAccess.Repositories;
using GymManagerApplicationServices.EquipmentTypes;
using GymManagerApplicationServices.Members;
using GymManagerApplicationServices.MembershipTypes;
using GymManagerApplicationServices.Navigation;
using GymManagerApplicationServices.ReportStaff;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.AspNetCore;
using Serilog.Extensions.Hosting;
using System;

namespace GymManager.UnitTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GymManagerContext>(options => options.UseInMemoryDatabase("DataTest"));

            services.AddTransient<IMembersAppService, MembersAppService>();
            services.AddTransient<IMembershipTypesAppService, MembershipTypesAppService>();
            services.AddTransient<IEquipmentTypeAppService, EquipmentTypeAppService>();
            services.AddTransient<IStaffAttendanceAppServices, StaffAttendanceAppServices>();
            services.AddTransient<IMenuAppService, MenuAppService>();
            services.AddTransient<IRepository<int, Member>, MembersRepository>();
            services.AddTransient<IRepository<int, MembershipType>, MembershipTypeRepository>();
            services.AddTransient<IRepository<int, EquipmentType>, EquipmentTypeRepository>();
            services.AddTransient<IRepository<int, StaffAttendance>, Repository<int, StaffAttendance>>();

            services.AddControllers();
            services.AddRouting();
            services.AddAuthorization();

          
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
