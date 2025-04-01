using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    #region VARIABLES
    //[Header("Asteroid Prefab")]
    //public GameObject asteroidPrefab; 

    [Header("Spawner Settings")]
    public float spawnRate = 1.0f;

    private float _elapsedTime = 0.0f;
    #endregion

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= spawnRate)
        {
            float randomDeviation = Random.Range(-11.0f, 11.0f);
            //Manual INSTANCING
            //Vector3 asteroidPos = new Vector3(transform.position.x + randomDeviation, transform.position.y, transform.position.z);
            //Instantiate(asteroidPrefab, asteroidPos, Quaternion.identity, transform);

            //GETING OBJECT FROM THE POOL
            GameObject asteroid =  ObjectPool.Instance.GetPooledObject();
            if(asteroid != null)
            {
                asteroid.transform.position = new Vector3(transform.position.x + randomDeviation, transform.position.y, transform.position.z);
                asteroid.SetActive(true);
            }

            _elapsedTime = 0.0f;
        }
        
    }
}
