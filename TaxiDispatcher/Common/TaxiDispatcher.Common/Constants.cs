namespace TaxiDispatcher.Common
{
    public static class Constants
    {
        public static class RideTypes
        {
            public const int City = 0;
            public const int InterCity = 1;
        }

        public static class NightHours
        {
            public const int Evening = 22;
            public const int Morning = 6;
        }

        public static class RideStates
        {
            public const int Ordered = 0;
            public const int Accepted = 1;
        }

        public static class TaxiAvailability
        {
            public const int Distance = 15;
        }

        public static class Messages
        {
            public const string TaxiNotAvailable = "There are no available taxi vehicles!";
            public static class Validation
            {
                public const string LocationFrom = "LocationFrom must be greather than or equal 0!";
                public const string LocationTo = "LocationTo must be greather than or equal 0!";
                public const string RideType = "RideType must be 0 or 1!";
            }
        }
    }
}
