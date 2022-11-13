using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    private Transform followDirection = null;

    void FixedUpdate() {
        if(!followDirection) return;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(followDirection.position.x, followDirection.position.y, transform.position.z), CharacterStats.runSpeed * 1.2f);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        followDirection = collision.transform;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        followDirection = null;
    }
}
