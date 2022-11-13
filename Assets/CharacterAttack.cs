using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    private Transform attack;
    private float attackTimer = 0f;
    private float attackLength = 1f;
    private Animator animator;
    [SerializeField] private GameObject sword;

    private void Start()
    {
        animator = GetComponent<Animator>();
        attack = transform.Find("Attack");
    }
    private void Update()
    {
        if (attackTimer > Time.fixedTime)
            return;

        if (Input.GetMouseButton(0))
        {
            if (CharacterStats.weaponType == "sword")
            {
                StartCoroutine("MeleeAttack");
                attackTimer = Time.fixedTime + attackLength;
            }
            else
            {
                StartCoroutine("RangedAttack");
                attackTimer = Time.fixedTime + attackLength / 2;
            }

        }
    }

    private IEnumerator MeleeAttack()
    {
        attack.gameObject.SetActive(true);
        sword.SetActive(true);
        Vector3 originalScaling = transform.localScale;
        Vector3 newScaling = transform.localScale;
        attack.GetComponent<SpriteRenderer>().sprite = null;
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
        {
            newScaling.x = Mathf.Abs(newScaling.x) * -1;
            attack.position = new Vector3(transform.position.x + (newScaling.x == originalScaling.x ? 1f : -1f), transform.position.y, transform.position.z);
        }
        else
        {
            newScaling.x = Mathf.Abs(newScaling.x);
            attack.position = new Vector3(transform.position.x + (newScaling.x == originalScaling.x ? -1f : 1f), transform.position.y, transform.position.z);
        }
        animator.SetBool("attack", true);
        transform.localScale = newScaling;
        yield return new WaitForSeconds(attackLength);
        attack.gameObject.SetActive(false);
        animator.SetBool("attack", false);
        sword.SetActive(false);
        transform.localScale = originalScaling;
    }
    private IEnumerator RangedAttack()
    {
        Vector3 originalScaling = transform.localScale;
        Vector3 newScaling = transform.localScale;

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
        {
            newScaling.x = Mathf.Abs(newScaling.x) * -1;
            attack.position = new Vector3(transform.position.x + (newScaling.x == originalScaling.x ? 1f : -1f), transform.position.y, transform.position.z);
        }
        else
        {
            newScaling.x = Mathf.Abs(newScaling.x);
            attack.position = new Vector3(transform.position.x + (newScaling.x == originalScaling.x ? -1f : 1f), transform.position.y, transform.position.z);
        }
        animator.SetBool("attack", true);
        transform.localScale = newScaling;
        Transform bullet = GameObject.Instantiate(attack);
        bullet.transform.position = attack.position;
        bullet.gameObject.SetActive(true);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x ?
                                CharacterStats.bulletSpeed : CharacterStats.bulletSpeed * -1),
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y > transform.position.y + 1f?
                                CharacterStats.bulletSpeed : 0,
            0);
        if (bullet.GetComponent<Rigidbody2D>().velocity.y != 0.0f)
            bullet.GetComponent<Rigidbody2D>().velocity /= 2;
        transform.localScale = originalScaling;
        animator.SetBool("attack", false);
        yield return new WaitForSeconds(attackLength);
        Destroy(bullet.gameObject);
    }

}
