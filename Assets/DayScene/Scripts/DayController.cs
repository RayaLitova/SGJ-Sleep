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
        dtd.nextWeapon = Strings.weaponNames[Random.Range(0, Strings.weaponNames.Length)];
        dtd.nextLevel = Strings.levelNames[Random.Range(0, Strings.levelNames.Length)];
        dtd.nextBoss = Strings.bossNames[Random.Range(0, Strings.bossNames.Length)];

        dtd.dayNumber++;

        SceneManager.LoadScene("DreamScene");
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
