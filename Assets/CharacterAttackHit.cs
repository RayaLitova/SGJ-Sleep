using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackHit : MonoBehaviour
{
    private void Update()
    {
        if(CharacterStats.weaponType == "melee")
            transform.position = new Vector3(transform.position.x, transform.parent.position.y, transform.parent.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.collider.gameObject.layer) != "Enemy")
            return;

        collision.collider.GetComponent<EnemyStats>().health -= CharacterStats.damage;
        gameObject.SetActive(false);
    }
}
