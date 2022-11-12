using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayScreenController : MonoBehaviour
{
    [SerializeField] private GameObject nextButton;

    public void OnAnimationEnd()
    {
        nextButton.SetActive(true);
    }
}
