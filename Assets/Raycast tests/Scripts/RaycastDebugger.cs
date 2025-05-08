using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;


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


    public void DrawRaycast()
    {
        //MAIN RAY
        Gizmos.color = baseRayColor;
        Gizmos.DrawRay(rayOrigin, hitDir * hitDistance);

        //PENETRATION RAY
        Gizmos.color = penetrationRayColor;
        Gizmos.DrawRay(hitPoint, hitDir * hitPenetrationDistance);

        //HIT POINT SPHERE
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
    public bool autoDeleteAfterTime = false;
    [Range(1.0f,10.0f)]
    public float rayLifeTime;

    [FormerlySerializedAs("BaseRayColor")] [Header("Ray Colors")]
    public Color baseRayColor = Color.yellow;
    public Color penetrationRayColor = Color.magenta;
    public Color hitPointColor = Color.red;
    public Color hitNormalColor = Color.blue;

    [Header("Stored Raycasts")]
    private readonly List<RaycastDebugVisual> raycastsDebugVisuals = new List<RaycastDebugVisual>();

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
        raycastVisual.SetRayVisualColors(baseRayColor, penetrationRayColor, hitPointColor, hitNormalColor);
        if (autoDeleteAfterTime)
        {
            raycastVisual.LifeTime = rayLifeTime;
        }
        raycastsDebugVisuals.Add(raycastVisual);
    }

    public void AddRaycastVisualDebug(Vector3 RayOrigin, Vector3 RayDir, float RayDistance, float PenetrationDistance, Vector3 HitNormal, Vector3 HitPoint)
    {
        RaycastDebugVisual raycastVisual = new RaycastDebugVisual(RayOrigin, RayDir, RayDistance, PenetrationDistance, HitNormal, HitPoint);
        raycastVisual.SetRayVisualColors(baseRayColor, penetrationRayColor, hitPointColor, hitNormalColor);
        if (autoDeleteAfterTime)
        {
            raycastVisual.LifeTime = rayLifeTime;
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
            raycastVisual.DrawRaycast();
        }

    }
}
