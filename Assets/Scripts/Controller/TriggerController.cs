using UnityEngine;

public class TriggerController : MonoBehaviour
{
    public InputResponder responder;

    public void OnTriggerEnter2D(Collider2D other) {
        if (responder) {
            responder.OnPress();
        }
    }

    public void OnTriggerStay2D(Collider2D other) {
        if (responder) {
            responder.TickPressed();
        }
    }
}
