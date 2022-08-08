using Newtonsoft.Json;
using System;

namespace MachineStream.Entity
{
    public class MachineStatus
    {

        [JsonProperty("machine_id")]
        public string MachineId { get; set; }

        public string Status { get; set; }
        [JsonIgnore]
        public DateTime? CreateDate { get; set; }
        [JsonIgnore]

        public DateTime? LastUpdateDate { get; set; }
    }
}
