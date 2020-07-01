using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapViewer : MonoBehaviour {

    private Camera mapCamera;
    private Transform player;
    private Vector3 offsetPos;

    void Start () {
        mapCamera = GameObject.FindGameObjectWithTag("MapCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offsetPos = mapCamera.transform.position - player.position;
    }
	
	void Update () {
        UpdateMap();
	}

	private void UpdateMap()
	{
        //更新地图信息
        mapCamera.transform.position = offsetPos + player.position;
    }
}
