// 管理者基类 单例类
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface ManagerBase
{
    void Init();
    void Update();
    void OnApplicationQuit();
}


public class ManagerBaseSingleton<T> : Singleton<T>, ManagerBase where T : new()
{
    public virtual void Init() {

    }

    public virtual void OnApplicationQuit() {
    }

    public virtual void Update() {

    }
}