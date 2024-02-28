using CookieClickerProject.Common;
using FortressFableProject.Program.Scripts.Common.Core;
using UnityEngine;

/// <summary>
/// タイプ別で生成する施設を変える
/// 生成したものをゲームマネージャーに保存している
/// </summary>
public class FactoryManager : AbstractSingleton<FactoryManager>
{
    [Header("FactoryFactory"), SerializeField]
    FactoryFactory _factoryFactory = default;

    [Tooltip("ゲームマネージャー")] GameManager _gameManager = default;

    void Start()
    {
        _gameManager = GameManager.Instance;
    }

    /// <summary>
    /// タイプに合わせて生成する施設を変える
    /// </summary>
    /// <param name="buildingType"> 施設のタイプ </param>
    /// オブジェクトを返す 建設側で位置を設定する必要がある
    public GameObject FactoryBuilding(FacilityBase.FacilityType buildingType)
    {
        GameObject facilityObject = _factoryFactory.CreateFacility(buildingType);
        if (facilityObject != null)
        {
            FacilityBase facilityComponent = facilityObject.GetComponent<FacilityBase>();
            if (facilityComponent != null)
            {
                // GameManagerに施設データを保存
                _gameManager.AddFacility(facilityComponent);
            }
            else
            {
                Debug.LogError("Facility component not found on the prefab.");
            }
        }
        else
        {
            Debug.LogError($"Failed to create facility of type: {buildingType}");
        }

        return facilityObject;
    }
}