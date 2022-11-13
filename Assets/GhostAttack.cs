using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GhostAttack : MonoBehaviour
{
    Transform target;
    EnemyStats stats;
    [SerializeField] private GameObject attack;
    private Animator animator;
    private bool immobilized = false;
    private bool terminatingExplosion = false;
    private void Start()
    {
        target = GameObject.Find("Player").transform;
        stats = GetComponent<EnemyStats>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (!terminatingExplosion && immobilized && Mathf.Abs(target.position.x - transform.position.x) > GetComponent<EnemyStats>().attackRange)
            StartCoroutine("TerminateExplosion");

        if (immobilized)
            return;

        if (Mathf.Abs(target.position.x - transform.position.x) > 15f)
        {
            animator.SetBool("SeesPlayer", false);
            return;
        }
        else
        {
            animator.SetBool("SeesPlayer", true);
        }

        if (Mathf.Abs(target.position.x - transform.position.x) <= GetComponent<EnemyStats>().attackRange)
        {
            StartCoroutine("Explosion");
        }
        else
        {
            StopCoroutine("Explosion");
            animator.SetBool("Attack", false);
            transform.position += new Vector3(Mathf.Clamp(target.position.x - transform.position.x, -1, 1) * stats.speed, 0, 0);
        }
    }

    private IEnumerator TerminateExplosion()
    {
        terminatingExplosion = true;
        yield return new WaitForSeconds(2f);
        immobilized = false;
        StopCoroutine("Explosion");
        animator.SetBool("Attack", false);
        attack.SetActive(false);
        terminatingExplosion = false;
    }
    private IEnumerator Explosion()
    {
        immobilized = true;
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(2f);
        attack.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;
       CharacterStats.health -= GetComponent<EnemyStats>().damage;
    }
    
}
    
   