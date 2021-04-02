using UnityEngine;
using DG.Tweening;

public class RevealUniverseResponder : InputResponder
{
    public GameObject blinderTarget;
    public GameObject instructionsTarget;
    public float revealDownwardMotion = -5.337f;
    public float duration = 2f;
    public Ease easing = Ease.InOutCubic;

    private bool activated = false;

    public override void OnPress()
    {
        if (activated) { return; }
        activated = true;

        blinderTarget.transform.DOMoveY(
            revealDownwardMotion,
            duration
        ).SetRelative(true).SetEase(easing);

        if (!instructionsTarget) { return; }
        var innerTextNodes = instructionsTarget.GetComponentsInChildren<SpriteRenderer>();
        foreach (var textNode in innerTextNodes) {
            textNode.DOColor(
                new Color(textNode.color.r, textNode.color.g, textNode.color.b, 0f),
                duration / 2
            ).SetEase(easing);
        }
    }
}