using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DayTransitionData", order = 1)]
public class DayTransitionData : ScriptableObject
{
    // Hidden stats
    public int dayNumber = 0;
    public int killCount = 0;
    public int successCount = 0;
    public int failureCount = 0;
    public int newKillsCount = 0;

    public bool gameOver = false;

    // Day
    public string[] nextSummaryTexts = {
        Strings.Get("day_start_summary_intro"),
        Strings.Get("day_start_summary_tutorial")
    };
    public string[] nextNewsTitles = {};
    public string[] nextNewsBodies = {};

    // Night
    public string nextLevel = null;
    public string nextWeapon = null;
    public string nextBoss = null;
    public string[] activeModifiers = {};

    public void ResetDay() {
        nextSummaryTexts = new string[] {
            Strings.Get("day_start_summary_intro"),
            Strings.Get("day_start_summary_tutorial")
        };
        nextNewsTitles = new string[] {};
        nextNewsBodies = new string[] {};
        newKillsCount = 0;
    }

    public void ResetNight() {
        nextLevel = null;
        nextWeapon = null;
        nextBoss = null;
        activeModifiers = new string[] {};
    }

    public void Reset() {
        ResetDay();
        ResetNight();

        dayNumber = 0;
        killCount = 0;
        successCount = 0;
        failureCount = 0;
    }
}
