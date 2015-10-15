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

public class LifeLine
{
    private bool phoneAFriend;
    private bool askTheAudience;
    private bool fiftyFifty;
    private int goWithLifeLineAnswer = 0;
    
    /*
        In certain parts of this class I have assumed that:
        1 = phoneAfriend
        2 = askTheAudience
        3 = fiftyFifty        
    */
    
    public LifeLine()
    {
        this.phoneAFriend   = true;
        this.askTheAudience = true;
        this.fiftyFifty     = true;
    }
    
    public string LifeLinesLeft()
    {
        string output = "Life Lines Available: \n";
        int count = 0;
        
        if(this.phoneAFriend  == true)
        {
            count++;
            output += string.Format("{0}. Phone a Friend (1)\n", count);
        }
        
        if(this.askTheAudience == true)
        {
            count++;
            output += string.Format("{0}. Ask the Audience (2)\n", count);
        }
        
        if(this.fiftyFifty == true)
        {
            count++;
            output += string.Format("{0}. Fifty Fifty (3)\n", count);
        }
        
        if(count == 0)
        {
            return "You do not have any lifelines left";
        }
        else
        {
            return output;
        }
        
    }
    
    public bool usedUp(int option)
    {
        if(option == 1)
        {
            return this.phoneAFriend;
        }
        else if(option == 2)
        {
            return this.askTheAudience;
        }
        else if(option == 3)
        {
            return this.fiftyFifty;
        }
        else 
        {
            return false;
        }
    }
    
    public void PhoneAfriend(string[] question)
    {
        if(!this.usedUp(1))
        {
            Console.WriteLine("Life Line has already been used up");
            return;
        }
        else
        {
            string options = question[1];
            string[] oPtions = options.Split(';');
                        
            string answer = question[2];
            Random rnd = new Random();
            
            int phone = rnd.Next(1,3);
            string phoneOption;
            
            switch(phone)
            {
                case 1:
                    phoneOption = "a";
                    break;
                case 2:
                    phoneOption = "b";
                    break;
                case 3:
                    phoneOption = "c";
                    break;
                default:
                    phoneOption = "";         
                    break;
            }
            
            Console.WriteLine("Your friend on the line thinks the answer is {0}" ,phoneOption.ToUpper());
            Console.WriteLine("Press P to make your friend confirm his answer");
            string input = Console.ReadLine();
            do
            {
                if(input.ToLower() != "p")
                {
                    Console.WriteLine("Invalid Response. You must make your friend confirm his answer");
                }
                
            }while(input.ToLower() != "p");
            
            //TODO: Write condition to process answer from phone friend.
            
            //rnd = new Random();
            //phone = rnd.Next(0,2);
            
            if(oPtions[phone] == answer)
            {
                phone = 1;
            }
            else
            {
                phone = 2;
            }
            
            string friendAssurance = "your Friend says: ";
            
            if(phone == 1)
            {
                Random rnd2 = new Random();
                int userSays = rnd2.Next(1,3);
                switch(userSays)
                {
                    case 1:
                        friendAssurance += "I am very sure!";
                        break;
                    case 2:
                        friendAssurance += "I am 100% sure!";
                        break;
                    case 3:
                        friendAssurance += "I am too too convinced..";
                        break;
                    default:
                        break;         
                }
            }
            else
            {
                Random rnd2 = new Random();
                int userSays = rnd2.Next(1,3);
                switch(userSays)
                {
                    case 1:
                        friendAssurance += "I am not quite sure.";
                        break;
                    case 2:
                        friendAssurance += "Don't take my word for it.";
                        break;
                    case 3:
                        friendAssurance += "I don't really know";
                        break;
                    default:
                        break;         
                }            
            }
            
            Console.WriteLine(friendAssurance);
            this.phoneAFriend = false;
        }    
    }
    
