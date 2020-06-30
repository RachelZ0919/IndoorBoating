using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour {

    private float speed;   //金币飞往UI的速度
    static private bool isCoinCollecting;
    static private GameObject coin;//需要收集的金币
    static private Vector3 coinIcon_worldPos;  //金币图标的世界坐标，即金币模型要飞向的终点

    private void Start()
    {
        speed = 5;
        isCoinCollecting = false;
        UpdateCoinCount(0);
    }

    public void CoinCollectAnimation(GameObject coin)
    {
        //准备开始金币飞到UI上的动画，传入的coin参数为CoinCollector获得的Coin

        CoinUI.coin = coin;
        Image coinIcon = GameObject.Find("/HUD/Canvas/GoldenCoin").GetComponent<Image>();
        
        isCoinCollecting = true;    //开始收集金币  
    }

    public void UpdateCoinCount(float count)
    {
        //更新UI上金币数量显示
        Text coin_num = GameObject.Find("/HUD/Canvas/GoldenCoin_Count").GetComponent<Text>();
        if (coin_num == null)
            Debug.Log("Can't fidn /HUD/Canvas/GoldenCoin_Count");
        coin_num.text = count.ToString();
    }

    private void Update()
    {

        //Debug.Log("isCoinCollecting=" + isCoinCollecting);
        if (isCoinCollecting==true)
        {
            Renderer rend = coin.GetComponent<Renderer>();
            Material[] materials = rend.materials;
            materials[0].shader = Shader.Find("Transparent/Diffuse");
            materials[1].shader = Shader.Find("Transparent/Diffuse");
            float transparency = materials[0].color.a;
            if (transparency <= 0)
            {
                //若金币已变为透明，则结束
                isCoinCollecting = false;
            }
            materials[0].color = new Color(materials[0].color.r, materials[0].color.g, materials[0].color.b, materials[0].color.a - 1.2f * Time.deltaTime);  //降低透明度            
            materials[1].color = new Color(materials[1].color.r, materials[1].color.g, materials[1].color.b, materials[1].color.a - 1.2f * Time.deltaTime);  //降低透明度            
            rend.materials = materials;
            coin.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));  //控制金币向上飞
        }
    }
}
