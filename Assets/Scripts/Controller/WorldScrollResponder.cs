using UnityEngine;

public class WorldScrollResponder : InputResponder
{
    public bool movesForward = true;

    private Vector2 scroll
    {
        get
        {
            var scroll = GetComponentInParent<WorldScroller>().scroll;
            return movesForward ? -scroll : scroll;
        }
    }
    private Collider2D blocker
    {
        get
        {
            return GetComponentInParent<WorldScroller>().blocker;
        }
    }

    private int universeNumber
    {
        get
        {
            return GetComponentInParent<WorldScroller>().universeNumber;
        }
    }

    private Vector3 lastFrameLocation;
    private float COLLISION_GAP = 0.1f;

    public void Update() {
        if (lastFrameLocation == this.transform.parent.position) {
            UpdateBlockerAnimation(false);
        }

        lastFrameLocation = this.transform.parent.position;
    }

    public override void TickPressed()
    {
        var nudgedPos = blocker.gameObject.transform.position + new Vector3(
            -scroll.normalized.x * COLLISION_GAP,
            -scroll.normalized.y * COLLISION_GAP,
            0
        );

        RaycastHit2D hitResult = Physics2D.BoxCast(
            nudgedPos,
            Vector3.Scale(blocker.bounds.size, new Vector3(1f, 0.9f, 1f)),
            0,
            -scroll,
            scroll.magnitude * Time.deltaTime,
            LayerMask.GetMask($"World Universe {universeNumber}")
        );

        if (!hitResult)
        {
            this.transform.parent.transform.Translate(scroll * Time.deltaTime);
            UpdateBlockerAnimation(true);
        }
    }

    void UpdateBlockerAnimation(bool isWalking)
    {
        var animator = blocker.gameObject.GetComponent<Animator>();
        if (animator)
        {
            animator.SetBool("IsWalking", isWalking);
        }

        if (isWalking)
        {
            var renderer = blocker.gameObject.GetComponent<SpriteRenderer>();
            if (
                (renderer.flipX && movesForward) ||
                (!renderer.flipX && !movesForward)
            )
            {
                renderer.flipX = !renderer.flipX;
            }
        }

    }
}
