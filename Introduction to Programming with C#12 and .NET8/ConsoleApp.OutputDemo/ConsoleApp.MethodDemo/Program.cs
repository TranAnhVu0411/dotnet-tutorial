// See https://aka.ms/new-console-template for more information

// void methods - completes a task without returning a value
void PrintName() {
    // Method code
    Console.WriteLine("My Name");
}

// value returning methods - returns a value after an operation
int GetFiveYearsAgo(){
    return DateTime.Now.AddYears(-5).Year;
}

// methods with parameters
void PrintNameWithParams(string name){
    Console.WriteLine("Your name is " + name);
}

int GetYearsDifferenceWithParams(int year){
    return DateTime.Now.Year - year;
}

// methods with optional parameters
int GetFutureOrPastYear(int numberOfYears = 0){
    var year = DateTime.Now.AddYears(numberOfYears).Year;
    return year;
}

// methods with nullable parameters
void PrintNameNullableParam(string? name, int? count = 0){
    // if (string.IsNullOrEmpty(name)) {
    //     name = "Default name";
    // }
    // if (!count.HasValue) {
    //     count = 1;
    // }

    // Shorter version
    name ??= "Default name";
    count ??= 1;
    
    for (int i = 0; i < count; i++) {
        Console.WriteLine(name);
    }
}

/* Function Calls */
PrintName(); // void method
Console.WriteLine("5 years ago was: " + GetFiveYearsAgo()); // returning method

Console.WriteLine("Enter your name:");
string name = Console.ReadLine();
PrintNameWithParams(name); // void method with parameters

Console.WriteLine("Enter year:");
int year = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Difference between Now and {year} is: {GetYearsDifferenceWithParams(year)}"); // returning method with parameters

// Optional params
var pastYear1 = GetFutureOrPastYear();
Console.WriteLine("0 years ago was: " + pastYear1);

// Nullable params
PrintNameNullableParam(null, null);