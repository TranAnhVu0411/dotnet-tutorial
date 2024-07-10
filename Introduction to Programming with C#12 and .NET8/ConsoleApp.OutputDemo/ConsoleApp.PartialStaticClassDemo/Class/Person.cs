// Define a class
using ConsoleApp.PartialStaticClassDemo.Util;

namespace ConsoleApp.PartialStaticClassDemo.Class;
public partial class Person{
    // Constructor
    public Person(){

    }

    public Person(string firstName, string lastName, string taxNumber){
        FirstName = firstName;
        LastName = lastName;
        _taxNumber = taxNumber;
    }

    // properties
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    // Private field (Cannot be shared in inherited classes)
    private string _taxNumber;
    // Protected field (Can be shared in inherited classes)
    protected string _idNumber = "N/A"; // Default value if not assigned

    public void PrintFullName(){
        Console.WriteLine($"{FirstName} {LastName}");
    }

    public void GenerateTaxNumber(){
        if (string.IsNullOrEmpty(_taxNumber)){
            _taxNumber = PersonHelper.GenerateIdNumber("");
        } else {
            Console.WriteLine("Tax Number already exists");
        }
    }

    public string GetTaxNumber(){
        return _taxNumber;
    }

    // Method overloading
    public int GetAge(){
        var age = DateTime.Now.Year - DateOfBirth.Year;
        return age;
    }

    public int GetAge(int year){
        var age = year - DateOfBirth.Year;
        return age;
    }

    public string GetIdNumber(){
        return _idNumber;
    }

}