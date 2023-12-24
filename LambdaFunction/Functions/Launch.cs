
﻿using Amazon.EC2;
using Amazon.EC2.Model;

namespace C_DotNetCore_Launch_EC2.Functions
{
    internal class Launch
    {
        /// <summary>
        /// EC2の起動
        /// </summary>
        /// <param name="ec2Client"></param>
        /// <param name="instanceIds"></param>
        /// <returns></returns>
        public static async Task LaunchEC2(IAmazonEC2 ec2Client, List<string> instanceId, string group)
        {
            var result = await ec2Client.StartInstancesAsync(new StartInstancesRequest(instanceId));
            var strlist =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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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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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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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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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 new List<string>();
            foreach (var si in result.StartingInstances)
            {
                var str = $"{si.CurrentState.Name}" + ":" + $"{si.InstanceId}";
                strlist.Add(str);
            }
            await Slack.PostToSlackChannel(strlist, "Start", group);
        }
    }
}

﻿v//vlcklk


あああてすと
