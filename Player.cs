using System;
using System.Collections.Generic;
using System.Text;

namespace WarGame
{
	
    public class Player
    {
        // Members/Fields
        private string sDeck;
        private Deck curDeck;
        private List<Card> cards = new List<Card>();
        // Properties
        public Deck CurrentDeck { get { return curDeck; } set { curDeck = value; } }
        public int CardCount { get { return cards.Count; } }
        // Public Methods
        public void AddCard(Card c)
        {
            cards.Add(c);
        }
        public Card RemCard()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
        // Override
        public override string ToString()
        {
            foreach (Card c in cards)
            {
                sDeck += string.Format("{0}", c);
            }
            return sDeck;
        }
    }
}