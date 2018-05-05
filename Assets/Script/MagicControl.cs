using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicControl {
    public GameObject MaskObj;
    public GameObject BlendObj;
    public UIPanel Panel;
    Vector3 lockPosition=Vector3.zero;
    //Vector2 maskPos=Vector2.zero;
    public Canvas canvas;
	// Use this for initialization
	public void Init (GameObject maskObj) {
        MaskObj = maskObj;
        BlendObj = maskObj.transform.GetChild(0).gameObject;
        lockPosition = BlendObj.transform.position;
        Panel = maskObj.GetComponent<UIPanel>();
	}
	
	// Update is called once per frame
	public void Update () {
        BlendObj.transform.position = lockPosition;
        Vector2 mosPos = Input.mousePosition;
        Vector3 pos = Camera.main.ScreenToWorldPoint(mosPos);
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, mosPos, canvas.worldCamera, out maskPos);
        MaskObj.transform.position = pos;
    }
    public void SetMaskTexture(Texture2D maskTexture)
    {
        Panel.clipTexture = maskTexture;
    }
    public void changeMask()
    {
        Panel.clipping = UIDrawCall.Clipping.TextureMask;
    }
}
