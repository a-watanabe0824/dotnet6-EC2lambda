namespace CLib
{
    public class T01
    {
        public static string ConvListToString(List<string> iList, string iKugiri = "\r\n")
        {

            string str1 = String.Empty;

            try
            {
                if (iList.Count > 0)
                {
                    for (int i = 0; i < iList.Count; i++)
                        str1 += iList[i] + iKugiri;
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

