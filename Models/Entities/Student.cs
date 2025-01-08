namespace UnderstandingMVC.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Branch { get; set; }
        public int Semester { get; set; }
        public double Result { get; set; }
        public string Address { get; set; }
    }
}
