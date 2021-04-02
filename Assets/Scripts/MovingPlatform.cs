using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 movementKeyframe = new Vector3(0, 0, 0);
    public float duration = 2;
    public Ease easing = Ease.InOutCubic;

    private Sequence movement;

    void Start()
    {
        movement = DOTween.Sequence();
        movement.Append(
            transform.DOLocalMove(movementKeyframe, duration)
            .SetRelative(true)
            .SetEase(easing)
        );
        movement.Append(
            transform.DOLocalMove(-movementKeyframe, duration)
            .SetRelative(true)
            .SetEase(easing)
        );
        movement.SetLoops(-1, LoopType.Restart);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(
            transform.position,
            transform.position + movementKeyframe
        );
    }
}
