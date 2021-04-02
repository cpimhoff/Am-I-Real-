using UnityEngine;
using DG.Tweening;

public class ButtonController : MonoBehaviour
{
    public InputResponder responder;
    public float transitionTime = 0.2f;

    private Vector3 buttonParentRestingPosition;
    private float timeSinceLastPress = float.PositiveInfinity;

    public void Start() {
        buttonParentRestingPosition = transform.parent.position;
    }

    public void Update() {
        timeSinceLastPress += Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (responder && timeSinceLastPress >= transitionTime) {
            responder.OnPress();
            timeSinceLastPress = 0;
        }
        transform.parent.DOMoveY(buttonParentRestingPosition.y - 0.5f, transitionTime);
    }

    public void OnTriggerStay2D(Collider2D other) {
        if (responder) {
            responder.TickPressed();
        }
        timeSinceLastPress = 0;
    }

    public void OnTriggerExit2D(Collider2D other) {
        transform.parent.DOMoveY(buttonParentRestingPosition.y, transitionTime);
        timeSinceLastPress = 0;
    }
}
