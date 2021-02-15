using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Domain
{
    public class Video
    {
        [JsonProperty("title")]
        public string Title { get; }

        [JsonProperty("title")]
        public string Description { get; set; }

        [JsonProperty("title")]
        public string SubsectionName { get; set; }

        [JsonProperty("title")]
        public string CourseName { get; set; }
    }
}
