using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    [SerializeField] private float degreesPerSec = 30f;
    [SerializeField] private RotationDirection rotationDirection = RotationDirection.Left;
    [SerializeField] private float gravityScale = 3f;

    private enum RotationDirection
    {
        Right,
        Left
    }

    // Start is called before the first frame update
    void Start()
    {
        // Modify rotation direction
        degreesPerSec = rotationDirection == RotationDirection.Left ? degreesPerSec : (-1) * degreesPerSec;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {   
        // Rotate planet at same speed as player
        transform.Rotate(new Vector3(0, 0, degreesPerSec) * Time.deltaTime);
    }

    // OnTriggerStay2D is called once per frame when inside the collider
    // Called once when player is in gravity field
    private void OnTriggerStay2D(Collider2D obj)
    {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        
        // Add gravitational force to object in gravity field
        Vector3 gravity = (transform.position - obj.transform.position) * gravityScale;
        rb.AddForce(gravity);

        // If player is in gravity field
        if (obj.CompareTag("Player"))
        {
            // Force player to stay upright on planet
            float correctionForce = 20f;
            //Quaternion targetRotation = Quaternion.LookRotation(rb.transform.forward, -1 * gravity);
            //rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, targetRotation, correctionForce * Time.fixedDeltaTime);
            obj.transform.up = Vector3.MoveTowards(obj.transform.up, -gravity, gravityScale * Time.deltaTime * 5f);

            // Rotate the player around the planet to simulate planet rotation
            if (obj.GetComponent<PlayerMovement>().isGrounded())
            {
                obj.transform.RotateAround(transform.position, Vector3.forward, degreesPerSec * Time.deltaTime);
            }
        }
    }
}
