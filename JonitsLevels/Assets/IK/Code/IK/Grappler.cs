using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour {
	[SerializeField] Animator grapplerAnim;

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Target")) {
			grapplerAnim.SetTrigger("grab");
			Destroy(other.gameObject);
		}
	}
}
