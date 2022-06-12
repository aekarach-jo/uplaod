

using ImageSaveAndReadCoreMongoDB.IRepository;
using ImageSaveAndReadCoreMongoDB.Models;
using MongoDB.Driver;
using System;
using System.Linq;

namespace ImageSaveAndReadCoreMongoDB.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private MongoClient _mongoClient = null;
        private IMongoDatabase _database = null;
        private IMongoCollection<Employee> _employeeTable = null;

        public EmployeeRepository()
        {
            _mongoClient = new MongoClient("mongodb+srv://ekaratxx1:aspirine007mn@cluster0.sx1ez.mongodb.net/test");
            _database = _mongoClient.GetDatabase("OfficeDB");
            _employeeTable = _database.GetCollection<Employee>("Employees");
        }
        public Employee GetSavedEmployee()
        {
            return _employeeTable.Find(FilterDefinition<Employee>.Empty).ToList().FirstOrDefault();
        }

        public Employee Save(Employee employee)
        {
            var empObj = _employeeTable.Find(x => x.Id == employee.Id).FirstOrDefault();
            if(empObj == null)
            {
                _employeeTable.InsertOne(employee);
            }
            else
            {
                _employeeTable.ReplaceOne(x => x.Id == employee.Id, employee);
            }
            return employee;
        }


    }
}
