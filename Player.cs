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


class Player
{
    public string userName;
    public Questions question;
    public Level money;
    public LifeLine userLifeLines;
    
    public Player (string userName)
    {
        this.userName = userName;
        this.money = new Level();
        this.userLifeLines = new LifeLine();
        this.question = new Questions();
    }
    
    public bool MarkAnswer(string userInput)
    {
        bool invalid = false;
        string[] thequestion = this.question.GetQuestion;

        
        bool test;
        do
        {
            test = thequestion[2].ToLower() == userInput.ToLower();
            invalid = false;
            
            if(userInput.ToUpper() == "A" || userInput.ToUpper() == "B" || userInput.ToUpper() == "C" || userInput.ToUpper() == "D")
            {    
                if(thequestion[2].ToLower() == userInput.ToLower())
                {
                    Console.WriteLine("Congratulations! That was the correct Answer!");
                    this.question.PresentQuestion++;
                }
                else
                {
                    Console.WriteLine("Sorry! That was the wrong Answer!");    
                
                }
            }
            else if(userInput == "1" || userInput == "2" || userInput == "3")
            {
                switch(userInput)
                {
                    case "1":
                    {
                        this.userLifeLines.PhoneAfriend(thequestion);
                        int lifeLineAnswer = this.userLifeLines.GetGoWithLifeLineAnswer();
                        if(lifeLineAnswer == 1){
                            test = true;
                        } else if(lifeLineAnswer == 2){
                            invalid = true;
                        }else if(lifeLineAnswer == 3){
                            test = false;
                        }
                        break;
                    }
                    case "2":
                    {
                        this.userLifeLines.askTheaudience(thequestion);
                        int lifeLineAnswer = this.userLifeLines.GetGoWithLifeLineAnswer();
                        if(lifeLineAnswer == 1){
                            test = true;
                        } else if(lifeLineAnswer == 2){
                            invalid = true;
                        }else if(lifeLineAnswer == 3){
                            test = false;
                        }
                        break;
                    }
                    case "3":
                    {
                        this.userLifeLines.Fiftyfifty(thequestion);
                        int lifeLineAnswer = this.userLifeLines.GetGoWithLifeLineAnswer();
                        if(lifeLineAnswer == 1){
                            test = true;
                        } else if(lifeLineAnswer == 2){
                            invalid = true;
                        }else if(lifeLineAnswer == 3){
                            test = false;
                        }
                        break;
                    }
                }
                
                
            }
            else
            {
                Console.WriteLine("Invalid Option. Try Again");
                invalid = true;
                userInput = Console.ReadLine();
            }
            
            
        } while(invalid);       
        return (test);
    }
    
    public bool WalkAway(string userInput)
    {
        if(userInput == "4")
        {
            Console.WriteLine("You have decided yo walk away");
            Console.WriteLine("Congratulations. You leave with {0}", this.money.CurrentLevel.Amount);
            return true;
        }
        else
        {
            return false;
        }
    }
} 