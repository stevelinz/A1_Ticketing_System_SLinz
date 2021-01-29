using System;
using System.IO;
using System.Text.RegularExpressions;
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
            // array for watching names
            string[] watchNames = new string[9];
            int  ticketLife = 4; // system will never hold more than 99,999 records.
            int i = 0, ticketID = 0, watchCount = 0;
            TicketInput ticketInput = new TicketInput();
            string str2 = "", watchString = "", watching = "",
            summary = "", inputReturn = "", start = "";

            try
            {
                using (StreamReader srTest = File.OpenText(file))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        System.Console.WriteLine(line);
                        string str1 = line;
                        str2 = string.Empty;
                        for (int x = 0; x < ticketLife; x++)
                        {
                            if (Char.IsDigit(str1[x]))
                                str2 += str1[x];
                        }
                    }
                    ticketID = int.Parse(str2); //get the current ticketID
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"The directory was not found: '{e}'");
            }
            catch (IOException e)
            {
                Console.WriteLine($"The file could not be opened: '{e}'");
            }
            sr.Close();
            StreamWriter sw = new StreamWriter(file, true);
            Info info = new Info();
            info.requirements();
            System.Console.WriteLine("Press Enter key to enter the A1-Ticket process");
            start = Console.ReadLine();

            while (true)
            {
                Console.Write("Summary of this ticket, or type D if done: ");
                summary = Console.ReadLine();

                while (digitsFound(summary)) 
                {
                    Console.Write("Summary of this ticket, numbers NOT allowed. type D if done: ");
                    summary = Console.ReadLine();
                    if (digitsFound(summary)) break;
                }


                if (summary == "D" || summary == "d")
                {
                    sw.Close();
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

                bool digitsFound(string summary)  // to make sure the ticketID remains correct
                {             
                    foreach (char c in summary)
                    {    
                            if (c >= '0' && c <= '9')
                            {
                              return true;
                            }
                    }
                    return false;
                }

                sw.WriteLine("{0},{1},{2},{3}", ticketID, summary, inputReturn, watchString);
                watchString = "";
                Array.Clear(watchNames, 0, i);
            }
            sw.Close();
        }

    }
}

