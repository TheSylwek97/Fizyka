using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndRespawn : MonoBehaviour {

    [SerializeField] GameObject enemyToRespawn;
    [SerializeField] Transform placeToRespawn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            Destroy(other.gameObject);
            var enemyInstance = Instantiate(enemyToRespawn, placeToRespawn.position, Quaternion.identity) as GameObject;
        }

        else
            Destroy(other.gameObject);

    }
}
