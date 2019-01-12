using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    bool goLeft;
    
	
	void Update () {

        if (goLeft == false)
            GoRight();

        else
            GoLeft();
    }

    void GoRight()
    {

        var x = Time.deltaTime * 150.0f;
        var z = Time.deltaTime * 3.0f;
        transform.Translate(0, 0, z);

    }

    void GoLeft()
    {
        var x = Time.deltaTime * 150.0f;
        var z = Time.deltaTime * -3.0f;

        transform.Translate(0, 0, z);
    }

    void OnTriggerEnter()
    {
        if(goLeft == false)
            goLeft = true;
        else
            goLeft = false;
    }
    
}
