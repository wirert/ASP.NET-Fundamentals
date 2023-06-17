namespace SMS.Data
{
    public static class DataConstants
    {
        public static class User
        {
            public const int MaxUserNameLenght = 20;
            public const int MinUserNameLenght = 5;

            public const int MaxPasswordLenght = 20;
            public const int MinPasswordLenght = 6;
        }

        public static class Product
        {
            public const int MaxNameLenght = 20;
            public const int MinNameLenght = 4;

            public const double MaxPrice = 1000;
            public const double MinPrice = 0.05;
        }
    }
}
