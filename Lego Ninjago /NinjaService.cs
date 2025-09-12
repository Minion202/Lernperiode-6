using System.Collections.Generic;

namespace Lego_Ninjago
{
    public static class NinjaService
    {
        public static Dictionary<string, Ninja> BuildAll()
        {
            return new Dictionary<string, Ninja>
            {
                ["COLE"]  = new Ninja("Cole",  "Erde",    new[] {"Erdbeben Punch", "Bodenwelle"},         new[] {"Tank", "Standfestigkeit"}),
                ["JAY"]   = new Ninja("Jay",   "Blitz",   new[] {"Kettenblitz", "Schneller Dash"},        new[] {"Tempo", "Reichweite"}),
                ["LLOYD"] = new Ninja("Lloyd", "Energie", new[] {"Energie Schwert", "Auren Schild"},      new[] {"Allrounder", "Fuehrung"}),
                ["KAI"]   = new Ninja("Kai",   "Feuer",   new[] {"Flammen Wirbel", "Feuerstoss"},         new[] {"Burst Damage", "Aggressiv"}),
                ["ZANE"]  = new Ninja("Zane",  "Eis",     new[] {"Frost Pfeil", "Eisige Gefangenschaft"}, new[] {"Kontrolle", "Praezision"})
            };
        }
    }
}
