using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMoveTest : MonoBehaviour
{
    NavMeshAgent NavMeshAgent;
    private Vector3 CamOffset;
    public GameObject DestSphere;
    public bool ShowDestSphere = true;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent = this.GetComponent<NavMeshAgent>();
        CamOffset = Camera.main.transform.position - this.transform.position;
    }

    // Update is called once per frame
    public void SetDestination(Vector3 dest)
    {
        NavMeshAgent.SetDestination(dest);
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            LayerMask mask = LayerMask.GetMask("Floor");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                Vector3 dest = hit.point;                
                SetDestination(dest);
                DestSphere.SetActive(ShowDestSphere);
                if(ShowDestSphere == true )
                {
                    DestSphere.transform.position = dest;
                }
            }
        }
    }

    private void LateUpdate()
    {
        Camera.main.transform.position = this.transform.position + CamOffset;
    }
}
