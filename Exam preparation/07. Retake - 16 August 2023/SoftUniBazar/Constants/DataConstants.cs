namespace SoftUniBazar.Constants
{
    public static class DataConstants
    {
        public static class Ad
        {
            public const int MaxNameLength = 25;
            public const int MinNameLength = 5;

            public const int MaxDescriptionLength = 250;
            public const int MinDescriptionLength = 15;

            public const string DateTimeFormat = "yyyy-MM-dd H:mm";
        }

        public static class Category
        {
            public const int MaxNameLength = 15;
            public const int MinNameLength = 3;
        }
    }
}
