using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour
{
    /// <summary> �N���b�N�̑��� </summary>
    public decimal _totalClicks;
    /// <summary> ���\�[�X�̑��� </summary>
    public decimal _totalResources;
    /// <summary> ���b����郊�\�[�X�̐� </summary>
    public int _resourcesCreatedPerSecond;
    /// <summary> ���̃N���b�N�ō���郊�\�[�X�̐� </summary>
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
    /// �N���b�N���邲�ƂɃ��\�[�X�̑����������郁�\�b�h
    /// </summary>
    public void ProduceResource() => _totalResources += _resourcesPerClick;

    /// <summary>
    /// ��b���Ƃ�_resourcesCreatedPerSecond�̕����\�[�X��������R���[�`��
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
