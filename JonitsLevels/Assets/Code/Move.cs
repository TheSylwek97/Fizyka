using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var x = Time.deltaTime * 150.0f;
        var z = Time.deltaTime * 3.0f;
        do
        {
            transform.Translate(0, 0, z);

        } while (z < 10);

    }
}
