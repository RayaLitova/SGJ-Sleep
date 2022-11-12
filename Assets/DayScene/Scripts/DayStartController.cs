using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayStartController : DayScreenController
{
    [SerializeField] private DayTransitionData dtd;
    [SerializeField] private TextMeshProUGUI daySummaryText;

    void Start()
    {
        daySummaryText.SetText(dtd.nextSummaryText);
    }
}
