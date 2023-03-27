public class Group
{
    public string name;
    public List<Student> student_list;
    public List<double> grades;

    // constructeur
    public Group(string name, List<Student> student_list, List<double> grades)
    {
        this.name = name;
        this.student_list = student_list;
        this.grades = grades;
    }

    // get attribut
    public string GetName
    {
        get { return name; }
    }

    public List<double> GetGrade
    {
        get { return grades; }
    }

    public List<Student> GetStudent_list
    {
        get { return student_list; }
    }
}