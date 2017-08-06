using System;

namespace WarGame 
{

    public class War
    {
        // Members_Fields
        private Player player1 = new Player();
        private Player player2 = new Player();
        private Deal dealCards = new Deal();
		private string _sStatus = "";
        private Random r = new Random(Environment.TickCount);
        private int rn;
        // Constructors
        public War()
        {
            dealCards.DealCards(player1, player2); // Start The Game
        }
        // Public Methods
        public void PlayGame()
        {
            while (true)
            {
                Console.WriteLine("Player 1 card count:" + player1.CardCount);
				Console.WriteLine("Player 2 card count:" + player2.CardCount);
				// Debug Information
                _sStatus = Battle(player1, player2); // Battle
                if (_sStatus == "War")
                {
                    _sStatus = WarBattle(player1, player2);

					if(_sStatus == "player 1 wins")
					{
						Console.WriteLine("Player 1 Wins"); 
                        break;
					}
					if(_sStatus == "player 2 wins")
					{
						Console.WriteLine("Player 2 Wins"); 
                        break;
					}


                }
                if (player1.CardCount == 0 || player2.CardCount == 52)
                {
                    Console.WriteLine("Player 2 Wins");
                    break;
                }
                if (player1.CardCount == 52 || player2.CardCount == 0)
                {
                    Console.WriteLine("Player 1 Wins"); 
                    break;
                }
			Console.WriteLine(string.Format("Status:" + _sStatus));
            }            
        }
        // Private Methods
        private string Battle(Player p1, Player p2)
        {
            Card p1Card = p1.RemCard(); // Remove 1 Card from Player1's Deck
            Card p2Card = p2.RemCard(); // Remove 1 Card from Player2's Deck
            Console.WriteLine(string.Format("Player 1 Draws : {0}", p1Card)); 
            Console.WriteLine(string.Format("Player 2 Draws : {0}", p2Card));
			Console.ReadKey(); //added for debugging

			//logic to convert check the numeric war equivelent to the face value
			if (p1Card.realVal > p2Card.realVal)
            {
                rn = r.Next(1, 2);
                if (rn == 1)
                {
                    p1.AddCard(p1Card);
                    p1.AddCard(p2Card);
                }
                if (rn == 2)
                {
                    p2.AddCard(p2Card);
                    p2.AddCard(p1Card);
                }
                return "Player 1 has won!";
            }
			else if (p2Card.realVal > p1Card.realVal)
            {
                rn = r.Next(1, 2);
                if (rn == 1)
                {
                    p1.AddCard(p1Card);
                    p1.AddCard(p2Card);
                }
                if (rn == 2)
                {
                    p2.AddCard(p2Card);
                    p2.AddCard(p1Card);
                }
                return "Player 2 has won!";
            }
			else if (p2Card.realVal == p1Card.realVal)
            {
                return "War";
            }
            else
            {
                return "eRR";
            }
        }
        private string WarBattle(Player p1, Player p2)
        {
			if(p1.CardCount < 2)
			{
				return "player 2 wins";
			}
			
			if(p2.CardCount < 2)
			{
				return "player 1 wins";
			}
            // Burn both player's cards
            Card p1Burn1 = p1.RemCard(); // Burn/Put cards "face-down"
            Card p1Burn2 = p1.RemCard(); // Burn/Put cards "face-down"
            Card p2Burn1 = p2.RemCard(); // Burn/Put cards "face-down"
            Card p2Burn2 = p2.RemCard(); // Burn/Put cards "face-down"
            // Draw the 'battle card'
            Card p1Card = p1.RemCard(); // Draw of the actual "battle" card
            Card p2Card = p2.RemCard(); // Draw of the actual "battle" card
            // Display whats going on
            Console.WriteLine(string.Format("Player 1 Burns 2 Cards and Draws : {0}", p1Card)); // Comented out to provide faster end-game calculations
            Console.WriteLine(string.Format("Player 2 Burns 2 Cards and Draws : {0}", p2Card)); // Comented out to provide faster end-game calculations
            /* ------------------------------------------------
             The following IF_ELSE-IF Statement and Switch blocks
             in the IF_ELSE are to provide a "random" order of 
             cards placed back into the winner's deck
            ------------------------------------------------ */
            if (p1Card.FaceVal > p2Card.FaceVal)
            {
                rn = r.Next(1, 16);
                switch (rn)
                {
                    case 1:
                        p1.AddCard(p1Card);
                        p1.AddCard(p1Burn1);
                        p1.AddCard(p1Burn2);
                        p1.AddCard(p2Burn1);
                        p1.AddCard(p2Burn2);
                        p1.AddCard(p2Card);
                        break;
                    case 2:
                        p1.AddCard(p1Card);
                        p1.AddCard(p1Burn2);
                        p1.AddCard(p2Burn1);
                        p1.AddCard(p2Burn2);
                        p1.AddCard(p2Card);
                        p1.AddCard(p1Burn1);
                        break;
                    case 3:
                        p1.AddCard(p1Card);
                        p1.AddCard(p2Burn1);
                        p1.AddCard(p2Burn2);
                        p1.AddCard(p2Card);
                        p1.AddCard(p1Burn1);
                        p1.AddCard(p1Burn2);
                        break;
                    case 4:
                        p1.AddCard(p1Card);
                        p1.AddCard(p2Burn2);
                        p1.AddCard(p2Card);
                        p1.AddCard(p1Burn1);
                        p1.AddCard(p1Burn2);
                        p1.AddCard(p2Burn1);
                        break;
                    case 5:
                        p1.AddCard(p2Card);
                        p1.AddCard(p1Burn1);
                        p1.AddCard(p1Burn2);
                        p1.AddCard(p2Burn1);
                        p1.AddCard(p2Burn2);
                        p1.AddCard(p1Card);
                        break;
                    case 6:
                        p1.AddCard(p2Card);
                        p1.AddCard(p1Burn2);
                        p1.AddCard(p2Burn1);
                        p1.AddCard(p2Burn2);
                        p1.AddCard(p1Card);
                        p1.AddCard(p1Burn1);
                        break;
                    case 7:
                        p1.AddCard(p2Card);
                        p1.AddCard(p2Burn1);
                        p1.AddCard(p2Burn2);
                        p1.AddCard(p1Card);
                        p1.AddCard(p1Burn1);
                        p1.AddCard(p1Burn2);
                        break;
                    case 8:
                        p1.AddCard(p2Card);
                        p1.AddCard(p2Burn2);
                        p1.AddCard(p1Card);
                        p1.AddCard(p1Burn1);
                        p1.AddCard(p1Burn2);
                        p1.AddCard(p2Burn1);
                        break;
                    case 9:
                        p1.AddCard(p2Card);
                        p1.AddCard(p1Card);
                        p1.AddCard(p1Burn1);
                        p1.AddCard(p1Burn2);
                        p1.AddCard(p2Burn1);
                        p1.AddCard(p2Burn2);
                        break;
                    case 10:
                        p1.AddCard(p1Burn1);
                        p1.AddCard(p1Burn2);
                        p1.AddCard(p2Burn1);
                        p1.AddCard(p2Burn2);
                        p1.AddCard(p2Card);
                        p1.AddCard(p1Card);
                        break;
                    case 11:
                        p1.AddCard(p1Burn1);
                        p1.AddCard(p2Burn1);
                        p1.AddCard(p2Burn2);
                        p1.AddCard(p2Card);
                        p1.AddCard(p1Card);
                        p1.AddCard(p1Burn2);
                        break;
                    case 12:
                        p1.AddCard(p1Burn1);
                        p1.AddCard(p2Burn2);
                        p1.AddCard(p2Card);
                        p1.AddCard(p1Card);
                        p1.AddCard(p1Burn2);
                        p1.AddCard(p2Burn1);
                        break;
                    case 13:
                        p1.AddCard(p1Burn1);
                        p1.AddCard(p2Card);
                        p1.AddCard(p1Card);
                        p1.AddCard(p1Burn2);
                        p1.AddCard(p2Burn1);
                        p1.AddCard(p2Burn2);
                        break;
                    case 14:
                        p1.AddCard(p1Burn1);
                        p1.AddCard(p1Card);
                        p1.AddCard(p1Burn2);
                        p1.AddCard(p2Burn1);
                        p1.AddCard(p2Burn2);
                        p1.AddCard(p2Card);
                        break;
                }
                return "Player 1 has won!";
            }
            else if (p2Card.FaceVal > p1Card.FaceVal)
            {
                rn = r.Next(1, 16);
                switch (rn)
                {
                    case 1:
                        p2.AddCard(p1Card);
                        p2.AddCard(p1Burn1);
                        p2.AddCard(p1Burn2);
                        p2.AddCard(p2Burn1);
                        p2.AddCard(p2Burn2);
                        p2.AddCard(p2Card);
                        break;
                    case 2:
                        p2.AddCard(p1Card);
                        p2.AddCard(p1Burn2);
                        p2.AddCard(p2Burn1);
                        p2.AddCard(p2Burn2);
                        p2.AddCard(p2Card);
                        p2.AddCard(p1Burn1);
                        break;
                    case 3:
                        p2.AddCard(p1Card);
                        p2.AddCard(p2Burn1);
                        p2.AddCard(p2Burn2);
                        p2.AddCard(p2Card);
                        p2.AddCard(p1Burn1);
                        p2.AddCard(p1Burn2);
                        break;
                    case 4:
                        p2.AddCard(p1Card);
                        p2.AddCard(p2Burn2);
                        p2.AddCard(p2Card);
                        p2.AddCard(p1Burn1);
                        p2.AddCard(p1Burn2);
                        p2.AddCard(p2Burn1);
                        break;
                    case 5:
                        p2.AddCard(p2Card);
                        p2.AddCard(p1Burn1);
                        p2.AddCard(p1Burn2);
                        p2.AddCard(p2Burn1);
                        p2.AddCard(p2Burn2);
                        p2.AddCard(p1Card);
                        break;
                    case 6:
                        p2.AddCard(p2Card);
                        p2.AddCard(p1Burn2);
                        p2.AddCard(p2Burn1);
                        p2.AddCard(p2Burn2);
                        p2.AddCard(p1Card);
                        p2.AddCard(p1Burn1);
                        break;
                    case 7:
                        p2.AddCard(p2Card);
                        p2.AddCard(p2Burn1);
                        p2.AddCard(p2Burn2);
                        p2.AddCard(p1Card);
                        p2.AddCard(p1Burn1);
                        p2.AddCard(p1Burn2);
                        break;
                    case 8:
                        p2.AddCard(p2Card);
                        p2.AddCard(p2Burn2);
                        p2.AddCard(p1Card);
                        p2.AddCard(p1Burn1);
                        p2.AddCard(p1Burn2);
                        p2.AddCard(p2Burn1);
                        break;
                    case 9:
                        p2.AddCard(p2Card);
                        p2.AddCard(p1Card);
                        p2.AddCard(p1Burn1);
                        p2.AddCard(p1Burn2);
                        p2.AddCard(p2Burn1);
                        p2.AddCard(p2Burn2);
                        break;
                    case 10:
                        p2.AddCard(p1Burn1);
                        p2.AddCard(p1Burn2);
                        p2.AddCard(p2Burn1);
                        p2.AddCard(p2Burn2);
                        p2.AddCard(p2Card);
                        p2.AddCard(p1Card);
                        break;
                    case 11:
                        p2.AddCard(p1Burn1);
                        p2.AddCard(p2Burn1);
                        p2.AddCard(p2Burn2);
                        p2.AddCard(p2Card);
                        p2.AddCard(p1Card);
                        p2.AddCard(p1Burn2);
                        break;
                    case 12:
                        p2.AddCard(p1Burn1);
                        p2.AddCard(p2Burn2);
                        p2.AddCard(p2Card);
                        p2.AddCard(p1Card);
                        p2.AddCard(p1Burn2);
                        p2.AddCard(p2Burn1);
                        break;
                    case 13:
                        p2.AddCard(p1Burn1);
                        p2.AddCard(p2Card);
                        p2.AddCard(p1Card);
                        p2.AddCard(p1Burn2);
                        p2.AddCard(p2Burn1);
                        p2.AddCard(p2Burn2);
                        break;
                    case 14:
                        p2.AddCard(p1Burn1);
                        p2.AddCard(p1Card);
                        p2.AddCard(p1Burn2);
                        p2.AddCard(p2Burn1);
                        p2.AddCard(p2Burn2);
                        p2.AddCard(p2Card);
                        break;
                }
                return "Player 2 has won!";
            }
            else if (p1Card.FaceVal == p2Card.FaceVal)
            {
                return "War";
            }
            else
            {
                return "eRR";
            }
        }
    }
}