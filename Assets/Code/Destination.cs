using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public NPCMove Player;
    public GameObject DestSphere;

    private Vector3 CamOffset;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Floor");
       // foreach (GameObject o in objs) o.GetComponent<MeshRenderer>().enabled = false;
        objs = GameObject.FindGameObjectsWithTag("Wall");
      //  foreach (GameObject o in objs) o.GetComponent<MeshRenderer>().enabled = false;

        CamOffset = Camera.main.transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            LayerMask mask = LayerMask.GetMask("Floor");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {                
                Vector3 dest = hit.point;                                
                DestSphere.transform.position = dest;
                Player.SetDestination(dest);
            }
        }
    }

    private void LateUpdate()
    {
        Camera.main.transform.position = Player.transform.position + CamOffset;
    }
}
