using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count => this.cards.Count;
        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            var searchedCard = this.cards.FirstOrDefault(p => p.Name == card.Name);

            if (searchedCard != null)
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cards.Add(card);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Player cannot be null");
            }

            return this.cards.Remove(card);
        }

        public ICard Find(string name) => this.cards.FirstOrDefault(c => c.Name == name);
    }
}
