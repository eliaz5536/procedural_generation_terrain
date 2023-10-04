using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LogoVideoPlayer : MonoBehaviour
{

    public float wait_time = 2f;
    public int loadScene;

    void Start()
    {
        StartCoroutine(WaitForVideoEnd());
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.anyKey)
        {
            SceneManager.LoadScene(loadScene);
        }
    }

    IEnumerator WaitForVideoEnd() {
        yield return new WaitForSeconds(wait_time);
        SceneManager.LoadScene(loadScene);
    }
}
