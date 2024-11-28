namespace SuperDuperMart.Web.Rendering
{
    public abstract class SelectOptionBase
    {
        public string Text { get; set; } = default!;
        public string Value { get; set; } = default!;
        public bool Selected { get; set; }
        public bool Disabled { get; set; }

        protected SelectOptionBase(string text, string value)
        {
            Text = text;
            Value = value;
        }
    }
}
