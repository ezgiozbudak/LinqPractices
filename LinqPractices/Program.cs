// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using LinqPractices;
using LinqPractices.DbOperations;


DataGenerator.Initialize();
LinqDbContext _context = new LinqDbContext();
var students = _context.Students.ToList<Student>();

//Find()
Console.WriteLine("****Find ****");
var student = _context.Students.Where(student => student.StudentId == 1).FirstOrDefault();
student = _context.Students.Find(2);
Console.WriteLine(student.Name);

Console.WriteLine();
Console.WriteLine("****FirstOrDefault ****");
student = _context.Students.Where(student => student.Surname == "Arda").FirstOrDefault();
Console.WriteLine(student.Name);

student = _context.Students.FirstOrDefault(x => x.Surname == "Arda");
Console.WriteLine(student.Name);

//SingleOrDefault()
Console.WriteLine();
Console.WriteLine("****SingleOrDefault****");
student = _context.Students.SingleOrDefault(student => student.Name == "Deniz");
Console.WriteLine(student.Surname);

//ToList()
Console.WriteLine();
Console.WriteLine("****ToList****");
var studentList = _context.Students.Where(student => student.ClassId ==2 ).ToList();
Console.WriteLine(studentList.Count);

//OrderBy
Console.WriteLine();
Console.WriteLine("****OrderBy****");
students = _context.Students.OrderBy(X => X.StudentId).ToList();
foreach(var st in students)
{
    Console.WriteLine(st.StudentId+" - "+ st.Name+" + "+st.Surname);
}

//OrderByDescending
Console.WriteLine();
Console.WriteLine("****OrderByDescending****");
students = _context.Students.OrderByDescending(X => X.StudentId).ToList();
foreach(var st in students)
{
    Console.WriteLine(st.StudentId+" - "+ st.Name+" + "+st.Surname);
}

//Anonymous Object Result
Console.WriteLine();
Console.WriteLine("****Anonymous Object Result****");
var anonymousObject = _context.Students.Where(x => x.ClassId ==2).Select(x => new {
    Id = x.StudentId, 
    Fullname = x.Name + " " + x.Surname
});

foreach(var obj in anonymousObject)
{
    Console.WriteLine(obj.Id + " - "+obj.Fullname);
}
