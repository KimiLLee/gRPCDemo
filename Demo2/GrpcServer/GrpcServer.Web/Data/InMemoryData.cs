using Google.Protobuf.WellKnownTypes;
using GrpcServer.Web.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Web.Data
{
    public class InMemoryData
    {
        public static List<Employee> Employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                No = 1994,
                FirstName = "A",
                LastName = "B",
                MonthSalary = new MonthSalary
                {
                    Basic = 5000f,
                    Bouns = 125.5f
                },
                Status = EmployeeStatus.Normal,
                LastModified = Timestamp.FromDateTime(DateTime.UtcNow)
            },
            new Employee
            {
                Id = 2,
                No = 1999,
                FirstName = "C",
                LastName = "D",
                MonthSalary = new MonthSalary
                {
                    Basic = 4500f,
                    Bouns = 15.5f
                },
                Status = EmployeeStatus.Resigned,
                LastModified = Timestamp.FromDateTime(DateTime.UtcNow)
            },
            new Employee
            {
                Id = 3,
                No = 1995,
                FirstName = "E",
                LastName = "F",
                MonthSalary = new MonthSalary
                {
                    Basic = 12000f,
                    Bouns = 125.5f
                },
                Status = EmployeeStatus.Onvacation,
                LastModified = Timestamp.FromDateTime(DateTime.UtcNow)
            },
        };
    }
}
