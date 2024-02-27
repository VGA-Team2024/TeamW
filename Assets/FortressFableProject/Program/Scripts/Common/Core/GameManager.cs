using System;
using System.Linq;
using System.Collections.Generic;
using CookieClickerProject.Common;
using CookieClickerProject.Data;
using UnityEngine;

namespace FortressFableProject.Program.Scripts.Common.Core
{
    public class GameManager : AbstractSingleton<GameManager>
    {
        protected override bool UseDontDestroyOnLoad => true;
        private SaveAndLoad _saveAndLoad;

        private void Awake()
        {
            _saveAndLoad = SaveAndLoad.Instance;
            _saveAndLoad.LoadGame();
            AddUnit(new Soldier { Type = UnitBase.UnitType.Soldier, Count = 1 });
            AddUnit(new Soldier { Type = UnitBase.UnitType.Soldier, Count = 1 });

            _saveAndLoad.SaveGame();
        }

        
        
        
        /// <summary>
        /// ユニットを追加
        /// </summary>
        /// <param name="unit"></param>
        public void AddUnit(UnitBase unit)
        {
            var unitData = _saveAndLoad.StorageData.GameData.Units.FirstOrDefault(u => u.Type == unit.Type);

            if (unitData != null)
            {
                unitData.Count += unit.Count;
            }
            else
            {
                unitData = new UnitData
                {
                    Type = unit.Type,
                    Count = unit.Count
                };
                _saveAndLoad.StorageData.GameData.Units.Add(unitData);
            }
        }

        public void AddFacility(FacilityBase facility)
        {
            var facilityData = new FacilityData
            {
                Type = facility.Type,
                IsProducing = facility.IsProducing,
                Position = facility.transform.position,
                WaitTime = facility.WaitTime,
                TimePerProduction = facility.TimePerProduction,
                AssetPerProduction = facility.AssetPerProduction
            };

            _saveAndLoad.StorageData.GameData.Facilities.Add(facilityData);
        }

        public void AddWave()
        {
            _saveAndLoad.StorageData.GameData.Wave++;
        }

        public void AddMoney(int money)
        {
            _saveAndLoad.StorageData.PlayerData.TotalMoney += money;
        }

        // ここから下は、実際にゲームオブジェクトを生成するロジックを実装します。
        private void LoadGame()
        {
            _saveAndLoad.LoadGame(); // セーブデータのロード

            // ユニットの復元
            foreach (var unitData in _saveAndLoad.StorageData.GameData.Units)
            {
                // ここで、実際にユニットのゲームオブジェクトを生成するロジックを実装します。
                // 例: CreateUnitGameObject(unitData);
            }

            // 施設の復元
            foreach (var facilityData in _saveAndLoad.StorageData.GameData.Facilities)
            {
                // ここで、実際に施設のゲームオブジェクトを生成するロジックを実装します。
                // 例: CreateFacilityGameObject(facilityData);
            }
        }
    }
}