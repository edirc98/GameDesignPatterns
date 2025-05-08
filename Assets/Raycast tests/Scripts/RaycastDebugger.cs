using UnityEngine;
using System.Collections.Generic;



[System.Serializable]
public struct RaycastDebugVisual
{
    public RaycastDebugVisual(Vector3 RayOrigin, Vector3 RayDir, float RayDistance, Vector3 HitNormal, Vector3 HitPoint)
    {
        rayOrigin = RayOrigin;
        hitDir = RayDir;
        hitNormal = HitNormal;
        hitPoint = HitPoint;
        hitDistance = RayDistance;
        hitPenetrationDistance = 0;
    }
    public RaycastDebugVisual(Vector3 RayOrigin, Vector3 RayDir, float RayDistance, float PenetrationDistance, Vector3 HitNormal, Vector3 HitPoint)
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


    public void DarwRaycast()
    {
        //MAIN RAY
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(rayOrigin, hitDir * hitDistance);
        //PENETRATION RAY
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(hitPoint, hitDir * hitPenetrationDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(hitPoint, 0.1f);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(hitPoint, hitNormal);
    }
}
public class RaycastDebugger : Singleton<RaycastDebugger>
{
    [Header("Stored Raycasts")]
    private List<RaycastDebugVisual> raycastsDebugVisuals = new List<RaycastDebugVisual>();


    public void AddRaycastVisualDebug(Vector3 RayOrigin, Vector3 RayDir, float RayDistance, Vector3 HitNormal, Vector3 HitPoint)
    {
        RaycastDebugVisual raycastVisual = new RaycastDebugVisual(RayOrigin, RayDir, RayDistance, HitNormal, HitPoint);
        raycastsDebugVisuals.Add(raycastVisual);
    }

    public void AddRaycastVisualDebug(Vector3 RayOrigin, Vector3 RayDir, float RayDistance, float PenetrationDistance, Vector3 HitNormal, Vector3 HitPoint)
    {
        RaycastDebugVisual raycastVisual = new RaycastDebugVisual(RayOrigin, RayDir, RayDistance, PenetrationDistance, HitNormal, HitPoint);
        raycastsDebugVisuals.Add(raycastVisual);
    }

    private void OnDrawGizmos()
    {
        foreach (RaycastDebugVisual raycastVisual in raycastsDebugVisuals)
        {
            raycastVisual.DarwRaycast();
        }

    }
}
