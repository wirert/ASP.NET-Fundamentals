namespace FootballManager.Constants
{
    public static class DataConstants
    {
        public static class User
        {
            public const int MaxUsernameLenght = 20;
            public const int MinUsernameLenght = 5;

            public const int MaxEmailLenght = 60;
            public const int MinEmailLenght = 10;

            public const int MaxPasswordLenght = 20;
            public const int MinPasswordLenght = 5;
        }

        public static class Player
        {
            public const int MaxNameLenght = 80;
            public const int MinNameLenght = 5;

            public const int MaxPositionLenght = 20;
            public const int MinPositionLenght = 5;

            public const int MaxSpeed = 10;
            public const int MinSpeed = 0;

            public const int MaxEndurace = 10;
            public const int MinEndurace = 0;

            public const int MaxDescriptionLenght = 200;
        }
    }
}
