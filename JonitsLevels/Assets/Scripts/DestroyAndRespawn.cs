using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndRespawn : MonoBehaviour {

    [SerializeField] GameObject enemyToRespawn;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        var enemyInstance = Instantiate(enemyToRespawn, transform.position, Quaternion.identity) as GameObject;
    }
}
