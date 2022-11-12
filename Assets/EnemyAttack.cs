using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEngine.GraphicsBuffer;

public class EnemyAttack : MonoBehaviour
{
    private Transform attack;
    private float attackTimer;
    private float attackLength = 1.5f;
    void Start()
    {
        attack = transform.Find("Attack");
    }

    void Update()
    {
        if (attackTimer > Time.fixedTime)
            return;

        if (Vector2.Distance(transform.position, GameObject.Find("Player").transform.position) <= GetComponent<EnemyStats>().attackRange)
        {
            if (GetComponent<EnemyStats>().enemyType == "zombie")
                StartCoroutine("ZombieAttack");
            attackTimer = Time.fixedTime + attackLength;
        }
    }
    private IEnumerator ZombieAttack()
    {
        attack.gameObject.SetActive(true);
        if (GameObject.Find("Player").transform.position.x > transform.position.x)
            attack.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
        else
            attack.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(attackLength);
        attack.gameObject.SetActive(false);
    }

   


}
