using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers : MonoBehaviour
{
    int _IncreaseSoldiers = 1;
    int _Dexresesgold = 100;
    private void OnMouseDown()
    {

        Debug.Log("���Y");
        /*gold�̃}�l�[�W���[*/  -= _Dexresesgold;
        /*���̃}�l�[�W���[*/ += _IncreaseSoldiers;

    }
}
