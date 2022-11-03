// See https://aka.ms/new-console-template for more information

using System.Net.Sockets;

public class Program
{
    private static List<byte[]> Root = new();

    public static void Main(string[] args)
    {
        
        long loop = 0;
        while (true)
        {
            byte[] bytes = new byte[1024*80];
            Root.Add(bytes);
            Thread.Sleep(10);
            loop++;
            if(loop%200 == 0)
              GC.Collect(generation: 2, GCCollectionMode.Default, blocking: true, compacting: true);
        }

        Console.ReadKey();
    }
}