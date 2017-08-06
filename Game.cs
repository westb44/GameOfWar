using System;

namespace WarGame
{

 public enum Suit
    {
        Diamonds, Spades, Clubs, Hearts
    }
 public enum FaceValue
    {
        Two = 2,Three = 3,Four = 4,Five = 5,Six = 6,
        Seven = 7,Eight = 8,Nine = 9,Ten = 10,
        Jack = 11,Queen = 12,King = 13,Ace = 14
    }
    class Game
    {
        public static void Main()
        {
	   	  while(true)
	  	  {
		      War w;
              w = new War();
              w.PlayGame();

			try
            { 
	  		   Console.WriteLine("End of Game");
		 	   Console.WriteLine("Enter Y to play again or any key to quit.");
               string entry1 = Console.ReadLine();

			   if(entry1 == "Y" || entry1 == "y")
			   {
			 	  continue;		
		   	   }
               else
			   {
				  break;
	      	   }
            }
            catch(FormatException)
            {
               Console.WriteLine("Invalid entry exiting program");
               break; 
            }
		  } 
        }
    }
}