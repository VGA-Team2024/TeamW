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
        _gameManager = FindObjectOfType<GameManager>();
    }

    /// <summary>
    /// タイプに合わせて生成する施設を変える
    /// </summary>
    /// <param name="buildingType"> 施設のタイプ </param>
    /// オブジェクトを返す 建設側で位置を設定する必要がある
    public GameObject FactoryBuilding(FacilityBase.FacilityType buildingType)
    {
        GameObject go = null;
        switch (buildingType)
        {
            // 鉱山
            case FacilityBase.FacilityType.Mine:
                go = _factoryFactory.CreateFactory(buildingType);
                // GameManagerに保存
                _gameManager.AddFacility(go.GetComponent<FacilityBase>());
                break;
            default:
                Debug.LogError($"Unknown facilityType type: {buildingType}");
                return null;
        }

        return go;
    }
}