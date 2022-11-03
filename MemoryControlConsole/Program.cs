// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

var rand = new Random();
long loop = 0;
while (true)
{
    for (int i = 0; i < 1024 * 1024; i++)
    {
        var bytes = new byte[1024];
        rand.NextBytes(bytes);
    }
    
    Thread.Sleep(rand.Next(1, 1000));
    if (loop + 1 == long.MaxValue)
        loop = 0;
    loop++;
}



void Alocate()
{
    var array = new List<byte[]>();
    
    long loop = 0;
    while (true)
    {
        for (int i = 0; i < rand.Next(1, 2048 * 2048); i++)
        {
            var size = rand.Next(1, 1204);
            byte[] bytes = null;

            try
            {
                bytes = new byte[size];
                rand.NextBytes(bytes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            array.Add(bytes);
        }
        if (loop % 10 == 0)
        {
            array.Clear();
            Debug.WriteLine("Gen-2 cleared out");
        }

        Thread.Sleep(1_000);

        if (loop + 1 == long.MaxValue)
            loop = 0;
        loop++;
    }
}
