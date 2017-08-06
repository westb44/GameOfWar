using System;
namespace WarGame
{
	public class Card
	{
        // Members/Fields
        private readonly Suit suit;
        private readonly FaceValue faceVal;
		public int realVal;
        // Properties
        public Suit Suit { get { return suit; } }
        public FaceValue FaceVal { get { return faceVal; } }
        // Constructor
        public Card(Suit suit, FaceValue faceVal, int v)
        {
            this.suit = suit;
            this.faceVal = faceVal;
			this.realVal = v;
        }
        // Override
        public override string ToString()
        {
            return "The " + faceVal.ToString() + " of " + suit.ToString();
        }
	}
}
