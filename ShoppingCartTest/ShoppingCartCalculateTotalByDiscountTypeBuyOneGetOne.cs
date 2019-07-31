

using NUnit.Framework;
using ShoppingCart_ConsoleApp;
using System;
using System.Collections.Generic;
using static ShoppingCart_ConsoleApp.ShoppingCart;

namespace ShoppingCartTest
{
    [TestFixture]
    public class ShoppingCartCalculateTotalByDiscountTypeBuyOneGetOne
    {
        decimal itemPrice = 0.60M;

        [Test]
        public void when_discount_type_is_buy_one_get_one_and_divided_by_2([Values(2, 4, 40)]int numberOfItems)
        {
            decimal expectedAmount = CalculateAmountByQuantityDividedBy2(numberOfItems, itemPrice);
            decimal output = ShoppingCart.CalculateAmountByDiscountType(numberOfItems, itemPrice, (int)DiscountType.BuyOneGetOne);

            Assert.AreEqual(expectedAmount, output);
        }

        [Test]
        public void when_discount_type_is_buy_one_get_one_and_not_divided_by_2([Values(1, 3, 5,9,11)]int numberOfItems)
        {
            decimal expectedAmount = CalculateAmountByQuantityNotDividedBy2(numberOfItems, itemPrice);
            decimal output = ShoppingCart.CalculateAmountByDiscountType(numberOfItems, itemPrice, (int)DiscountType.BuyOneGetOne);

            Assert.AreEqual(expectedAmount, output);
        }

        private decimal CalculateAmountByQuantityDividedBy2(int numberOfItems, decimal price)
        {
            return (numberOfItems / 2) * price;
        }

        private decimal CalculateAmountByQuantityNotDividedBy2(int numberOfItems, decimal price)
        {
            return ((numberOfItems / 2) + (numberOfItems % 2)) * price;
        }
    }
}
