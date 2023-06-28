using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Button turnChanger;
    public string playerOwner;

    public Text txtManaP1;
    public Text txtManaP2;

    public Button menu;

    LightSensorPluginScript test;
    void Start()
    {
        test = GetComponent<LightSensorPluginScript>();
        Button btn = turnChanger.GetComponent<Button>();
        btn.onClick.AddListener(turnChange);

        try
        {
            if (test.getLux() > 100)
            {
                varGlobais.luminosidadeAtual = "Claro";
            }
            else if (test.getLux() < 30)
            {
                varGlobais.luminosidadeAtual = "Escuro";
            }
            else
            {
                varGlobais.luminosidadeAtual = "Neutro";
            }
        }
        catch
        {
            varGlobais.luminosidadeAtual = "Neutro";
        }

    }

    // Update is called once per frame
    void Update()
    {
        txtManaP1.text = varGlobais.p1Mana.ToString();
        txtManaP2.text = varGlobais.p2Mana.ToString();
        

        if (playerOwner == varGlobais.playerTurn)
        {
            this.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("vermelho");
        }
        else
        {
            this.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("cinza");
        }
    }

    public  void turnChange()
    {
        menu.gameObject.SetActive(true);
        if(playerOwner == varGlobais.playerTurn)
        if(varGlobais.playerTurn == "P1" )
        {
            varGlobais.playerTurn = "P2";
            if(varGlobais.p2Rounds < 10){
                varGlobais.p2Rounds++;
                varGlobais.p2Mana= varGlobais.p2Rounds;
            }
            else
            {
                varGlobais.p2Mana = 10;
            }
        }
        else
        {
            varGlobais.playerTurn = "P1";
            if(varGlobais.p1Rounds < 10){
                varGlobais.p1Rounds++;
                varGlobais.p1Mana = varGlobais.p1Rounds;
            }
            else
            {
                varGlobais.p1Mana = 10;
            }
        }

        varGlobais.ventoAtual = "Neutro";
    }
}
