// See https://aka.ms/new-console-template for more information

using Linq.Examples.Entities;

IList<Student> studentList = new List<Student> {
        new Student() {StudentID = 1, StudentName = "Jhon", Age= 18, StandardID= 1},
        new Student() {StudentID = 2, StudentName = "Steve", Age= 21, StandardID= 1},
        new Student() {StudentID = 3, StudentName = "Bill", Age= 18, StandardID= 2},
        new Student() {StudentID = 4, StudentName = "Ram", Age= 20, StandardID= 2},
        new Student() {StudentID = 5, StudentName = "Ron", Age= 21},
        new Student() {StudentID = 5, StudentName = "Webo", Age= 14}

    };
IList<Standard> standardList = new List<Standard>()
{
    new Standard() {StandardID = 1,StandardName="Standard 1"},
    new Standard() {StandardID = 2,StandardName="Standard 2"},
    new Standard() {StandardID = 3,StandardName="Standard 3"}

};
var test = studentList.Where(x => (x.Age >= 18 && x.StandardID>0) ).Select(x=>x.StudentName);

var teenStudentsName = from s in studentList
                       where s.Age > 12 && s.Age < 20
                       select new { Name2 = s.StudentName };

var studentsGroupByStandar = from s in studentList
                             where s.Age > 12 && s.Age < 20
                             group s by s.StandardID into sg
                             orderby sg.Key
                             select new 
                             { 
                                 StandardID = sg.Key, 
                                  Items = sg 
                             };
var studentWithStandar = from s in studentList
                         join stad in standardList
                         on s.StandardID equals stad.StandardID
                         select new
                         {
                             StudentName = s.StudentName,
                             StandardName = stad.StandardName
                         };

foreach(var element in studentWithStandar)
{
    Console.WriteLine($"Student: {element.StudentName} is in {element.StandardName}");
}


Console.ReadKey();
