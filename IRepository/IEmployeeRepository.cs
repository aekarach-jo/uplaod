using ImageSaveAndReadCoreMongoDB.Models;

namespace ImageSaveAndReadCoreMongoDB.IRepository
{
    public interface IEmployeeRepository
    {
         Employee Save(Employee employee);

         Employee GetSavedEmployee();

    }
}
