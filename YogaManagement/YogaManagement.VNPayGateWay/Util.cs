namespace YogaManagement.VNPayGateWay
{
    public class Util
    {

        private static Util instance;
        private Util() { }
        public static Util getInstance()
        {
            if (instance == null)
            {
                instance = new Util();
            }
            return instance;
        }

        public DateTime GetCurrentDateTimeInTimeZone()
        {
            TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            // Lấy thời gian hiện tại theo múi giờ địa phương của máy tính
            DateTime localTime = DateTime.Now;

            // Chuyển đổi thời gian địa phương sang múi giờ của Việt Nam
            DateTime vietnamTime = TimeZoneInfo.ConvertTime(localTime, vietnamTimeZone);

            return vietnamTime;
        }

        public DateTime GetCurrentDateInTimeZone()
        {
            TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            // Lấy thời gian hiện tại theo múi giờ địa phương của máy tính
            DateTime localTime = DateTime.Now;

            // Chuyển đổi thời gian địa phương sang múi giờ của Việt Nam
            DateTime vietnamTime = TimeZoneInfo.ConvertTime(localTime, vietnamTimeZone);

            return vietnamTime.Date;
        }
    }
}
