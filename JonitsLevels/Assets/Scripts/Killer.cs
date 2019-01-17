using UnityEngine;

public class Killer : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        var player = other.transform.GetComponent<Player_Controller>();
        if (player == null)
            return;
        player.SwitchToRagdoll();
    }
}
