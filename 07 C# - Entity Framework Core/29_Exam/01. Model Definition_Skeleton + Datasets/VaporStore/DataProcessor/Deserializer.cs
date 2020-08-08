using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Import;

namespace VaporStore.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data;

    public static class Deserializer
    {
        private static string ErrorMessage = "Invalid Data";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var validEntities = new List<Game>();

            var gamesDtos = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            foreach (var gameDto in gamesDtos)
            {
                bool isGameValid = true;

                if (!IsValid(gameDto))
                {
                    isGameValid = false;
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (string.IsNullOrEmpty(gameDto.Name))
                {
                    isGameValid = false;
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                DateTime gameReleaseDate;
                bool ispgameReleaseDateValid = DateTime.TryParseExact(gameDto.ReleaseDate, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out gameReleaseDate);
                if (!ispgameReleaseDateValid)
                {
                    isGameValid = false;
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!gameDto.Tags.Any())
                {
                    isGameValid = false;
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var game = new Game()
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = gameReleaseDate
                };

                if (isGameValid)
                {//check if developer exists
                    var developer = context.Developers.FirstOrDefault(x => x.Name == gameDto.Developer);
                    if (developer == null)
                    {
                        developer = new Developer() { Name = gameDto.Developer };
                    }

                    game.Developer = developer;
                    //check if genre exists
                    var genre = context.Genres.FirstOrDefault(x => x.Name == gameDto.Genre);
                    if (genre == null)
                    {
                        genre = new Genre() { Name = gameDto.Genre };
                    }

                    game.Genre = genre;

                    foreach (var tagDto in gameDto.Tags)
                    {
                        //check if tag exists
                        var tag = context.Tags.FirstOrDefault(x => x.Name == tagDto);
                        if (tag == null)
                        {
                            tag = new Tag() { Name = tagDto };
                        }

                        game.GameTags.Add(new GameTag()
                        {
                            Game = game,
                            Tag = tag
                        });
                    }
                }

                context.Games.Add(game);
                context.SaveChanges();

                //validEntities.Add(game);
                sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

            //context.Games.AddRange(validEntities);
            //context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);
            var validEntites=new List<User>();
            StringBuilder sb = new StringBuilder();

            foreach (var userDto in usersDtos)
            {
                var errorOccured = false;

                if (!IsValid(userDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!userDto.Cards.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var user = new User()
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age
                };

                foreach (var cardDto in userDto.Cards)
                {
                    if (!IsValid(cardDto))
                    {
                        errorOccured = true;
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var card = new Card()
                    {
                        Number = cardDto.Number,
                        Cvc = cardDto.CVC
                    };

                    if (cardDto.Type == "Debit")
                    {
                        card.Type = CardType.Debit;
                    }
                    else if (cardDto.Type == "Credit")
                    {
                        card.Type = CardType.Credit;
                    }
                    else
                    {
                        errorOccured = true;
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    user.Cards.Add(card);
                }

                if (errorOccured)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                validEntites.Add(user);
                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            context.Users.AddRange(validEntites);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var purchasesDtos = XmlConverter.Deserializer<ImportPurchasesDto>(xmlString, "Purchases");

            StringBuilder sb = new StringBuilder();

            var validEntites = new List<Purchase>();

            foreach (var purchaseDto in purchasesDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var purchase = new Purchase();

                DateTime purchaseDate;
                bool isPurchaseDateValid = DateTime.TryParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out purchaseDate);
                if (!isPurchaseDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                purchase.ProductKey = purchaseDto.ProductKey;
                purchase.Date = purchaseDate;

                if (purchaseDto.Type == "Retail")
                {
                    purchase.Type = PurchaseType.Retail;
                }
                else if(purchaseDto.Type == "Digital")
                {
                    purchase.Type = PurchaseType.Digital;
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Title);
                if (game == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                purchase.Game = game;

                var card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.CardNumber);
                if (card == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                purchase.Card = card;

                var user = context.Users.FirstOrDefault(x => x.Cards.Any(f=>f.Number == card.Number));
                if (user == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                // may fail card.Purchases // idk
                validEntites.Add(purchase);
                sb.AppendLine($"Imported {purchaseDto.Title} for {user.Username}");
            }

            context.Purchases.AddRange(validEntites);
            context.SaveChanges();
            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}