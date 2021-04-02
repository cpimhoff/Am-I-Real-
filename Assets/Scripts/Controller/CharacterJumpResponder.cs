using UnityEngine;

public class CharacterJumpResponder : InputResponder
{
    public float strength = 9f;
    public float universeNumber = 1;

    private float cyoteTimeLeft = 0f;
    private float CYOTE_TIME = 0.2f;
    private float timeSinceLastJump = float.PositiveInfinity;
    private float MIN_TIME_BETWEEN_JUMPS = 0.3f;

    public void Update()
    {
        timeSinceLastJump += Time.deltaTime;

        bool onGround = IsOnGround();
        if (!onGround)
        {
            cyoteTimeLeft -= Time.deltaTime;
        }
        else
        {
            cyoteTimeLeft = CYOTE_TIME;
        }

        var animator = GetComponent<Animator>();
        if (animator)
        {
            animator.SetBool("OnGround", onGround);
        }
    }

    public override void OnPress()
    {
        if (cyoteTimeLeft > 0 && timeSinceLastJump >= MIN_TIME_BETWEEN_JUMPS)
        {
            var rigidbody = GetComponent<Rigidbody2D>();
            rigidbody.AddForce(new Vector2(0, strength), ForceMode2D.Impulse);
            cyoteTimeLeft = 0;
            timeSinceLastJump = 0;

            var animator = GetComponent<Animator>();
            if (animator)
            {
                animator.SetTrigger("Jump");
            }
        }
    }

    bool IsOnGround()
    {
        var collision = GetComponent<Collider2D>();

        RaycastHit2D hitResult = Physics2D.BoxCast(
            transform.position,
            collision.bounds.size,
            0,
            Vector3.down,
            0.5f,
            LayerMask.GetMask($"World Universe {universeNumber}")
        );

        return hitResult;
    }
}
