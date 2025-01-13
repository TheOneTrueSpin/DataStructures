// See https://aka.ms/new-console-template for more information
using DataStructures.DataStructures;

Console.WriteLine("Hello");
int[] intArray = new int[10];
intArray[1] = 10;
Console.WriteLine(intArray[1]);

CustomList customList = new CustomList();
customList[10] = 100;
Console.WriteLine(customList[10]);

CustomArray<int> customArray = new CustomArray<int>(5);
CustomArray<long> customArray2 = new CustomArray<long>(5);
CustomArray<int> customArray3 = new CustomArray<int>(5);
customArray.SetValue(0, 53);
customArray.SetValue(1, 230);
customArray.SetValue(2, 110);
customArray.SetValue(3, 10);
Console.WriteLine(customArray.GetValue(2));
customArray3.PrintNumOfArray();
Console.WriteLine(CustomArray<int>.numArray);

List<long> list = new List<long>();

void AddNumbers<T>(T num1)
{
    Console.WriteLine($"input was {num1}");
}

AddNumbers<double>(1.2);
AddNumbers<float>(1.421F);
AddNumbers("test");
AddNumbers(123123123);

