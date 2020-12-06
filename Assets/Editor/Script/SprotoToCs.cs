using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;


public class SprotoToCs : MonoBehaviour
{
    [MenuItem("Custom/SprotoToCs")]
    static void Excute() {
        string args = "/k" + "lua" + " Assets/Editor/Util/sprotodump/sprotodump.lua -cs ";

        // 获取sproto文件下所有文件
        string spFiles = "";
        string load = Application.dataPath + "/Sproto";
        DirectoryInfo dInfo = new DirectoryInfo(load);
        foreach (FileInfo file in dInfo.GetFiles()) {
            if (file.Extension.Equals(".sproto")) {
                spFiles += "Assets/Sproto/" + file.Name + " ";
            }
        }
        args += spFiles;
        // 输出到对应文件夹
        args += " -d " + Application.dataPath + "/Script/Net/sprotoFile/";
        System.Diagnostics.Process.Start(@"cmd", args);

        Debug.Log("SprotoToCs!");
    }
}
