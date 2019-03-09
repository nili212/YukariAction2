using System.Collections;
using System.Collections.Generic;
using System.Text;
using UniRx;
using UnityEngine;

public class YnetConnecter {

    System.Net.Sockets.TcpClient tcpClient;
    private Subject<MessageData> _messageData;
    byte[] buffer;

    public IObservable<MessageData> OnRecievedMessage { get { return _messageData; } }

    public bool IsConnected
    {
        get { return this.tcpClient != null && this.tcpClient.Connected; }
    }

    public YnetConnecter()
    {
        _messageData = new Subject<MessageData>();
        buffer = new byte[2048];
    }

    public void Connect(string host,int port)
    {
        if(IsConnected)
        {
            Disconnect();
        }

        tcpClient = new System.Net.Sockets.TcpClient(host, port);
        tcpClient.GetStream().BeginRead(buffer,0,buffer.Length, CallBackBeginReceive, null);
    }

    private void CallBackBeginReceive(System.IAsyncResult ar)
    {
        try
        {
            var bytes = this.tcpClient.GetStream().EndRead(ar);

            if(bytes == 0)
            {
                Disconnect();
                return;
            }

            var recievedMessage = Encoding.UTF8.GetString(buffer, 0, bytes);
            Debug.Log(recievedMessage);
            var m = MessageData.FromJson(recievedMessage);
            _messageData.OnNext(m);
            tcpClient.GetStream().BeginRead(buffer, 0, buffer.Length,CallBackBeginReceive,null);

        }
        catch(System.Exception e)
        {
            Disconnect();
        }
    }

    public void Disconnect()
    {
        if(tcpClient!=null&&tcpClient.Connected)
        {
            tcpClient.GetStream().Close();
            tcpClient.Close();
            tcpClient = null;
        }
    }
}

public class MessageData
{
    public string text;

    public static MessageData FromJson(string json)
    {
        return JsonUtility.FromJson<MessageData>(json);
    }
}
