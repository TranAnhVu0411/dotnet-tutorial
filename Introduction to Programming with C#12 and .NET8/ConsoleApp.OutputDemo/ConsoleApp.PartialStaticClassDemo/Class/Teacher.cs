using ConsoleApp.PartialStaticClassDemo.Util;

namespace ConsoleApp.PartialStaticClassDemo.Class;
public class Teacher : Person{
    public void GenerateTeacherIdNumber(){
        _idNumber = PersonHelper.GenerateIdNumber("TCH-");
    }
}