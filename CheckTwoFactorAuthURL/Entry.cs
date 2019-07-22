namespace CheckTwoFactorAuthURL
{
    using System.Drawing;

    internal class Entry
    {
        public string URL { get; }

        public string Name { get; }

        public bool SupportsTwoFactor { get; }

        public bool SupportsSmS { get; }

        public bool SupportsPhone { get; }

        public bool SupportsSoftware { get; }

        public Icon Icon { get; }
    }
}
