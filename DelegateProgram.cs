using System.IO.Pipes;

namespace ConsoleApp84
{
    public delegate bool IsEligibleforScholarship(Student std);

     public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Marks { get; set; }
        public char SportsGrade { get; set; }

        public static string GetEligibleStudents(List<Student> studentsList,IsEligibleforScholarship isEligible)
        {
            string Result = "";
            foreach (var student in studentsList)
            {
                if (isEligible(student) == true)
                {
                    if (Result == "")
                    {
                        Result +=student.Name;
                    }
                    else
                    {
                        Result += ", " + student.Name;
                    }
                   
                } 
            }
            return Result;
        }
    }
    class Program
    {
        public static bool ScholarshipEligibility(Student std)
        {
            if (std.Marks > 80 && std.SportsGrade == 'A')
            {
                return true;
            }
            return false;
        }
   
        static void Main(string[] args)
        {
            List<Student> lststudents = new List<Student>();
            Student Obj1= new Student() { RollNo = 1 ,Name="Raj",Marks=75,SportsGrade='A'};
            Student Obj2 = new Student() { RollNo = 2, Name = "Rahul", Marks = 82, SportsGrade = 'A' };
            Student Obj3 = new Student() { RollNo = 3, Name = "Kiran", Marks = 89, SportsGrade = 'B' };
            Student Obj4 = new Student() { RollNo = 4, Name = "Sunil", Marks = 86, SportsGrade = 'A' };
            lststudents.Add(Obj1);
            lststudents.Add(Obj2);
            lststudents.Add(Obj3);
            lststudents.Add(Obj4);

            IsEligibleforScholarship del = new IsEligibleforScholarship(ScholarshipEligibility);
            var Result=Student.GetEligibleStudents(lststudents,del);
            Console.WriteLine(Result);
        }
    }
}
