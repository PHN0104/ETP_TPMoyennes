public class Student
{
    public string name;
    public int age;
    public Dictionary<string, List<double>> grades;
    public double mean;

    // constructeur
    public Student(string name, int age, Dictionary<string, List<double>> grades, double mean)
    {
        this.name = name;
        this.age = age;
        this.grades = grades;
        this.mean = mean;
    }

    // get attribut
    public string GetName
    {
        get { return name; }
    }

    public int GetAge
    {
        get { return age; }
    }

    public Dictionary<string, List<double>> GetGrade
    {
        get { return grades; }
    }

    public double GetMean
    {
        get { return mean; }
    }
}
