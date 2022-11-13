using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAttackHit : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine("DestroyTimer");
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject.transform.parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(LayerMask.LayerToName(collision.gameObject.layer) != "Character")
            return;
        CharacterStats.health -= transform.parent.GetComponent<EnemyStats>().damage;
        Destroy(gameObject.transform.parent.gameObject);
    }
}
