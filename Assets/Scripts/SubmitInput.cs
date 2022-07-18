using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubmitInput : MonoBehaviour
{
    //X0：温度、X1：湿度、X2：降水量、X3：日照時間、X4：土壌水分量、X5：土壌温度、X6：定数部、X7：農地面積
    public TMP_InputField inputField0;
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public TMP_InputField inputField3;
    public TMP_InputField inputField4;
    public TMP_InputField inputField5;

    public TMP_InputField inputField7;

    public int SceneIndex;

    [SerializeField]
    private SceneNavigator m_sceneNavigator;
    public SceneNavigator SceneNavigator
    {
        set
        {
        m_sceneNavigator = value;
        }
    }

    [SerializeField]
    private double[] inputs;
   


    // Start is called before the first frame update
    void Start()
    {
        SceneNavigator = GameObject.Find("SceneNavigator").GetComponent<SceneNavigator>();
        SceneIndex = SceneNavigator.SceneIndex;
        inputs = m_sceneNavigator.Inputs;

        //if (m_sceneNavigator.Inputs == null)
        //{
        //    m_sceneNavigator.Inputs = new double[8];
        //    Debug.Log("create input");
        //}

        if (SceneIndex == 1)
        {
            inputField0 = inputField0.GetComponent<TMP_InputField>();
            inputField0.text = inputs[0].ToString();
            inputField1 = inputField1.GetComponent<TMP_InputField>();
            inputField1.text = inputs[1].ToString();
            inputField2 = inputField2.GetComponent<TMP_InputField>();
            inputField2.text = inputs[2].ToString();
            inputField3 = inputField3.GetComponent<TMP_InputField>();
            inputField3.text = inputs[3].ToString();
            inputField4 = inputField4.GetComponent<TMP_InputField>();
            inputField4.text = inputs[4].ToString();
            inputField5 = inputField5.GetComponent<TMP_InputField>();
            inputField5.text = inputs[5].ToString();
        }

        if (SceneIndex == 2)
        {
            inputField7 = inputField7.GetComponent<TMP_InputField>();
            inputField7.text = inputs[7].ToString();
        }
    }

    public void InputKion()
    {
        inputs[0] = double.Parse(inputField0.text);
    }
    public void InputSitudo()
    {
        inputs[1] = double.Parse(inputField1.text);
    }
    public void InputKousuiryo()
    {
        inputs[2] = double.Parse(inputField2.text);
    }
    public void InputNissyojikan()
    {
        inputs[3] = double.Parse(inputField3.text);
    }
    public void InputDojoSuibun()
    {
        inputs[4] = double.Parse(inputField4.text);
    }
    public void InputDojoOndo()
    {
        inputs[5] = double.Parse(inputField5.text);
    }

    public void Submit1()
    {
        inputs[6] = 1d;
    }

    public void InputNouti()
    {
        inputs[7] = double.Parse(inputField7.text);
    }

}
