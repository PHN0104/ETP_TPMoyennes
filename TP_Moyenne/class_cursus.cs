using System;

public class Cursus
{
    public string name;
    public List<string> subject_list;
    public List<string> group_list;

    // constructeur
    public Cursus(string name, List<string> subject_list, List<string> group_list)
    {
        this.name = name;
        this.subject_list = subject_list;
        this.group_list = group_list;
    }

    // get attribut
    public string GetName
    {
        get { return name; }
    }

    public List<string> GetSubject_list
    {
        get { return subject_list; }
    }

    public List<string> GetGroup_list
    {
        get { return group_list; }
    }
}


