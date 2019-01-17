using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    bool goLeft;
    [SerializeField] float speed = 3;
	
	void Update () {

        if (goLeft == false)
            GoRight();

        else
            GoLeft();
    }

    void GoRight()
    {
        var z = Time.deltaTime * speed;
        transform.Translate(0, 0, z);
    }

    void GoLeft()
    {
        var z = Time.deltaTime * -1.0f * speed;
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
