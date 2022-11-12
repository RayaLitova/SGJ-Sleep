using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    private Transform attack;
    private float attackTimer = 0f;
    private float attackLength = 1f;

    private void Start()
    {
        attack = transform.Find("Attack");
    }
    private void Update()
    {
        if (attackTimer > Time.fixedTime)
            return;

        if (Input.GetMouseButton(0))
        {
            if (CharacterStats.weaponType == "melee")
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
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
            attack.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
        else
            attack.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(1f);
        attack.gameObject.SetActive(false);
    }
    private IEnumerator RangedAttack()
    {
        Debug.Log(GetComponent<BoxCollider2D>().offset.y);
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x)
            attack.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
        else
            attack.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);

        Transform bullet = GameObject.Instantiate(attack);
        bullet.transform.position = attack.position;
        bullet.gameObject.SetActive(true);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x ?
                                CharacterStats.bulletSpeed : CharacterStats.bulletSpeed * -1),
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y > transform.position.y + 1f?
                                CharacterStats.bulletSpeed : 0,
            0);
        yield return new WaitForSeconds(1f);
        Destroy(bullet.gameObject);
    }

}
