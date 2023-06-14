namespace BusStation.Constants
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

        public static class Destination
        {
            public const int MaxNameLenght = 50;
            public const int MinNameLenght = 2;
            
            public const int MaxOriginLenght = 50;
            public const int MinOriginLenght = 2;

            public const int MaxDateLength = 30;

            public const int MaxTimeLength = 30;
        }

        public static class Ticket
        {
            public const double MinPrice = 10.0;
            public const double MaxPrice = 90.0;
        }
    }
}
