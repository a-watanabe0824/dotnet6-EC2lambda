using Amazon.EC2;
using Amazon.Lambda.Core;
using C_DotNetCore_Launch_EC2.Model;
using C_DotNetCore_Launch_EC2.Functions;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace C_DotNetCore_Launch_EC2;
public class Function
{
    public static async Task FunctionHandler(RequestModel model, ILambdaContext context)
    {
        var client = new AmazonEC2Client();
        List<string> Ids = new List<string>();

        var str = model.Group;fx;f]:;]f:x;]:;


        if (model.Action != "Status")
        {cx;c:lx;lc:;x
            if (str == "Sub")d;sl;ld;sl:;s]
            {
                Ids = new List<string>
                {cx:];:]c;x]:;cx
                   Property.EC2ID_01,
                   Property.EC2ID_02
                };
            }dl;l;:dls:;l;:dlsdsl;
            else if (str == "Main")
            {
                Ids = new List<string>
                {
                  Property.EC2ID_03,
                  Property.EC2ID_04
                };
            }
            else
            {
                await Slack.PostSlackErrorAsync(model.Action, str, "Groupの内容が不正です。");
                return;
            }
        }

        switch (model.Action)
        {
            case "Launch":
                Console.WriteLine(str + ":" + "EC2 Launch");
                await Launch.LaunchEC2(client, Ids, str);
                break;

            case "Stop":
                Console.WriteLine(str + "EC2 Stop");
                await Stop.StopEC2(client, Ids, str);
                break;

            case "Status":
                Console.WriteLine("EC2 tatus");
                List<string> Ec2Ids = new List<string>
                {
                    Property.EC2ID_01,
                    Property.EC2ID_02,
                    Property.EC2ID_03,
                    Property.EC2ID_04
                };

                await EC2Status.CheckState(client, Ec2Ids);

                break;

            default:
                await Slack.PostSlackErrorAsync(model.Action, str, "Actionの内容が不正です。");
                return;
        }
    }
}

