using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour
{
    /// <summary> �N���b�N�̑��� </summary>
    [SerializeField] private decimal _totalClicks;

    /// <summary> ���\�[�X�̑��� </summary>
    [SerializeField] private decimal _totalResources;

    /// <summary> ���b����郊�\�[�X�̐� </summary>
    [SerializeField] private int _resourcesCreatedPerSecond;

    /// <summary> ���̃N���b�N�ō���郊�\�[�X�̐� </summary>
    [SerializeField] private int _resourcesPerClick;

    public decimal TotalClicks
    {
        get => _totalClicks;
        set => _totalClicks = value;
    }

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
    public void ProduceResource(decimal resources) => _totalResources += resources;

    /// <summary>
    /// ��b���Ƃ�_resourcesCreatedPerSecond�̕����\�[�X��������R���[�`��
    /// </summary>
    /// <returns></returns>
    private IEnumerator Span()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            _totalResources += _resourcesCreatedPerSecond;
        }
    }
}