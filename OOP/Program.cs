using System;

public class Student
{
    private string name;
    private double score;
    private static int totalStudents = 0;

    public Student(string name, double score)
    {
        this.name = name;
        this.score = score;
        totalStudents++;
    }

    // Instance Methods
    public string GetName()
    {
        return this.name;
    }

    public double GetScore()
    {
        return this.score;
    }

    public bool IsPassed()
    {
        return this.score > 5.0; 
    }

    public string GetClassification()
    {
        if (this.score >= 8.0) { return "Excellent"; }
        else if (this.score >= 6.5) { return "Good";)}
        else if (this.score >= 5.0) { return "Average"; }
        else { return "Weak";)}


        // Static Methods 

public static int GetTotalStudents()
    {
        return totalStudents;
    }

    public static Student FindTopStudent(Student[] students)
    {
        Student topStudent = students[0];

        for (int i = 1; i < students.Length; i++)
        {
            if (students[i].GetScore() > topStudent.GetScore())
            {
                topStudent = students[i];
            }
        }

        return topStudent;
    }

    public static double CalculateAverageScore(Student[] students)
    {
        double sum = 0;

        for (int i = 0; i < students.Length; i++)
        {
            sum += students[i].GetScore();
        }

        return sum / students.Length;
    }
}
  class Program
{
    static void Main(string[] args)
    {

        // 5.1 Tạo mảng ít nhất 5 Student
        Student[] students =
        {
new Student("Nguyen Van Teo", 8.5),
new Student("Tran Thi Det", 7.0),
new Student("Le Van Tam", 5.5),
new Student("Pham Thi Ti", 4.0),
new Student("Hoang Van Tun", 9.0)
};


        // 5.2 In tổng số Student
        Console.WriteLine("Total students: "
        + Student.GetTotalStudents());


        // 5.3 In danh sách Student
        Console.WriteLine("Student List:");

        for (int i = 0; i < students.Length; i++)
        {
            Console.WriteLine(
            "Name: " + students[i].GetName()
            + " | Score: " + students[i].GetScore()
            + " | Classification: " + students[i].GetClassification()
            + " | Passed: " + students[i].IsPassed()
            );
        }


        // 5.4 Tìm Student có điểm cao nhất
        Student topStudent = Student.FindTopStudent(students);

        Console.WriteLine("Top Student:");
        Console.WriteLine(
        topStudent.GetName()
        + " - "
        + topStudent.GetScore()
        );


        // 5.5 Tính điểm trung bình cả lớp
        double average = Student.CalculateAverageScore(students);

        Console.WriteLine("Class Average Score: "
        + average.ToString("F2"));
    }
}
