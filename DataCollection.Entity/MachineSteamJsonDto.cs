using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollection.Entity
{
    public class MachineSteamJsonDto
    {
        [JsonProperty("machine_id")]
        public string MachineId { get; set; }

        public string Id { get; set; }

        public DateTime? Timestamp { get; set; }

        public string Status { get; set; }
    }
}
