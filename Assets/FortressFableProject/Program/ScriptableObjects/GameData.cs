using System.Collections.Generic;

namespace CookieClickerProject.Data
{
    public class GameData
    {
        public readonly List<UnitBase> Units = new();
        public readonly List<FacilityBase> Facilities = new ();
        public int Wave = 0;
    }
}