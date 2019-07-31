using NUnit.Framework;
using ShoppingCart_ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartTest
{
    [TestFixture]
    public class ShoppingCartCalculateTotalByDiscountTypeBuyThreeForTwo
    {

        decimal itemPrice = 0.25M;

        [Test]
        public void when_discount_type_is_three_for_two_and_divided_by_3([Values(3, 6, 9, 15 , 21)]int numberOfItems)
        {
            decimal expectedAmount = CalculateAmountByQuantityDividedBy3(numberOfItems, itemPrice);
            decimal output = ShoppingCart.CalculateAmountByDiscountType(numberOfItems, itemPrice, (int)ShoppingCart.DiscountType.ThreeForTwo);

            Assert.AreEqual(expectedAmount, output);
        }

        [Test]
        public void when_discount_type_is_three_for_two_and_not_divided_by_3([Values(1, 3, 5, 9, 11)]int numberOfItems)
        {
            decimal expectedAmount = CalculateAmountByQuantityNotDividedBy3(numberOfItems, itemPrice);
            decimal output = ShoppingCart.CalculateAmountByDiscountType(numberOfItems, itemPrice, (int)ShoppingCart.DiscountType.ThreeForTwo);

            Assert.AreEqual(expectedAmount, output);
        }

        private decimal CalculateAmountByQuantityDividedBy3(int numberOfItems, decimal price)
        {
            return (numberOfItems / 3) * 2 * price;
        }

        private decimal CalculateAmountByQuantityNotDividedBy3(int numberOfItems, decimal price)
        {
            return (((numberOfItems / 3) * 2) + (numberOfItems % 3))  * price;
        }
    }
}
