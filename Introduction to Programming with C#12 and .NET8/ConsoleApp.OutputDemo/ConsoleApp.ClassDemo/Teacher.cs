using System.Security.Cryptography;

public class Teacher : Person{
    public void GenerateTeacherIdNumber(){
        _idNumber = "TCH-" + GetRandomNumber();
    }
}