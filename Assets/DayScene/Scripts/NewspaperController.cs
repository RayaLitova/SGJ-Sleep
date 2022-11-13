using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewspaperController : DayScreenController
{
    [SerializeField] private GameObject titlesRoot;
    [SerializeField] private GameObject bodiesRoot;

    void Start()
    {
        TextMeshProUGUI[] titles = titlesRoot.GetComponentsInChildren<TextMeshProUGUI>();
        TextMeshProUGUI[] bodies = bodiesRoot.GetComponentsInChildren<TextMeshProUGUI>();

        for(int i = 0; i < dtd.nextNewsTitles.Length; i++) {
            titles[i].SetText(dtd.nextNewsTitles[i]);
            bodies[i].SetText(dtd.nextNewsBodies[i]);
        }
    }
}
