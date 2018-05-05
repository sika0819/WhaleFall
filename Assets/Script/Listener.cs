using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Listener : MonoBehaviour {
    //Gesture.GestureData gestureData;
    public GameObject maskPanel;
    public GameObject movPanel;
    public VideoClip videoClip;
    MagicControl magicControl;
    MovController movController;
    public Texture2D maskTexture;
    public VideoPlayer player;
    // Use this for initialization
    void Start () {
        magicControl = new MagicControl();
        movController = new MovController();
        magicControl.Init(maskPanel);
        movController.Init(movPanel);
        movController.SetPlayer(player);
    }
	
	// Update is called once per frame
	void Update () {
       
        //switch (gestureData)
        //{
        //    case Gesture.GestureData.none:
        //        break;
        //    case Gesture.GestureData.click:
        //        StartMov();
        //        break;
        //}
        //if(Input.GetKeyUp(KeyCode.S))
        //{
        //    gestureData = Gesture.GestureData.click;
        //}
	}
    public void StartMov() {
        movController.SetMov(videoClip);
        magicControl.Update();
        magicControl.SetMaskTexture(maskTexture);
        magicControl.changeMask();
    }
}
