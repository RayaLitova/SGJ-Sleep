using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayController : MonoBehaviour
{
    [SerializeField] private DayTransitionData dtd;
    [SerializeField] private GameObject[] screens;

    private int currScreen = -1;

    void Start()
    {
        dtd.ResetNight();
        ProgressScreens();
    }

    public void SwitchToNight() {
        dtd.nextWeapon = Strings.weaponNames[UnityEngine.Random.Range(0, Strings.weaponNames.Length)];
        if(dtd.nextLevel != null) {
            int index = Array.IndexOf(Strings.levelNames, dtd.nextLevel);
            if(index >= 0 && index < Strings.levelNames.Length -1) {
                dtd.nextLevel = Strings.levelNames[index + 1];
            } else {
                dtd.nextLevel = Strings.levelNames[UnityEngine.Random.Range(0, Strings.levelNames.Length)];
            }
        } else {
            dtd.nextLevel = Strings.levelNames[0];
        }
        dtd.nextBoss = Strings.bossNames[UnityEngine.Random.Range(0, Strings.bossNames.Length)];

        dtd.dayNumber++;

        SceneManager.LoadScene(dtd.nextLevel);
    }

    public void ProgressScreens() {
        if(currScreen >= 0)
            screens[currScreen].SetActive(false);

        if(++currScreen < screens.Length) {
            screens[currScreen].SetActive(true);
        } else {
            SwitchToNight();
        }
    }
}
