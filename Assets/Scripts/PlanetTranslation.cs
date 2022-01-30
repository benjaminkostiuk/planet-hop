using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTranslation : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypoint = 0;

    [SerializeField] private float speed = 2f;
    private float minSpeed = 1.5f;

    // Update is called once per frame
    void Update()
    {
        GameObject current = waypoints[currentWaypoint];
        GameObject last = waypoints[Mod((currentWaypoint - 1), waypoints.Length)];
        float moveSpeed = speed;
        if (Vector2.Distance(current.transform.position, transform.position) < 8f)
        {
            moveSpeed = Mathf.Min(CalculateSlowdown(current.transform.position), moveSpeed);
        }
        else if (Vector2.Distance(last.transform.position, transform.position) < 8f)
        {
            moveSpeed = Mathf.Min(CalculateSlowdown(last.transform.position), moveSpeed);
        }

        if (Vector2.Distance(current.transform.position, transform.position) < .1f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * moveSpeed);
    }

    private int Mod(int x, int m)
    {
        return (x % m + m) % m;
    }

    private float CalculateSlowdown(Vector3 target)
    {
        return (float) (minSpeed + 0.08f * System.Math.Pow(Vector2.Distance(target, transform.position), 2));
    }
}
