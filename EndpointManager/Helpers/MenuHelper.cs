using System;
using EndpointManager.Extensions;

namespace EndpointManager.Helpers
{
    public static class MenuHelper
    {
        public static void WriteOptions<T>(string header) where T : Enum
        {
            var type = typeof(T);
            Console.WriteLine(header);
            Console.WriteLine();

            foreach (var option in Enum.GetValues(type))
            {
                var value = (int)option;
                var enumOption = (T)Enum.Parse(type, option.ToString());
                var description = enumOption.ToName();

                Console.WriteLine($"{value} - {description}");
            }
            Console.WriteLine();
        }

        public static T GetResponse<T>()
        {
            while (true)
            {
                try
                {
                    var result = (T)Enum.Parse(typeof(T), Console.ReadLine());

                    if (!Enum.IsDefined(typeof(T), result))
                    {
                        Console.WriteLine("Invalid input, please try again.");
                        continue;
                    }

                    return result;
                }
                catch (Exception)
                {
                    Console.WriteLine("Unsuported command, please try again.");
                    continue;
                }
            }
        }

        public static void WriteResponse<T>(T enumOption) where T : Enum
        {
            var description = enumOption.ToName();
            Console.WriteLine(description);
        }
    }
}
