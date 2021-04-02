using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EndGameResponder : InputResponder
{
    public Camera targetCamera;
    public GameObject blinderTarget;

    public Texture2D fadeTexture;
    public float downwardMotion = -14f;
    public float duration = 8f;
    public Ease easing = Ease.InOutCubic;

    private bool activated = false;
    private float fadeAlpha = 0f;
    private float animatedTime = 0f;

    public override void OnPress()
    {
        if (activated) { return; }
        activated = true;

        targetCamera.transform.DOMoveY(
            downwardMotion,
            duration
        ).SetRelative(true).SetEase(easing);

        blinderTarget.SetActive(false);
    }

    public void Update()
    {
        if (activated)
        {
            animatedTime += Time.deltaTime;
        }

        if (animatedTime > duration) {
            SceneManager.LoadScene("End", LoadSceneMode.Single);
            this.gameObject.SetActive(false);
        }
    }

    void OnGUI()
    {
        if (!activated || animatedTime < (duration / 2f)) { return; }

        fadeAlpha -= -(1f / duration) * Time.deltaTime;
        fadeAlpha = Mathf.Clamp01(fadeAlpha);

        Color newColor = GUI.color;
        newColor.a = fadeAlpha;

        GUI.color = newColor;
        GUI.depth = -9999;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }
}
