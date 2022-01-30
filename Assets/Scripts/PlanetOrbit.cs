using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    [SerializeField] private GameObject waypoint;
    [SerializeField] private float degreesPerSecond = 30f;


    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(waypoint.transform.position, Vector3.forward, degreesPerSecond * Time.deltaTime);
    }
}
