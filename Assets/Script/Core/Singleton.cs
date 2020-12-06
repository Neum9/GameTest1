//单例模板类


public class Singleton<T>  where T : new()
{
    protected static T m_instance;
    public static T instance {
        get {
            if (m_instance == null) {
                m_instance = new T();
            }
            return m_instance;
        }
    }
}
