using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Player player;

    void Awake()
    {
        player = GetComponent<Player>();
    }
    public void StartAttackAnimation()
    {
        player.Status = Player.Attacking;
        player.didDamage = false;
    }

    public void StartWalkAnimation()
    {
        player.Status = Player.Walking;
    }

    public void StartRunAnimation()
    {
        player.Status = Player.Running;
    }

    public void StartIdleAnimation()
    {
        player.Status = Player.Idle;
    }

    public void StartJumpAnimation()
    {
        player.Status = Player.Jumping;
    }

    public void StartImpactAnimation()
    {
        player.Status = Player.Impact;
    }

    public void StartDeadAnimation()
    {
        player.Status = Player.Dead;
    }

}
