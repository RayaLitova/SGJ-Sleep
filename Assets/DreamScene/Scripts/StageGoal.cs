using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGoal : MonoBehaviour
{
    [SerializeField] private DayTransitionData dtd;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        if(dtd.dayNumber <= 1  || dtd.newKillsCount > 0)
            StageController.OnStageComplete();
        else
            StageController.OnPlayerEscape();
    }
}
