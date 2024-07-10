// See https://aka.ms/new-console-template for more information

// Define an obj type Person
// Person baby; // This will be null by default

Person person = new Person();
person.LastName = "Thompson";
person.FirstName = "Theresa";
person.DateOfBirth = new DateOnly(2022, 10, 29);

// Console.WriteLine($"{person.FirstName} {person.LastName}");
person.PrintFullName();

person.GenerateTaxNumber();
var taxNumber = person.GetTaxNumber();
Console.WriteLine(taxNumber);

var person1 = new Person("Dev", "One", new DateOnly(2022, 10, 29));
person1.PrintFullName();

var person2 = new Person("Dev", "Two", "12234");
person2.PrintFullName();
person2.GenerateTaxNumber();
var person2IdNumber = person2.GetIdNumber();
Console.WriteLine(person2IdNumber);

var teacher = new Teacher();
teacher.LastName = "Thompson";
teacher.FirstName = "Theresa";
teacher.DateOfBirth = new DateOnly(2022, 10, 29);
teacher.PrintFullName();
teacher.GenerateTeacherIdNumber();
var teacherIdNumber = teacher.GetIdNumber();
Console.WriteLine(teacherIdNumber);

Student student = new();
student.LastName = "Thompson";
student.FirstName = "Theresa";
student.DateOfBirth = new DateOnly(2022, 10, 29);
student.PrintFullName();
student.GenerateStudentIdNumber();
var studentIdNumber = student.GetIdNumber();
Console.WriteLine(studentIdNumber);