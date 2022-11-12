using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GhostAttack : MonoBehaviour
{
    Transform target;
    EnemyStats stats;
    private bool isInverted = false;
    private float targetY;
    private void Start()
    {
        target = GameObject.Find("Player").transform;
        targetY = transform.position.y;
        stats = GetComponent<EnemyStats>();
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(target.position.x - transform.position.x) < GetComponent<EnemyStats>().attackRange)
        {
            transform.position += isInverted ?
                Vector3.MoveTowards(transform.position, new Vector3(-1 * Mathf.Clamp(target.position.x - transform.position.x, -1, 1), targetY, transform.position.z), stats.speed) :
                Vector3.MoveTowards(transform.position, target.position, stats.speed);

        }
        else
        {
            transform.position += new Vector3(Mathf.Clamp(target.position.x - transform.position.x, -1, 1) * stats.speed, 0, 0);
        }
        if (transform.position.y == target.position.y)
            isInverted = true;
        else
            isInverted = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;
       CharacterStats.health -= GetComponent<EnemyStats>().damage;
    }
    
}
    
   