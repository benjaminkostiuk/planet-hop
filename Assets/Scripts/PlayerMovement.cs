using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask planetSurface;
    [SerializeField] private float jumpForce = 9f;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    //private CapsuleCollider2D boxCollider;
    private Animator animator;
    private const string ANIMATION_STATE = "state";

    private enum MovementState
    {
        IDLE,
        JUMPING
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        //boxCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Remove drag on astronaut
        body.drag = 0f;
        if(isGrounded())
        {
            // Add drag from planet surface
            body.drag = 1f;
            // Jump on space button down
            if (Input.GetButtonDown("Jump"))
            {
                body.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state = MovementState.IDLE;

        float dirY = body.transform.up.y > 0 ? 1 : -1;
        float dirX = body.transform.up.x > 0 ? 1 : -1;

        if((body.velocity.y * dirY > .1f || body.velocity.x * dirX > .1f) && !isGrounded())
        {
            state = MovementState.JUMPING;
        }
        animator.SetInteger(ANIMATION_STATE, (int) state);
    }

    public bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, -1 * transform.up, .1f, planetSurface);
    }
}
