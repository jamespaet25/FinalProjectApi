﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpProject.DataModels
{

    public partial class Token
    {
        [JsonProperty("token")]
        public string TokenAuth { get; set; }
    }
    
}
