using UnityEngine;

public class DebugInputResponder : InputResponder
{
    public override void OnAttach()
    {
        Debug.Log($"Attached to {this.name}.");
    }

    public override void OnPress()
    {
        Debug.Log($"{this.name} was pressed.");
    }

    public override void TickPressed()
    {
        Debug.Log($"{this.name} has pressed frame.");
    }
}