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
    public class Level
    {    
        LevelNumber head;
        LevelNumber tail;
        LevelNumber currentLevel;
        int count;
        
        public Level ()
        {
            this.head = new LevelNumber(0);
            this.tail = new LevelNumber(1000000);
            this.head.Next = this.tail;       
            count = 2; 

            this.InsertBeforeTail(1000);
            this.InsertBeforeTail(2000);
            this.InsertBeforeTail(5000);
            this.InsertBeforeTail(10000);
            this.InsertBeforeTail(15000);
            this.InsertBeforeTail(25000);
            this.InsertBeforeTail(50000);
            this.InsertBeforeTail(75000);
            
            this.currentLevel = this.head;
        }
        
        public LevelNumber CurrentLevel
        {
            get{return this.currentLevel;}
            set{ this.currentLevel = value;}
        }
        
        //Insert in between head and tail
        private void InsertBeforeTail(int amount)
        { 
            LevelNumber current  = this.head;
            
            while(current.Next != this.tail)
            {
                current  = current.Next;
                
            }
            
            LevelNumber toInsert = new LevelNumber(amount);
            
            toInsert.Next = this.tail;
            current.Next = toInsert;   
            this.count++;
        }
        
        public override string ToString()
        {
            LevelNumber tmp = this.head;
            string output = "Where you are: ";
           
            while(tmp != null)
            {
                if(tmp.Amount == this.currentLevel.Amount)
                {
                    output += string.Format("**${0}** ", tmp.Amount);
                }
                else
                {
                    output += string.Format("${0} ", tmp.Amount);
                }
                tmp = tmp.Next;
            }        
           return output;
        }
    }
}