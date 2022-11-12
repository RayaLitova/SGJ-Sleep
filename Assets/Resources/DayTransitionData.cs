using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DayTransitionData", order = 1)]
public class DayTransitionData : ScriptableObject
{
    public int dayNumber = 0;
    public int killCount = 0;

    public string nextSummaryText = Strings.Get("demo_day_summary_1");
    public string[] nextNewsTitles = {};

    public string nextLevel = null;
    public string nextWeapon = null;
    public string nextBoss = null;
    public string[] activeModifiers = {};
}