using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapController : DayScreenController
{
    [SerializeField] private MapButton[] mapPoints;
    [SerializeField] public readonly List<MapButton> activePoints = new List<MapButton>();
    [SerializeField] private Color activePointColor;
    [SerializeField] private Color inactivePointColor;

    void Start()
    {
        mapPoints = GetComponentsInChildren<MapButton>();
        foreach(MapButton point in mapPoints) {
            point.GetComponent<Image>().color = inactivePointColor;
        }
    }

    public void OnButtonClick(MapButton button) {
        if(activePoints.Contains(button)) {
            activePoints.Remove(button);
            button.GetComponent<Image>().color = inactivePointColor;
        } else {
            activePoints.Add(button);
            button.GetComponent<Image>().color = activePointColor;
        }

        while(activePoints.Count > 2) {
            activePoints[0].GetComponent<Image>().color = inactivePointColor;
            activePoints.RemoveAt(0);
        }
    }
}
