using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTest : MonoBehaviour {
    public float interval = 0.1f;
    float timer = 0;
    public GameObject magicPrefab;
    public Transform transformRoot;
    public Vector2 rootPos;
    UdpServer udpServer;
    // Use this for initialization
    void Start () {
        udpServer = GetComponent<UdpServer>();
    }
	
	// Update is called once per frame
	void Update () {
        transformRoot.position = udpServer.pos;
        timer += Time.deltaTime;
        if (timer > interval)
        {
            Vector2 rootPos = transformRoot.position;
            GameObject magicObj = Instantiate<GameObject>(magicPrefab, Vector3.zero, Quaternion.identity);
            magicObj.transform.position = rootPos;
            timer = 0;
        }


    }
}
