using System;

namespace A1_Ticketing_System_SLinz
{
    public class Info
    {

        public void requirements()
        {
             System.Console.WriteLine();
             System.Console.WriteLine("______________ A1 Software Ticketing System __________________");
             System.Console.WriteLine("Info you will need to create a NEW ticket item: ");
             System.Console.WriteLine("Summary: What kind of issue? Bug, US, New feature or Product");
             System.Console.WriteLine("Status: Open, Closed, Old, Backlogged");
             System.Console.WriteLine("Priority: High, Medium, Low");
             System.Console.WriteLine("Submitter: Who submitted this ticket?");
             System.Console.WriteLine("Assigned:  Who is the Project Manager?");
             System.Console.WriteLine("Watching: Who is watching, stakeholders, testers. Up to 8 people.");
             System.Console.WriteLine();
        }
    }
}