using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public static int health = 3;
    public static int maxHealth = 3;
    private int lastHealth = health;
    public static int damage = 1;
    public static float runSpeed = 0.2f;
    public static float dashSpeed = 3.5f;
    public static float jumpSpeed = 7.5f;
    public static bool isDoubleJumpEnabled = false;
    public static string weaponType;  //melee / ranged
    public static float bulletSpeed = 7f;

    private Transform heartContainer;
    private void Start()
    {
        weaponType = Random.Range(0, 2) == 0 ? "melee" : "ranged";
        heartContainer = transform.Find("HeartContainer");
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
            heartContainer.GetChild(i).gameObject.SetActive((i < health ? true : false));
        if (health == 0)
            Destroy(gameObject);
    }
}
