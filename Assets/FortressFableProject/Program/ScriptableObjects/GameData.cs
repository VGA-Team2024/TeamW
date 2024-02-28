using System.Collections.Generic;

namespace CookieClickerProject.Data
{
    [System.Serializable]
    public class GameData
    {
        public List<UnitData> Units = new List<UnitData>();
        public List<FacilityData> Facilities = new List<FacilityData>();
        public int Wave = 0;
    }

}