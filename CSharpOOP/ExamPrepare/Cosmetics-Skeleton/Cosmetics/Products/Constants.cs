namespace Cosmetics.Products
{
    public static class Constants
    {
        public const string ValidityMessageForNullOrEmptyString = "can not be null or empty value!";
        public const string ValidityMessageForNullObject = "can not be a null value!";

        public const int MinLettersProductNameLength = 3;
        public const int MaxLettersProductNameLength = 10;
        public const int MinLettersProductBrandLength = 2;
        public const int MaxLettersProductBrandLength = 10;

        public const int MinLettersIngradientLength = 4;
        public const int MaxLettersIngradientLength = 12;

        public const int MinLettersCategoryName = 2;
        public const int MaxLettersCategoryName = 15;

        public const decimal DefaultShoppingCartTotalPriceValue = 0;

    }
}
