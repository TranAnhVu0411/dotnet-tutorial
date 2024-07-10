// Define a class
using System.Security.Cryptography;

namespace ConsoleApp.NameSpaceDemo.Class.PersonDemo;
public class Person{
    // Constructor
    public Person(){

    }

    public Person(string firstName, string lastName, DateOnly dob){
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dob;
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
            _taxNumber = GetRandomNumber();
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

    // Protected method (Can be shared in inherited classes)
    protected string GetRandomNumber(){
        return RandomNumberGenerator.GetInt32(10000, 99999).ToString();
    }

    public string GetIdNumber(){
        return _idNumber;
    }

}