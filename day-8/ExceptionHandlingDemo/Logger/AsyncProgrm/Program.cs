﻿Console.WriteLine("Fetching...");

var data = await FetchDataAsync();  
Console.WriteLine($"Got: {data}");

string FetchData()
{
    Thread.Sleep(5000);  
    return "Data";
}

async Task<string> FetchDataAsync()
{
    await Task.Delay(5000);  
    return "Data";
}