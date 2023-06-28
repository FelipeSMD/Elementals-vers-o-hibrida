using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System;

public class waether : MonoBehaviour
{
    public Text temperatura;
    public String[] local ;
    public  float tempStats;

    public delegate void OnVariableChangeDelegate(string newVal);
    public event OnVariableChangeDelegate OnVariableChange;
    private string m_MyVar = varGlobais.playerTurn;

    private void Start()
    {
        this.OnVariableChange += VariableChangeHandler;
        StartCoroutine(test());
    }

    private void Update()
    {
        if (varGlobais.playerTurn != m_MyVar && OnVariableChange != null)
        {
            m_MyVar = varGlobais.playerTurn;
            OnVariableChange(varGlobais.playerTurn);
        }
    }

    public IEnumerator test()
    {
        int pos = (int)UnityEngine.Random.Range(0, local.Length);
        string localTemp = local[pos].ToString();
        string url = "api.openweathermap.org/data/2.5/weather?q="+ localTemp + ",br&APPID=9bec7d1ca6c39d4133c0d36390d2708d";
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            String[] info = www.text.Split(':');
            String[] aux = info[11].Split(',');
            String[] aux2 = aux[0].Split('.');

            
            float temp = (float.Parse(aux2[0]) - 273);
            Debug.Log(localTemp + " - " + temp);
            tempStats = temp;
            temperatura.text = temp.ToString();

            if (temp <= 20)
            {
                varGlobais.temperaturaAtual = "Frio";  
            }
            if (temp >= 20 && temp < 30)
            {
                varGlobais.temperaturaAtual = "Neutro";
            }
            if (temp >= 30)
            {
                varGlobais.temperaturaAtual = "Quente";
            }

        }
        else
        {
            Debug.Log("ERROR: " + www.error + "array pos:"+ pos);

        }


        //this.gameObject.GetComponent<waether>().enabled = false;
    }

    private void VariableChangeHandler(string newVal)
    {
        StartCoroutine(test());
    }
}
