using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance = null;

    [SerializeField]
    GameObject FallingPlatform;

    [SerializeField]
    public float distanceX = -5f;
    [SerializeField]
    public float distanceY = .25f;
    [SerializeField]
    public float distanceX2 = -1f;
    [SerializeField]
    public float distanceY2 = .50f;

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
        Instantiate(FallingPlatform, new Vector2(distanceX,distanceY), FallingPlatform.transform.rotation);
        Instantiate(FallingPlatform, new Vector2(distanceX2, distanceY2), FallingPlatform.transform.rotation);
    }

  IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(FallingPlatform, spawnPosition, FallingPlatform.transform.rotation);
    }
}
