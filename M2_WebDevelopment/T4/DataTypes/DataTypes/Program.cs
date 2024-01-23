// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

String text = "This is a String";
int age  = 35;
DateTime now = DateTime.Now;
double ammount  = 0;

String string2 = text + " a second String " + age + now + ammount;
String string3 = string.Format("The age is {0}, the time is {1}, and the amount is {2}",age,now,ammount);
String string4 = $"The age is {age}, the time is {now}, and the amount is {ammount}";

char sampleChar ='A';
char[] arrayChar = string4.ToCharArray();

ammount = (double)10/(double)3;

DateTime dateTime = new DateTime(2000,1,1);

var timeStamp = now - dateTime;
//var otherText = "This is a text";

Console.WriteLine(timeStamp.TotalMilliseconds);

String test = "15";
String booleanValue = "true";   
bool isTrue = bool.Parse(booleanValue);

age = int.Parse(test);
Console.ReadKey();
