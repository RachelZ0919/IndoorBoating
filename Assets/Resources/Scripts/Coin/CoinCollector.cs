using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour {

    private float totalCoin;
    private CoinUI coinUI;
    public AudioClip clip;
    public AudioSource source;

    private void Start()
    {        
        totalCoin = 0;
        coinUI = new CoinUI();
        source = gameObject.GetComponent<AudioSource>();
        source.volume = 0.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        //当碰撞到金币，进行金币收集，并告知CoinUI作出动画反馈
        if (other.gameObject.tag == "Coin")
        {           
            coinUI.CoinCollectAnimation(other.gameObject);  //金币增加动画
            //金币数量增加，并在UI上体现
            totalCoin += 1;
            coinUI.UpdateCoinCount(totalCoin);

            //发出收集金币的声音
            Debug.Log("collect the coin. play sound");
            clip = Resources.Load<AudioClip>("Music/getCoin");
            source.clip = clip;
            source.Play();
        }
        //Destroy(coinUI);
    }
}
