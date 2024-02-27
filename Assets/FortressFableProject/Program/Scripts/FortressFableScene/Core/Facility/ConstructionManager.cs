using CookieClickerProject.Common;
using FortressFableProject.Program.Scripts.Common.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ConstructionManager : AbstractSingleton<ConstructionManager>
{
    [SerializeField, Tooltip("�|�W�V�����Z�b�g�p�v���n�u")] GameObject[] _factoryPosSetPrefab;
    [SerializeField, Tooltip("�������邩�N���X�̃��X�g")] List<FacilityCount> _maxFaciCount;
    public List<FacilityCount> MaxFaciCount { get { return _maxFaciCount; } set { _maxFaciCount = value; } }

    [SerializeField] EventSystem _es;
    ConstructPos _constructPos;
    GameObject _blueSheet = null;
    public GameObject BlueSheet { get { return _blueSheet; } set { _blueSheet = value; } }
    GameObject _factoryPosSet;
    [SerializeField, Tooltip("���݂ł���Ƃ��̃{�^���̏���")] UnityEvent _isSetButton;
    int _selectFacilityPrice;
    string _selectFacilityName;

    /// <summary>��錚�����I�΂ꂽ�Ƃ��ɌĂ΂�� </summary>
    /// <param name="name">���v���n�u�̖��O</param>
    public void SelectFacility(string name)
    {
        foreach (GameObject g in _factoryPosSetPrefab)
        {
            if (name == g.name)
            {
                _factoryPosSet = Instantiate(g);
            }
        }
        //_factoryPosSet = Instantiate(_factoryPosSetPrefab);
        _constructPos = _factoryPosSet.GetComponent<ConstructPos>();
        _constructPos.Es = _es;
    }
    /// <summary>�I�΂�Ă��錚���̏����|�W�V��������܂Ŏ����Ă���</summary>
    /// <param name="prise">�����̉��i</param>
    /// <param name="name">�����̖��O</param>
    public void SelectFacilityPriceAndName(int prise, string name)
    {
        _selectFacilityPrice = prise;
        _selectFacilityName = name;
    }
    /// <summary> �|�W�V�������莞�ɌĂ΂��</summary>
    public void FacilitySet()
    {
        if (_constructPos.IsSet && _blueSheet == null)
        {
            _isSetButton.Invoke();
            //GOLD.Instance.Gold -= _selectFacilityPrice;
            //�������炷����
            foreach (FacilityCount si in _maxFaciCount)
            {
                if (si.Name == _selectFacilityName)
                {
                    si.Count++;
                }//�����Ă��錚���̐����ӂ₷�B�ő嗧�Ă��鐔
            }
            _constructPos.Set();
        }
    }
    /// <summary>�|�W�V����������L�����Z�������Ƃ��ɌĂ΂��</summary>
    public void FacilitySetCancel()
    {
        Destroy(_factoryPosSet);
    }

}

public class FacilityCount
{
    public string Name;
    public int MaxCount;
    public int Count;
}