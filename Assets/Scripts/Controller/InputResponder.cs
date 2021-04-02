using UnityEngine;

public class InputResponder : MonoBehaviour
{
    public virtual void OnAttach() { }

    public virtual void OnPress() { }
    public virtual void TickPressed() { }
}