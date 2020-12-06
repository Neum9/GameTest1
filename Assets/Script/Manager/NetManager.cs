//TODOCjc:
//1,login

using Sproto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetManager : ManagerBaseSingleton<NetManager>
{
    private string ip = "127.0.0.1";
    private int port = 1234;
    override public void Init() {
        NetSender.Init();
        NetReceiver.Init();
        NetCore.Init();

        NetCore.enabled = true;

        Connect();
    }

    override public void Update() {
        NetCore.Dispatch();
    }

    public void Connect() {
        NetCore.Connect(ip, port, () => {
            Debug.Log("connect to server!");
            NetCore.logined = true;
        });
    }

    public void DisConnent() {
        NetCore.Disconnect();
        NetCore.logined = false;
    }

    override public void OnApplicationQuit() {
        DisConnent();
    }
    //初始化事件派发 TODOCjc
    void initEventDispatch() {
        NetReceiver.AddHandler<Protocol.foobar>(
    (SprotoTypeBase sp, long session) => {
        EventManager.instance.FireEvent(EVENTKEY.net_Recv, sp, session);
        return null;
    }
    );
    }
}
