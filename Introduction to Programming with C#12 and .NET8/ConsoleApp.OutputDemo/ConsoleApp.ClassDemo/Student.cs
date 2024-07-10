using System.Security.Cryptography;

public class Student : Person{
    public void GenerateStudentIdNumber(){
        _idNumber = "STU-" + GetRandomNumber();
    }
}