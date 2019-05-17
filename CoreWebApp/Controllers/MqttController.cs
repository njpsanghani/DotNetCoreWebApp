using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Extensions.Rpc;
using MQTTnet.Protocol;



namespace CoreWebApp.Controllers
{
    [Route("api/[controller]")]
    public class MqttController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();
            var rpcClient = new MqttRpcClient(mqttClient);

    var options = new MqttClientOptionsBuilder()
        .WithWebSocketServer("10.195.97.228:1883/mqtt")
    .Build();

        mqttClient.ConnectAsync(options);
        

        var message = new MqttApplicationMessageBuilder()
            .WithTopic("MyTopic")
            .WithPayload("Hello World")
            .WithExactlyOnceQoS()
            .WithRetainFlag()
            .Build();

        var timeout = TimeSpan.FromSeconds(5);
        var qos = MqttQualityOfServiceLevel.AtMostOnce;
        var response = rpcClient.ExecuteAsync(timeout, "myMethod", "Hello World", qos);

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
