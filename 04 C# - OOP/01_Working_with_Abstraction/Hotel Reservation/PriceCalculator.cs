using System;
using System.Collections.Generic;
using System.Text;

namespace P04._Hotel_Reservation
{
    public static class PriceCalculator
    {
        public static decimal CalculatePrice(decimal pricePerDay, int numberOfDays, Season season, Discount discountType)
        {
            int priceMultiplier = (int)season;
            decimal discountMultiplier = (decimal)discountType / 100;
            decimal price = pricePerDay * (decimal)numberOfDays * priceMultiplier;
            decimal discount = price * discountMultiplier;
            decimal totalPrice = price - discount;

            return totalPrice;
        }
    }

    public enum Season
    {
        spring = 2,
        summer = 4,
        autumn = 1,
        winter = 3
    }

    public enum Discount
    {
        none,
        secondvisit = 10,
        vip = 20
    }
}
