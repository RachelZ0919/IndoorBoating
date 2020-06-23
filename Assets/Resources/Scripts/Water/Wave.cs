using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public Vector4 waveA;
    public Vector4 waveB;

    public float GetWaterHeight(Vector3 pos, ref Vector3 normal)
    {
        float ret = transform.position.y;
        Vector3 tangent = new Vector3(1, 0, 0);
        Vector3 binormal = new Vector3(0, 0, 1);
        ret += GersterWave(waveA, transform.InverseTransformPoint(pos), ref tangent, ref binormal);
        ret += GersterWave(waveB, transform.InverseTransformPoint(pos), ref tangent, ref binormal);
        normal = - Vector3.Normalize(Vector3.Cross(tangent, binormal));
        return ret;
    }

    private float GersterWave(Vector4 wave, Vector3 p, ref Vector3 tangent,ref Vector3 binormal)
    {
        float steepness = wave.z;
        float wavelength = wave.w;

        float k = 2 * Mathf.PI / wavelength;
        float c = Mathf.Sqrt(9.8f / k);
        Vector2 d = new Vector2(wave.x, wave.y);
        float f = k * (Vector2.Dot(d.normalized, new Vector2(p.x, p.z)) - c * Time.timeSinceLevelLoad);
        float a = steepness / k;

        tangent += new Vector3(
            -d.x * d.x * (steepness * Mathf.Sin(f)),
            d.x * (steepness * Mathf.Cos(f)),
            -d.x * d.y * (steepness * Mathf.Sin(f))
        );

        binormal += new Vector3(
            -d.x * d.y * (steepness * Mathf.Sin(f)),
            d.y * (steepness * Mathf.Cos(f)),
            -d.y * d.y * (steepness * Mathf.Sin(f))
        );

        return a * Mathf.Sin(f);
    }

    private void Update()
    {
        GetComponent<MeshRenderer>().material.SetFloat("_Time0", Time.timeSinceLevelLoad);
    }

    private void Start()
    {
        GetComponent<MeshRenderer>().material.SetVector("_WaveA", waveA);
        GetComponent<MeshRenderer>().material.SetVector("_WaveB", waveB);
    }
}
