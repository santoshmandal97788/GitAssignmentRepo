namespace StudentCrudAPI.Entities
{
    public class Department: BaseEntity
    {
        public string DepartmentName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
