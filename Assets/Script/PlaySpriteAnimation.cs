using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySpriteAnimation : MonoBehaviour {
    public int fps = 30;
    public int Index {
        get {
            return index;
        }
        set {
            index = value;
            PlayAnim();
        }
    }
    public bool isLoop=true;
    float timer = 0;
    int index;
    UITexture movTex;
    public Texture[] animList;
	// Use this for initialization
	void Start () {
        movTex = GetComponent<UITexture>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 1 / fps)
        {
            timer = 0;
            Index++;
        }
	}
    void PlayAnim() {
        if (Index >= animList.Length)
        {
            if (isLoop)
            {
                Index = 0;
            }
            else
            {
                return;
            }
        }
        movTex.mainTexture = animList[Index];
    }
}
