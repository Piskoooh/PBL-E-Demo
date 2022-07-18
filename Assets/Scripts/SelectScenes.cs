using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScenes : MonoBehaviour
{
    [SerializeField]
    private int SceneIndex;
    [SerializeField]
    private SceneNavigator m_sceneNavigator;
    public SceneNavigator SceneNavigator
    {
        set
        {
            m_sceneNavigator = value;
        }
        get
        {
            return m_sceneNavigator;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SceneNavigator = GameObject.Find("SceneNavigator").GetComponent<SceneNavigator>();
        SceneIndex = m_sceneNavigator.SceneIndex;
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
        m_sceneNavigator.SceneIndex = SceneIndex;
        SceneManager.LoadScene(SceneIndex);
    }

    public void pressBtnBackward()
    {
        SceneIndex -= 1;
        m_sceneNavigator.SceneIndex = SceneIndex;
        SceneManager.LoadScene(SceneIndex);
    }
    public void pressBtnReset()
    {
        SceneIndex = 0;
        m_sceneNavigator.SceneIndex = SceneIndex;
        SceneManager.LoadScene(SceneIndex);
    }
}
