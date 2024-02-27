using UnityEngine;

namespace CookieClickerProject.Data
{
    [System.Serializable]
    public class FacilityData
    {
        public FacilityBase.FacilityType Type;
        public bool IsProducing;
        public Vector3 Position;
        public float WaitTime;
        public float TimePerProduction;
        public int AssetPerProduction;
    }
}