using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastTest : MonoBehaviour
{
    public float RayDistance = 50.0f;

    public int MaxPenetration = 2;
    public float maxPenetrationDistance = 1.4f;

    public Vector3 rayOrigin;
    public Vector3 rayDir;



    public LayerMask layerMask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rayDir = transform.forward;
        if (Input.GetMouseButtonDown(0))
        {
            CastRay(transform.position,rayDir,RayDistance);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            CastRayWithPenetration(transform.position, rayDir, RayDistance, maxPenetrationDistance, 0);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            RaycastDebugger.Instance.ClearRaycastVisualDebugs();
        }
    }

    private void CastRay(Vector3 Origin, Vector3 Direction, float MaxDistacnce)
    {
        RaycastHit hit;
        if (Physics.Raycast(Origin,Direction, out hit, MaxDistacnce,layerMask)){

            RaycastDebugger.Instance.AddRaycastVisualDebug(Origin, Direction, hit.distance, hit.normal, hit.point);
            Debug.Log("Hit with:" + hit.transform.name);
        }

    }

    private void CastRayWithPenetration(Vector3 Origin, Vector3 Direction,float MaxDistacnce, float PenetrationDistance, int CurrentPenetrated)
    {
        //Base ray
        RaycastHit hit;
        if (Physics.Raycast(Origin, Direction, out hit, MaxDistacnce, layerMask))
        {
            RaycastDebugger.Instance.AddRaycastVisualDebug(Origin, Direction, hit.distance, PenetrationDistance, hit.normal, hit.point);
            CurrentPenetrated++;
            Debug.Log("Hit with:" + hit.transform.name + " Penetrations: " + CurrentPenetrated);

            if(CurrentPenetrated <= MaxPenetration)
            {
                //From final point after penetration raycast backguards to see if the penetration is completed
                RaycastHit backHit;
                Vector3 backOrigin = hit.point + Direction * PenetrationDistance;
                if (Physics.Raycast(backOrigin, -Direction, out backHit, PenetrationDistance, layerMask))
                {
                    RaycastDebugger.Instance.AddRaycastVisualDebug(backOrigin, -Direction, backHit.distance, backHit.normal, backHit.point);
                    CastRayWithPenetration(backOrigin, Direction, MaxDistacnce, PenetrationDistance, CurrentPenetrated);
                }
            }
        }
    }

    
}
