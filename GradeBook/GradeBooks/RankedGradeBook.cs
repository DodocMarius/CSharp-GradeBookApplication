using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook:BaseGradeBook
    {
        public RankedGradeBook(string name):base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count<5)
            {
                throw new System.InvalidOperationException("Ranked - grading requires a minimum of 5 students to work");
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
    }
}
