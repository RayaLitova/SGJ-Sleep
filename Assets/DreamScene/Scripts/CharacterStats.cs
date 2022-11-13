using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private DayTransitionData dtd;
    [SerializeField] private Transform heartContainer;
    private void Start()
    {
        StageController.dtd = dtd;

        weaponType = dtd.nextWeapon ?? "sword";
        if(Array.IndexOf(dtd.activeModifiers, "playerSpeed") >= 0)
            runSpeed *= 1.5f;
        if(Array.IndexOf(dtd.activeModifiers, "playerStrength") >= 0)
            bulletSpeed *= 1.5f;
        if(Array.IndexOf(dtd.activeModifiers, "showHiddenPlatforms") >= 0)
            isDoubleJumpEnabled = true;
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
        if (health <= 0) {
            StageController.OnPlayerDie();
        }
    }
}
