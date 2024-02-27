using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ConstructPos : MonoBehaviour
{
    [SerializeField, Tooltip("���݉\��Ԃ̃}�e���A��")] Material green;
    [SerializeField, Tooltip("���ݕs�\��Ԃ̃}�e���A��")] Material red;
    EventSystem _es;
    public EventSystem Es { set { _es = value; } }
    [SerializeField, Tooltip("�ʒu�ݒ��Raycast�������郌�C���[�A���Ɠ������̂ɂ���")] LayerMask _layerMask;
    [SerializeField, Tooltip("�ڐG���Č��ݕs�\�ɂȂ���̂̃^�O")] string _tagName;
    MeshRenderer _meshRenderer;
    bool _isSet = true;
    public bool IsSet { get { return _isSet; } }
    [SerializeField, Tooltip("���ݒ��̃v���n�u")] GameObject _bluesheetPrefab;
    [SerializeField, Tooltip("���̃I�u�W�F�N�g�̈ʒu������Ă������ɒ�������p")] Vector3 _shiftPos;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        this.gameObject.transform.position = _shiftPos;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, _layerMask) && _es.currentSelectedGameObject == null)
            {
                this.transform.position = hit.point + new Vector3(0, 0, 0) + _shiftPos;
            }
        }
    }

    public void Set()
    {
        GameObject _blueSheet = Instantiate(_bluesheetPrefab);
        _blueSheet.transform.position = transform.position;
        ConstructionManager.Instance.BlueSheet = _blueSheet;
        _blueSheet.GetComponent<BlueSheetScript>().ConstructWait(0);
        Destroy(this.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == _tagName)
        {
            _meshRenderer.material = red;
            _isSet = false;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == _tagName)
        {
            _meshRenderer.material = green;
            _isSet = true;
        }
    }
}
