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
                Salary = 2200
            },
            new Employee
            {
                Id = 2,
                No = 1999,
                FirstName = "C",
                LastName = "D",
                Salary = 2300
            },
            new Employee
            {
                Id = 3,
                No = 1995,
                FirstName = "E",
                LastName = "F",
                Salary = 2600
            },
        };
    }
}
