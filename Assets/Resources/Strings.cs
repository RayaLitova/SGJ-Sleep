using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Strings
{
    public static string Get(string key) { return values[key]; }

    public static readonly string[] weaponNames = { "fireball", "sword" };
    public static readonly string[] levelNames = { "test1", "test2", "test3" };
    public static readonly string[] bossNames = { "boss1", "boss2", "boss3" };

    private static readonly Dictionary<string, string> values = new Dictionary<string, string>() {
        {"demo_day_summary_1", "Man I feel amazing. Usane Bolt won't be able to out run me around town today."},
        {"demo_day_summary_2", "Today is gonna be a good day. Hope I will have time for everything I want to do."},
        {"demo_day_summary_3", "Ugh! Can't I sleep a little longer? F*ck, no, I can't. Work is waiting/calling."},
        {"demo_day_summary_4", "Where am I? In the middle of nowhere. God f*cking damit! Kill me! I have to get back home again."},

        {"demo_headline_1", "A man walking his dog gets hit by a brick dropped by an attack eagle."},
        {"demo_headline_2", "Last night a man has been attacked by a zombie and found dead in a small alley"},
        {"demo_headline_3", "A women found dead after aliens try to abduct her!"},
        {"demo_headline_4", "Ut enim ad minima veniam, quis nostrum"},
        {"demo_headline_5", "Quis autem vel eum iure reprehenderit qui"},
        {"demo_headline_6", "At vero eos et accusamus et iusto"},
    };
}
