using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 4f;

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.position, transform.position) > .5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y, transform.position.z), Time.deltaTime * speed);
        } else
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
}
