using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class YnetClient : MonoBehaviour {

    public string Host = "127.0.0.1";
    public int Port = 17306;
    public bool ConnectOnAwake;

    private YnetConnecter client;

    private UniRx.IObservable<MessageData> stream;

    public UniRx.IObservable<MessageData> OnRecievedMessageAsObservable
    {
        get { return stream; }
    }

    private void Awake()
    {
        client = new YnetConnecter();
        if(ConnectOnAwake)
        {
            Connect();
        }
        stream = client.OnRecievedMessage.ObserveOnMainThread().Publish().RefCount();
    }

    private void OnDestroy()
    {
        client.Disconnect();
    }
    public void Connect()
    {
        client.Connect(Host, Port);
    }
    public void Disconnect()
    {
        client.Disconnect();
    }
}
