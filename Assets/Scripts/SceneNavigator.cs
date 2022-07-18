using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneNavigator : MonoBehaviour
{
    public static int SceneIndex;

    [SerializeField]
    private double[] inputs;
    public double[] Inputs
    {
        get
        {
            return inputs;
        }

        set
        {
            inputs = value;
        }
    }

    [SerializeField]
    private double[] reccomends;
    public double[] Reccomends
    {
        get
        {
            return reccomends;
        }

        set
        {
            reccomends = value;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        SceneIndex = 0;
//        inputs = new double[8];
    }

    private void Update()
    {
        if (SceneIndex == 0)
        {
            SceneManager.sceneLoaded += ResetInput;
        }

    }

    private void ResetInput(Scene scene,LoadSceneMode loadSceneMode)
    {
        inputs = new double[8];
        reccomends = new double[9];
        SceneManager.sceneLoaded -= ResetInput;
    }
    //private void OnLevelWasLoaded(int level)
    //{
    //    if(SceneIndex==1||SceneIndex==2)m_submitInput = GetComponent<SubmitInput>();
    //}
}
