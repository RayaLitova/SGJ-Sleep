using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayScreenController : MonoBehaviour
{
    [SerializeField] private GameObject nextButton;
    [SerializeField] protected DayTransitionData dtd;

    public void OnAnimationEnd()
    {
        nextButton.GetComponent<Button>().onClick.AddListener(ProgressScreens);
        nextButton.SetActive(true);
    }

    public virtual void ProgressScreens() {
        if(dtd.gameOver) {
            Application.Quit();
            return;
        }

        nextButton.GetComponent<Button>().onClick.RemoveListener(ProgressScreens);
        GetComponentInParent<DayController>().ProgressScreens();
        nextButton.SetActive(false);
    }
}
