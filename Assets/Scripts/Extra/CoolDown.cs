using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : MonoBehaviour
{
    public static IEnumerator Wait(float second, Action action = null)
    {
        if (second < 0)
        {
            yield break;
        }
        yield return new WaitForSeconds(second);
        if (action != null)
        {
            action();
        }
    }
}
