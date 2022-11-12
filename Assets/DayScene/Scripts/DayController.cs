using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DayController : MonoBehaviour
{
    [SerializeField] private DayTransitionData dtd;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject[] screens;

    private int currScreen = -1;

    private void ResetTransitionData() {
        if(dtd?.nextSummaryText.Length <= 0)
            dtd.nextSummaryText = Strings.Get("demo_day_summary_1");

        dtd.nextWeapon = "";
        dtd.nextLevel = "";
        dtd.nextBoss = "";

        dtd.activeModifiers = new string[] {};
    }

    void Start()
    {
        ResetTransitionData();
        ProgressScreens();
    }

    public void SwitchToNight() {
        dtd.nextWeapon = Strings.weaponNames[Random.Range(0, Strings.weaponNames.Length)];
        dtd.nextLevel = Strings.levelNames[Random.Range(0, Strings.levelNames.Length)];
        dtd.nextBoss = Strings.bossNames[Random.Range(0, Strings.bossNames.Length)];

        MapController mapCtrl = GetComponentInChildren<MapController>(true);
        dtd.activeModifiers = new string[mapCtrl.activePoints.Count];
        for(int i = 0; i < mapCtrl.activePoints.Count; i++) {
            dtd.activeModifiers[i] = mapCtrl.activePoints[i].modifierName;
        }
        dtd.dayNumber++;
        dtd.nextSummaryText = Strings.Get("demo_day_summary_2");
        dtd.nextNewsTitles = new string[] {
            Strings.Get("demo_headline_4"),
            Strings.Get("demo_headline_5"),
            Strings.Get("demo_headline_6")
        };

        SceneManager.LoadScene("Day");
    }

    public void ProgressScreens() {
        if(currScreen >= 0)
            screens[currScreen].SetActive(false);
        nextButton.SetActive(false);

        if(++currScreen < screens.Length) {
            screens[currScreen].SetActive(true);
        } else {
            SwitchToNight();
        }
    }
}
