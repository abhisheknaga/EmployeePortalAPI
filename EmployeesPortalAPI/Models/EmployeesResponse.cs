using System.Collections.Generic;

namespace EmployeesPortalAPI.Models
{
    public class EmployeesResponse
    {
        public List<Employee> Response { get; set; }
        public ErrorResponseModel ErrorResponse { get; set; }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string PrimarySkill { get; set; }
        public string ProjectCode { get; set; }
        public string Location { get; set; }
    }

    public class ErrorResponseModel
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}