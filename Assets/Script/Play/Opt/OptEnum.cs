
// 玩家操作枚举
public enum OptType
{
    None,
    MoveHor,
    MoveVer,
    Attack,
    Defence,
    Jump
}

// 代表一个操作单元
// MoveHor , MoveVer 移动的距离
// Attack 攻击的类型
// Defence 防御的类型
// Jump 跳跃的类型
public struct OptStruct {
    public OptStruct(OptType _type, int _value) {
        type = _type;
        value = _value;
    }
    public OptType type;
    public int value;
}
