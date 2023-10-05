using System;

public class MyObject
{
    public void Run()
    {
       
        string[] dataArray = { "Line 1", "Line 2", "Line 3" };

       
        MyOtherObject otherObj = new MyOtherObject(dataArray);

        
        otherObj.Dispose();
    }
}

public class MyOtherObject : IDisposable
{
    private string[] data;

    public MyOtherObject(string[] dataArray)
    {
        data = dataArray;
    }

    public void Dispose()
    {
       
        Console.WriteLine($"The number of elements in the array: {data.Length}");

        
        Console.WriteLine("Array elements:");
        foreach (var item in data)
        {
            Console.WriteLine(item);
        }

        
        GC.Collect();
        GC.WaitForPendingFinalizers();

       
        Console.WriteLine("The object MyOtherObject has been deleted.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            
            MyObject obj = new MyObject();
            obj.Run();
        }
        else
        {
            
            Console.WriteLine("Type the lines (press Enter after each line, to finish typing type 'exit'):");

            var dataArray = new System.Collections.Generic.List<string>();
            string input;
            do
            {
                input = Console.ReadLine();
                if (input.ToLower() != "exit")
                {
                    dataArray.Add(input);
                }
            } while (input.ToLower() != "exit");

            MyObject obj = new MyObject();
            obj.Run();
        }
    }
}
