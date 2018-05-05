using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UdpServer : MonoBehaviour {
    Socket udpServer;
    public Text showText;
    float[] data;
    public Vector2 pos;
    Thread thUdp;
    // Use this for initialization
    void Start () {
        udpServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7788);
        udpServer.Bind(iPEndPoint);
        thUdp = new Thread(udpReceive);
        thUdp.Start();
    }
	
	// Update is called once per frame
	void Update () {
        if (pos.x < -56)
        {
            pos = new Vector2(-56, pos.y);
        }
        if (pos.x > 56)
        {
            pos = new Vector2(56, pos.y);
        }
        if (pos.y < -50)
        {
            pos = new Vector2(pos.x, -50);
        }
        if (pos.y > 50)
        {
            pos = new Vector2(pos.x, 50);
        }
        if (data != null && data.Length > 3)
        {
            if (data[1] > 0.5f)
            {
                pos = new Vector2(pos.x + 1, pos.y);
            }
            if (data[1] < -0.5f)
            {
                pos = new Vector2(pos.x-1,pos.y);
            }
            if (data[2] > 0.5f)
            {
                pos = new Vector2(pos.x, pos.y + 1);
            }
            if (data[2] < -0.5f)
            {
                pos = new Vector2(pos.x, pos.y - 1);
            }
        }
    }
    void udpReceive() {
        byte[] Data = new byte[1024];
        EndPoint remoteIp = new IPEndPoint(IPAddress.Any,0);
        while (true)
        {
            int length = udpServer.ReceiveFrom(Data, ref remoteIp);
            string msg = Encoding.UTF8.GetString(Data, 0, length);
            if (msg != "")
            {
                showText.text = msg;
                string[]recv=msg.Split('\n');
                data = new float[recv.Length];
                for (int i = 0; i < recv.Length; i++) {
                    float.TryParse(recv[i], out data[i]);
                }
            }
            Thread.Sleep(0);
        }

    }
    private void OnApplicationQuit()
    {
        udpServer.Close();
        thUdp.Abort();
    }
}
