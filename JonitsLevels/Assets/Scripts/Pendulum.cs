using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float lenght = 2f;    //długość liny
    public float gravity = 0.81f;   // siła grawitacji

    public float theta0 = (1 / 10) * Mathf.PI;// początkowy kąt, inny niż 0
    public float omega0 = 0;                // początkowa prędkość kątowa

    //public bool _________________;

    public float theta_k;                //Theta watrość w kroku K
    public float omega_k;                //Omega watrość w kroku K
    public float omega_k1;               //Omega watrość w kroku K+1
    public float theta_k1;               //Theta watrość w kroku K+1
    public Vector3 p, p0;
    Vector3 v;

    void Awake()
    {
        omega_k1 = omega0;
        theta_k1 = theta0;
        p0 = transform.position; 
        p0.y += lenght;
    }

    void FixedUpdate()
    {
        EulerCromer();
        PolarToCartesian();
        RotateWithMotion(transform);
    }

    //implementacja metody Euler-Cromer
    void EulerCromer()
    {
        omega_k = omega_k1;
        theta_k = theta_k1;
        omega_k1 = omega_k - (gravity / lenght) * theta_k * Time.deltaTime;
        theta_k1 = theta_k + omega_k1 * Time.deltaTime * 10;
    }

    //Konwertowanie współrzędne biegunowe na współrzędne kartezjańskie 
    void PolarToCartesian()
    {
        p.z = p0.z + lenght * Mathf.Sin(theta_k1);
        p.y = p0.y + -lenght * Mathf.Cos(theta_k1);
        p.x = p0.x;
        transform.position = p;
    }

    float radiansToDegrees(float radians)
    {
        return radians * 180 / Mathf.PI;
    }

    //Rotate the rope? and the transform with the motion of the pendulum
    void RotateWithMotion(Transform t)
    {
        Vector3 rot = t.rotation.eulerAngles;
        rot.x = radiansToDegrees(-theta_k1);
        t.rotation = Quaternion.Euler(rot);
    }


}