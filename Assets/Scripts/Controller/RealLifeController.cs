using UnityEngine;

public class RealLifeController : MonoBehaviour
{
    public InputResponder rightResponder;
    public InputResponder leftResponder;
    public InputResponder spaceResponder;

    private bool rightTickedLastFrame = false;
    private bool leftTickedLastFrame = false;

    private float AXIS_DEADZONE = 0.6f;

    public void Start() {
        rightResponder.OnAttach();
        leftResponder.OnAttach();
        spaceResponder.OnAttach();
    }

    public void Update()
    {
        UpdateButton("Space", spaceResponder);
        UpdateAxis("Horizontal", false, ref this.rightTickedLastFrame, rightResponder);
        UpdateAxis("Horizontal", true, ref this.leftTickedLastFrame, leftResponder);
    }

    public void SetRightResponder(InputResponder newResponder) {
        rightResponder = newResponder;
        rightResponder.OnAttach();
    }

    public void SetLeftResponder(InputResponder newResponder) {
        leftResponder = newResponder;
        leftResponder.OnAttach();
    }

    public void SetSpaceResponder(InputResponder newResponder) {
        spaceResponder = newResponder;
        spaceResponder.OnAttach();
    }

    void UpdateButton(string buttonName, InputResponder responder) {
        if (Input.GetButtonDown(buttonName)) {
            responder.OnPress();
        }
        if (Input.GetButton(buttonName)) {
            responder.TickPressed();
        }
    }

    void UpdateAxis(string axisName, bool inverted, ref bool tickedLastFrame, InputResponder responder) {
        float axis = Input.GetAxis(axisName);
        bool axisPastDeadzone = !inverted
            ? axis > AXIS_DEADZONE
            : axis < -AXIS_DEADZONE;

        if (axisPastDeadzone) {
            if (!tickedLastFrame) {
                responder.OnPress();
            }
            responder.TickPressed();
            tickedLastFrame = true;
        } else {
            tickedLastFrame = false;
        }
    }
}
