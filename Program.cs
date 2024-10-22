// See https://aka.ms/new-console-template for more information
using GenericListProject;

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

foreach (var element in alist)
{
    Console.WriteLine(element);
}

Console.ReadLine();
