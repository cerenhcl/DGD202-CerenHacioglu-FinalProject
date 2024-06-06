using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COIN : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            player.score += 5;
            gameObject.SetActive(false);
        }
    }
}
