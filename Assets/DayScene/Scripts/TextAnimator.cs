using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TextAnimator : MonoBehaviour
{
    private TextMeshProUGUI textBox = null;

    [SerializeField] private float wordDelay = 0.1f;

    public UnityEvent OnAnimationComplete;

    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
    }

    public IEnumerator AnimateText(string text) {
        string[] words = text.Split(' ');
        string displayedText = "";

        foreach(string word in words) {
            displayedText += word + " ";
            textBox.SetText(displayedText);

            yield return new WaitForSeconds(wordDelay);
        }

        OnAnimationComplete.Invoke();
    }
}
