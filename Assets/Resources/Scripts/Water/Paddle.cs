using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		UpdateShader();	
	}

	private void UpdateShader()
	{
		//TODO:通过修改Shader参数，更新水花出现位置，也可能不用Shader实现，仍需要调研
	}
}
