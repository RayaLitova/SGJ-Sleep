using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    private Vector2 followDirection = Vector2.zero;

    void FixedUpdate() {
        if(followDirection == Vector2.zero) return;

        transform.position += (Vector3)followDirection * CharacterStats.runSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        Debug.Log(collision.transform.position.x - transform.position.x);
        followDirection = collision.transform.position.x - transform.position.x > 0 ? Vector2.right: Vector2.left;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        followDirection = Vector2.zero;
    }
}
