using GenericListProject;

//Just testing here
var justText = "Here Peter";
var justTextTwo = "Here Peter Two";
var justTextThree = "Here Peter Three";

var alist = new GenericList<string>();

alist.Add(justText);
alist.Add(justTextTwo);
alist.Add(justTextThree);

for (int i = 1; i < 6; i++)
{
    alist.Add($"{justText}: {i.ToString()}");
}
for (int i = 1; i < 6; i++)
{
    alist.AddBefore($"{justText}: {i.ToString()}");
}

foreach (var element in alist)
{
    Console.WriteLine(element);
}

var elementAt4 = alist.GetElementAt(5);
Console.WriteLine($"Value of element at 4 is: {elementAt4.Value}");
//alist.DeleteElementAt(11);
alist.UpdateValueAt(11, "newText");

Console.WriteLine("After deletion....");
foreach (var element in alist)
{
    Console.WriteLine(element);
}

Console.ReadLine();
