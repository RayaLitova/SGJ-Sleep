using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayStartController : DayScreenController
{
    [SerializeField] private TextMeshProUGUI daySummaryText;
    private int summaryIndex = 0;

    void Start()
    {
        daySummaryText.SetText(dtd.nextSummaryTexts[summaryIndex]);
    }

    override public void ProgressScreens() {
        if(summaryIndex >= dtd.nextSummaryTexts.Length - 1) {
            base.ProgressScreens();
        } else {
            daySummaryText.SetText(dtd.nextSummaryTexts[++summaryIndex]);
        }
    }
}
