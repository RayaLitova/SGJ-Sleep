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
    public static readonly string[] levelNames = { "Stage1", "Stage 2" };
    public static readonly string[] bossNames = { "boss1", "boss2", "boss3" };

    private static readonly Dictionary<string, string> values = new Dictionary<string, string>() {
        // Displayed at the start of each day
        {"day_start_summary_intro", "This nightmare was exhausting,it feels like I have walked all night"},
        {"day_start_summary_tutorial", "day_start_summary_tutorial"},
        {"day_start_summary_failed_1", "Ugh! Can't I sleep a little longer? F*ck, no, I can't. Work is waiting/calling."},
        {"day_start_summary_failed_2", "Where am I? In the middle of nowhere. God f*cking damit! Kill me! I have to get back home again."},
        {"day_start_summary_failed_3", "Those nightmares again i feel so sick,after them."},
        {"day_start_summary_success_1", "Man I feel amazing. Usane Bolt won't be able to out run me around town today."},
        {"day_start_summary_success_2", "Today is gonna be a good day. Hope I will have time for everything I want to do."},
        {"day_start_summary_success_3", "I am gonna battle trough today like I battled trought that stupid dream."},
        {"day_start_summary_game_lost_1", "The police found out about your mischievous nights out.How do you think prison is going to treat you."},
        {"day_start_summary_game_lost_2", "After all those nightmares you went trough.Your now sick mind couldn't stop it's self from trying to comit genocide"},
        {"day_start_summary_game_won", "Congratulations you beat the urge to kill while asleep.You are a new  refined person."},

        // Random generic news
        {"news_headline_generic_1", "A man walking his dog gets hit by a brick dropped by an attack eagle."},
        {"news_headline_generic_2", "Last night a man has been attacked by a zombie and found dead in a small alley"},
        {"news_headline_generic_3", "A women found dead after aliens try to abduct her!"},
        {"news_headline_generic_4", "Ut enim ad minima veniam, quis nostrum"},
        {"news_headline_generic_5", "Quis autem vel eum iure reprehenderit qui"},
        {"news_headline_generic_6", "At vero eos et accusamus et iusto"},
        {"news_body_generic_1", "Local cashier gets hit by a brick in the head and has therefore been found earlier today. A nearby bird watcher who called the police says that the brick fell at the same time an eagle flew above the man.He claims that the higher-ups train attack eagles for that(such) reason/s. Is this even possible or maybe it's just a cover up story for someone??"},
        {"news_body_generic_2", "Miss Ivanovich had been woken up by a horrible scream when she looked out the window and saw a zombie attacking a man, in a small alley, with a knife. Is the apocalypse coming? And why did the zombie just kill and not infect or eat the victim's brain? "},
        {"news_body_generic_3", "This is a crazy/insane story that Bob the neighborhood's homeless protector reported to  the police. Everyone believes Bob. After all he is known for his good deeds. However, has Bob gone crazy? Medical expertise show a heavy head injury, seen by a giant hole, in the upper part of the skull."},
        {"news_body_generic_4", "news_body_generic_4"},
        {"news_body_generic_5", "news_body_generic_5"},
        {"news_body_generic_6", "news_body_generic_6"},

        // Displayed when a boss is killed
        {"news_headline_boss1", "Local hobo murdered last night"},
        {"news_headline_boss2", "news_headline_boss2"},
        {"news_headline_boss3", "news_headline_boss3"},
        {"news_body_boss1", "Neighborhood association night guards find the body of young Mister Bob .Someone had brutalized him ,police bearly recognize his deformed face."},
        {"news_body_boss2", "news_body_boss2"},
        {"news_body_boss3", "news_body_boss3"},

        // Displayed on top of the map screen
        {"map_screen_prompt", "What am I intrested in doing today."},

        // Displayed at the end of each day before the dream begins
        {"day_end_summary_1", "Finnaly I might be able to rest a little."},
        {"day_end_summary_2", "What a long day it was,I hope everything at home is done."},
        {"day_end_summary_3", "I would appreciate some alone time after a hard day like ."},
        {"day_end_summary_playerStrength", "Heavy Weight.Big Muscle."},
        {"day_end_summary_enemyCount", "May God protect you from all sins."},
        {"day_end_summary_playerSpeed", "If you don't come fast enough you will wait a few eternities."},
        {"day_end_summary_showHiddenPlatforms", "Modern art is very abstract ,but it might boost your imagination."},

        // Displayed in the tutorial level
        {"tutorial_level_prompt_1", "tutorial_level_prompt_1"},
        {"tutorial_level_prompt_2", "tutorial_level_prompt_2"},
        {"tutorial_level_prompt_3", "tutorial_level_prompt_3"}
    };
}
