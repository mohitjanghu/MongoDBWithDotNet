using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDBWithDotNet.Models
{
    public class MongoContext
    {

        private IMongoDatabase db;
        public MongoContext()
        {
            MongoClient server = new MongoClient("mongodb://liam:liam123@ds151707.mlab.com:51707/learn");
            db = server.GetDatabase("learn");
            //db.GetCollection<Designations>("Designations").InsertMany(
            //    new Designations[]
            //    {
            //         new Designations { Name = "Software Developer" ,Department="IT"}
            //        ,new Designations { Name = "Account Manager",Department="Finance" }
            //    });
        }

        public IMongoCollection<Employee> Employees { get { return db.GetCollection<Employee>("Employees"); } }

        public IList<Employee> GetAllEmployees()
        {
            return db.GetCollection<Employee>("Employees").AsQueryable().Where(x => x.Name == "Mohit").ToList();
        }
        public bool UpdateEmployee(string EmployeeName)
        {
            var filter = Builders<Employee>.Filter.Eq("Name", EmployeeName);
            var update = Builders<Employee>.Update.Set("Salary", 4500M);
            Employees.UpdateOne(filter, update);
            return true;
        }
        public Tuple<string, string> GetEmployeeDepartment(string employeeName)
        {
            var employees = db.GetCollection<Employee>("Employees").AsQueryable();
            var designations = db.GetCollection<Designations>("Designations").AsQueryable();

            var query = (from e in employees
                         join d in designations on e.Designation equals d.Name
                         where e.Name == employeeName
                         select new
                         {
                             EmployeeName = e.Name,
                             Department = d.Department
                         }).First();
            return new Tuple<string, string>(query.EmployeeName.ToString(), query.Department.ToString());
        }
    }
}