using UnityEngine;
using System.Collections.Generic;



[System.Serializable]
public class RaycastDebugVisual
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

    //Auto Delete Ray Afeter Time
    private float lifeTime = -1.0f;
    public float LifeTime { set { lifeTime = value; } }
    public bool RayExpired => lifeTime <= 0.0f && lifeTime != -1.0f;

    public void RayTick()
    {
        if(lifeTime != -1.0f) lifeTime -= Time.deltaTime;
    }

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
    #region VARIABLES
    [Header("Ray Visual Configuration")]
    public bool AutoDeleteAfterTime = false;
    [Range(1.0f,10.0f)]
    public float RayLifeTime;

    [Header("Ray Colors")]
    public Color BaseRayColor = new Color();

    [Header("Stored Raycasts")]
    private List<RaycastDebugVisual> raycastsDebugVisuals = new List<RaycastDebugVisual>();

    #endregion
    #region UNITY METHODS
    private void Update()
    {
        for (int i = raycastsDebugVisuals.Count - 1; i >= 0; i--)
        {
            
            raycastsDebugVisuals[i].RayTick();
            
            if (raycastsDebugVisuals[i].RayExpired)
            {
                raycastsDebugVisuals.RemoveAt(i);
                Debug.Log("Removed Ray");
            } 
        }
        
    }
    #endregion
    #region CUSTOM METHODS
    public void AddRaycastVisualDebug(Vector3 RayOrigin, Vector3 RayDir, float RayDistance, Vector3 HitNormal, Vector3 HitPoint)
    {
        RaycastDebugVisual raycastVisual = new RaycastDebugVisual(RayOrigin, RayDir, RayDistance, HitNormal, HitPoint);
        if (AutoDeleteAfterTime)
        {
            raycastVisual.LifeTime = RayLifeTime;
        }
        raycastsDebugVisuals.Add(raycastVisual);
    }

    public void AddRaycastVisualDebug(Vector3 RayOrigin, Vector3 RayDir, float RayDistance, float PenetrationDistance, Vector3 HitNormal, Vector3 HitPoint)
    {
        RaycastDebugVisual raycastVisual = new RaycastDebugVisual(RayOrigin, RayDir, RayDistance, PenetrationDistance, HitNormal, HitPoint);
        if (AutoDeleteAfterTime)
        {
            raycastVisual.LifeTime = RayLifeTime;
        }
        raycastsDebugVisuals.Add(raycastVisual);
    }

    public void ClearRaycastVisualDebugs()
    {
        raycastsDebugVisuals.Clear();
    }
    #endregion

    private void OnDrawGizmos()
    {
        foreach (RaycastDebugVisual raycastVisual in raycastsDebugVisuals)
        {
            raycastVisual.DarwRaycast();
        }

    }
}
