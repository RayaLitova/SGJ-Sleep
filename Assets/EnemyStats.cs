using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float speed = 0.4f;
    public int damage = 1;
    public float attackRange = 2f;
    public int maxHealth;
    public int health;
    private int lastHealth;

    [SerializeField] Transform heartContainer;
    [SerializeField] Transform heart;
    void Start()
    {
        maxHealth = Mathf.RoundToInt(Random.Range(1.0f, 3.0f));
        health = maxHealth;
        lastHealth = maxHealth;
        for (int heartCount = 1; heartCount < maxHealth; heartCount++)
        {
            Transform newHeart = GameObject.Instantiate(heart, heartContainer);
            if (heartCount == 1)
                newHeart.position = heart.position + new Vector3(-0.3f, 0, 0);
            else
                newHeart.position = heart.position + new Vector3(0.3f, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        DrawHearts();
    }
    private void DrawHearts()
    {
        if (lastHealth == health) return; // skip loop if not needed
        lastHealth = health;
        for (int i = 0; i < maxHealth; i++)
            heartContainer.GetChild(i).gameObject.SetActive((i < health - 1 ? true : false));
    }
    
}
