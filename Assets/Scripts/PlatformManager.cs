using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager Instance = null;

    [SerializeField]
    GameObject FallingPlatform;

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
        Instantiate(FallingPlatform, new Vector2(3.716f,-1.97f), FallingPlatform.transform.rotation);
        Instantiate(FallingPlatform, new Vector2(-0.534f, 0.25f), FallingPlatform.transform.rotation);
    }

  IEnumerator SpawnPlatform(Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(2f);
        Instantiate(FallingPlatform, spawnPosition, FallingPlatform.transform.rotation);
    }
}
