namespace CheckTwoFactorAuthURL
{
    using System.Drawing;
    using Newtonsoft.Json;

    public class Entry
    {
        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tfa")]
        public bool SupportsTwoFactor { get; set; }

        [JsonProperty("sms")]
        public bool SupportsSmS { get; set; }

        [JsonProperty("phone")]
        public bool SupportsPhone { get; set; }

        [JsonProperty("software")]
        public bool SupportsSoftware { get; set; }

        [JsonProperty("hardware")]
        public bool SupportsHardware { get; set; }

        [JsonProperty("icon")]
        public Icon Icon { get; set; }

        public string Category { get; set; }
    }
}
