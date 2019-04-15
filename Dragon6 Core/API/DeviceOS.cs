using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonFruit.Six.Core.API
{
    public class DeviceOS
    {
        //private static string GetUserEnvironment(HttpRequest request)
        //{
        //    var browser = request.Browser;
        //    var platform = GetUserPlatform(request);
        //    return string.Format("{0} {1} / {2}", browser.Browser, browser.Version, platform);
        //}

        //public static string GetUserPlatform(HttpRequest request)
        //{
        //    var ua = request.Headers["User-Agent"];

        //    if (ua.Contains("Android"))
        //        return string.Format("Android {0}", GetMobileVersion(ua, "Android"));

        //    if (ua.Contains("iPad"))
        //        return string.Format("iPad OS {0}", GetMobileVersion(ua, "OS"));

        //    if (ua.Contains("iPhone"))
        //        return string.Format("iPhone OS {0}", GetMobileVersion(ua, "OS"));

        //    if (ua.Contains("Linux") && ua.Contains("KFAPWI"))
        //        return "Kindle Fire";

        //    if (ua.Contains("RIM Tablet") || ua.Contains("BB") && ua.Contains("Mobile"))
        //        return "Black Berry";

        //    if (ua.Contains("Windows Phone"))
        //        return string.Format("Windows Phone {0}", GetMobileVersion(ua, "Windows Phone"));

        //    if (ua.Contains("Mac OS"))
        //        return "Mac OS";

        //    if (ua.Contains("Windows NT 5.1") || ua.Contains("Windows NT 5.2"))
        //        return "Windows XP";

        //    if (ua.Contains("Windows NT 6.0"))
        //        return "Windows Vista";

        //    if (ua.Contains("Windows NT 6.1"))
        //        return "Windows 7";

        //    if (ua.Contains("Windows NT 6.2"))
        //        return "Windows 8";

        //    if (ua.Contains("Windows NT 6.3"))
        //        return "Windows 8.1";

        //    if (ua.Contains("Windows NT 10"))
        //        return "Windows 10";

        //    //fallback to basic platform:
        //    return request.Browser.Platform + (ua.Contains("Mobile") ? " Mobile " : "");
        //}

        public static bool IsCompatibleWindows(HttpRequest request)
        {
            try
            {
                if (request.Headers["User-Agent"].ToString().Contains("Windows NT 10")) return true;
            }
            catch{ }
            return false;
        }

        public static bool IsCompatibleiPhone(HttpRequest request)
        {
            var ua = request.Headers["User-Agent"].ToString();
            if (!ua.Contains("iPhone")) return false;
            if (double.Parse(GetMobileVersion(ua, "OS")) > 10.3)
                return true;
            return false;
        }

        public static bool IsCompatibleAndroid(HttpRequest request)
        {
            try
            {
                var ua = request.Headers["User-Agent"].ToString();
                if (!ua.Contains("Android")) return false;
                if (double.Parse(GetMobileVersion(ua, "Android").Split('.')[0]) > 5)
                    return true;
            }
            catch { }
            return false;
        }

        public static string GetMobileVersion(string userAgent, string device)
        {
            var temp = userAgent.Substring(userAgent.IndexOf(device) + device.Length).TrimStart();
            var version = string.Empty;

            foreach (var character in temp)
            {
                var validCharacter = false;
                var test = 0;

                if (int.TryParse(character.ToString(), out test))
                {
                    version += character;
                    validCharacter = true;
                }

                if (character == '.' || character == '_')
                {
                    version += '.';
                    validCharacter = true;
                }

                if (validCharacter == false)
                    break;
            }

            return version;
        }
    }
}
