

using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Enemy enemy;
    private NavMeshAgent navMeshAgent;
    private Player player;
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        enemy = GetComponent<Enemy>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {

        if (enemy.IsDead())
        {
            navMeshAgent.velocity = Vector3.zero;
            return;
        }
        if (!enemy.IsWin() && enemy.win)
        {
            animator.SetTrigger("win");
        }

        if (Vector3.Distance(transform.position, player.transform.position) > 10 || enemy.win)
        {
            navMeshAgent.velocity = Vector3.zero;

            animator.SetFloat("speedV", 0);
            return;
        }
        navMeshAgent.speed = enemy.Speed;
        if (Vector3.Distance(transform.position, player.transform.position) > enemy.AttackDestance)
        {
            navMeshAgent.SetDestination(player.transform.position);
            animator.SetFloat("speedV", 1);
        }
        else
        {
            navMeshAgent.velocity = Vector3.zero;
            if (!enemy.IsAttacking())
            {
                bool tmp = Random.Range(0, 2) == 0;

                if (tmp)
                {
                    animator.SetBool("attack1", true);
                    animator.SetBool("attack2", false);
                }
                else
                {
                    animator.SetBool("attack1", false);
                    animator.SetBool("attack2", true);
                }
                animator.SetFloat("speedV", 0);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // This is for check if the collision make with Enemy Weapon tage
        if (other.gameObject.CompareTag("PlayerWeapon"))
        {
            Player player = other.gameObject.GetComponentInParent<Player>();
            if (player != null && !player.didDamage && player.IsAttacking())
            {
                Vector3 directionOfAttack = (other.transform.position - transform.position).normalized;
                float dotProduct = Vector3.Dot(transform.forward, directionOfAttack);

                enemy.DoDamage(player.GetDamage());
                player.didDamage = true;
                if (enemy.IsDead())
                {
                    if (dotProduct > 0)
                    {
                        animator.SetTrigger("backDeath");

                    }
                    else
                    {
                        animator.SetTrigger("forwordDeath");

                    }
                    player.win = true;
                    return;
                }

                if (dotProduct > 0)
                {
                    animator.SetTrigger("forwordDamage");

                }
                else
                {
                    animator.SetTrigger("backDamage");
                }

                navMeshAgent.velocity = Vector3.zero;



            }
        }

    }
}
