// See https://aka.ms/new-console-template for more information
using Notes.PerformanceCheck;
using System.Net.NetworkInformation;

Console.WriteLine("Hello, World!");

var url = @"http://localhost:5075/api/v1/Performance/notes";
Console.WriteLine("PERFORMANCE CHECK");

ISetUrl a = new PerformanceService();
    a.SetUrl(url).CheckPerformance();

Console.ReadLine();

public class MyException : Exception
{

}