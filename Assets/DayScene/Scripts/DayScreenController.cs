using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayScreenController : MonoBehaviour
{
    [SerializeField] private GameObject nextButton;

    public void OnAnimationEnd()
    {
        nextButton.GetComponent<Button>().onClick.AddListener(ProgressScreens);
        nextButton.SetActive(true);
    }

    public virtual void ProgressScreens() {
        nextButton.GetComponent<Button>().onClick.RemoveListener(ProgressScreens);
        GetComponentInParent<DayController>().ProgressScreens();
        nextButton.SetActive(false);
    }
}
