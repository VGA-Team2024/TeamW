using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        //UniRx��Click�����Ƃ��ɌĂяo��
        //Observable.EveryUpdate()
        //    .Where(_ => Input.GetMouseButtonDown(0))
        //    .Subscribe(_ => handleClick());
    }
}
