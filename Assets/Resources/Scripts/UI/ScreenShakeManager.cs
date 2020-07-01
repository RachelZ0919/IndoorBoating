using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeManager : MonoBehaviour
{
    static public float shakeDegree = 3f;  //震动强度
    static public float shakeTime = 0.5f;  //震动时间
    public float shakeFPS = 45f;    //震动的FPS

    static public bool isShakeCamera = false;  //是否震动
    private float frameTime = 0.0f;
    private float shakeDelta = 0.005f;
    private Camera camera;

    private void Start()
    {
        camera = gameObject.GetComponent<Camera>();
    }

    private void Update()
    {
        if (isShakeCamera && shakeTime > 0)
        {
            Debug.Log("is shaking camera");
            shakeTime -= Time.deltaTime;
            if (shakeTime <= 0)
            {
                camera.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
                isShakeCamera = false;
            }                
            else
            {
                frameTime += Time.deltaTime;
                if(frameTime > 1.0 / shakeFPS)
                {
                    frameTime = 0;
                    camera.rect = new Rect(shakeDelta* (-1.0f + shakeDegree * Random.value), shakeDelta * (-1.0f + shakeDegree * Random.value), 1.0f, 1.0f);
                }
            }
        }
    }

    public void ScreenShake(float degree, float lastTime)
    {
        isShakeCamera = true;
        shakeDelta = degree;
        shakeTime = lastTime;
        frameTime = 0.03f;
        shakeDelta = 0.005f;
    }
}
