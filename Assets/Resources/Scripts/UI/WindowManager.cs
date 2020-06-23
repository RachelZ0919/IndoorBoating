using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour {

    public GameObject[] windows;
    private float windowOpened = 0;
    
    private void Start()
    {
        InitializeWindows();
    }

    private void InitializeWindows()
    {
        //TODO:游戏运行时初始化所有窗口状态（可能都是关闭）
    }

    public void OpenWindow(int index)
    {
        //TODO:显示窗口，设置层级，暂停游戏
    }

    public void CloseWindow()
    {
        //TODO:关闭最前的窗口
    }

}
