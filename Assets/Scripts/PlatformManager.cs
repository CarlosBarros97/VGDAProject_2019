using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance = null;

    [SerializeField]
    GameObject FallingPlatform;

    [SerializeField]
    private float distanceX;
    [SerializeField]
    private float distanceY;

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
    }

  IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(FallingPlatform, spawnPosition, FallingPlatform.transform.rotation);
    }
}
