using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance = null;

    [SerializeField]
    GameObject FallingPlatform;

    public float distanceX1 = -5f;
    public float distanceY1 = 0.25f;
    public float distanceX2 = -5f;
    public float distanceY2 = 0.25f;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(FallingPlatform, new Vector2(distanceX1, distanceY1), FallingPlatform.transform.rotation);
        Instantiate(FallingPlatform, new Vector2(distanceX2, distanceY2), FallingPlatform.transform.rotation);
    }

  IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(FallingPlatform, spawnPosition, FallingPlatform.transform.rotation);
    }
}
