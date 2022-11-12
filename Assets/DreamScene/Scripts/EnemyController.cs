using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform character;
    void Start()
    {
        character = GameObject.Find("Player").transform;
        StartCoroutine("Move");
    }

    private IEnumerator Move()
    {
        while (true)
        {
            if (Vector2.Distance(character.position, transform.position) > GetComponent<EnemyStats>().attackRange)
                transform.position += new Vector3(Mathf.Clamp(character.position.x - transform.position.x, -1, 1) * GetComponent<EnemyStats>().speed, 0, 0);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
