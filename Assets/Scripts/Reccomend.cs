using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reccomend : MonoBehaviour
{

    //品種ごとの各係数を格納
    //X0：温度、X1：湿度、X2：降水量、X3：日照時間、X4：土壌水分量、X5：土壌温度、X6：定数部、X7：農地面積(判別分析には関係ないので０を格納)
    private double[,] coefficient;

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
    //品種別単位面積あたりのたんぱく質量
    private int[] protein = new int[9] { 1383, 1309, 1548, 1439, 1278, 1926, 1738, 707, 1479 };

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

        coefficient = new double[9, 8] {
            //●エンレイ [0,]
            { 2623.5, 12229.3, 2162, 4624.9, -1152100.1, -14045.1, -1185415.97, 0 },
            //●コトユタカ reccomend[1,]
            { 7.4, 1.6, -0.4, -0.9, 72.2, -5.8, 96.926, 0 },
            //●フクユタカ reccomend[2,]
            { -20184, -29396.1, -5739.6, -16174.1, 3419112.6, 31929.9, 3669821.17, 0 },
            //●ユキホマレ reccomend[3,]
            { 8911.2, -16509.2, -1206.3, -3220.1, 544289.8, 179.1, 1594172.88, 0 },
            //●くろこじろう reccomend[4,]
            { 707.6, -1002.6, -98.7, -262.7, 34499.8, 258.1, 102068.229, 0 },
            //●こがねさやか reccomend[5,]
            { -1383029.3, 3200165.3, 329128.1, 648924.3, -99445158.4, -1347973.9, -301067833, 0 },
            //●オオツル reccomend[6,]
            { 0.4, 7.1, 0.4, 1.2, -266.5, -0.1, -675.669, 0 },
            //●シュウレイ reccomend[7,]
            { -5.5, 10.9, 1.5, 3.1, -607.2, -0.5, -1201.406, 0 },
            //●すずかれん reccomend[8,]
            { 0.4, -2.7, -2.0, -6.2, 1334.2, -37.1, 1802.191, 0 },
        };

        Analyze(inputs);
    }

    void Analyze(double[] inputs)
    {
        Culculate(inputs);
        PrintResult();
    }

    void Culculate(double[] inputs)
    {
        for (int i = 0; i < 9;i++)
        {
            //判別分析
            for(int j = 0; j < 8; j++)
            {
                reccomends[i] += inputs[j] * coefficient[i, j];
            }
            //負：栽培不可
            if (reccomends[i] < 0)
            {
                reccomends[i] = 0;
            }
            //正：栽培可
            else
            {
                reccomends[i] = protein[i];
            }
        }
    }
    void PrintResult()
    {
        Array.Sort(reccomends);
        Array.Reverse(reccomends);
        if (reccomends[0] == 0)
        {
            resultField.text = "栽培可能な品種がありません。";
        }
        else
        {
            for(int i = 0; i < 9; i++)
            {
                if (reccomends[i] <= 0)
                    break;
                else
                {
                    string variety=proteinDic[(int)reccomends[i]];
                    resultField.text += $"{i+1}番目におすすめの品種：{variety:F1}\n単位面積あたりのたんぱく質：{reccomends[i]}(kg/ha)\n\n";

                }
            }
        }
    }
}
