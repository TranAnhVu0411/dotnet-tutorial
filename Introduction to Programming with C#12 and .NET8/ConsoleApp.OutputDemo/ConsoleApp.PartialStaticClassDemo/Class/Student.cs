using ConsoleApp.PartialStaticClassDemo.Util;

namespace ConsoleApp.PartialStaticClassDemo.Class;
public class Student : Person{
    public void GenerateStudentIdNumber(){
        _idNumber = PersonHelper.GenerateIdNumber("STU-");
    }
}