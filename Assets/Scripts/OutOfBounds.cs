using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            collision.gameObject.transform.SetPositionAndRotation(new Vector2(-13.5f, 12.2f), Quaternion.identity);
            rb.velocity = new Vector2(0, 0);
        }
    }
}
