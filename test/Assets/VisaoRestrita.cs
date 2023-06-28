using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisaoRestrita : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;
    public GameObject slot6;
    private string playerTurn;
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = varGlobais.playerTurn;

        if (varGlobais.playerTurn == "P2")
        {
            slot1 = GameObject.Find("slot1");
            slot2 = GameObject.Find("slot2");
            slot3 = GameObject.Find("slot3");
            slot4 = GameObject.Find("slot4");
            slot5 = GameObject.Find("slot5");
            slot6 = GameObject.Find("slot6");
        }
        else
        {
            slot1 = GameObject.Find("slot7");
            slot2 = GameObject.Find("slot8");
            slot3 = GameObject.Find("slot9");
            slot4 = GameObject.Find("slot10");
            slot5 = GameObject.Find("slot11");
            slot6 = GameObject.Find("slot12");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTurn != varGlobais.playerTurn)
        {
            if (slot1.transform.childCount != 0)
            {
                slot1.transform.GetChild(0).gameObject.GetComponent<cardAtk>().isNauseated = true;

            }
            if (slot2.transform.childCount != 0)
            {
                slot2.transform.GetChild(0).gameObject.GetComponent<cardAtk>().isNauseated = true;

            }
            if (slot3.transform.childCount != 0)
            {
                slot3.transform.GetChild(0).gameObject.GetComponent<cardAtk>().isNauseated = true;

            }
            if (slot4.transform.childCount != 0)
            {
                slot4.transform.GetChild(0).gameObject.GetComponent<cardAtk>().isNauseated = true;

            }
            if (slot5.transform.childCount != 0)
            {
                slot5.transform.GetChild(0).gameObject.GetComponent<cardAtk>().isNauseated = true;

            }
            if (slot6.transform.childCount != 0)
            {
                slot6.transform.GetChild(0).gameObject.GetComponent<cardAtk>().isNauseated = true;

            }
            Destroy(gameObject);
        }
        
        Color teste = new Color(255, 255, 255, 0);
        this.GetComponent<Image>().CrossFadeColor(teste, 0.5f, false, true);
    }
}
