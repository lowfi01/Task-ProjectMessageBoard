using Application;
using Domain;
using System;
using System.Collections.Generic;

namespace Submission1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Concerns
            // 1# Initially tried to build this in dotnet 6, but I seem to have lost intellisense,
            // 2# Attempted to use dotnet 5, but my installation of dotnet 6 prevent that option,
            // 3# After 1 hour of that struggling remade in dotnet core.

            var IsActive = true;
            Console.WriteLine("Hello World!");
            var application = new App();
            var input = "";
            while (IsActive)
            {
                input = "";
                RenderOptions(input);
                input = Console.ReadLine();
                application.StateManagement(input);
            }

        }
        static void RenderOptions(string input)
        {
            if (input == "-h" || input == "")
            {
                Console.WriteLine("posting: <user name> -> @<project name> <message>");
                Console.WriteLine("reading: <project name>");
                Console.WriteLine("following: <user name> follows <project name>");
                Console.WriteLine("wall: <user name> wall");
            }
        }
    }
}
