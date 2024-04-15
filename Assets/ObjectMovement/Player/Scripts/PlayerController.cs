using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = -9.81f;
    private Animator animator;
    private Player player;
    private GroundCheck groundCheck;
    private CharacterController controller;

    void Awake()
    {
        // Get the rigidbody on this.
        player = GetComponent<Player>();
        animator = GetComponentInChildren<Animator>();
        groundCheck = GetComponentInChildren<GroundCheck>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (player.win)
        {
            return;
        }
        if (player.IsAttacking())
        {
            animator.speed = player.GetAttackSpeed();
        }
        else
        {
            animator.speed = 1;
        }
        if (player.Health == 0)
        {
            if (!player.IsDead())
            {
                animator.SetTrigger("backDeath");
                player.Status = Player.Dead;
            }
            return;
        }

        if (!player.IsAttacking() && Input.GetMouseButtonDown(0) && groundCheck.isGrounded)
        {
            animator.SetTrigger("attack");
        }
        MovePlayer();
    }


    private Vector3 velocity;
    private void MovePlayer()
    {
        //Check if attacking the caracter can not move
        if (player.IsAttacking() || player.IsDead())
        {
            return;
        }
        if (groundCheck.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        // this to get -1 , 0 , 1 numbers
        float horizontalInput = getHorizontalMove() / 2f;
        float virticalInput = getVirticalMove();

        if (virticalInput < 0) virticalInput = virticalInput / 2;

        float speed = player.Speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = player.Run;
        }

        // Apply movement.
        Vector3 move = transform.right * horizontalInput + transform.forward * virticalInput;

        controller.Move(move * speed * Time.deltaTime);

        //move animation
        animator.SetFloat("speedV", getVirticalMove());
        animator.SetFloat("speedH", getHorizontalMove() * speed);

        // Jump when the Jump button is pressed and we are on the ground.
        if (Input.GetButtonDown("Jump") && groundCheck.isGrounded)
        {
            // v= (2gh)^0.5
            velocity.y += Mathf.Sqrt(player.jumpHeight * -2f * gravity);
            animator.SetTrigger("jump");
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    private int getHorizontalMove()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            return 0;
        if (Input.GetKey(KeyCode.A))
            return -1;
        if (Input.GetKey(KeyCode.D))
            return 1;
        return 0;
    }

    private int getVirticalMove()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
            return 0;
        if (Input.GetKey(KeyCode.W))
            return 1;
        if (Input.GetKey(KeyCode.S))
            return -1;
        return 0;
    }




    private void OnTriggerEnter(Collider other)
    {
        // This is for check if the collision make with Enemy Weapon tage
        if (other.CompareTag("EnemyWeapon"))
        {
            Enemy enemy = other.gameObject.GetComponentInParent<Enemy>();
            if (enemy != null && !enemy.didDamage && enemy.IsAttacking())
            {

                Vector3 directionOfAttack = (other.transform.position - transform.position).normalized;
                float dotProduct = Vector3.Dot(transform.forward, directionOfAttack);
                player.DoDamage(enemy.Strength);
                enemy.didDamage = true;
                if (player.IsDead())
                {
                    if (dotProduct > 0)
                    {
                        animator.SetTrigger("backDeath");

                    }
                    else
                    {
                        animator.SetTrigger("forwordDeath");

                    }

                    enemy.win = true;
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
            }


        }

    }

}
