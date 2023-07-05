using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using YogaCenterLibrary.Models;
using BCryptNet = BCrypt.Net;

namespace YogaCenterAPIV2.Utils
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

        public string GetContentRecoveryCode(string recipient)
        {
            string code = GenerateRandomString();
            string content = @"<!DOCTYPE html>
<html>

<head>
    <title></title>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
    <style type=""text/css"">
        @media screen {
            @font-face {
                font-family: 'Lato';
                font-style: normal;
                font-weight: 400;
                src: local('Lato Regular'), local('Lato-Regular'), url(https://fonts.gstatic.com/s/lato/v11/qIIYRU-oROkIk8vfvxw6QvesZW2xOQ-xsNqO47m55DA.woff) format('woff');
            }

            @font-face {
                font-family: 'Lato';
                font-style: normal;
                font-weight: 700;
                src: local('Lato Bold'), local('Lato-Bold'), url(https://fonts.gstatic.com/s/lato/v11/qdgUG4U09HnJwhYI-uK18wLUuEpTyoUstqEm5AMlJo4.woff) format('woff');
            }

            @font-face {
                font-family: 'Lato';
                font-style: italic;
                font-weight: 400;
                src: local('Lato Italic'), local('Lato-Italic'), url(https://fonts.gstatic.com/s/lato/v11/RYyZNoeFgb0l7W3Vu1aSWOvvDin1pK8aKteLpeZ5c0A.woff) format('woff');
            }

            @font-face {
                font-family: 'Lato';
                font-style: italic;
                font-weight: 700;
                src: local('Lato Bold Italic'), local('Lato-BoldItalic'), url(https://fonts.gstatic.com/s/lato/v11/HkF_qI1x_noxlxhrhMQYELO3LdcAZYWl9Si6vvxL-qU.woff) format('woff');
            }
        }

        /* CLIENT-SPECIFIC STYLES */
        body,
        table,
        td,
        a {
            -webkit-text-size-adjust: 100%;
            -ms-text-size-adjust: 100%;
        }

        table,
        td {
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
        }

        img {
            -ms-interpolation-mode: bicubic;
        }

        /* RESET STYLES */
        img {
            border: 0;
            height: auto;
            line-height: 100%;
            outline: none;
            text-decoration: none;
        }

        table {
            border-collapse: collapse !important;
        }

        body {
            height: 100% !important;
            margin: 0 !important;
            padding: 0 !important;
            width: 100% !important;
        }

        /* iOS BLUE LINKS */
        a[x-apple-data-detectors] {
            color: inherit !important;
            text-decoration: none !important;
            font-size: inherit !important;
            font-family: inherit !important;
            font-weight: inherit !important;
            line-height: inherit !important;
        }

        /* MOBILE STYLES */
        @media screen and (max-width:600px) {
            h1 {
                font-size: 32px !important;
                line-height: 32px !important;
            }
        }

        /* ANDROID CENTER FIX */
        div[style*=""margin: 16px 0;""] {
            margin: 0 !important;
        }
    </style>
</head>

<body style=""background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;"">
    <!-- HIDDEN PREHEADER TEXT -->
    <div style=""display: none; font-size: 1px; color: #fefefe; line-height: 1px; font-family: 'Lato', Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;""> We're thrilled to have you here! Get ready to dive into your new account.
    </div>
    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
        <!-- LOGO -->
        <tr>
            <td bgcolor=""F2CED8 "" align=""center"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td align=""center"" valign=""top"" style=""padding: 40px 10px 40px 10px;""> </td>
                    </tr>
                </table>

                
            </td>
        </tr>
        <tr>
            <td bgcolor=""F2CED8 "" align=""center"" style=""padding: 0px 10px 0px 10px;"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td bgcolor=""#ffffff"" align=""center"" valign=""top"" style=""padding: 40px 20px 20px 20px; border-radius: 4px 4px 0px 0px; color: #111111; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 48px; font-weight: 400; letter-spacing: 4px; line-height: 48px;"">
                            <h1 style=""font-size: 48px; font-weight: 400; margin: 2;"">Welcome!</h1> 
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td bgcolor=""#f4f4f4"" align=""center"" style=""padding: 0px 10px 0px 10px;"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"" style=""padding: 20px 30px 40px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                            <p style=""margin: 0;"">We received a request to recover your password because you forgot it. We provide validation code for you to restore. The validation code is below.</p>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"">
                            <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                <tr>
                                    <td bgcolor=""#ffffff"" align=""center"" style=""padding: 20px 30px 60px 30px;"">
                                        <table border=""0"" cellspacing=""0"" cellpadding=""0"">
                                            <tr>
                                                <td align=""center"" style=""border-radius: 3px;"" bgcolor=""F2CED8 ""><a  target=""_blank"" style=""font-size: 20px; font-family: Helvetica, Arial, sans-serif; color: #000; text-decoration: none; color: #000; text-decoration: none; padding: 15px 25px; border-radius: 2px; border: 1px solid F2CED8 ; display: inline-block;"">" + code + @"</a></td>

                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr> 
                  
                    
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"" style=""padding: 0px 30px 20px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                            <p style=""margin: 0;"">If you have any questions, just reply to this email&mdash;we're always happy to help out.</p>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"" style=""padding: 0px 30px 40px 30px; border-radius: 0px 0px 4px 4px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                            <p style=""margin: 0;"">Cheers,<br>Yoga Center Team</p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
      
    </table>
</body>

</html>"; ;
            SendEmail(recipient, "Validation Code Request", content);
            return code;
        }
        public string GetContentRegisterCode(string recipient)
        {
            string code = GenerateRandomString();
            string content = @"<!DOCTYPE html>
<html>

<head>
    <title></title>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
    <style type=""text/css"">
        @media screen {
            @font-face {
                font-family: 'Lato';
                font-style: normal;
                font-weight: 400;
                src: local('Lato Regular'), local('Lato-Regular'), url(https://fonts.gstatic.com/s/lato/v11/qIIYRU-oROkIk8vfvxw6QvesZW2xOQ-xsNqO47m55DA.woff) format('woff');
            }

            @font-face {
                font-family: 'Lato';
                font-style: normal;
                font-weight: 700;
                src: local('Lato Bold'), local('Lato-Bold'), url(https://fonts.gstatic.com/s/lato/v11/qdgUG4U09HnJwhYI-uK18wLUuEpTyoUstqEm5AMlJo4.woff) format('woff');
            }

            @font-face {
                font-family: 'Lato';
                font-style: italic;
                font-weight: 400;
                src: local('Lato Italic'), local('Lato-Italic'), url(https://fonts.gstatic.com/s/lato/v11/RYyZNoeFgb0l7W3Vu1aSWOvvDin1pK8aKteLpeZ5c0A.woff) format('woff');
            }

            @font-face {
                font-family: 'Lato';
                font-style: italic;
                font-weight: 700;
                src: local('Lato Bold Italic'), local('Lato-BoldItalic'), url(https://fonts.gstatic.com/s/lato/v11/HkF_qI1x_noxlxhrhMQYELO3LdcAZYWl9Si6vvxL-qU.woff) format('woff');
            }
        }

        /* CLIENT-SPECIFIC STYLES */
        body,
        table,
        td,
        a {
            -webkit-text-size-adjust: 100%;
            -ms-text-size-adjust: 100%;
        }

        table,
        td {
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
        }

        img {
            -ms-interpolation-mode: bicubic;
        }

        /* RESET STYLES */
        img {
            border: 0;
            height: auto;
            line-height: 100%;
            outline: none;
            text-decoration: none;
        }

        table {
            border-collapse: collapse !important;
        }

        body {
            height: 100% !important;
            margin: 0 !important;
            padding: 0 !important;
            width: 100% !important;
        }

        /* iOS BLUE LINKS */
        a[x-apple-data-detectors] {
            color: inherit !important;
            text-decoration: none !important;
            font-size: inherit !important;
            font-family: inherit !important;
            font-weight: inherit !important;
            line-height: inherit !important;
        }

        /* MOBILE STYLES */
        @media screen and (max-width:600px) {
            h1 {
                font-size: 32px !important;
                line-height: 32px !important;
            }
        }

        /* ANDROID CENTER FIX */
        div[style*=""margin: 16px 0;""] {
            margin: 0 !important;
        }
    </style>
</head>

<body style=""background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;"">
    <!-- HIDDEN PREHEADER TEXT -->
    <div style=""display: none; font-size: 1px; color: #fefefe; line-height: 1px; font-family: 'Lato', Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;""> We're thrilled to have you here! Get ready to dive into your new account.
    </div>
    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
        <!-- LOGO -->
        <tr>
            <td bgcolor=""F2CED8 "" align=""center"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td align=""center"" valign=""top"" style=""padding: 40px 10px 40px 10px;""> </td>
                    </tr>
                </table>

                
            </td>
        </tr>
        <tr>
            <td bgcolor=""F2CED8 "" align=""center"" style=""padding: 0px 10px 0px 10px;"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td bgcolor=""#ffffff"" align=""center"" valign=""top"" style=""padding: 40px 20px 20px 20px; border-radius: 4px 4px 0px 0px; color: #111111; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 48px; font-weight: 400; letter-spacing: 4px; line-height: 48px;"">
                            <h1 style=""font-size: 48px; font-weight: 400; margin: 2;"">Welcome!</h1> 
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td bgcolor=""#f4f4f4"" align=""center"" style=""padding: 0px 10px 0px 10px;"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"" style=""padding: 20px 30px 40px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                            <p style=""margin: 0;"">We're excited to have you get started. First, you need to confirm your account. The validation code is below.</p>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"">
                            <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                <tr>
                                    <td bgcolor=""#ffffff"" align=""center"" style=""padding: 20px 30px 60px 30px;"">
                                        <table border=""0"" cellspacing=""0"" cellpadding=""0"">
                                            <tr>
                                                <td align=""center"" style=""border-radius: 3px;"" bgcolor=""F2CED8 ""><a  target=""_blank"" style=""font-size: 20px; font-family: Helvetica, Arial, sans-serif; color: #000; text-decoration: none; color: #000; text-decoration: none; padding: 15px 25px; border-radius: 2px; border: 1px solid F2CED8 ; display: inline-block;"">" + code + @"</a></td>

                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr> 
                  
                    
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"" style=""padding: 0px 30px 20px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                            <p style=""margin: 0;"">If you have any questions, just reply to this email&mdash;we're always happy to help out.</p>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"" style=""padding: 0px 30px 40px 30px; border-radius: 0px 0px 4px 4px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                            <p style=""margin: 0;"">Cheers,<br>Yoga Center Team</p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
      
    </table>
</body>

</html>";
            SendEmail(recipient, "Validation Code Request", content);
            return code;
        }
        public void GetContentThankYou(string? recipient, string? name)
        {
            string content = @"<!DOCTYPE html>
<html>

<head>
    <title></title>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
    <style type=""text/css"">
        @media screen {
            @font-face {
                font-family: 'Lato';
                font-style: normal;
                font-weight: 400;
                src: local('Lato Regular'), local('Lato-Regular'), url(https://fonts.gstatic.com/s/lato/v11/qIIYRU-oROkIk8vfvxw6QvesZW2xOQ-xsNqO47m55DA.woff) format('woff');
            }

            @font-face {
                font-family: 'Lato';
                font-style: normal;
                font-weight: 700;
                src: local('Lato Bold'), local('Lato-Bold'), url(https://fonts.gstatic.com/s/lato/v11/qdgUG4U09HnJwhYI-uK18wLUuEpTyoUstqEm5AMlJo4.woff) format('woff');
            }

            @font-face {
                font-family: 'Lato';
                font-style: italic;
                font-weight: 400;
                src: local('Lato Italic'), local('Lato-Italic'), url(https://fonts.gstatic.com/s/lato/v11/RYyZNoeFgb0l7W3Vu1aSWOvvDin1pK8aKteLpeZ5c0A.woff) format('woff');
            }

            @font-face {
                font-family: 'Lato';
                font-style: italic;
                font-weight: 700;
                src: local('Lato Bold Italic'), local('Lato-BoldItalic'), url(https://fonts.gstatic.com/s/lato/v11/HkF_qI1x_noxlxhrhMQYELO3LdcAZYWl9Si6vvxL-qU.woff) format('woff');
            }
        }

        /* CLIENT-SPECIFIC STYLES */
        body,
        table,
        td,
        a {
            -webkit-text-size-adjust: 100%;
            -ms-text-size-adjust: 100%;
        }

        table,
        td {
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
        }

        img {
            -ms-interpolation-mode: bicubic;
        }

        /* RESET STYLES */
        img {
            border: 0;
            height: auto;
            line-height: 100%;
            outline: none;
            text-decoration: none;
        }

        table {
            border-collapse: collapse !important;
        }

        body {
            height: 100% !important;
            margin: 0 !important;
            padding: 0 !important;
            width: 100% !important;
        }

        /* iOS BLUE LINKS */
        a[x-apple-data-detectors] {
            color: inherit !important;
            text-decoration: none !important;
            font-size: inherit !important;
            font-family: inherit !important;
            font-weight: inherit !important;
            line-height: inherit !important;
        }

        /* MOBILE STYLES */
        @media screen and (max-width:600px) {
            h1 {
                font-size: 32px !important;
                line-height: 32px !important;
            }
        }

        /* ANDROID CENTER FIX */
        div[style*=""margin: 16px 0;""] {
            margin: 0 !important;
        }
    </style>
</head>

<body style=""background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;"">
    <!-- HIDDEN PREHEADER TEXT -->
    <div style=""display: none; font-size: 1px; color: #fefefe; line-height: 1px; font-family: 'Lato', Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;""> We're thrilled to have you here! Get ready to dive into your new account.
    </div>
    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
        <!-- LOGO -->
        <tr>
            <td bgcolor=""F2CED8 "" align=""center"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td align=""center"" valign=""top"" style=""padding: 40px 10px 40px 10px;""> </td>
                    </tr>
                </table>

                
            </td>
        </tr>
        <tr>
            <td bgcolor=""F2CED8 "" align=""center"" style=""padding: 0px 10px 0px 10px;"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td bgcolor=""#ffffff"" align=""center"" valign=""top"" style=""padding: 40px 20px 20px 20px; border-radius: 4px 4px 0px 0px; color: #111111; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 48px; font-weight: 400; letter-spacing: 4px; line-height: 48px;"">
                            <h1 style=""font-size: 48px; font-weight: 400; margin: 2;"">Welcome!</h1> 
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td bgcolor=""#f4f4f4"" align=""center"" style=""padding: 0px 10px 0px 10px;"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"" style=""padding: 20px 30px 40px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                             <p style=""margin: 0;"">Dear " + name + @",</p>
                          
                            <p style=""margin: 0;"">We are delighted to inform you that your account has been successfully created. On behalf of our team at Yoga Center, we would like to extend our heartfelt gratitude for choosing our service and placing your trust in us.</p>
                        </td>
                    </tr>
                
                  
                    
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"" style=""padding: 0px 30px 20px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                            <p style=""margin: 0;"">At Yoga Center, we are committed to providing exceptional service to our valued customers, and we are thrilled to have you as a part of our community. Your support and trust mean a lot to us, and we assure you that we will strive to exceed your expectations.</p>
                           
                            <p style=""margin: 0;"">If you have any questions or need any assistance, please feel free to reach out to us. Our dedicated team is always here to help.</p>
                            <p style=""margin: 0;"">Once again, thank you for joining us. We look forward to serving you and providing you with a seamless experience.</p>

                        </td>
                    </tr>
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"" style=""padding: 0px 30px 40px 30px; border-radius: 0px 0px 4px 4px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                            <p style=""margin: 0;"">Best regards,<br>Yoga Center Team</p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
      
    </table>
</body>

</html>";
            SendEmail(recipient, "Thank You for Joining Our Yoga Service!", content);
        }
        public void GetContentBooking(Account AccountDto, Course CourseDTO, Booking BookingDto, Setting SettingDto)
        {
            string? recipient = AccountDto.Email;
            string? name = AccountDto.Firstname;
            string contentStatus=" ", status =" ";
            DateTime datetime = new DateTime() ;
            if (BookingDto.Status == Constant.Booking.PENDING_PAY || BookingDto.Status == Constant.Booking.RESERVED)
            {
                contentStatus = @" <tr>
                        <td bgcolor=""#ffffff"" align=""left"" style=""padding: 0px 30px 10px 30px; color: red; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                            <p style=""margin: 0;"">*** Note that you must pay this bill within " + SettingDto.PreactiveValue + @" hours. ***</p>
                        </td>
                    </tr>";
                status = "Pending";
                datetime = (DateTime)BookingDto.BookingDate;
            }else if (BookingDto.Status == Constant.Booking.SUCCESS_PAY)
            {
                contentStatus = "";
                status = "Success";
                datetime = (DateTime)BookingDto.PayDate;


            }else if(BookingDto.Status == Constant.Booking.SUCCESS_REFUND)
            {
                contentStatus = "";
                status = "Refund Success";
                datetime = (DateTime)BookingDto.RefundDate;

            }
            else if (BookingDto.Status == Constant.Booking.SUCCESS_ATM)
            {
                contentStatus = @" <tr>
                        <td bgcolor=""#ffffff"" align=""left"" style=""padding: 0px 30px 10px 30px; color: red; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                            <p style=""margin: 0;"">*** Your booking is being processed. We will get back to you within the next 3 hours. Please pay attention to the phone. ***</p>
                        </td>
                    </tr>";
                status = "Pending confirm..";
                datetime = (DateTime)BookingDto.BookingDate;

            }

            string content = @"<!DOCTYPE html>
<html>

<head>
    <title>Thank You!</title>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
    <style type=""text/css"">
        @media screen {
            @font-face {
                font-family: 'Lato';
                font-style: normal;
                font-weight: 400;
                src: local('Lato Regular'), local('Lato-Regular'), url(https://fonts.gstatic.com/s/lato/v11/qIIYRU-oROkIk8vfvxw6QvesZW2xOQ-xsNqO47m55DA.woff) format('woff');
            }

            @font-face {
                font-family: 'Lato';
                font-style: normal;
                font-weight: 700;
                src: local('Lato Bold'), local('Lato-Bold'), url(https://fonts.gstatic.com/s/lato/v11/qdgUG4U09HnJwhYI-uK18wLUuEpTyoUstqEm5AMlJo4.woff) format('woff');
            }

            @font-face {
                font-family: 'Lato';
                font-style: italic;
                font-weight: 400;
                src: local('Lato Italic'), local('Lato-Italic'), url(https://fonts.gstatic.com/s/lato/v11/RYyZNoeFgb0l7W3Vu1aSWOvvDin1pK8aKteLpeZ5c0A.woff) format('woff');
            }

            @font-face {
                font-family: 'Lato';
                font-style: italic;
                font-weight: 700;
                src: local('Lato Bold Italic'), local('Lato-BoldItalic'), url(https://fonts.gstatic.com/s/lato/v11/HkF_qI1x_noxlxhrhMQYELO3LdcAZYWl9Si6vvxL-qU.woff) format('woff');
            }
        }

        /* CLIENT-SPECIFIC STYLES */
        body,
        table,
        td,
        a {
            -webkit-text-size-adjust: 100%;
            -ms-text-size-adjust: 100%;
        }

        table,
        td {
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
        }

        img {
            -ms-interpolation-mode: bicubic;
        }

        /* RESET STYLES */
        img {
            border: 0;
            height: auto;
            line-height: 100%;
            outline: none;
            text-decoration: none;
        }

        table {
            border-collapse: collapse !important;
        }

        body {
            height: 100% !important;
            margin: 0 !important;
            padding: 0 !important;
            width: 100% !important;
        }

        /* iOS BLUE LINKS */
        a[x-apple-data-detectors] {
            color: inherit !important;
            text-decoration: none !important;
            font-size: inherit !important;
            font-family: inherit !important;
            font-weight: inherit !important;
            line-height: inherit !important;
        }

        /* MOBILE STYLES */
        @media screen and (max-width: 600px) {
            h1 {
                font-size: 32px !important;
                line-height: 32px !important;
            }
        }

        /* ANDROID CENTER FIX */
        div[style*=""margin: 16px 0;""] {
            margin: 0 !important;
        }

        .payment-table {
            font-family: 'Lato';
                font-weight: 400;
            font-size: 14px;
            width: 100%;
            max-width: 600px;
            margin: 20px auto;
        }

        .payment-table th,
        .payment-table td {
            padding: 10px;
            text-align: center;
            border: 1px solid #ddd;
        }

        .payment-table .total-row {
            font-weight: bold;
        }
    </style>
</head>

<body style=""background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;"">
    
    <!-- HIDDEN PREHEADER TEXT -->
  
    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
        <!-- LOGO -->
     
        <tr>
            <td bgcolor=""#F2CED8"" align=""center"" style=""padding: 0px 10px 0px 10px;"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td bgcolor=""#ffffff"" align=""center"" valign=""top"" style=""padding: 40px 20px 20px 20px; border-radius: 4px 4px 0px 0px; color: #111111; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 48px; font-weight: 400; letter-spacing: 4px; line-height: 48px;"">
                            <h1 style=""font-size: 48px; font-weight: 400; margin: 2;"">Thank you!</h1>
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
        <tr>
            <td bgcolor=""#f4f4f4"" align=""center"" style=""padding: 0px 10px 0px 10px;"">
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"" style=""padding: 20px 30px 10px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                            <p style=""margin: 0;"">Dear " + name + @",</p>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"" style=""padding: 20px 30px 20px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                            <p style=""margin: 0;"">We would like to extend our sincere appreciation for your promptness and reliability in settling the invoice for our course. Your timely payment not only demonstrates your commitment to our business partnership but also greatly contributes to our continued growth and success.</p>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor=""#ffffff"" align=""center"" style=""padding: 0px 10px 0px 10px;"">
                            <table class=""payment-table"" cellpadding=""0"" cellspacing=""0"">
                                <thead>
                                    <tr>
                                        <th scope=""col"">Course Name</th>
                                        <th scope=""col"">Date</th>
                                        <th scope=""col"">Amount</th>
                                        <th scope=""col"">Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                                 
                                    <tr>
                                        <td>" + CourseDTO.CourseName + @"</td>
                                        <td>" + datetime + @"</td>
                                        <td>" + BookingDto.Amount + @"đ</td>
                                        <td>"+status+@"</td>
                                    </tr>
                                   
                                </tbody>
                            </table>
                        </td>
                    </tr>
                   "+ contentStatus+@"
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"" style=""padding: 0px 30px 20px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                            <p style=""margin: 0;"">If you have any questions, just reply to this email&mdash;we're always happy to help out.</p>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"" style=""padding: 0px 30px 40px 30px; border-radius: 0px 0px 4px 4px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                            <p style=""margin: 0;"">Cheers,<br>Yoga Center Team</p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
      
    </table>
</body>

</html>
";
            SendEmail(recipient, "Thank you for your booking", content);
        }
        public string GenerateRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 5)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
        public void SendEmail(string recipient, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Yoga Center", "yogacenter.contact@gmail.com"));
            message.To.Add(new MailboxAddress("Trainee", recipient));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = body;
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                client.Authenticate("yogacenter.contact@gmail.com", "ltndmfckyoefvhgh");
                client.Send(message);
                client.Disconnect(true);
            }
        }



        public static string HashPassword(string? password)
        {
            string salt = BCryptNet.BCrypt.GenerateSalt();
            string hashedPassword = BCryptNet.BCrypt.HashPassword(password, salt);
            return hashedPassword;
        }

        public static bool VerifyPassword(string? password, string? hashedPassword)
        {
            return BCryptNet.BCrypt.Verify(password, hashedPassword);
        }

        public static DateTime ParseDateTime(string? dateString, string? format)
        {
            DateTime dateTime;
            bool success = DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);

            if (success)
            {
                return dateTime;
            }
            else
            {
                throw new Exception("Unable to convert string to DateTime.");
            }
        }
        public static string FormatDateTime(DateTime? dateTime, string format)
        {
            return dateTime?.ToString(format);
        }

        public string ReadAppSettingsJson()
        {
            var appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            return File.ReadAllText(appSettingsPath);
        }
        public void UpdateAppSettingValue(string section, string key, string value)
        {
            var appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            var json = File.ReadAllText(appSettingsPath);
            var settings = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            if (settings.ContainsKey(section) && settings[section] is JObject sectionObject)
            {
                if (sectionObject.ContainsKey(key))
                {
                    sectionObject[key] = value;
                    var updatedJson = JsonConvert.SerializeObject(settings, Formatting.Indented);
                    File.WriteAllText(appSettingsPath, updatedJson);
                }
            }
        }



    }
}
