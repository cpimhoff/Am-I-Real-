using UnityEngine;

// parent component to group shared info for WorldScrollResponders
public class WorldScroller : MonoBehaviour {
    public Vector2 scroll = new Vector2(7, 0);
    public Collider2D blocker;
    public int universeNumber;

    public void MoveScroll(float delta) {
        this.transform.Translate(new Vector3(-delta, 0, 0));
    }
}