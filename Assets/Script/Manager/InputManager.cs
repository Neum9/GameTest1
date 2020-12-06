// 输入管理
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : ManagerBaseSingleton<InputManager>
{
    public bool isKeyPress(KeyCode key) {
        return Input.GetKey(key);
    }
}
