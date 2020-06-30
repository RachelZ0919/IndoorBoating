using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour {

    public GameObject[] windows;
    private float windowOpened = 0;
    private GameObject PauseUI;


    private void Start()
    {
        InitializeWindows();
    }

    private void InitializeWindows()
    {
        //TODO:游戏运行时初始化所有窗口状态（可能都是关闭）
        PauseUI = GameObject.Find("HUD/Canvas/PauseUI/");
        PauseUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (PauseUI.activeInHierarchy == false) //判断PauseUI是否显示
            {
                PauseUI.SetActive(true);
            }
        }
    }


    public void OpenWindow(int index)
    {
        //TODO:显示窗口，设置层级，暂停游戏
    }

    public void CloseWindow()
    {
        //TODO:关闭最前的窗口
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
