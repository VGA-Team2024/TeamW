using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour
{
    /// <summary> クリックの総数 </summary>
    public decimal _totalClicks;
    /// <summary> リソースの総数 </summary>
    public decimal _totalResources;
    /// <summary> 毎秒作られるリソースの数 </summary>
    public int _resourcesCreatedPerSecond;
    /// <summary> 一回のクリックで作られるリソースの数 </summary>
    public int _resourcesPerClick;

    void Awake()
    {
        _totalClicks = 0;
        _resourcesCreatedPerSecond = 0;
        _resourcesPerClick = 1;
    }

    private void Start()
    {
        StartCoroutine("Span");
    }

    void Update()
    {
        
    }

    /// <summary>
    /// クリックするごとにリソースの総数が増えるメソッド
    /// </summary>
    public void ProduceResource() => _totalResources += _resourcesPerClick;

    /// <summary>
    /// 一秒ごとに_resourcesCreatedPerSecondの分リソースが増えるコルーチン
    /// </summary>
    /// <returns></returns>
    IEnumerator Span()
    {
        while (true) 
        {
            yield return new WaitForSecondsRealtime(1);
            _totalResources += _resourcesCreatedPerSecond;
        }
    }
}
