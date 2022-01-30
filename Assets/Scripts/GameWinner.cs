using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWinner : MonoBehaviour
{
    [SerializeField] Text message; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
            message.text = "You Win! Welcome Home!";
        }
    }
}
