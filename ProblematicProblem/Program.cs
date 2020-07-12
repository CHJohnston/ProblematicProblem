using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace ProblematicProblem
{
    public static class Program 
    {  
        public static void Main(string[] args)
        {
            List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
            
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");  
            //Call the UserContinue Method for a valid yes or no response
            bool cont = UserResponse(Console.ReadLine());

            //NOTE -Added Logic to End the Program if UserResponse is false
            if (cont == true)
            {
                Console.WriteLine();
                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is your age? ");
                //Added logic to ensure the user enters an integer for their Age
                string userAgeString = Console.ReadLine();
                int userAge = 0;
                // The user will be asked to renter a value until a vaild integer is input
                while (int.TryParse(userAgeString, out userAge) == false)
                {
                    Console.WriteLine($"{userAgeString} is not an Integer");
                    Console.Write("Try Again ");
                    userAgeString = Console.ReadLine();
                }

                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? yes/no: ");               
                bool seeList = UserResponse(Console.ReadLine());
                if (seeList)
                {
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? yes/no: ");                    
                    bool addToList = UserResponse(Console.ReadLine());
                    Console.WriteLine();

                    while (addToList)
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);

                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }

                        Console.WriteLine();
                        Console.Write("Would you like to add more? yes/no: ");
                        addToList = UserResponse(Console.ReadLine());                      
                    }
                }
                bool chooseActivity = true;
                while (chooseActivity)
                    {
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Console.Write("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();

                    //This Logic generates a random activity from the list
                    var rng = new Random();
                    int randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber];

                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Pick something else!");
                        activities.Remove(randomActivity);
                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                    }

                    Console.Write($"Ah got it! {randomActivity}, your random activity is: {userName}! Is this ok or do you want to grab another activity? yes/no: ");
                    chooseActivity = UserResponse(Console.ReadLine());
                    Console.WriteLine();                    
                }

                Console.WriteLine("Thanks for Playing");
            }
            else
            {
                Console.WriteLine("No Worries!!");
            }
           Console.ReadLine();
        }
        
        public static bool UserResponse(string userInput)
        //This method requires a Yes or No User Input and returns a bool value of true/false
        //The letter case doesn't matter for the user input since all values are converted to lower case        
        {
            bool validResponse = false;
            bool userCont = false;  
            while (validResponse == false)
            {
                if (userInput.ToLower() == "yes")
                {
                    validResponse = true;
                    userCont = true;
                }
                else
                {
                    if (userInput.ToLower() == "no")
                    {
                        validResponse = true;
                        userCont = false;
                    }
                    else
                    { 
                    Console.Write($"Please enter yes/no: ");
                    userInput = Console.ReadLine();
                    }
                }
            }
            return userCont;
        }
    }
}
