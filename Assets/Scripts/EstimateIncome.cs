using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EstimateIncome : MonoBehaviour
{
    public double protainPrice = 0.43d;
    double[] income;

    //品種別単位面積あたりたんぱく質量と品種の関係辞書
    private Dictionary<int, string> proteinDic = new Dictionary<int, string>()
    {
        {1383,"エンレイ"},
        {1309,"コトユタカ"},
        {1548,"フクユタカ"},
        {1439,"ユキホマレ"},
        {1278,"くろこじろう"},
        {1926,"こがねさやか"},
        {1738,"サチユタカ"},
        {707,"シュウレイ"},
        {1479,"すずかれん"},
    };

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
    [SerializeField]
    private double[] reccomends;

    public TMP_InputField resultField;
    // Start is called before the first frame update
    void Start()
    {
        SceneNavigator = GameObject.Find("SceneNavigator").GetComponent<SceneNavigator>();
        SceneIndex = SceneNavigator.SceneIndex;
        inputs = m_sceneNavigator.Inputs;
        reccomends = m_sceneNavigator.Reccomends;

        income = new double[9];
        Calculate();
        PrintResult();
    }

    void Calculate()
    {
        for (int i = 0; i < 9; i++)
        {
            if (reccomends[i] <= 0)
                break;
            else
            {
                income[i] = reccomends[i] * inputs[7] * protainPrice;

            }
        }
    }
    void PrintResult()
    {
        if (reccomends[0] == 0)
        {
            resultField.text = "栽培可能な品種がありません。";
        }
        else
        {
            for (int i = 0; i < 9; i++)
            {
                if (reccomends[i] <= 0)
                    break;
                else
                {
                    string variety = proteinDic[(int)reccomends[i]];
                    resultField.text += $"{i + 1}番目におすすめの品種{variety:F1}を生産した場合\n" +
                        $"予測される収入額は　￥{income[i]}です。\n\n";

                }
            }
        }
    }
}
