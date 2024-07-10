// See https://aka.ms/new-console-template for more information

// Declare a List
List<int> grades = new List<int>();
// Other ways to declare a List
// var grades = new List<int>();
// List<int> grades = new();

// Add values to List
// grades.Add(45);
// grades.Add(95);

int grade;
do
{
    Console.Write("Enter grade:");
    grade = Convert.ToInt32(Console.ReadLine());
    if (grade != -1){
        grades.Add(grade);
    }
} while (grade != -1);

// Print values in list - for
Console.WriteLine("Print using for loop:");
for (int i = 0; i < grades.Count; i++) {
    Console.WriteLine(grades[i]);
}

// Print values in list - foreach
Console.WriteLine("Print using foreach loop:");
foreach (var item in grades){
    Console.WriteLine(item);
}