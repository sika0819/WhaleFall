using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MovController {
    public UIPanel Panel;
    public VideoPlayer player;
	// Use this for initialization
	public void Init (GameObject panel) {
        Panel = panel.GetComponent<UIPanel>();
	}
    public void SetPlayer(VideoPlayer player)
    {
        this.player = player;
    }
    public void SetMov(VideoClip videoClip)
    {
        player.clip = videoClip;
        player.Play();
    }

}
