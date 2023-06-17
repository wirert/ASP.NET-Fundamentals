namespace Watchlist.Constants
{
    public static class DataConstants
    {
        public static class User
        {
            public const int MaxUserNameLenght = 20;
            public const int MinUserNameLenght = 5;

            public const int MaxEmailLenght = 60;
            public const int MinEmailLenght = 10;

            public const int MaxPasswordLenght = 20;
            public const int MinPasswordlLenght = 5;
        }

        public static class Movie
        {
            public const int MaxTitleLenght = 50;
            public const int MinTitleLenght = 10;

            public const int MaxDirectorLenght = 50;
            public const int MinDirectorLenght = 5;

            public const double MaxRating = 10.00;
            public const double MinRating = 0.00;
        }

        public static class Genre
        {
            public const int MaxNameLenght = 50;
            public const int MinNameLenght = 5;
        }
    }
}
