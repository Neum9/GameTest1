using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCenter : MonoBehaviour
{
    List<ManagerBase> m_mgrList;
    // Start is called before the first frame update
    void Awake() {
        AddMgrs();
        InitMgrs();
    }

    void AddMgrs() {
        m_mgrList = new List<ManagerBase>();

        m_mgrList.Add(MoveManager.instance);
        m_mgrList.Add(InputManager.instance);
        m_mgrList.Add(NetManager.instance);
    }

    void InitMgrs() {
        foreach (ManagerBase mgr in m_mgrList) {
            mgr.Init();
        }
    }

    // Update is called once per frame
    void Update() {
        foreach (ManagerBase mgr in m_mgrList) {
            mgr.Update();
        }
    }

    private void OnApplicationQuit() {
        foreach (ManagerBase mgr in m_mgrList) {
            mgr.OnApplicationQuit();
        }
    }


}
