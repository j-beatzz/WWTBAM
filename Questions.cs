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


namespace WWTBAM 
{
    class Questions
    {
        int[] number;
        int presentQuestion;
        
        public Questions()
        {
            Random questionNumber = new Random();
            number = new int[10];
            
            for (int i = 0; i < 10; i++)
            {
                if( i < 5 )
                {
                    number[i] = questionNumber.Next(1 , 11);
                    
                }           
                else if(i > 5 && i < 8)
                {
                   number[i] = questionNumber.Next(10 , 21); 
                }
                else 
                {
                    number[i] = questionNumber.Next(20 , 31); 
                }
            }
            this.presentQuestion = 0;
        }
        
        public int PresentQuestion
        {
            get { return this.presentQuestion;}
            set { this.presentQuestion = value;}
        }
        
        public string[] GetQuestion
        {
            get
            {
                StreamReader inStream = new StreamReader("GameQuestions.csv");
                int loop = 0;
                string line = "";
                string[] data = null;
                while(!inStream.EndOfStream && loop < this.number[this.presentQuestion])
                {
                    line = inStream.ReadLine();
                    loop++;
                }
                
                data = line.Split('>', '#');
                inStream.Close();
                
                return data;
            }
        }
        
        public override string ToString()
        {
            string[] values = this.GetQuestion;
            
            string output = string.Format("{0}\n{1}", values[0], values[1]);
            
            return output;
        }
    }
}