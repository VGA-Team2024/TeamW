using UnityEngine;

public class GoldMineController : MonoBehaviour
{
    public GoldMine goldMineData; // Inspectorから割り当てる
    private float _timer = 0f;

    void Update()
    {
        if (goldMineData.AssetPerProduction >= goldMineData._maxGold) return;
        _timer += Time.deltaTime;
        if (!(_timer >= goldMineData.TimePerProduction)) return;
        goldMineData.AssetPerProduction += goldMineData.AssetPerProduction;
        if (goldMineData.AssetPerProduction > goldMineData._maxGold)
        {
            goldMineData.AssetPerProduction = goldMineData._maxGold;
        }
        _timer = 0f;
    }

    private void OnMouseDown()
    {
        Debug.Log("Gold collected.");
        // ここでプレイヤーの全体ゴールドにgoldMineData.currentGoldを追加するロジックを実装
        goldMineData.AssetPerProduction = 0;
    }
}