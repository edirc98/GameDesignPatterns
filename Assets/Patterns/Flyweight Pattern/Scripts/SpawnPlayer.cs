using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private GameObject playerGO;
    private bool playerSpawned = false;
    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlayerGO();
    }

    #region CUSTOM METHODS
    private void SpawnPlayerGO()
    {
        if (!playerSpawned)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 spawnPos = new Vector3(10, 5, 10);
                GameObject playerInstance = Instantiate(playerGO, spawnPos, Quaternion.identity);
                Camera.main.GetComponent<SmoothFollow>().target = playerInstance.transform;
            }
        }
        
    }
    #endregion
}
