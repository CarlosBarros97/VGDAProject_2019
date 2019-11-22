using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelonTouch : MonoBehaviour
{
    string CurrentScene;
    Scene Tscene;
    // Start is called before the first frame update
    void Start()
    {
        Tscene = SceneManager.GetActiveScene();
        CurrentScene = Tscene.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && CurrentScene == "Level1")
        {
            SceneManager.LoadScene("Level3");
        }
        //if (col.gameObject.tag == "Player" && CurrentScene == "Level2")
        //{
        //    SceneManager.LoadScene("Level3");
       // }
        if (col.gameObject.tag == "Player" && CurrentScene == "Level3")
        {
            SceneManager.LoadScene("LevelEnd");
        }
    }
}
