using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public GameObject cloudPrefab;
    public int cloudCount = 20;
    public Transform topRight;
    public Transform bottomLeft;
    public float cloudSpeed = 2f;
    public Color maxCloudDarkness = new Color(0.5f, 0.5f, 0.5f); // Dark greyish tone
    public float colorChangeSpeed = 0.01f; // How fast the color darkens

    private List<GameObject> clouds = new List<GameObject>();
    [SerializeField] List<CloudData> cloudData = new List<CloudData>();
    public float checkDuration = 1f;
    public float crtTime = 0.0f;
    void Start()
    {
        SpawnClouds();
    }

    public void check_moisture(CloudData cd)
    {
        if(crtTime >= 0.0f)
        {
            return;
        }else{
            cd.checkMoisture(checkDuration);    
            crtTime = checkDuration;
        }
    }
    void SpawnClouds()
    {
        for (int i = 0; i < cloudCount; i++)
        {
            Vector3 spawnPosition = GetRandomPosition();
            GameObject newCloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
            clouds.Add(newCloud);
            CloudData _cloudData = newCloud.GetComponent<CloudData>();
            _cloudData.cloudMaterial = newCloud.GetComponent<Renderer>().material; // Get cloud material
            _cloudData.moisture = Random.Range(0.0f, 1.0f);
            _cloudData.cloudMaterial.color = Color.Lerp(_cloudData.startColor, maxCloudDarkness, _cloudData.moisture);
            _cloudData.startColor = _cloudData.cloudMaterial.color; // Store initial color
            //StartCoroutine(ChangeCloudColor(cloudData, Random.Range(0.0f, 0.6f)));
            cloudData.Add(_cloudData);
            StartCoroutine(MoveCloudRandomly(newCloud));
        }
    }

    Vector3 GetRandomPosition()
    {
        float x = Random.Range(bottomLeft.position.x, topRight.position.x);
        float y = Random.Range(bottomLeft.position.y, topRight.position.y);
        float z = Random.Range(bottomLeft.position.z, topRight.position.z);
        return new Vector3(x, y, z);
    }

    IEnumerator ChangeCloudColor(CloudData cloud, float _t)
    {
        float t = _t; // Interpolation factor

        while (t < 1f)
        {
            cloud.GetComponent<SpriteRenderer>().color = Color.Lerp(cloud.startColor, maxCloudDarkness, t);
            Debug.Log(Color.Lerp(cloud.startColor, maxCloudDarkness, t));
            t += colorChangeSpeed * Time.deltaTime;

            yield return null;
        }
    }

    IEnumerator MoveCloudRandomly(GameObject cloud)
    {
        while (true)
        {
            Vector3 targetPosition = GetRandomPosition();

            while (Vector3.Distance(cloud.transform.position, targetPosition) > 0.1f)
            {
                cloud.transform.position = Vector3.MoveTowards(
                    cloud.transform.position,
                    targetPosition,
                    cloudSpeed * Time.deltaTime
                );
                yield return null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (topRight == null || bottomLeft == null) return;

        Gizmos.color = Color.cyan;
        Vector3 center = (topRight.position + bottomLeft.position) / 2;
        Vector3 size = new Vector3(
            Mathf.Abs(topRight.position.x - bottomLeft.position.x),
            Mathf.Abs(topRight.position.y - bottomLeft.position.y),
            Mathf.Abs(topRight.position.z - bottomLeft.position.z)
        );

        Gizmos.DrawWireCube(center, size);
    }
}
