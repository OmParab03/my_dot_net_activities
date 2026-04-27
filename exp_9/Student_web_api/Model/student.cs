namespace Student_web_api.Model;

public class Student
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public required string Email { get; set; }
}