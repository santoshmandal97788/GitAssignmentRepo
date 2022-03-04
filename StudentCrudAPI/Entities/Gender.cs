namespace StudentCrudAPI.Entities
{
    public class Gender: BaseEntity
    {
        public string GenderName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
