using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Strings
{
    public static string Get(string key) { return values[key]; }

    public static readonly string[] weaponNames = {"fireball", "sword", "lightning"};
    public static readonly string[] levelNames = {"test1", "test2", "test3"};
    public static readonly string[] bossNames = {"boss1", "boss2", "boss3"};

    private static readonly Dictionary<string, string> values = new Dictionary<string, string>() {
        {"demo_day_summary_1", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat..."},
        {"demo_day_summary_2", "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur."},
        {"demo_day_summary_3", "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."},

        {"demo_headline_1", "Sed ut perspiciatis unde omnis iste"},
        {"demo_headline_2", "Nemo enim ipsam voluptatem quia voluptas"},
        {"demo_headline_3", "Neque porro quisquam est"},
        {"demo_headline_4", "Ut enim ad minima veniam, quis nostrum"},
        {"demo_headline_5", "Quis autem vel eum iure reprehenderit qui"},
        {"demo_headline_6", "At vero eos et accusamus et iusto"},
    };
}
