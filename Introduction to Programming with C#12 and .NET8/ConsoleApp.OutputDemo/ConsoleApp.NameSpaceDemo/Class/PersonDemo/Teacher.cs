using System.Security.Cryptography;

namespace ConsoleApp.NameSpaceDemo.Class.PersonDemo;
public class Teacher : Person{
    public void GenerateTeacherIdNumber(){
        _idNumber = "TCH-" + GetRandomNumber();
    }
}