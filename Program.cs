using System;
using System.IO;
namespace A1_Ticketing_System_SLinz
{
    /*
    Build data file with initial system tickets and data in a CSV
    Write Console application to process and add records to the CSV file  Tickets.csv    
    TicketID, Summary, Status, Priority, Submitter, Assigned, Watching
    1,This is a bug ticket,Open,High,Drew Kjell,Jane Doe,Drew Kjell|John Smith|Bill Jones
*/
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            StreamReader sr = new StreamReader(file);
            try{
            {
                sr.Read();
            } 
            }
            catch (FileNotFoundException e){
                System.Console.WriteLine(e);
            }
            
            StreamWriter sw = new StreamWriter(file, true);
            // array for watching names
            string[] watchNames = new string[9];
            int i = 0, ticketID = 0, watchCount = 0;
            TicketInput ticketInput = new TicketInput();
            string current = "", watchString = "", watching = "", summary = "", inputReturn = "";

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                System.Console.WriteLine(line);
                current = line.Substring(0, 1);
            }
            ticketID = Int32.Parse(current); //get the current ticketID


            while (true)
            {
                Console.Write("Summary of this ticket, or type D if done: ");
                summary = Console.ReadLine();
                if (summary == "D" || summary == "d")
                {
                   break;  
                }
                else
                {
                    ticketID++;
                }
                inputReturn = ticketInput.inputTicket(); 
        
                Console.Write("Watching this ticket: You add can up to 8 people, type D if done: ");
                watching = Console.ReadLine();
                for (i = 0; i < 9; i++)
                {
                    if (watching == "d" || watching == "D" || watchCount > 8)
                    {
                        break;
                    }
                    else
                    {
                        watchNames[i] = watching;
                        if (i == 0)        // formatting issue to address
                        {
                            watchString = watchString + watchNames[i];
                        }
                        else
                        {
                            watchString = watchString + "|" + watchNames[i];
                        }
                        watchCount++;
                        Console.Write("Watching this ticket: You add can up to 8 people, type D if done: ");
                        watching = Console.ReadLine();
                    }
                }
 
                sw.WriteLine("{0},{1},{2},{3}", ticketID, summary, inputReturn, watchString);
                watchString = "";
                Array.Clear(watchNames, 0, i);
            }

            sw.Close();
            //sr.Close();
        }
    }
}

