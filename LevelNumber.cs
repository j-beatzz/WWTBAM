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


public class LevelNumber
    {
        int amount;
        LevelNumber next;
        int group;
        
        public LevelNumber(int amount)
        {
            this.amount = amount;
            this.next = null;
            this.group = 0;
        }
        
        public LevelNumber Next
        {
            get {return this.next;}
            
            set{ this.next = value;}      
        }        
        
        public int Amount
        {
            get {return this.amount;}
            
            set{ this.amount = value;}      
        }

        public int Group
        {
            get 
            {              
                if(this.Amount >= 0 || this.Amount < 10000)
                {
                    this.group = 0;
                    //toBeReturned = 0;
                }
                else if (this.Amount >= 10000 || this.Amount < 50000)
                {
                    this.group = 10000;
                    //toBeReturned = 0;                  
                }
                else if (this.Amount >= 50000 || this.Amount < 100000)
                {
                    this.group = 50000;
                    //toBeReturned = 0;                   
                }
                else 
                    this.group = 100000;
                //return toBeReturned;
                return this.group;
            }
                  
        }  
        
    }