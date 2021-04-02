using UnityEngine;

public class StartMusicResponder : InputResponder
{
    public AudioSource player;
    private bool activated = false;

    public override void OnPress()
    {
        if (activated) { return; }
        activated = true;

        player.Play();
    }
}
