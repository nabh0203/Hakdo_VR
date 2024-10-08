using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamer : MonoBehaviour
{
    public bool TVON;
    public GameObject Camer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            Camer.SetActive(true);
            TVON = true;
        }
    }
}
