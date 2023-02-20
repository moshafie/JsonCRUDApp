using JsonCRUDApp.Model;
using JsonCRUDApp.Model.ViewModels;
using System.Text.Json;

namespace JsonCRUDApp.Exctensions
{
    public class JSONCRUDExtensions
    {
        //create extension crud operation to json file
        public static void Create( string path, Employee obj)
        {
            string text = System.IO.File.ReadAllText(path);
            var employee = JsonSerializer.Deserialize<Employees>(text);
            employee.employees.Add(obj);
            string json = JsonSerializer.Serialize(employee);
            System.IO.File.WriteAllText(path, json);
        }
        //read data from json file
        public static Employees Read(string path)
        {
            string text = System.IO.File.ReadAllText(path);
            var employee = JsonSerializer.Deserialize<Employees>(text);
            return employee;
        }
        //get object from json file by id
        public static Employee Get(string path, string id)
        {
            string text = System.IO.File.ReadAllText(path);
            var employee = JsonSerializer.Deserialize<Employees>(text);
            var emp = employee.employees.Find(x => x.Id == id);
            return emp;
        }
        //Edit json file 
        public static void Edit(string path, Employee obj)
        {
            string text = System.IO.File.ReadAllText(path);
            var employee = JsonSerializer.Deserialize<Employees>(text);
            var emp = employee.employees.Find(x => x.Id == obj.Id);
            emp.firstName = obj.firstName;
            emp.lastName = obj.lastName;
            emp.Age = obj.Age;
            string json = JsonSerializer.Serialize(employee);
            System.IO.File.WriteAllText(path, json);
        }
        //delete data from json file
        public static void Delete(string path, string id)
        {
            string text = System.IO.File.ReadAllText(path);
            var employee = JsonSerializer.Deserialize<Employees>(text);
            var emp = employee.employees.Find(x => x.Id == id);
            employee.employees.Remove(emp);
            string json = JsonSerializer.Serialize(employee);
            System.IO.File.WriteAllText(path, json);
        }




    }
}
