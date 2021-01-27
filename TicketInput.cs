using System;
using System.IO;

namespace A1_Ticketing_System_SLinz
{
    public class TicketInput
    {

        public string inputTicket()
        {
            string status = "", priority = "";
            string submitter = "", assigned = "";

            System.Console.WriteLine();
            Console.Write("Status of this ticket: ");
            status = Console.ReadLine();
            Console.Write("Priority of this ticket: ");
            priority = Console.ReadLine();
            Console.Write("Submitter of this ticket: ");
            submitter = Console.ReadLine();
            Console.Write("Assigned of this ticket: ");
            assigned = Console.ReadLine();
            return (status + "," + priority + "," +
            submitter + "," + assigned);  
        }
    }
}