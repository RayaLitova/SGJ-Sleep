using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Transform player;
    private Animator animator;
    [SerializeField] GameObject meleeAttack;
    private void Start()
    {
        player = GameObject.Find("Player").transform;
        animator = GetComponent<Animator>();
        StartCoroutine("Attack");
    }
    private IEnumerator Attack()
    {
        while (true)
        {
            
            animator.SetBool("Attack", true);
            if (Vector2.Distance(player.position, transform.position) > 3.0f)
            {
                StartCoroutine("RangedAttack");
                animator.SetFloat("AttackRange", 1);
            }
            else
            {
                StartCoroutine("MeleeAttack");
                animator.SetFloat("AttackRange", 0);
            }
            yield return new WaitForSeconds(.5f);
            animator.SetBool("Attack", false);
            yield return new WaitForSeconds(3f);
        }
    }

    private IEnumerator RangedAttack()
    {
        Debug.Log("ranged");
        for (int i = 0; i < 2; i++)
        {
            GameObject ball = transform.Find("Balls").GetChild(i).gameObject;
            ball.SetActive(true);
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.0f, 0);
            StartCoroutine("DestroyBulletTimer", ball);
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator DestroyBulletTimer(GameObject ball)
    {
        yield return new WaitForSeconds(3f);
        ball.transform.position = new Vector3(-0.6f, ball.transform.position.y, ball.transform.position.z);
        ball.SetActive(false);
    }
    private IEnumerator MeleeAttack()
    {
        yield return new WaitForSeconds(0.5f);
        meleeAttack.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        meleeAttack.SetActive(false);
    }
}
