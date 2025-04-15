using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public struct RayHitDebugInfo
{
    public RayHitDebugInfo(Vector3 RayOrigin, Vector3 RayDir, float RayDistance, Vector3 HitNormal, Vector3 HitPoint)
    {
        rayOrigin = RayOrigin;
        hitDir = RayDir;
        hitNormal = HitNormal;
        hitPoint = HitPoint;
        hitDistance = RayDistance;
        hitPenetrationDistance = 0;
    }
    public RayHitDebugInfo(Vector3 RayOrigin ,Vector3 RayDir,float RayDistance,float PenetrationDistance,Vector3 HitNormal, Vector3 HitPoint)
    {
        rayOrigin = RayOrigin;
        hitDir = RayDir;
        hitNormal = HitNormal;
        hitPoint = HitPoint;
        hitDistance = RayDistance;
        hitPenetrationDistance = PenetrationDistance;
    }
    

    private Vector3 rayOrigin;
    private Vector3 hitDir;
    private Vector3 hitNormal;
    private Vector3 hitPoint;
    private float hitDistance;
    private float hitPenetrationDistance;

    private Vector3 RayOrigin { get { return rayOrigin; } }
    private Vector3 HitDirection { get { return hitDir; } }
    private Vector3 HitNormal { get { return hitNormal; } }
    private Vector3 HitPoint { get { return hitPoint; } }
    private float HitDistance{ get { return hitDistance; } }
    private float HitPenetrationDistance{ get { return hitPenetrationDistance; } }
    
    public void DrawDebug()
    {
        //MAIN RAY
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(RayOrigin, HitDirection * HitDistance);
        //PENETRATION RAY
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(HitPoint, HitDirection * HitPenetrationDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(HitPoint, 0.1f);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(HitPoint, HitNormal);
    }
}
public class RaycastTest : MonoBehaviour
{
    public float RayDistance = 50.0f;

    public int MaxPenetration = 2;
    public float maxPenetrationDistance = 1.4f;

    public Vector3 rayOrigin;
    public Vector3 rayDir;

    private List<RayHitDebugInfo> hitsDebug = new List<RayHitDebugInfo>();


    public LayerMask layerMask;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rayOrigin = transform.position;
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rayDir = transform.forward;
        if (Input.GetMouseButtonDown(0))
        {
            CastRay(rayOrigin,rayDir,RayDistance);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            CastRayWithPenetration(rayOrigin, rayDir, RayDistance, maxPenetrationDistance, 0);
        }
    }

    private void CastRay(Vector3 Origin, Vector3 Direction, float MaxDistacnce)
    {
        RaycastHit hit;
        if (Physics.Raycast(Origin,Direction, out hit, MaxDistacnce,layerMask)){

            RayHitDebugInfo hitdeubg = new RayHitDebugInfo(Origin,Direction,hit.distance,hit.normal, hit.point);
            hitsDebug.Add(hitdeubg);
            Debug.Log("Hit with:" + hit.transform.name);
        }

    }

    private void CastRayWithPenetration(Vector3 Origin, Vector3 Direction,float MaxDistacnce, float PenetrationDistance, int CurrentPenetrated)
    {
        //Base ray
        RaycastHit hit;
        if (Physics.Raycast(Origin, Direction, out hit, MaxDistacnce, layerMask))
        {
            RayHitDebugInfo HitDebug = new RayHitDebugInfo(Origin, Direction, hit.distance, PenetrationDistance, hit.normal, hit.point);
            hitsDebug.Add(HitDebug);
            CurrentPenetrated++;
            Debug.Log("Hit with:" + hit.transform.name + " Penetrations: " + CurrentPenetrated);

            if(CurrentPenetrated <= MaxPenetration)
            {
                //From final point after penetration raycast backguards to see if the penetration is completed
                RaycastHit backHit;
                Vector3 backOrigin = hit.point + Direction * PenetrationDistance;
                if (Physics.Raycast(backOrigin, -Direction, out backHit, MaxDistacnce, layerMask))
                {
                    RayHitDebugInfo BackHitDeubg = new RayHitDebugInfo(backOrigin, -Direction, backHit.distance, backHit.normal, backHit.point);
                    hitsDebug.Add(BackHitDeubg);

                    CastRayWithPenetration(backOrigin, Direction, MaxDistacnce, PenetrationDistance, CurrentPenetrated);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        foreach(RayHitDebugInfo hitdebug in hitsDebug)
        {
            hitdebug.DrawDebug();
        }
        
    }
}
