using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [SerializeField] public static DayTransitionData dtd;

    private static void GenerateTitlesAndSummary() {
        dtd.nextSummaryTexts = new string[] {
            Strings.Get("day_start_summary_failed_" + UnityEngine.Random.Range(1, 3))
        };
        IEnumerable<int> headlineNumbers = Enumerable.Range(1, 6)
            .OrderBy(g => UnityEngine.Random.Range(0, 10))
            .Take(3);

        dtd.nextNewsTitles = headlineNumbers
            .Select(i => Strings.Get("news_headline_generic_" + i))
            .ToArray();
        dtd.nextNewsBodies = headlineNumbers
            .Select(i => Strings.Get("news_body_generic_" + i))
            .ToArray();
    }

    public static void OnPlayerDie() {
        dtd.ResetNight();

        GenerateTitlesAndSummary();
        dtd.killCount += dtd.newKillsCount;
        dtd.newKillsCount = 0;
        dtd.failureCount++;
        if(dtd.failureCount >= 3) {
            dtd.nextSummaryTexts = new string[] {
                Strings.Get("day_start_summary_game_lost_1")
            };
            dtd.gameOver = true;
        }
        else dtd.nextSummaryTexts[0] = Strings.Get("day_start_summary_failed_" + UnityEngine.Random.Range(1, 3));

        SceneManager.LoadScene("Day");
    }

    public static void OnStageComplete() {
        dtd.ResetNight();

        GenerateTitlesAndSummary();
        dtd.successCount++;
        dtd.killCount += dtd.newKillsCount;
        dtd.newKillsCount = 0;
        if(dtd.successCount >= 3) {
            dtd.nextSummaryTexts = new string[] {
                Strings.Get("day_start_summary_game_lost_2")
            };
            dtd.gameOver = true;
        }
        else {
            dtd.nextSummaryTexts[0] = Strings.Get("day_start_summary_success_" + UnityEngine.Random.Range(1, 3));
            dtd.nextNewsTitles[0] = Strings.Get("news_headline_" + dtd.nextBoss);
            dtd.nextNewsTitles[0] = Strings.Get("news_body_" + dtd.nextBoss);
        }

        SceneManager.LoadScene("Day");
    }

    public static void OnPlayerEscape() {
        dtd.ResetNight();

        dtd.nextSummaryTexts = new string[] {
            Strings.Get("day_start_summary_game_won")
        };
        dtd.gameOver = true;

        SceneManager.LoadScene("Day");
    }
}
