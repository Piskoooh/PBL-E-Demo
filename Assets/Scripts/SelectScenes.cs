using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScenes : MonoBehaviour
{
    [SerializeField]
    private int SceneIndex;


    public 

    // Start is called before the first frame update
    void Start()
    {
        SceneIndex =SceneNavigator.SceneIndex;
    //    SceneManager.LoadScene(SceneIndex);
    }

    private void Update()
    {
        if (Input.anyKeyDown & SceneIndex == 0)
        {
            pressBtnForward();
        }
    }
    public void pressBtnForward()
    {
        SceneIndex += 1;
        SceneNavigator.SceneIndex = SceneIndex;
        SceneManager.LoadScene(SceneIndex);
    }

    public void pressBtnBackward()
    {
        SceneIndex -= 1;
        SceneNavigator.SceneIndex = SceneIndex;
        SceneManager.LoadScene(SceneIndex);
    }
    public void pressBtnReset()
    {
        SceneIndex = 0;
        SceneNavigator.SceneIndex = SceneIndex;
        SceneManager.LoadScene(SceneIndex);
    }
}
