using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Strings
{
    public static string Get(string key) {
        try {
            return values[key];
        } catch {
            return "";
        }
    }

    public static readonly string[] weaponNames = { "fireball", "sword" };
    public static readonly string[] levelNames = { "Stage 2" };
    public static readonly string[] bossNames = { "boss1", "boss2", "boss3" };

    private static readonly Dictionary<string, string> values = new Dictionary<string, string>() {
        // Displayed at the start of each day
        {"day_start_summary_intro", "day_start_summary_intro"},
        {"day_start_summary_tutorial", "day_start_summary_tutorial"},
        {"day_start_summary_failed_1", "Ugh! Can't I sleep a little longer? F*ck, no, I can't. Work is waiting/calling."},
        {"day_start_summary_failed_2", "Where am I? In the middle of nowhere. God f*cking damit! Kill me! I have to get back home again."},
        {"day_start_summary_failed_3", "day_start_summary_failed_3"},
        {"day_start_summary_success_1", "Man I feel amazing. Usane Bolt won't be able to out run me around town today."},
        {"day_start_summary_success_2", "Today is gonna be a good day. Hope I will have time for everything I want to do."},
        {"day_start_summary_success_3", "day_start_summary_success_3"},
        {"day_start_summary_game_lost_1", "day_start_summary_game_lost_1"},
        {"day_start_summary_game_lost_2", "day_start_summary_game_lost_2"},
        {"day_start_summary_game_won", "day_start_summary_game_won"},

        // Random generic news
        {"news_headline_generic_1", "A man walking his dog gets hit by a brick dropped by an attack eagle."},
        {"news_headline_generic_2", "Last night a man has been attacked by a zombie and found dead in a small alley"},
        {"news_headline_generic_3", "A women found dead after aliens try to abduct her!"},
        {"news_headline_generic_4", "Ut enim ad minima veniam, quis nostrum"},
        {"news_headline_generic_5", "Quis autem vel eum iure reprehenderit qui"},
        {"news_headline_generic_6", "At vero eos et accusamus et iusto"},
        {"news_body_generic_1", "news_body_generic_1"},
        {"news_body_generic_2", "news_body_generic_2"},
        {"news_body_generic_3", "news_body_generic_3"},
        {"news_body_generic_4", "news_body_generic_4"},
        {"news_body_generic_5", "news_body_generic_5"},
        {"news_body_generic_6", "news_body_generic_6"},

        // Displayed when a boss is killed
        {"news_headline_boss1", "news_headline_boss1"},
        {"news_headline_boss2", "news_headline_boss2"},
        {"news_headline_boss3", "news_headline_boss3"},
        {"news_body_boss1", "news_body_boss1"},
        {"news_body_boss2", "news_body_boss2"},
        {"news_body_boss3", "news_body_boss3"},

        // Displayed on top of the map screen
        {"map_screen_prompt", "map_screen_prompt"},

        // Displayed at the end of each day before the dream begins
        {"day_end_summary_1", "day_end_summary_1"},
        {"day_end_summary_2", "day_end_summary_2"},
        {"day_end_summary_3", "day_end_summary_3"},
        {"day_end_summary_playerStrength", "day_end_summary_playerStrength"},
        {"day_end_summary_enemyCount", "day_end_summary_enemyCount"},
        {"day_end_summary_playerSpeed", "day_end_summary_playerSpeed"},
        {"day_end_summary_showHiddenPlatforms", "day_end_summary_showHiddenPlatforms"},

        // Displayed in the tutorial level
        {"tutorial_level_prompt_1", "tutorial_level_prompt_1"},
        {"tutorial_level_prompt_2", "tutorial_level_prompt_2"},
        {"tutorial_level_prompt_3", "tutorial_level_prompt_3"}
    };
}
