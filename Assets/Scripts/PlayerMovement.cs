using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask planetSurface;
    [SerializeField] private float jumpForce = 9f;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Jump on space button down
        if(isGrounded() && Input.GetButtonDown("Jump"))
        {
            body.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        //float degreesPerSecond = 30f;
        //transform.RotateAround(onPlanet.position, Vector3.forward, degreesPerSecond * Time.deltaTime);
    }

    public bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, -1 * transform.up, .1f, planetSurface);
    }
}
