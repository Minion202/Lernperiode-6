using System.Collections.Generic;

namespace Lego_Ninjago
{
    public static class WeaponService
    {
        public static List<Weapon> GetDefaultSix()
        {
            return new List<Weapon>
            {
                new Weapon("Katana",   "Schnell und praezise."),
                new Weapon("Nunchaku", "Flexibel fuer Kombos."),
                new Weapon("Shuriken", "Wurfwaffe mit Reichweite."),
                new Weapon("Speer",    "Gute Distanzkontrolle."),
                new Weapon("Hammer",   "Langsam aber sehr stark."),
                new Weapon("Bogen",    "Hohe Reichweite, praezise.")
            };
        }
    }
}