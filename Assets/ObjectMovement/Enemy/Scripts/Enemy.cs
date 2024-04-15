using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Status constant strings
    public const string Attacking = "Attacking";
    public const string Walking = "Walking";
    public const string Idle = "Idle";
    public const string Impact = "Impact";
    public const string Dead = "Dead";
    public const string FinishDead = "FinishDead";
    public const string Win = "Win";

    public int Health = 100;

    public float DamageResistance = 0f;

    public int Speed = 2;

    public int Strength = 20;

    public float AttackDestance = 1.2f;

    public string Status = Idle;// Attacking , Walking , Running , Idle , Jumping , impact , Deaded

    public bool win = false;

    public bool didDamage = false;

    public int correct = 0;


    private void Start()
    {
        correct = PlayerPrefs.GetInt("State", 0);
        switch (correct)
        {
            case 0: easyEnemy(); break;
            case 1: normalEnemy(); break;
            case 2: hardEnemy(); break;
        }
    }

    private void easyEnemy()
    {
        Health = 100;
        DamageResistance = 0f;
        Strength = 10;
    }

    private void normalEnemy()
    {
        Health = 150;
        DamageResistance = 0.1f;
        Strength = 15;
    }

    private void hardEnemy()
    {
        Health = 200;
        DamageResistance = 0.2f;
        Strength = 20;
    }


    public void DoDamage(float damage)
    {
        Health -= (int)(damage - damage * DamageResistance);
        if (Health <= 0)
        {
            Health = 0;
            Status = Dead;
        }
    }

    // Function to check if the player is attacking
    public bool IsAttacking()
    {
        return Status == Attacking;
    }

    // Function to check if the player is walking
    public bool IsWalking()
    {
        return Status == Walking;
    }

    // Function to check if the player is idle
    public bool IsIdle()
    {
        return Status == Idle;
    }

    // Function to check if the player is impacted
    public bool IsImpacted()
    {
        return Status == Impact;
    }

    // Function to check if the player is dead
    public bool IsDead()
    {
        return Status == Dead;
    }
    public bool IsFinishDead()
    {
        return Status == FinishDead;
    }

    public bool IsWin()
    {
        return Status == Win;
    }

}
