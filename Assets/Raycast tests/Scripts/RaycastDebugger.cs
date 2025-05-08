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

    //Ray Colors
    private Color baseRayColor = Color.yellow;
    private Color penetrationRayColor = Color.magenta;
    private Color hitPointColor = Color.red;
    private Color hitNormalColor = Color.blue;


    #region CUSTOM METHODS
    public void RayTick()
    {
        if (lifeTime != -1.0f) lifeTime -= Time.deltaTime;
    }

    public void SetRayVisualColors(Color BaseColor, Color PenetrationColor, Color HitPointColor, Color HitNormalColor)
    {
        baseRayColor = BaseColor;
        penetrationRayColor = PenetrationColor;
        hitPointColor = HitPointColor;
        hitNormalColor = HitNormalColor;
    }


    public void DarwRaycast()
    {
        //MAIN RAY
        Gizmos.color = baseRayColor;
        Gizmos.DrawRay(rayOrigin, hitDir * hitDistance);

        //PENETRATION RAY
        Gizmos.color = penetrationRayColor;
        Gizmos.DrawRay(hitPoint, hitDir * hitPenetrationDistance);

        //HIT POINT SPEHERE
        Gizmos.color = hitPointColor;
        Gizmos.DrawSphere(hitPoint, 0.1f);

        //HIT NORMAL RAY
        Gizmos.color = hitNormalColor;
        Gizmos.DrawRay(hitPoint, hitNormal);
    }
    #endregion
}
public class RaycastDebugger : Singleton<RaycastDebugger>
{
    #region VARIABLES
    [Header("Ray Visual Configuration")]
    public bool AutoDeleteAfterTime = false;
    [Range(1.0f,10.0f)]
    public float RayLifeTime;

    [Header("Ray Colors")]
    public Color BaseRayColor = Color.yellow;
    public Color PenetrationRayColor = Color.magenta;
    public Color HitPointColor = Color.red;
    public Color HitNormalColor = Color.blue;

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
        raycastVisual.SetRayVisualColors(BaseRayColor, PenetrationRayColor, HitPointColor, HitNormalColor);
        if (AutoDeleteAfterTime)
        {
            raycastVisual.LifeTime = RayLifeTime;
        }
        raycastsDebugVisuals.Add(raycastVisual);
    }

    public void AddRaycastVisualDebug(Vector3 RayOrigin, Vector3 RayDir, float RayDistance, float PenetrationDistance, Vector3 HitNormal, Vector3 HitPoint)
    {
        RaycastDebugVisual raycastVisual = new RaycastDebugVisual(RayOrigin, RayDir, RayDistance, PenetrationDistance, HitNormal, HitPoint);
        raycastVisual.SetRayVisualColors(BaseRayColor, PenetrationRayColor, HitPointColor, HitNormalColor);
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
