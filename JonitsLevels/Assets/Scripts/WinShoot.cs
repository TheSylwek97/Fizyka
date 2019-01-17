using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinShoot : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Win");
    }
}
