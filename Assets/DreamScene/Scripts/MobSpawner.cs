using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private GameObject mobType;
    [SerializeField] private int count;
    [SerializeField] private float timeout;
    [SerializeField] private DayTransitionData dtd;

    private IEnumerator spawnCoroutine;

    void Start() {
        if(Array.IndexOf(dtd.activeModifiers, "enemyCount") >= 0 && count > 1)
            count /= 2;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position, GetComponent<CircleCollider2D>().radius);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        spawnCoroutine = DoSpawn();
        StartCoroutine(spawnCoroutine);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        StopCoroutine(spawnCoroutine);
        spawnCoroutine = null;
    }

    public IEnumerator DoSpawn()
    {
        while (true && count != 0)
        {
            yield return new WaitForSeconds(timeout);
            Instantiate(mobType, transform.position, transform.rotation);
            if(count > 0) count--;
        }
    }
}
