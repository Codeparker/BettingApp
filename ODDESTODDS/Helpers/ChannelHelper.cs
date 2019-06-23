using Microsoft.AspNetCore.Mvc;
using PusherServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODDESTODDS.Helpers
{
    public class ChannelHelper
    {
        public static async Task<IActionResult> Trigger(object data, string channelName, string eventName)
        {
            var options = new PusherOptions
            {
                Cluster = "eu",
                Encrypted = true
            };
            var pusher = new Pusher(
              "809086",
              "8547d7df8ea09890aded",
              "ba7129914d053ffd14b3",
              options
            );

            var result = await pusher.TriggerAsync(
              channelName,
              eventName,
              data
            );
            return new OkObjectResult(data);
        }
    }
}
