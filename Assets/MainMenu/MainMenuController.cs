using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private DayTransitionData dtd;
    [SerializeField] private Animator[] anim;

    public void StartGame() {
        dtd.Reset();

        IEnumerable<int> headlineNumbers = Enumerable.Range(1, 6)
            .OrderBy(g => Random.Range(0, 10))
            .Take(3);

        dtd.nextNewsTitles = headlineNumbers
            .Select(i => Strings.Get("news_headline_generic_" + i))
            .ToArray();
        dtd.nextNewsBodies = headlineNumbers
            .Select(i => Strings.Get("news_body_generic_" + i))
            .ToArray();

        SceneManager.LoadScene("TutorialS");
    }

    public void QuitGame() {
        Application.Quit();
    }

    void Start() {
        foreach(Animator a in anim) {
            a.SetBool("SeesPlayer", true);
        }
    }
}
