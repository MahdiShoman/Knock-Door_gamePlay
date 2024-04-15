using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Enemy enemy;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    public void StartAttackAnimation()
    {
        enemy.Status = Enemy.Attacking;
        enemy.didDamage = false;
    }

    public void StartWalkAnimation()
    {
        enemy.Status = Enemy.Walking;
    }

    public void StartIdleAnimation()
    {
        enemy.Status = Enemy.Idle;
    }

    public void StartImpactAnimation()
    {
        enemy.Status = Enemy.Impact;
    }

    public void StartDeadAnimation()
    {
        enemy.Status = Enemy.Dead;
    }
    public void StartFinishDeadAnimation()
    {
        enemy.Status = Enemy.FinishDead;
    }

    public void StartWinAnimation()
    {
        enemy.Status = Enemy.Win;
    }



}
