using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        //UniRx‚ÅClick‚µ‚½‚Æ‚«‚ÉŒÄ‚Ño‚·
        //Observable.EveryUpdate()
        //    .Where(_ => Input.GetMouseButtonDown(0))
        //    .Subscribe(_ => handleClick());
    }
}
