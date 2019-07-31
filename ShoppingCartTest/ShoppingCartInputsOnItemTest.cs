using NUnit.Framework;
using ShoppingCart_ConsoleApp;

namespace ShoppingCartTest
{
    [TestFixture]
    public class ShoppingCartInputsOnItemTest
    {
        string invalidErrorMessage = "Invalid input entry. Please enter only integers";

        [Test]
        public void when_Item_Value_Is_Integer([Values(1,2,3,40)] int input)
        {
            string output = ShoppingCart.GetValues(input.ToString());

            Assert.AreEqual(input.ToString(), output);
        }

        [Test]
        public void when_Item_Value_Is_string_return_error()
        {
            string input = "Test";

            string output = ShoppingCart.GetValues(input);

            Assert.AreEqual(invalidErrorMessage, output);
        }
        [Test]
        public void when_Item_Value_Is_symbols_return_error()
        {
            string input = "#";

            string output = ShoppingCart.GetValues(input);

            Assert.AreEqual(invalidErrorMessage, output);
        }
        [Test]
        public void when_Item_Value_Is_whitespaces_return_error()
        {
            string input = "  ";

            string output = ShoppingCart.GetValues(input);

            Assert.AreEqual(invalidErrorMessage, output);
        }

    }
}
