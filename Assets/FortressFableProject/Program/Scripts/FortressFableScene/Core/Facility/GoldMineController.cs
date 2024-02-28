using UnityEngine;

public class GoldMineController : MonoBehaviour
{
    public GoldMine goldMineData; // Inspectorから割り当てる
    private float _timer = 0f;

    void Update()
    {
        if (goldMineData.currentGold >= goldMineData.maxGold) return;
        _timer += Time.deltaTime;
        if (!(_timer >= goldMineData.TimePerProduction)) return;
        goldMineData.currentGold += goldMineData.AssetPerProduction;
        if (goldMineData.currentGold > goldMineData.maxGold)
        {
            goldMineData.currentGold = goldMineData.maxGold;
        }
        _timer = 0f;
    }

    private void OnMouseDown()
    {
        Debug.Log("Gold collected.");
        // ここでプレイヤーの全体ゴールドにgoldMineData.currentGoldを追加するロジックを実装
        goldMineData.currentGold = 0;
    }
}