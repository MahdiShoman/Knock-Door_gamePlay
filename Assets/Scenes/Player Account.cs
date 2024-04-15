using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAccount : MonoBehaviour
{
    // person information
    public static string id = "1";
    public static string nickName = "Abu Odeh";
    public static string email = "abu_odeh@email.com";

    // game information
    public static int score = 0;
    public static int coin = 10000;
    public static int numberOfSolve = 0;
    public static int level = 1;
    public static string[] WeaponesStore = WeaponNames.AllWeaponNames;

    // player information 
    public static int Health = 100;
    public static float DamageResistance = 0f;
    public static float Speed = 3;
    public static int Strength = 5;
    public static string SelectedWeapone = WeaponNames.SWORD;
    public static List<string> Weapones = new List<string> { WeaponNames.SWORD };


    public static void BuyWeapone(string weapone, int price)
    {
        coin -= price;
        Weapones.Add(weapone);
    }

    public static void AddReward(int mazeScore, int mazeCoin)
    {
        coin += mazeCoin;
        score += mazeScore;
    }

    public static void LevelUP()
    {
        coin -= LevelUPPrice();
        level++;
        Health *= 2;
        Speed += 0.1f;
        Strength += 5;
        DamageResistance += 0.05f;
    }

    public static int LevelUPPrice()
    {
        return (level + 1) * 1000;
    }
}
