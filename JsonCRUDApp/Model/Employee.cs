namespace JsonCRUDApp.Model
{
    public class Employee
    {
        public string Id { get; set; }
        public string? lastName { get; set; }
        public List<string>? skills { get; set; }
        public string? Age { get; set; }
        public string? firstName { get; set; }
    }
}
