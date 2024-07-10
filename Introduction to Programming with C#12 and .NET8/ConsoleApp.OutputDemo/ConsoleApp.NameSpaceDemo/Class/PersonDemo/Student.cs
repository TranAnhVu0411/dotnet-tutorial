using System.Security.Cryptography;

namespace ConsoleApp.NameSpaceDemo.Class.PersonDemo;
public class Student : Person{
    public void GenerateStudentIdNumber(){
        _idNumber = "STU-" + GetRandomNumber();
    }
}