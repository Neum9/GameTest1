// 移动控制者



using System;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : ControllerBase
{
    private delegate void onFunc(int value);
    Dictionary<OptType, onFunc> m_onList = new Dictionary<OptType, onFunc>();
    void Awake() {
        MoveManager.instance.AddController(this);

        m_onList.Add(OptType.MoveHor, onMoveHor);
        m_onList.Add(OptType.MoveVer, onMoveVer);
        m_onList.Add(OptType.Attack, onAttack);
        m_onList.Add(OptType.Defence, onDefence);
        m_onList.Add(OptType.Jump, onJump);
    }
    public void Move(OtherDef.Dir dir) {
        Vector3 offset = Vector3.zero;
        switch (dir) {
            case OtherDef.Dir.up:
                offset = Vector3.forward;
                break;
            case OtherDef.Dir.down:
                offset = Vector3.back;
                break;
            case OtherDef.Dir.left:
                offset = Vector3.left;
                break;
            case OtherDef.Dir.right:
                offset = Vector3.right;
                break;
            default:
                break;
        }
        transform.localPosition = transform.localPosition + offset;
    }

    public void handleOpt(OptStruct optUnit) {
        m_onList[optUnit.type](optUnit.value);
    }

    private void onMoveHor(int value) {
        transform.localPosition = transform.localPosition + value * Vector3.right;
    }
    private void onMoveVer(int value) {
        transform.localPosition = transform.localPosition + value * Vector3.up;
    }
    private void onAttack(int value) {

    }
    private void onDefence(int value) {

    }
    private void onJump(int value) {

    }
}
