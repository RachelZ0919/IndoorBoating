using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speedbar : MonoBehaviour
{
    //public Color[] colors = new Color[] { new Color(157, 216, 152), new Color(240, 208, 95), new Color(240, 139, 106) };
    public Color[] colors;
    Slider slider;
    Boat boat;

    private void Start()
    {
        colors = new Color[] { new Color(0.616f, 0.847f, 0.596f), new Color(0.941f, 0.816f, 0.373f), new Color(0.941f, 0.545f, 0.416f) };
        slider = GetComponent<Slider>();
        slider.fillRect.transform.GetComponent<Image>().color = colors[0];
        //boat = GameObject.Find("GameArea/Player/boat").GetComponent<Boat>();  设置船
    }

    // Update is called once per frame
    void Update()
    {   
        updateSpeedBar();
    }

    void updateSpeedBar()
    {
        //TODO:从船体Rigidbody获取velocity，根据值修改Speedbar显示

        //slider.value = Boat.velocity;    //更新船的速度到slider

        //更新speedbar显示
        float val = slider.value;
        val *= (colors.Length - 1);
        int startIndex = Mathf.FloorToInt(val);

        Color color = colors[0];

        if (startIndex >= 0)
        {
            if (startIndex + 1 < colors.Length)
            {
                float factor = val - startIndex;
                color = Color.Lerp(colors[startIndex], colors[startIndex + 1], factor);
            }
            else if (startIndex < colors.Length)
            {
                color = colors[startIndex];
            }
            else color = colors[colors.Length - 1];
        }

        color.a = slider.fillRect.transform.GetComponent<Image>().color.a;
        slider.fillRect.transform.GetComponent<Image>().color = color;
    }
}
