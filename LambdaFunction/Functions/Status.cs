using Amazon.EC2;
using Amazon.EC2.Model;
namespace C_DotNetCore_Launch_EC2.Functions
{
    internal class EC2Status
    {
        /// <summary>
        /// instanceの状態を確認
        /// </summary>
        /// <param name="ec2Client"></param>
        /// <param name="instanceIds"></param>
        /// <returns></returns>
        public static async Task CheckState(IAmazonEC2 ec2Client, List<string> instanceIds)
        {


            vcvcっkvcjkvjcjkcvj
            vcっkvckvcjkcjkjvckj
            
            string EC2ID_01 = Property.EC2ID_01;
            string EC2ID_02 = Property.EC2ID_02;
            int numberRunning;
            DescribeInstancesResponse responseDescribe;
            var requestDescribe = new DescribeInstancesRequest
            {
                InstanceIds = instanceIds
            };

            // Check every couple of seconds
            int wait = 2000;
            while (true)
            {
                Console.Write(".");
                numberRunning = 0;
                responseDescribe = await ec2Client.DescribeInstancesAsync(requestDescribe);
                foreach (Instance i in responseDescribe.Reservations[0].Instances)
                {
                    if ((i.State.Code & 255) > 0) numberRunning++;
                }
                if (numberRunning == responseDescribe.Reservations[0].Instances.Count)
                    break;
                Thread.Sleep(wait);
                if (Console.KeyAvailable)
                    break;
            }

            Console.WriteLine("\nNo more instances are pending.");

            var　EC2States = new List<string>();
            for (int i = 0; i < responseDescribe.Reservations.Count; i++)
            {
                foreach (Instance z in responseDescribe.Reservations[i].Instances)
                {
                    var Group = "";
                    if (EC2ID_01 == z.InstanceId || EC2ID_02 == z.InstanceId)
                    {
                        Group = "Main";
                    }
                    else
                    {
                        Group = "Sub";
                    }
                    var str =
                                   "///////////////////////////////////////////////////////////" + "\n" +
                                   "Group" + ":" + Group + "\n" +
                                   "Instance Id" + ":" + $"{z.InstanceId}" + "\n" +
                                   "Status" + ":" + $"{z.State.Name}" + "\n" +
                                    "Public Ip" + ":" + $"{z.PublicIpAddress}";
                    Console.WriteLine(str);
                    EC2States.Add(str);
                }
            }

            await Slack.PostToSlackChannel(E2States, "Status", "All");
        }
    }
}
