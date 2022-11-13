using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHit : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (LayerMask.LayerToName(collision.collider.gameObject.layer) != "Character")
            return;

        if (GetComponent<EnemyStats>() == null)
        {
            CharacterStats.health -= transform.GetComponentInParent<EnemyStats>().damage;
            gameObject.SetActive(false);
        }
        else
        {
            CharacterStats.health -= GetComponent<EnemyStats>().damage;
        }
    }
}
