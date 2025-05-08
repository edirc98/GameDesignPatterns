using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    public float rayDistance = 50.0f;

    public int maxPenetration = 2;
    public float maxPenetrationDistance = 1.4f;

    public Vector3 rayOrigin;
    public Vector3 rayDir;
    
    public LayerMask layerMask;
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        rayDir = transform.forward;
        if (Input.GetMouseButtonDown(0))
        {
            CastRay(transform.position,rayDir,rayDistance);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            CastRayWithPenetration(transform.position, rayDir, rayDistance, maxPenetrationDistance, 0);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            RaycastDebugger.Instance.ClearRaycastVisualDebugs();
        }
    }

    private void CastRay(Vector3 Origin, Vector3 Direction, float MaxDistacnce)
    {
        if (Physics.Raycast(Origin,Direction, out RaycastHit hit, MaxDistacnce,layerMask)){

            RaycastDebugger.Instance.AddRaycastVisualDebug(Origin, Direction, hit.distance, hit.normal, hit.point);
            Debug.Log("Hit with:" + hit.transform.name);
        }

    }

    private void CastRayWithPenetration(Vector3 Origin, Vector3 Direction,float MaxDistacnce, float PenetrationDistance, int CurrentPenetrated)
    {
        //Base ray
        if (Physics.Raycast(Origin, Direction, out RaycastHit hit, MaxDistacnce, layerMask))
        {
            RaycastDebugger.Instance.AddRaycastVisualDebug(Origin, Direction, hit.distance, PenetrationDistance, hit.normal, hit.point);
            CurrentPenetrated++;
            Debug.Log("Hit with:" + hit.transform.name + " Penetrations: " + CurrentPenetrated);

            if(CurrentPenetrated <= maxPenetration)
            {
                //From final point after penetration raycast backwards to see if the penetration is completed
                Vector3 backOrigin = hit.point + Direction * PenetrationDistance;
                if (Physics.Raycast(backOrigin, -Direction, out RaycastHit backHit, PenetrationDistance, layerMask))
                {
                    RaycastDebugger.Instance.AddRaycastVisualDebug(backOrigin, -Direction, backHit.distance, backHit.normal, backHit.point);
                    CastRayWithPenetration(backOrigin, Direction, MaxDistacnce, PenetrationDistance, CurrentPenetrated);
                }
            }
        }
    }
}
