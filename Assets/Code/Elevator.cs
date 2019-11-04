using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Elevator : MonoBehaviour
{
    NavMeshSurface Surface;

    bool Moving = false;
    float LerpStartTime;
    float LerpDuration = 2f;
    Vector3 StartPos, EndPos;
    private void OnGUI()
    {
        if (Moving == true) return;

        if(GUI.Button(new Rect(0,0,100,100), "move"))
        {
            int dest;
            if (transform.position.y == 0) dest = -20;
            else dest = 0;
            Debug.Log("move to: " + dest);
            StartPos = transform.position;
            EndPos = new Vector3(transform.position.x, dest, transform.position.z);
            Moving = true;
            LerpStartTime = Time.time;
        }
        /*if (GUI.Button(new Rect(0, 100, 100, 100), "build"))
        {
            Surface.BuildNavMesh();
        }*/
    }

    private void FixedUpdate()
    {
        if(Moving == true )
        {
            float lerpTime = Time.time - LerpStartTime;
            float lerpPercentage = lerpTime / LerpDuration;
            transform.position = Vector3.Lerp(StartPos, EndPos, lerpPercentage);
            if(lerpPercentage >= 1f)
            {
                transform.position = EndPos;
                Moving = false;
            }
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Surface = GetComponent<NavMeshSurface>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
