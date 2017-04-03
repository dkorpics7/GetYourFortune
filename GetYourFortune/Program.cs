using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetYourFortune
{
    class Program
    {
        static void Main(string[] args)
        {

            // This is the Fortune Teller Project

            // It tells a person's fortune based on their age, birthmonth, 
            // favorite color and number of siblings

            // declare and initialize variables

            string input = "";        //string input by user in response to a question
            string fName = "";        // first name as entered by user
            string lName = "";        // last name as entered by user
            string fname = "";        // first name trimmed and converted to lower case
            string lname = "";        // last name trimmed and converted to lower case
            int age = -3;             // age
            double doubleAge = -3;    // age as a decimal
            string stringMonth = "";  // birth month if entered as a string
            string strMonth = "";     // birth month truncated to first 3 letters (if entered as a string)   
            int intMonth = -1;        // birth month if entered as an integer  (initialized to -1)
            bool testMonth = false;   // used to check if month is entered as a string or an integer
            string color = "";        // color 
            int numSiblings = -3;     // number of siblings

            int retireYears;          // number of years until retirement
            string vacHome;           // location of vacation home
            string transport;         // method of transportation
            int dollars;              // amount of money in the bank

            string goodbye = "have a nice day!";        //personalized goodbye message

            bool valid;               //used to test if input is valid  (true is valid,  false is invalid)
            bool quit = true;         //initialize quit to "true" -- change to "false" if user wants to quit program
            int icount = 0;           //set counter to 0  (so that I know if the user quits the program before completing their fortune)


            // Introduce the user to the program

            Console.WriteLine("\r\n\r\n  *************************************************************");
            Console.WriteLine("  *                                                           *");
            Console.WriteLine("  *        Hi!  I'm Diane, your friendly fortune teller!      *");
            Console.WriteLine("  *                                                           *");
            Console.WriteLine("  *        If you will answer a few simple questions,         *");
            Console.WriteLine("  *              I will tell you your fortune!                *");
            Console.WriteLine("  *                                                           *");
            Console.WriteLine("  * if you want to quit the program, type \"Quit\" at any time  *");
            Console.WriteLine("  *                                                           *");
            Console.WriteLine("  *************************************************************");

            while (quit)                                                          // as long as quit is true, the program continues to run
            {
                icount++;                                                         // increase counter every time the user asks for a new fortune
                if (icount > 1)                                                   // if it is not the first fortune, remind user to enter "quit" to exit
                {
                    Console.WriteLine("\r\nPress any key to continue ...");
                    Console.ReadKey();
                    Console.Clear();                                              // clear screen if user is getting a new fortune
                    Console.WriteLine("\r\n*****  Remember to type \"Quit\" if you want to leave the program!");

                }

                // Collect information from the user

                valid = false;                                                         // assume input is invalid until checked for validity
                while (quit && !valid)                                                 // execute the following code as long as quit=true and valid=false
                {
                    Console.Write("\r\n\r\nEnter your first name:                     ");
                    input = Console.ReadLine();                                        // get first name
                    fname = input.Trim().ToLower();                                    // convert to lowercase and trim in fixstr
                    if (fname == "quit") quit = false;                                 // test to see if user entered "Quit"
                    if (quit) fName = input;                                           // store first name in fName if it is not "Quit"
                    if (fname.Length == 0)                                             // if no name was entered, print error msg and repeat question
                    {
                        if (quit) Console.Write("\r\n***** Invalid Entry:   You must enter a name.\r\n"); 
                    }
                    else
                    {
                        valid = true;                                                  // input is valid
                    }
                }

                valid = false;                                                        // assume input is invalid until checked
                while (quit && !valid)                                                // execute the following code as long as quit=true and valid=false
                {
                    Console.Write("\r\nEnter your last name:                      ");
                    input = Console.ReadLine();                                       // get last name
                    lname = input.Trim().ToLower();                                   // convert to lowercase and trim in fixstr
                    if (lname == "quit") quit = false;                                // test to see if user entered "Quit"
                    if (lname.Length == 0)                                            // if no name was entered, print error msg and repeat question
                    {
                        if (quit) Console.Write("\r\n***** Invalid Entry:  You must enter a name.\r\n");
                    }
                    else
                    {
                        valid = true;                                                 // input is valid
                        lName = input;
                    }
                }


                valid = false;                                                        // assume input is invalid until checked
                while (quit && !valid)                                                // execute the following code as long as quit=true and valid=false
                {
                    Console.Write("\r\nEnter your age (in years):                 ");
                    input = Console.ReadLine().Trim().ToLower();                      // read age as a string, trim, and convert to lower case
                    if (input == "quit") quit = false;                                // test to see if user entered "Quit"

                    valid = int.TryParse(input, out age);                             // test to see if an integer was entered
                    if (!valid && input.IndexOf(".")>0)                               // if it has a decimal ...
                    {
                        valid = double.TryParse(input, out doubleAge);                // try converting to decimal (double)
                        if (valid) age = Convert.ToInt32(doubleAge);                  // then convert it to an integer
                    }
                    if (!valid || age <= 0 || age >= 121)                             // if not, or if it is out of range, print error msg
                    {
                        if (quit) Console.Write("\r\n***** Invalid Entry:  Be sure to enter a positive number.\r\n");
                        valid = false;
                    }
                    else
                    {
                        valid = true;                                                 
                    }
                }

                valid = false;                                                        // assume input is invalid until checked
                while (quit && !valid)                                                // execute the following code as long as quit=true and valid=false
                {
                    Console.Write("\r\nIn what month were you born?               ");
                    input = Console.ReadLine().Trim().ToLower();                      // read month as a string, trim, and convert to lower case
                    if (input == "quit") quit = false;                                // test to see if user entered "Quit"

                    testMonth = int.TryParse(input, out intMonth);                    // testMonth = true if month was entered as an integer
                    stringMonth = input;                                              // store month in stringMonth

                    if ((input.Length <= 2 && !testMonth) || (intMonth <= 0 && testMonth) || (intMonth > 12 && testMonth))
                    {
                        if (quit) Console.Write("\r\n\r\n***** Invalid Entry:  Enter month as a digit or text (e.g., \"7\" or \"July\"\r\n");
                    }
                    else
                    {
                        valid = true;
                        if (!testMonth) strMonth = stringMonth.Substring(0, 3);        // if entered as string, abbreviate to first 3 characters
                    }
                }


                valid = false;                                                        // assume input is invalid until checked
                while (quit && !valid)                                                // execute the following code as long as quit=true and valid=false
                {
                    Console.Write("\r\n\r\nEnter your favorite ROYGBIV color \r\n(or type \"Help\" to see your color choices):  ");
                    input = Console.ReadLine().Trim().ToLower();                      // read favorite color, trim, and convert to lower case
                    if (input == "quit") quit = false;                                // test to see if user entered "Quit"

                    if (input == "help")                                              // if user entered "help", give them a list of colors to choose from
                    {
                        if (quit) Console.WriteLine("\r\n\r\nROYGBIV stands for:\r\n\r\n\tR = red\r\n\tO = orange\r\n\tY = yellow\r\n\tG = green\r\n\tB = blue\r\n\tI = indigo\r\n\tV = violet");
                    }
                    else if (input.Length == 0)                                       // if user did not enter anything, give them an error and prompt again
                    {
                        if (quit) Console.Write("\r\n***** Invalid Entry:  You must enter a color.\r\n");
                    }
                    else
                    {
                        valid = true;
                        color = input;
                    }
                }


                valid = false;                                                        // assume input is invalid until checked
                while (quit && !valid)                                                // execute the following code as long as quit=true and valid=false
                {
                    Console.Write("\r\nHow many siblings do you have?:            ");
                    input = Console.ReadLine().Trim().ToLower();                      // read number of siblings as a string, trim, and convert to lower case
                    if (input == "quit") quit = false;                                // test to see if user entered "Quit"

                    valid = int.TryParse(input, out numSiblings);                     // test to see if an integer was entered
                    if (!valid || numSiblings < 0)                                    // keep prompting until the entry is an integer >= 0
                    {
                        if (quit) Console.Write("\r\n***** Invalid Entry:   Enter a positive number or zero.\r\n");
                        valid = false;
                    }
                    else
                    {
                        valid = true;
                        if (quit && numSiblings >= 20) Console.WriteLine("\r\n\r\n                      WOW!  Your mom was a busy bee!!!\r\n\r\n");
                    }
                }

                if (quit)                                                   // execute the rest of the program if quit is true
                {

                    // show the user their entries

                    Console.WriteLine("\r\nPress any key to continue ...");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("\r\n\r\n*****   Thank you for your input!   *****\r\n\r\nHere is what you entered:\r\n");
                    Console.WriteLine("\r\n\tName:          {0} {1} \r\n\tAge:           {2}\r\n\tBirth Month:   {3}\r\n\tColor:         {4}\r\n\tSiblings:      {5}\r\n\r\n", fName, lName, age, stringMonth, color, numSiblings);

                    // set retirement years based on age
                    if (age % 2 == 0)
                    {
                        retireYears = 5;                             // if age is even, retirement is in 5 years
                    }
                    else
                    {
                        retireYears = 99;                            // if age is odd, retirement is in 99 years
                    }

                    //set vacation home location based on number of siblings

                    switch (numSiblings)
                    {
                        case 0:
                            vacHome = "The Virgin Islands";
                            break;
                        case 1:
                            vacHome = "Cleveland, Ohio";
                            break;
                        case 2:
                            vacHome = "a lovely trailer park";
                            break;
                        case 3:
                            vacHome = "the nearest homeless shelter";
                            break;
                        default:
                            vacHome = " a cardboard box under a bridge";
                            break;
                    } // end of switch case for siblings


                    // set mode of transportation based on color selection

                    switch (color)
                    {
                        case "red":
                            transport = "red, convertible ferrari";
                            goodbye = "don't forget to wear your seatbelt!";
                            break;
                        case "orange":
                            transport = "orange Yamaha motorcyle";
                            goodbye = "don't forget to wear your helmet!";
                            break;
                        case "yellow":
                            transport = "yellow submarine";
                            goodbye = "did you know that we both live in a yellow submarine, \r\n\t a yellow submarine, a yellow submarine?";
                            break;
                        case "green":
                            transport = "private leer jet";
                            goodbye = "if you have any extra room in that jet of yours, \r\n\t remember ... I love Paris!";
                            break;
                        case "blue":
                            transport = "1941 orange and yellow bi-plane";
                            goodbye = "you may want to invest in a parachute!  Just Saying ...";
                            break;
                        case "indigo":
                            transport = "pair of indigo speed skates";
                            goodbye = "don't forget your knee and elbow pads.  Safety First!";
                            break;
                        case "violet":
                            transport = "purple mountain bike";
                            goodbye = "have fun on that bike of yours. Don't forget to hydrate!";
                            break;
                        default:
                            Console.WriteLine("\r\n***** Warning:  You entered an invalid color.\r\n***** Don't worry! I can still work with it!");
                            transport = "pair of perfectly good feet for exploring new places";
                            goodbye = "you may want to invest in a good pair of hiking boots.";
                            break;
                    } // end of switch case for colors


                    // set dollars based on birth month (strMonth)

                    if (strMonth == "jan" || strMonth == "feb" || strMonth == "mar" || strMonth == "apr" || intMonth >= 1 && intMonth <= 4)
                    {
                        dollars = 39752;
                    }
                    else if (strMonth == "may" || strMonth == "jun" || strMonth == "jul" || strMonth == "aug" || intMonth >= 5 && intMonth <= 8)
                    {
                        dollars = 12874512;
                    }
                    else if (strMonth == "sep" || strMonth == "oct" || strMonth == "nov" || strMonth == "dec" || intMonth >= 9 && intMonth <= 12)
                    {
                        dollars = 111;
                    }
                    else
                    {
                        Console.WriteLine("\r\n***** Warning:  You entered an invalid birth month.\r\n***** Fortunately, I am also telepathic so I already know when you were born!");
                        dollars = 1;
                    }

                    // Write the fortune to the screen

                    Console.WriteLine("\r\nPress any key to get your fortune!!!");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("\r\n\r\n\a\a\a          !!!!!!!!!! Here is your fortune !!!!!!!!!!\r\n\r\n\r\n\a\a\a");
                    Console.WriteLine("\r\n  ******************************************************************\r\n");

                    Console.WriteLine("\t{0} {1} will retire in {2} years \r\n\twith {3:C} in the bank, \r\n\ta vacation home in {4}\r\n\tand a {5}.", fName, lName, retireYears, dollars, vacHome, transport);
                    Console.WriteLine("\r\n  ******************************************************************\r\n\r\n");


                    Console.Write("\r\n\r\n\r\nIf you are unhappy with your fortune, would you like to try again?  ");
                    input = Console.ReadLine().Trim().ToLower();                       // read answer, trim, and convert to lower case
                    if (input == "quit") quit = false;                                 // test to see if user entered "Quit"
                    if (input.Length >= 1) input = input.Substring(0, 1);
                    if (input == "n")
                    {
                        icount++;
                        quit = false;
                        Console.WriteLine("\r\n\r\nPress any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                    }

                } // end if statement that executes remainder of program if quit is true
            }  //end while loop  (this loop is exited when the user enters "Quit")

            if (icount == 1)
            {
                Console.WriteLine("\r\n\r\n\t\tNobody likes a quitter ...\r\n\a\a\a");               //prints only if they quit before getting their fortune
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\r\n\r\n                             --");
                Console.WriteLine("                          --    --");
                Console.WriteLine("      Thanks           --          --");
                Console.WriteLine("        for          --              --");
                Console.WriteLine("     visiting       --                --         Come");
                Console.WriteLine("                    --                --         again");
                Console.WriteLine("      Diane's        --              --          soon!");
                Console.WriteLine("      Crystal          --          --");
                Console.WriteLine("       Ball.              --    --");
                Console.WriteLine("                             --\r\n\r\n\r\n\r\n\t {0}, {1}\r\n", fName, goodbye);
            }
            Console.WriteLine("\r\nPress any key to exit...");
            Console.ReadKey();  // keeps screen from disappearing
        }  //end of static void
    }  //end of class
}  //end of namespace
