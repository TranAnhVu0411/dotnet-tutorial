// See https://aka.ms/new-console-template for more information

// Declare Fixed Size Array
int[] grades = new int[5];

// Add values to Fixed Size Array
// grades[0] = 45;
// grades[1] = 50;
// grades[2] = 45;
// grades[3] = 50;
// grades[4] = 45;

for (int i = 0; i < grades.Length; i++) {
    Console.WriteLine("Enter grade: ");
    grades[i] = Convert.ToInt32(Console.ReadLine());
}

// Print values in Fixed Size Array
Console.WriteLine("Your grades you entered are: ");
for (int i = 0; i < grades.Length; i++) {
    Console.WriteLine(grades[i]);
}

// Declare Variable Sized Array
string[] studentNames = new string[] { "A", "B", "C", "D", "E", "F" };

// Add values to Variable Sized Array
for (int i = 0; i < studentNames.Length; i++) {
    Console.WriteLine("Enter name: ");
    studentNames[i] = Console.ReadLine();
}

// Print values in Variable Sized Array
Console.WriteLine("Your names you entered are: ");
for (int i = 0; i < studentNames.Length; i++) {
    Console.WriteLine(studentNames[i]);
}