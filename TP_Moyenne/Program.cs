// librairies required
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Microsoft.Data.Analysis;


class Program
{
    static void Main(string[] args)
    {
        // define random
        Random Random = new Random();

        // cursus creation + list of subjects
        List<string> subject_list = new List<string> { "COBOL", "JCL", "DB2", "CICS", "C#", "HTML", "CSS", "XML" };
        Cursus hn_cursus = new Cursus("HN_formation", subject_list, new List<string>());

        // print cursus name
        Console.WriteLine("Cursus en cours : " + hn_cursus.GetName + "\r\n");


        // print subject_list from hn_cursus
        Console.WriteLine("liste des matières du cursus : ");
        hn_cursus.GetSubject_list.ForEach(p => Console.WriteLine("-" + p));
        Console.WriteLine();


        // HNS01 student names list generation
        List<int> indice_subject = new(collection: Enumerable.Range(0, subject_list.Count)); 
        List<int> indice_student = new(collection: Enumerable.Range(0, 20)); // for 20 students
        List<string> student_names = new List<string>();

        indice_student.ForEach(i =>
        {
            student_names.Add("HNS01" + i.ToString("0#"));
        });


        // define Group HNS01
        Group hns01 = new Group("HNS01", new List<Student>(), new List<double>());

        // define grades_list and adequate dictionnary for each subject
        List<double> grades = new List<double>();
        Dictionary<string, List<double>> grades_dict = new Dictionary<string, List<double>>();

        // define all grades_list of all student in group 01
        foreach (var name in student_names)
        {
            grades_dict = new Dictionary<string, List<double>>();

            foreach (var subject in subject_list)
            {
                grades = new List<double>();

                indice_subject.ForEach(i =>
                {
                    int max = 20;
                    double grade = Random.NextDouble() * max;
                    grades.Add(grade);
                });

                grades_dict[subject] = grades;  // key : value attribution
            }

            var mean = grades.Sum() / grades.Count; // mean operation
            //Console.WriteLine(mean);

            hns01.GetStudent_list.Add(new Student(name, Random.Next(10, 14), grades_dict, mean));
            //Console.WriteLine(grades.Sum());
            //Console.WriteLine();
        }

        // print student_list from group obj
        Console.WriteLine("Liste de élèves du groupe HNS01 : ");
        hns01.GetStudent_list.ForEach(p => Console.WriteLine("-" + p.GetName));
        Console.WriteLine();


        // ---------- select your subject and your student --------------
        var chosen = 09;
        var selected = "HTML";
       

        // print student HNS0110 mean in selected subject 

        Console.WriteLine("Moyenne en " + selected + " de l’élève HNS01" + chosen.ToString("0#") + " :");
        var total = hns01.GetStudent_list[chosen].GetGrade[selected].Sum();
        var count = hns01.GetStudent_list[chosen].GetGrade[selected].Count();
        Console.WriteLine((total / count).ToString("0.#0") + "\n");


        // print student HNS0110 global mean 
        total = 0;
        foreach (var kvp in hns01.GetStudent_list[chosen].GetGrade)
        {
            total += kvp.Value.Sum() / kvp.Value.Count();
        }
        Console.WriteLine("Moyenne générale de l’élève HNS01" + chosen.ToString("0#") + " :");
        Console.WriteLine((total / count).ToString("0.#0") + "\n");


        // print group HNS01 global mean
        total = 0;
        double total_G = 0;
        foreach (var p in hns01.GetStudent_list)
        {
            total = 0;
            foreach (var kvp in p.GetGrade)
            {
                total += kvp.Value.Sum() / kvp.Value.Count();
            }
            total_G += total / count;
        }
      
        Console.WriteLine("Moyenne générale du Groupe HNS01");
        Console.WriteLine((total_G / 20).ToString("0.#0") + "\n");

    }
}