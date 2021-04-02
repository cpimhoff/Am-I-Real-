using UnityEngine;

public class ResetUniverseToCheckpointResponder : InputResponder
{
    public GameObject universePlayer;
    public WorldScroller universeScroller;

    public Vector3 playerPosition = new Vector3(0, 1, 1);
    public float scrollPosition = -1f;

    public override void OnPress()
    {
        universePlayer.transform.position = playerPosition;
        universeScroller.MoveScroll(scrollPosition);
    }

    public void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(playerPosition, 0.1f);
        
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(
            transform.position + new Vector3(scrollPosition, 0, 0),
            0.1f
        );
    }
}
