using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace DiscordInjectionsRemover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = $"Empyrean Fixer - 1.0";

            EmpyreanRemover.removeEmpyrean();
            DiscordInjectionRemover.RemoveInjection();

            Console.ReadLine();
        }


    }
}
