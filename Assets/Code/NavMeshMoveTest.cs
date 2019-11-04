using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class NavMeshMoveTest : MonoBehaviour
{
    NavMeshAgent OurNavMeshAgent;
    private Vector3 CamOffset;
    public GameObject DestSphere;
    public bool ShowDestSphere = true;

    public Text DebugText;
    public NavMeshSurface Elevator;
    public NavMeshSurface[] Floors;
    Vector3 Dest;
    bool ResetPath = false;
    private void OnTriggerEnter(Collider other)
    {
        //return;
        foreach (NavMeshSurface floor in Floors) floor.enabled = false;
        foreach (NavMeshSurface floor in Floors) floor.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //return;
        Elevator.enabled = false;
        Elevator.enabled = true;
    }  

    
    // Start is called before the first frame update
    void Start()
    {
        OurNavMeshAgent = this.GetComponent<NavMeshAgent>();
        CamOffset = Camera.main.transform.position - this.transform.position;
    }
    
    // Update is called once per frame
    public void SetDestination(Vector3 dest)
    {
        OurNavMeshAgent.SetDestination(dest);
    }
    void Update()
    {
        if (DebugText != null)
        {
            DebugText.text = OurNavMeshAgent.navMeshOwner.name + "\n";
            DebugText.text += OurNavMeshAgent.destination.ToString("F4");

        }
        if (Input.GetMouseButton(0))
        {
            LayerMask mask = LayerMask.GetMask( "Floor", "Elevator");            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                Vector3 dest = hit.point;                
                SetDestination(dest);
                if(DestSphere != null )
                {
                    DestSphere.SetActive(ShowDestSphere);
                    if (ShowDestSphere == true)
                    {
                        DestSphere.transform.position = dest;
                    }
                }                
            }
        }
    }

    
}
