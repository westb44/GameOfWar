using System;
using System.Collections.Generic;
using System.Text;

namespace WarGame
{
    public class Deck
    {
        // Members/Fields
        protected List<Card> cards = new List<Card>();
        private Random random;
        // Properties
        public Card this[int position] { get { return (Card)cards[position]; } }
        public int Cards { get { return cards.Count; } }
        // Constructor
        public Deck()
        {
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (FaceValue f in Enum.GetValues(typeof(FaceValue)))
                {
					
					int v = (int)f;
					if(v >= 10 && v != 14) v=10;
					if (v == 14) v=11;
                    cards.Add(new Card(s, f, v));
                }
            }
            random = new Random();
        }
        // Public Methods
        public Card Draw()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
        public void Shuffle()
        {
            for (int n = 0; n != 1; n++)
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    int index1 = i;
                    int index2 = random.Next(cards.Count);
                    SwapCard(index1, index2);
                }
            }
        }
        public void Shuffle(int SuffleAmount)
        {
            if (SuffleAmount == 0)
            {
                throw new ArgumentException("You must shuffle at least once");
            }
            else
            {
                for (int n = 0; n != SuffleAmount; n++)
                {
                    for (int i = 0; i != cards.Count; i++)
                    {
                        int index1 = i;
                        int index2 = random.Next(cards.Count);
                        SwapCard(index1, index2);
                    }
                }
            }
        }
        // Private Method
        private void SwapCard(int index1, int index2)
        {
            Card card = cards[index1];
            cards[index1] = cards[index2];
            cards[index2] = card;
        }

    }
    public class Hand
    {
        // Members/Fields
        protected List<Card> cards = new List<Card>();
        // Properties
        public int NumCards { get { return cards.Count; } }
        public List<Card> Cards { get { return cards; } }
        // Public Method
        public bool ContainsCard(FaceValue item)
        {
            foreach (Card c in cards)
            {
                if (c.FaceVal == item)
                {
                    return true;
                }
            }
            return false;
        }
    }
	public class Deal
    {
        // Members/Fields
        private Deck deck = new Deck();
        // Properties
        public Deck GetDeck { get { return deck; } }
        // Public Methods
        public void DealCards(Player p1, Player p2)
        {
            deck.Shuffle(10);
            for (int i = 0; i != 26; i++)
            {
                p1.AddCard(deck.Draw());
                p2.AddCard(deck.Draw());
            }
        }
    }
}
