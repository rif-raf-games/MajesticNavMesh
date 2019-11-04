using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshTrigger : MonoBehaviour
{
    public NavMeshSurface Elevator;
    public NavMeshSurface Floor;
    public NavMeshAgent Player;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter() other: " + other.name);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
