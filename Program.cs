//------------------------------------------------------------------------------
// Name:          LEO-Irabor Joshua
// Title:         Who want's to be a Millionaire Game Model
// Date Started:  27th December 2013
// Date Finished: 29th December 2013
// 
// Updates:
// 30th December 2013 --> Added the "Walk away" option.
//
//
//------------------------------------------------------------------------------

using System;
using System.IO;
using System.Diagnostics;


class Program
{
    static void Main()
    {
        int count = 0;
        Console.WriteLine("Who Wants to A Millionaire");
        Console.Write("Enter your name: ");
        string playerName = Console.ReadLine();
        string userInput;
        
        bool stillInTheGame = true;
        bool walkAway = false;
                
        Player theplayer = new Player(playerName);
        
        bool invaliid = false;
        
        do
        {
            Console.Write("Hello {0}! Are you ready to play Who Wants to be a Millionaire? Y/N: ", 
                                theplayer.userName.Trim());
            
            string response = Console.ReadLine();
            
            if(response.ToLower() == "n")
            {
                return;
            }   
            else if(response.ToLower() == "y")
            {
                
            
                do
                {                   
                    Console.Clear();  
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    Console.WriteLine(theplayer.money.ToString());
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    Console.WriteLine(theplayer.userLifeLines.LifeLinesLeft());
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    Console.WriteLine(theplayer.question.ToString());
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    Console.WriteLine("Press (4) to walk away");
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    
                    userInput      = Console.ReadLine();
                    walkAway       = theplayer.WalkAway(userInput);
                    
                    if(!walkAway)
                    {
                        stillInTheGame = theplayer.MarkAnswer(userInput);
                        
                        if(stillInTheGame)
                        {
                            theplayer.money.CurrentLevel = theplayer.money.CurrentLevel.Next;
                            Console.WriteLine("You have won yourself ${0}", theplayer.money.CurrentLevel.Amount);
                            Console.WriteLine();
                            
                            count++;
                            
                            do
                            {
                                if(count != 9)
                                {
                                    Console.WriteLine("Go to the next question? Y/N: ");
                                    response = Console.ReadLine();
                                
                                    if(response.ToLower() == "n")
                                    {
                                        //To Do Something really cool right here
                                        return;
                                    }
                                    else if(response.ToLower() != "n" && response.ToLower() != "y")
                                    {
                                        Console.WriteLine("Invalid Response");
                                    }
                                }
                                
                            }while (response.ToLower() != "n" && response.ToLower() != "y");
                        }
                        else    
                        {
                            Console.WriteLine("You Leave with ${0}", theplayer.money.CurrentLevel.Group);
                            Console.WriteLine("GAME OVER !!!");
                        }
                    }
                    else
                    {
                        return;
                    }
                    
                    Console.WriteLine("------------------------------------------------------------------------------------");
                        
                }while (stillInTheGame && count < 9);
            }
            else
            {
                Console.WriteLine("Invalid Response");
                invaliid = true;
            }
        }
        while(invaliid);
        
    }
}