using System;
namespace C_DotNetCore_Launch_EC2
{
    public class Property
    {

        public static string EC2ID_01
        {
            get
            {
                return $"{Environment.GetEnvironmentVariable("EC2ID_01")}";
            }
        }

        public static string EC2ID_02
        {
            get
            {
                return $"{Environment.GetEnvironmentVariable("EC2ID_02")}";
            }
        }

        public static string EC2ID_03
        {
            get
            {
                return $"{Environment.GetEnvironmentVariable("EC2ID_03")}";
            }
        }

        public static string EC2ID_04
        {
            get
            {
                return $"{Environment.GetEnvironmentVariable("EC2ID_04")}";
            }
        }
        public static string WebHook_Url
        {
            get
            {
                return $"{Environment.GetEnvironmentVariable(" WebHook_Url")}";
            }
        }
    }
}

