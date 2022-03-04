namespace StudentCrudAPI.Entities
{
    public class Student: BaseEntity
    {
        public string FirstName { get; set; }
        public string lastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
