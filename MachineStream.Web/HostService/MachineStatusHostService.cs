using MachineStream.Entity;
using MachineStream.IService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace MachineStream.Web.HostService
{
    public class MachineStatusHostService : IHostedService
    {
        private IMachineStatusService _machineStatusService;
        private IConfiguration _configuration;
        public MachineStatusHostService(IConfiguration configuration,IMachineStatusService service)
        {
            _configuration = configuration;
            _machineStatusService = service;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(() => CollectMachineStatus());
            return Task.CompletedTask;

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        

        public async Task CollectMachineStatus()
        {

            var socketClient = new ClientWebSocket();
            //缓冲区
            byte[] buffer = null;
            var uri = new Uri(_configuration["DataWSUrl"]);
            try
            {
                await socketClient.ConnectAsync(uri, CancellationToken.None);

                var json = string.Empty;
                while (socketClient.State == WebSocketState.Open)
                {
                    buffer = new byte[1024 * 4];
                    var result = await socketClient.ReceiveAsync(buffer, CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Text)
                    {

                        json = System.Text.Encoding.UTF8.GetString(buffer);

                        var data = JObject.Parse(json);
                        var statusData = data["payload"].ToString();
                        var entity = Convert(statusData);
                        _machineStatusService.Save(entity);
                    }
                }
            }
            catch (WebSocketException ex)
            {
                Console.WriteLine(ex.Message);
                if (socketClient.State == WebSocketState.Aborted)
                {
                    socketClient.Dispose();
                }
                Thread.Sleep(5000);

                await CollectMachineStatus();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

        }
        private MachineStatus Convert(string json)
        {
            var item = JsonConvert.DeserializeObject<MachineStatus>(json);

            return item;
        }
    }
}
