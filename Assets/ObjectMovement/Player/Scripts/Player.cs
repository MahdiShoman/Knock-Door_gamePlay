using UnityEngine;

public class Player : MonoBehaviour
{
    // Status constant strings
    public const string Attacking = "Attacking";
    public const string Walking = "Walking";
    public const string Running = "Running";
    public const string Idle = "Idle";
    public const string Jumping = "Jumping";
    public const string Impact = "Impact";
    public const string Dead = "Dead";


    public int Health;

    public float DamageResistance;

    public float Speed;

    public int AttackSpeed;

    public float jumpHeight;

    public float Run;

    public int Strength;

    public string Status = Idle;// Attacking , Walking , Running , Idle , Jumping , impact , Deaded

    public string Weapone;

    public string Shield = "Shield";

    public bool didDamage = false;

    public bool win = false;
    public bool pause = false;

    private void Start()
    {
        Health = PlayerAccount.Health;
        DamageResistance = PlayerAccount.DamageResistance;
        Speed = PlayerAccount.Speed;
        Run = Speed * 4 / 3;
        Strength = PlayerAccount.Strength;
        Weapone = PlayerAccount.SelectedWeapone;
        jumpHeight = 2;
    }

    private void Update()
    {

        Weapone = PlayerAccount.SelectedWeapone;
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
    public float GetDamage()
    {
        return Strength + WeaponNames.AttackDamage(Weapone);
    }
    public float GetAttackSpeed()
    {
        return WeaponNames.AttackSpeed(Weapone);
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

    // Function to check if the player is running
    public bool IsRunning()
    {
        return Status == Running;
    }

    // Function to check if the player is idle
    public bool IsIdle()
    {
        return Status == Idle;
    }

    // Function to check if the player is jumping
    public bool IsJumping()
    {
        return Status == Jumping;
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



}
