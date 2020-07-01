using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class FloatPhysic : MonoBehaviour
{
    private Rigidbody rigidbody;
    private BoxCollider collider;
    private Vector3[] boxPoints = new Vector3[8];
    List<Vector3> underWaterPoints = new List<Vector3>();
    List<Vector3> interPoints = new List<Vector3>();
    private float waterHeight = 0;
    Vector3 forcePoint = Vector3.zero;
    Vector3 center;
    Vector3 size;
    float width;
    Vector3 waveNormal;

    public float density;
    private float volume;

    public Wave wave;

    List<Vector3> test = new List<Vector3>();

    public float viscosity = 0.05f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<BoxCollider>();
        center = collider.center;
        size = collider.size;
        Vector3 ssize = Vector3.Scale(size, transform.localScale);
        width = Mathf.Max(Mathf.Max(ssize.x, ssize.y), ssize.z);
        volume = ssize.x * ssize.y * ssize.z;
        //Debug.Log(volume);

        for (float i = -0.5f, index = 0;i <= 0.5f; i += 1)
        {
            for (float j = -0.5f; j <= 0.5f; j += 1)
            {
                for (float k = -0.5f; k <= 0.5f; k += 1, index++) 
                {
                    boxPoints[(int)index] = center + Vector3.Scale(new Vector3(i, j, k), size);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        test.Clear();
        waterHeight = wave.GetWaterHeight(transform.position, ref waveNormal);
        if (transform.position.y < waterHeight) {
            //浮力设置
            Vector3 force = GetBuoyancyForce();//获得浮力大小，理论上和排水量有关
            forcePoint = GetForcePoint();//获得浮点的世界坐标

            rigidbody.AddForceAtPosition(force, forcePoint);

            //阻力设置
            Vector3 dragForce = rigidbody.velocity * -1 * viscosity;
            rigidbody.AddForce(dragForce);
            
            Vector3 velocityDirection = Vector3.Normalize(rigidbody.velocity);

            Vector3 v1 = Vector3.Cross(velocityDirection, Vector3.up);
            if(v1 == Vector3.zero)
            {
                v1 = Vector3.Cross(velocityDirection, Vector3.forward);
            }
            Vector3 v2 = Vector3.Cross(velocityDirection, v1);

            Vector3 pointOutFront = transform.position + (velocityDirection * 10);

            for (float x = -width; x <= width; x += 1f)
            {
                for (float y = -width; y <= width; y += 1f)
                {
                    Vector3 start = pointOutFront + (v1 * x) + (v2 * y);
                    
                    RaycastHit hit;
                    if (Physics.Raycast(start, -velocityDirection, out hit, 10))
                    {
                        if(hit.point.y < waterHeight)
                        {
                            rigidbody.AddForce(dragForce);
                            test.Add(hit.point);
                        }  
                    }
                }
            }

            Debug.Log(interPoints.Count);

        }
    }

    Vector3 GetBuoyancyForce()
    {
        float interFaceArea, objectVolume = 0;
        if(interPoints.Count < 3)
        {
            
        }

        return Vector3.up * 10;
    }

    Vector3 GetForcePoint()
    {
        underWaterPoints.Clear();
        interPoints.Clear();
        Vector3 center = Vector3.zero;
        float pointCount = 0;
        for(int i = 0; i < 8; i++)
        {
            Vector3 boxPoint = transform.TransformPoint(boxPoints[i]);
            if (boxPoint.y < waterHeight)
            {
                underWaterPoints.Add(boxPoint);
                Vector3 v = Vector3.Scale(boxPoints[i], new Vector3(1 / size.x, 1 / size.y, 1 / size.z)) * (-2);
                Vector3 interp;
                if (Intersect(waveNormal, boxPoint, transform.TransformPoint(boxPoints[i] + new Vector3(v.x, 0, 0)), out interp))
                {
                    interPoints.Add(interp);
                }
                if (Intersect(waveNormal, boxPoint, transform.TransformPoint(boxPoints[i] + new Vector3(0, v.y, 0)), out interp))
                {
                    interPoints.Add(interp);
                }
                if (Intersect(waveNormal, boxPoint, transform.TransformPoint(boxPoints[i] + new Vector3(0, 0, v.z)), out interp)) 
                {
                    interPoints.Add(interp);
                }
            }
        }

        foreach(Vector3 up in underWaterPoints)
        {
            pointCount++;
            center += up;
        }
        foreach (Vector3 up in interPoints)
        {
            pointCount++;
            center += up;
        }
        if (pointCount > 0)
        {
            center /= pointCount;
        }
        return center;
    }


    private void OnDrawGizmos()
    {
        foreach (Vector3 p in underWaterPoints)
        {
            Gizmos.DrawSphere(p, 0.05f);
        }
        Gizmos.DrawLine(transform.position, transform.position + waveNormal * 5);
        //foreach (Vector3 p in test)
        //{
        //    Gizmos.DrawSphere(p, 0.05f);
        //}
        //Gizmos.DrawSphere(forcePoint, 0.05f);
        //Vector3 po = transform.position;
        //po.y = waterHeight;
        //Gizmos.DrawSphere(po, 0.05f);
    }

    bool Intersect(Vector3 faceNormal, Vector3 p1, Vector3 p2, out Vector3 p)
    {
        float d = Vector3.Dot(-p1, faceNormal) / Vector3.Dot((p2 - p1), faceNormal);
        //p = p2;
        p = d * (p2 - p1) + p1;
        if(d > 0 && d < 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
