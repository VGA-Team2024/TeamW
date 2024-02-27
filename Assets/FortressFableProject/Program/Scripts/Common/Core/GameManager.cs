using System;
using System.Linq;
using System.Collections.Generic;
using CookieClickerProject.Common;
using CookieClickerProject.Data;
using UnityEngine;

namespace FortressFableProject.Program.Scripts.Common.Core
{
    public class GameManager : MonoBehaviour
    {
        private SaveAndLoad _saveAndLoad;

        private void Awake()
        {
            _saveAndLoad = new SaveAndLoad();
        }

        public void AddUnit(UnitBase.UnitType unitType, int count)
        {
            var unit = _saveAndLoad.StorageData.GameData.Units.FirstOrDefault(u => u.Type == unitType);

            if (unit != null)
            {
                unit.Count += count;
            }
            else
            {
                unit = CreateUnit(unitType);
                unit.Count = count;
                _saveAndLoad.StorageData.GameData.Units.Add(unit);
            }
        }

        private UnitBase CreateUnit(UnitBase.UnitType unitType)
        {
            switch (unitType)
            {
                case UnitBase.UnitType.Soldier:
                    return gameObject.AddComponent<Soldier>();
                case UnitBase.UnitType.Worker:
                    return gameObject.AddComponent<Worker>();
                default:
                    throw new ArgumentOutOfRangeException(nameof(unitType), unitType, "Unsupported unit type.");
            }
        }

        public void AddFacility(FacilityBase.FacilityType facilityType)
        {
            FacilityBase facility = facilityType switch
            {
                FacilityBase.FacilityType.Mine => gameObject.AddComponent<GoldMine>(),
                FacilityBase.FacilityType.TrainingFacility => gameObject.AddComponent<Training>(),
                _ => throw new ArgumentOutOfRangeException(nameof(facilityType), facilityType,
                    "Unsupported facility type.")
            };

            _saveAndLoad.StorageData.GameData.Facilities.Add(facility);
        }

        public void AddWave()
        {
            _saveAndLoad.StorageData.GameData.Wave++;
        }
        
        public void AddMoney(int money)
        {
            _saveAndLoad.StorageData.PlayerData.TotalMoney += money;
        }
    }
}