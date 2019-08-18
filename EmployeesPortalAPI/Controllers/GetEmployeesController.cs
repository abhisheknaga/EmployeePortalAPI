using EmployeesPortalAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Http;

namespace EmployeesPortalAPI.Controllers
{
    public class GetEmployeesController : ApiController
    {
        public EmployeesResponse Get()
        {
            List<Employee> employees = new List<Employee>();
            ErrorResponseModel errorResponse = new ErrorResponseModel();
            EmployeesResponse employeeResponse = new EmployeesResponse();
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml(HttpContext.Current.Server.MapPath("../EmployeesDetails.xml"));
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Employee employee = new Employee();
                    employee.ID = Convert.ToInt16(dr["id"]);
                    employee.Name = dr["name"].ToString();
                    employee.Department = dr["department"].ToString();
                    employee.PrimarySkill = dr["primarySkill"].ToString();
                    employee.ProjectCode = dr["projectCode"].ToString();
                    employee.Location = dr["location"].ToString();

                    employees.Add(employee);
                }
                errorResponse.StatusCode = 0;
                errorResponse.ErrorMessage = "";
                employeeResponse.Response = employees;
                employeeResponse.ErrorResponse = errorResponse;
                return employeeResponse;
            }
            catch (Exception)
            {
                errorResponse.StatusCode = 500;
                errorResponse.ErrorMessage = "Server Error";
                employeeResponse.Response = employees;
                employeeResponse.ErrorResponse = errorResponse;
                return employeeResponse;
            }
        }                   
    }
}
