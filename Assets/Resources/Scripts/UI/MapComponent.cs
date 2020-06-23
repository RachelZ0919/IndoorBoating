using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MapComponent : MonoBehaviour
{
    public GameObject icon;
    // Start is called before the first frame update
    void Start()
    {
        InitializeIcon();
    }

    private void InitializeIcon()
    {
        
    }
}
