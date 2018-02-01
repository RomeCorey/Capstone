﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net;


namespace AfterMarketStocks.Models
{
   
    public partial class AlphaStock
    {
        [JsonProperty("Meta Data")]
        public MetaData MetaData { get; set; }

        [JsonProperty("Time Series (1min)")]
        public Dictionary<string, TimeSeries1Min> TimeSeries1Min { get; set; }
    }

    public partial class MetaData
    {
        [JsonProperty("1. Information")]
        public string The1Information { get; set; }

        [JsonProperty("2. Symbol")]
        public string The2Symbol { get; set; }

        [JsonProperty("3. Last Refreshed")]
        public System.DateTime The3LastRefreshed { get; set; }

        [JsonProperty("4. Interval")]
        public string The4Interval { get; set; }

        [JsonProperty("5. Output Size")]
        public string The5OutputSize { get; set; }

        [JsonProperty("6. Time Zone")]
        public string The6TimeZone { get; set; }
    }

    public partial class TimeSeries1Min
    {
        [JsonProperty("1. open")]
        public string The1Open { get; set; }

        [JsonProperty("2. high")]
        public string The2High { get; set; }

        [JsonProperty("3. low")]
        public string The3Low { get; set; }

        [JsonProperty("4. close")]
        public string The4Close { get; set; }

        [JsonProperty("5. volume")]
        public string The5Volume { get; set; }
    }

    public partial class AlphaStock
    {
        public static AlphaStock FromJson(string json) => JsonConvert.DeserializeObject<AlphaStock>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this AlphaStock self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}