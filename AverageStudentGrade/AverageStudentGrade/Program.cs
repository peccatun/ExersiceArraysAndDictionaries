using System;
using System.Collections.Generic;

namespace AverageStudentGrade
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string student = input[0];
                double grade = double.Parse(input[1]);
                if (students.ContainsKey(student))
                {
                    students[student].Add(grade);
                }
                else if (!students.ContainsKey(student))
                {
                    students.Add(student, new List<double>());
                    students[student].Add(grade);
                }
            }
            foreach (var student in students)
            {
                double sumGrades = 0;
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                    sumGrades += grade;
                }
                Console.Write($"(avg: {sumGrades/student.Value.Count:f2})");
                Console.WriteLine();
            }
        }
    }
}
