using GradeBook.Enums;
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) :base(name,isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count<5)
            {
                throw new InvalidOperationException("Ranked - grading requires a minimum of 5 students to work");
            }
            int numberOfStudentsWithHigherGrade = 0;
            foreach(var student in Students)
            {
                if (student.AverageGrade > averageGrade)
                    numberOfStudentsWithHigherGrade++;
            }
            if (Students.Count / 5 > numberOfStudentsWithHigherGrade)
                return 'A';
            else if (Students.Count / 5 * 2 > numberOfStudentsWithHigherGrade)
                return 'B';
            else if (Students.Count / 5 * 3 > numberOfStudentsWithHigherGrade)
                return 'C';
            else if (Students.Count / 5 * 4 > numberOfStudentsWithHigherGrade)
                return 'D';
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count<5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count<5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }

        }
    }
}
