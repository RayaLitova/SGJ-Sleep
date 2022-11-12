using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewspaperController : DayScreenController
{
    [SerializeField] private TextMeshProUGUI[] newsTitles;
    [SerializeField] private DayTransitionData dtd;

    void Start()
    {
        for(int i = 0; i < dtd.nextNewsTitles.Length; i++) {
            newsTitles[i].SetText(dtd.nextNewsTitles[i]);
        }
    }
}
