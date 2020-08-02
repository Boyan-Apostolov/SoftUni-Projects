using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.Models.BattleFields;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;

namespace PlayersAndMonsters.Core
{
    public class Controller : IManagerController
    {
        private PlayerRepository players;
        private CardRepository cards;
        public Controller()
        {
            this.players = new PlayerRepository();
            this.cards = new CardRepository();
        }

        public string AddPlayer(string type, string username)
        {
            IPlayer player;
            CardRepository emptyrepo = new CardRepository();
            if (type == "Beginner")
            {
                player = new Beginner(emptyrepo, username);
                this.players.Add(player);
                return $"Successfully added player of type {type} with username: {username}";
            }

            if (type == "Advanced")
            {
                player = new Advanced(emptyrepo, username);
                this.players.Add(player);
                return $"Successfully added player of type {type} with username: {username}";
            }
            //TODO: Dont get here, add player;
            return "How did you get in here?";
        }

        public string AddCard(string type, string name)
        {
            ICard card;

            if (type == "Magic")
            {
                card = new MagicCard(name);
                this.cards.Add(card);
                return $"Successfully added card of type {type}Card with name: {name}";
            }

            if (type == "Trap")
            {
                card = new TrapCard(name);
                this.cards.Add(card);
                return $"Successfully added card of type {type}Card with name: {name}";
            }

            //TODO: Dont get here, add card;
            return "How did you get in here?";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.players.Find(username);
            var card = this.cards.Find(cardName);

            player.CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            BattleField battleField = new BattleField();

            var attacker = this.players.Find(attackUser);
            var enemy = this.players.Find(enemyUser);

            battleField.Fight(attacker, enemy);

            return $"Attack user health {attacker.Health} - Enemy user health {enemy.Health}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            //"Username: {username} - Health: {health} – Cards {cards count}"
            //"Card: {name} - Damage: {card damage}"
 
            foreach (var player in this.players.Players)
            {
                sb.AppendLine(
                    $"Username: {player.Username} - Health: {player.Health} – Cards {player.CardRepository.Count}");

                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }

                sb.AppendLine("###");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
