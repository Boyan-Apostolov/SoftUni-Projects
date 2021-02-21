using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Export;

namespace VaporStore.DataProcessor
{
    using System;
    using Data;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var genres = new List<Genre>();

            foreach (var genre in genreNames)
            {
                genres.AddRange(context.Genres.Where(x => x.Name == genre));
            }

            var output = genres.Select(x => new
            {
                Id = x.Id,
                Genre = x.Name,
                Games = x.Games.Where(x => x.Purchases.Any())
                        .Select(c => new
                        {
                            Id = c.Id,
                            Title = c.Name,
                            Developer = c.Developer.Name,
                            Tags = string.Join(", ", c.GameTags.Select(v => v.Tag.Name)),
                            Players = c.Purchases.Count
                        })
                        .ToArray()
                        .OrderByDescending(c => c.Players)
                        .ThenBy(c => c.Id)
                        .ToArray(),
                TotalPlayers = x.Games.Sum(c => c.Purchases.Count)
            })
                .ToArray()
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToArray();

            var json = JsonConvert.SerializeObject(output, Formatting.Indented);
            return json;
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
        {
            var type = new PurchaseType();
            if (storeType == "Digital")
            {
                type = PurchaseType.Digital;
            }
            else
            {
                type = PurchaseType.Retail;
            }

            var result = context.Users
				.Include(u => u.Cards)
				.ThenInclude(c => c.Purchases)
				.ThenInclude(p => p.Game)
				.ThenInclude(g => g.Genre)
				.ToList()
				.Where(u => u.Cards.SelectMany(c => c.Purchases).Count() > 0)
				.Select(u => new ExportUsersDto()
				{
					Username = u.Username,
					Purchases = u.Cards.SelectMany(c => c.Purchases)
						.Where(p => p.Type.ToString() == storeType)
						.Select(p => new ExportPurchaseDto()
						{
							Card = p.Card.Number,
							Cvc = p.Card.Cvc,
							Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
							Game = new ExportGameDto()
							{
								Title = p.Game.Name,
								Genre = p.Game.Genre.Name,
								Price = p.Game.Price
							}
						})
						.OrderBy(p => DateTime.Parse(p.Date)).ToList(),
					TotalMoneySpent = u.Cards.SelectMany(c => c.Purchases)
						.Where(p => p.Type.ToString() == storeType).Sum(p => p.Game.Price)
				})
				.Where(u => u.Purchases.Count > 0)
				.OrderByDescending(u => u.TotalMoneySpent)
				.ThenBy(u => u.Username)
				.ToList();

            var xml = XmlConverter.Serialize(result, "Users");
            return xml;

        }
    }
}