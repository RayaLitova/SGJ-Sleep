using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapController : DayScreenController
{
    [SerializeField] private MapButton[] mapPoints;
    [SerializeField] public readonly List<MapButton> activePoints = new List<MapButton>();
    [SerializeField] private TextMeshProUGUI mapTitle;

    void Start()
    {
        mapPoints = GetComponentsInChildren<MapButton>();
        foreach(MapButton button in mapPoints) {
            button.Deactivate();
        }
        mapTitle.SetText(Strings.Get("map_screen_prompt"));
    }

    public void OnButtonClick(MapButton button) {
        if(activePoints.Contains(button)) {
            activePoints.Remove(button);
            button.Deactivate();
        } else {
            activePoints.Add(button);
            button.Activate();
        }

        while(activePoints.Count > 2) {
            activePoints[0].Deactivate();
            activePoints.RemoveAt(0);
        }
    }

    override public void ProgressScreens() {
        List<string> dayEndSummaries = new List<string>();
        dayEndSummaries.Add(Strings.Get("day_end_summary_" + Random.Range(1, 3)));

        dtd.activeModifiers = new string[activePoints.Count];
        for(int i = 0; i < activePoints.Count; i++) {
            dtd.activeModifiers[i] = activePoints[i].modifierName;
            dayEndSummaries.Add(Strings.Get("day_end_summary_" + activePoints[i].modifierName));
        }

        dtd.nextSummaryTexts = dayEndSummaries.ToArray();

        base.ProgressScreens();
    }
}