    public void askTheaudience(string[] question)
    {
        if(!this.usedUp(2))
        {
            Console.WriteLine("Life Line has already been used up");
            return;
        }
        else
        {
            Random random  = new Random();
            int votesForHighest = random.Next(50, 100);
            
            int votesForSecond = random.Next(0, 49);
            
            int votesForThird = 100 - votesForHighest - votesForSecond -random.Next(0, 49);
            if(votesForThird < 0)
            {
                votesForThird = 0;
            }
            int votesForFourth = 100 - votesForHighest - votesForSecond -votesForThird;
            if(votesForFourth < 0)
            {
                votesForFourth = 0;
            }

            int optionS;
            string options = question[1];
            string[] oPtions = options.Split(';');
            string answer = question[2];
            Random rnd = new Random();
            int[] qwerty = new int[4];
            int xyz;
            
            switch (answer)
            {
                case "A":
                {
                    optionS = 1;
                    break;
                }
                case "B":
                {
                    optionS = 2;
                    break;
                }
                case "C":
                {
                    optionS = 3;
                    break;
                }
                case "D":
                {
                    optionS = 4;
                    break;
                }
                default:
                {
                    optionS = 0;
                    break;
                }
            }
            
            for(int i = 0; i < 4; i++ )
            {
                do
                {
                    xyz = rnd.Next(1,4);
                    
                    qwerty[i] = xyz;
                }while(xyz == optionS);
            }
            
            qwerty[optionS-1] = votesForHighest;
            for(int i = 0; i < 4; i++)
            {
                if(qwerty[i] != optionS)
                {
                    if(qwerty[i] == 1)
                    {
                        qwerty[i] = votesForHighest; 
                    }
                    else if(qwerty[i] == 2)
                    {
                        qwerty[i] = votesForSecond;
                    } 
                    else if(qwerty[i] == 3)
                    {
                        qwerty[i] = votesForThird;
                    } 
                    else if(qwerty[i] == 4)
                    {
                        qwerty[i] = votesForFourth;
                    }                    
                }
            }
            
            string output = "";
            
            for(int i = 0; i < 4; i++)
            {
                switch (i+1)
                {
                    case 1:
                        output = "A";
                        break;
                    case 2:
                        output = "B";
                        break;
                    case 3:
                        output = "C";
                        break;
                    case 4:
                        output = "D";
                        break;
                }
                if(qwerty[i] == votesForHighest )
                {
                    output += string.Format(": {0} ({1}%)" ,this.Graph(votesForHighest), votesForHighest);
                }
                else if (qwerty[i] == votesForSecond)
                {
                    output += string.Format(": {0} ({1}%)" ,this.Graph(votesForSecond),votesForSecond);
                }
                else if(qwerty[i] == votesForThird)
                {
                    output += string.Format(": {0} ({1}%)" ,this.Graph(votesForThird),votesForThird);
                }
                else
                {
                    output += string.Format(": {0} ({1}%)" ,this.Graph(votesForFourth),votesForFourth);
                }
                Console.WriteLine(output);
                output = "";
            }
            
            
            
           /* Random rnd = new Random();
            int[] voting = new int[4];
            voting[optionS] = votesForHighest;
            int count = 0;
            do
            {
                if(count != optionS)
                {
                    voting[count];
                }
                
                count++;
            }while();*/
            
            
        
            this.askTheAudience = false;
        }
    }

    public void GoWithLifeLineAnswer(int LifeLineAnwer, int correctAnswer )
    {
        Console.WriteLine("Is that your Final Answer?Y/N");
        string userInput = Console.ReadLine().ToLower();
        if(userInput == "y"){
            
            if(LifeLineAnwer == correctAnswer){
                //Next Level
                this.goWithLifeLineAnswer =  1;
            }
            else{
                this.goWithLifeLineAnswer =  2;
            } 
        
        }
        else{

            this.goWithLifeLineAnswer = 3;
        }
        
    }

    public int GetGoWithLifeLineAnswer() {
        return this.goWithLifeLineAnswer;
    }
    
    private string Graph(int percentage)
    {
        double number = ( percentage / 100.0 ) * 20.0;
        number = (int)number;
        string output = "";
        
        for (int i = 0; i < number; i++)
        {
            output += "*";
        }
        
        return output;
    }

    public void Fiftyfifty(string[] question)
    {
        if(!this.usedUp(3))
        {
            Console.WriteLine("Life Line has already been used up");
            return;
        }
        else
        {
            int option = 0;
            Random rnd = new Random();
            string[] options = question[1].Split(';');
            
            switch(question[2].ToUpper())
            {
                case "A":
                    option = 1;
                    break;
                case "B":
                    option = 2;
                    break;
                case "C":
                    option = 3;
                    break;
                case "D":
                    option = 4;
                    break;    
            }
            
            int secondOption = 0;
            do
            {
                secondOption = rnd.Next(1,4);
            }while(secondOption == option);
            
            Console.Clear();
            Console.WriteLine(question[0]);
            
            if(option < secondOption)
            {
                Console.Write("{0} ", options[option - 1]);
                Console.WriteLine("{0}" , options[secondOption - 1]); 
            }
            else           
            {
                Console.Write("{0}" ,options[secondOption - 1]);
                Console.WriteLine("{0} ", options[option - 1]);
            }
            
            
            this.fiftyFifty  = false;
        }
    }
}