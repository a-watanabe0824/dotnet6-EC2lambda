namespace CLib
{
    public class T01
    {
        public static string ConvListToString(List<string> strList)
        {

            string str1 = String.Empty;

            try
            {
                if (strList.Count > 0)
                {
                    for (int i = 0; i < iList.Count; i++)
                        str1 += strList[i] + "\r\n";
                }

                return str1;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Exception Error");
                return "Exception Error";
            }
        }
    }
}

