using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Sproto;

public class MoveManager : ManagerBaseSingleton<MoveManager>
{
    List<MoveController> m_ctlList;

    public MoveManager() {
        m_ctlList = new List<MoveController>();
    }

    override public void Update() {
        handleInput();
    }

    public void handleInput() {
        OptStruct optVer = new OptStruct { type = OptType.None }, optHor = new OptStruct { type = OptType.None };
        if (InputManager.instance.isKeyPress(KeyCode.W)) {
            optVer.type = OptType.MoveVer;
            optVer.value = 1;
        } else if (InputManager.instance.isKeyPress(KeyCode.S)) {
            optVer.type = OptType.MoveVer;
            optVer.value = -1;
        }


        if (InputManager.instance.isKeyPress(KeyCode.A)) {
            optHor.type = OptType.MoveHor;
            optHor.value = -1;
        } else if (InputManager.instance.isKeyPress(KeyCode.D)) {
            optHor.type = OptType.MoveHor;
            optHor.value = 1;
        }

        if (optVer.type != OptType.None) {
            SprotoType.playopt.request opt = new SprotoType.playopt.request();
            opt.optUnit = new SprotoType.optUnit { type = (int)optVer.type, param = optVer.value };
            NetSender.Send<Protocol.playopt>(opt, OnRecvOpt);
        }

        if (optHor.type != OptType.None) {
            SprotoType.playopt.request opt = new SprotoType.playopt.request();
            opt.optUnit = new SprotoType.optUnit { type = (int)optHor.type, param = optHor.value };
            NetSender.Send<Protocol.playopt>(opt, OnRecvOpt);
        }
    }

    public void OnRecvOpt(SprotoTypeBase sp) {
        //TODOCjc 先不分角色
        var resp = sp as SprotoType.playopt.response;
        OptStruct opt = new OptStruct { type = (OptType) resp.optUnit.type, value = (int)resp.optUnit.param };
        foreach (var ctr in m_ctlList) {
            ctr.handleOpt(opt);
        }
    }

    public void AddController(MoveController c) {
        m_ctlList.Add(c);
    }
    public void RemoveController(MoveController c) {
        m_ctlList.Remove(c);
    }
}
