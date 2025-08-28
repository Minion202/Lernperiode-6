namespace Lego_Ninjago
{
    public class Ninja
    {
        public Ninja(string name, string element, string[] abilities, string[] strengths)
        {
            Name = name;
            Element = element;
            Abilities = abilities ?? [];
            Strengths = strengths ?? [];
        }

        public string Name { get; }
        public string Element { get; }
        public string[] Abilities { get; }
        public string[] Strengths { get; }

        public string BuildTooltip() =>
            $"{Name} – Element: {Element}\n" +
            $"Abilities: {string.Join(", ", Abilities)}\n" +
            $"Stärken: {string.Join(", ", Strengths)}";
    }
}