using System.Collections.Generic;
using UnityEngine;

public class MultiInputResponder : InputResponder
{
    public List<InputResponder> responses = new List<InputResponder>();

    public override void OnAttach()
    {
        foreach (var responder in this.responses) {
            responder.OnAttach();
        }
    }

    public override void OnPress()
    {
        foreach (var responder in this.responses) {
            responder.OnPress();
        }
    }

    public override void TickPressed()
    {
        foreach (var responder in this.responses) {
            responder.TickPressed();
        }
    }
}
