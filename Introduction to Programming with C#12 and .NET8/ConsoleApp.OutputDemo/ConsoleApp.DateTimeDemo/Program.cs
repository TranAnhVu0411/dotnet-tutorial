// See https://aka.ms/new-console-template for more information

using System.Globalization;

Console.WriteLine("DATETIME MANIPULATION");
// Empty DateTime object
DateTime dateTime = new DateTime();

// Create a DateTime from date and time
var dateOfBirth = new DateTime(2000, 11, 4);
Console.WriteLine($"My DOB is: {dateOfBirth}");

var exactDateAndTimeOfBirth = new DateTime(2000, 11, 4, 12, 3, 4, DateTimeKind.Local);
Console.WriteLine($"My DTOB is: {exactDateAndTimeOfBirth}");

Console.WriteLine($"Day of Week: {dateOfBirth.DayOfWeek}");
Console.WriteLine($"Day of Year: {dateOfBirth.DayOfYear}");
Console.WriteLine($"Time of Day: {exactDateAndTimeOfBirth.TimeOfDay}");
Console.WriteLine($"Tick: {exactDateAndTimeOfBirth.Ticks}");
Console.WriteLine($"Kind: {exactDateAndTimeOfBirth.Kind}");

// Create a DateTime from current timestamp
DateTime now = DateTime.Now;
Console.WriteLine($"The Time Now is: {now}");

// Create a DateTime from a String
Console.WriteLine($"What is your DOB (MM/dd/yyyy):");
string dob = Console.ReadLine();
var userDob = DateTime.Parse(dob);
Console.WriteLine($"My DOB is: {userDob}");
Console.WriteLine($"Day of Week: {userDob.DayOfWeek}");
Console.WriteLine($"Day of Year: {userDob.DayOfYear}");
Console.WriteLine($"Time of Day: {userDob.TimeOfDay}");
Console.WriteLine($"Tick: {userDob.Ticks}");
Console.WriteLine($"Kind: {userDob.Kind}");

// Change Format DateTime
Console.WriteLine($"Formatted Date: {userDob.ToString("dd/MM/yyyy")}");
Console.WriteLine($"Formatted Date: {userDob.ToString("MMM, dd-yyyy")}");
Console.WriteLine($"Formatted Date: {userDob.ToString("dd-MMMM-yyyy")}");
Console.WriteLine($"Formatted Date: {userDob: dddd, dd-MM-yyyy}");

// Add additional Time
Console.WriteLine("One hour from now is: " + now.AddHours(1));
Console.WriteLine("One day from now is: " + now.AddDays(1));

Console.WriteLine("DATETIME OFFSET MANIPULATION");
// UTC
var utcNow = DateTime.UtcNow;
Console.WriteLine("UTC Datetime: " + utcNow);
Console.WriteLine("Now DateTime: " + now);

// DateTimeOffset and TimeZone Info
var tz = TimeZoneInfo.Local.GetUtcOffset(utcNow);
Console.WriteLine($"User Time Zone: {tz}");
var dto = new DateTimeOffset(now, tz);
Console.WriteLine($"User Time Zone with UTC Offset: {dto}");
Console.WriteLine($"UTC Time of Action: {dto.UtcDateTime}");

var indiaTz = TimeZoneInfo.FindSystemTimeZoneById("India StandardTime");
var indiaDateTime = TimeZoneInfo.ConvertTimeFromUtc(dto.UtcDateTime, indiaTz);
Console.WriteLine($"Action was completed in India at: {indiaDateTime}");


Console.WriteLine("DATE ONLY AND TIME ONLY MANIPULATION");
// DateOnly
var dateOnly = new DateOnly(1980, 12, 25);
var nextDay = dateOnly.AddDays(1);
var previousDay = dateOnly.AddDays(-1);
var decadeLater = dateOnly.AddYears(10);
var lastMonth = dateOnly.AddMonths(-1);

Console.WriteLine($"Date: {dateOnly}");
Console.WriteLine($"Next day: {nextDay}");
Console.WriteLine($"Previous day: {previousDay}");
Console.WriteLine($"Decade later: {decadeLater}");
Console.WriteLine($"Last month: {lastMonth}");

var dateOnlyFromDateTime = DateOnly.FromDateTime(now);
Console.WriteLine($"Date Only from DateTime: {dateOnlyFromDateTime}");

Console.WriteLine($"What is your DOB (MM/dd/yyyy):");
string dobDateOnly = Console.ReadLine();
var userDobDateOnly = DateOnly.ParseExact(dobDateOnly, "dd MMM yyyy", CultureInfo.InvariantCulture);
Console.WriteLine($"DOB Date Only: {userDobDateOnly}");

// TimeOnly
var timeNow = TimeOnly.FromDateTime(now);
Console.WriteLine($"Time Now: {timeNow}");
Console.WriteLine($"Time Now: {timeNow:hh:mm tt}");

// Date Comparison
var date1 = new DateTime(1985, 11, 23);
var date2 = new DateTime(1965, 1, 20);
Console.WriteLine($"Is {nameof(date1)} equal to {nameof(date2)}? {date1 == date2}");
Console.WriteLine($"Is {nameof(date1)} equal to {nameof(date2)}? {date1.Equals(date2)}");
Console.WriteLine($"Is {nameof(date1)} after {nameof(date2)}? {date1 > date2}");