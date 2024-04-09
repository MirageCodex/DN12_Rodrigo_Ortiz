using GymManager.Core.Staff;
using GymManager.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerApplicationServices.ReportStaff
{
    public class StaffAttendanceAppServices : IStaffAttendanceAppServices
    {
        private readonly IRepository<int, StaffAttendance> _repository;
        public StaffAttendanceAppServices(IRepository<int, StaffAttendance> repository)
        {
            _repository = repository;
        }

        public async Task<List<StaffAttendance>> StaffAttendances()
        {
            return await _repository.GetAll().ToListAsync();
        }
    }
}
