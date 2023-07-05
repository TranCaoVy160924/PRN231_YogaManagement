namespace YogaCenterAPIV2.Utils
{
    public class Constant
    {
        public static string FORMAT_DATETIME = "yyyyMMddHHmmss";
        public static int VIETNAM_TIME_ZONE = 7;
        private static Constant instance;
        private Constant() { }
        public static Constant getInstance()
        {
            if (instance == null)
            {
                instance = new Constant();
            }
            return instance;
        }
        public class Role
        {
            public static int ADMIN_ROLEID = 1;
            public static int STAFF_ROLEID = 2;
            public static int TRAINER_ROLEID = 3;
            public static int TRAINEE_ROLEID = 4;
        }

        public class Level
        {
            public static string BEGINNER_LEVEL = "Beginner";
            public static string INTERMEDIATE_LEVEL = "Intermediate";
            public static string ADVANCED_LEVEL = "Advanced";
        }

        public class FeedbackStatus
        {
            public static int UNCHECKED = 0;
            public static int APPROVED = 1;
            public static int REJECTED = 2;
        }

        public class BlogStatus
        {
            public static int UNCHECKED = 0;
            public static int APPROVED = 1;
            public static int REJECTED = 2;
        }

        public class Class
        {
            //public static int MAX_TRAINEE_NUMBER = 40;
            public static int PENDING = 1;
            public static int ACTIVE = 2;
            public static int CLOSED = 3;
            public static bool UNFINISHED = false;
            public static bool FINISHED = true;
        }

        public class Booking
        {
            public static int PENDING_PAY = 0;
            public static int SUCCESS_PAY = 1;
            public static int FAIL_PAY = 2;
            public static int FAIL_REFUND = 3;
            public static int SUCCESS_REFUND = 4;
            public static int RESERVED = 5;
            public static int PENDING_REFUND = 6;
            public static int SUCCESS_ATM = 7;

        }

        public class SettingValue
        {
            public static int PAYINGTIME = 1;
            public static int REFUNDTIME = 2;
            public static int MINOFTRAINEE = 3;
            public static int MAXOFTRAINEE = 4;
        }
    }
}
