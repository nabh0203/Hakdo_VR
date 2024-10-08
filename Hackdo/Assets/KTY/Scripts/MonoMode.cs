using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoMode : MonoBehaviour
{
    void Start()
    {
        if (Application.isEditor)
        {
            OVRManager.instance.monoscopic = true;
        }
    }

}
