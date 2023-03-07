using Amazon.EC2;
using Amazon.EC2.Model;

namespace C_DotNetCore_Launch_EC2.Functions
{
    internal class Stop
    {
        /// <summary>
        /// EC2の停止
        /// </summary>
        /// <param name="ec2Client"></param>
        /// <param name="instanceIds"></param>
        /// <returns></returns>
        public static async Task StopEC2(IAmazonEC2 ec2Client, List<string> instanceId, string group)
        {
            var result = await ec2Client.StopInstancesAsync(new StopInstancesRequest(instanceId));
            var strlist = new List<string>();
            foreach (var si in result.StoppingInstances)
            {
                var str = $"{si.CurrentState.Name}" + ":" + $"{si.InstanceId}";
                strlist.Add(str);
            }
            await Slack.PostToSlackChannel(strlist, "Stop", group);
        }
    }
}
