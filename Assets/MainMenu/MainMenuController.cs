using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private DayTransitionData dtd;

    public void StartGame() {
        dtd.dayNumber = 0;
        dtd.killCount = 0;
        dtd.nextSummaryText = Strings.Get("demo_day_summary_1");
        dtd.nextNewsTitles = new string[] {
            Strings.Get("demo_headline_1"),
            Strings.Get("demo_headline_2"),
            Strings.Get("demo_headline_3")
        };
        dtd.nextLevel = null;
        dtd.nextWeapon = null;
        dtd.nextBoss = null;
        dtd.activeModifiers = new string[] {};

        SceneManager.LoadScene("Day");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
