using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasVenenoso : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;
    public GameObject slot5;
    public GameObject slot6;
    // Start is called before the first frame update
    void Start()
    {

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


        if (slot1.transform.childCount != 0)
        {
            slot1.transform.GetChild(0).gameObject.GetComponent<cardAtk>().Def -= 100;

        }
        if (slot2.transform.childCount != 0)
        {
            slot2.transform.GetChild(0).gameObject.GetComponent<cardAtk>().Def -= 100;

        }
        if (slot3.transform.childCount != 0)
        {
            slot3.transform.GetChild(0).gameObject.GetComponent<cardAtk>().Def -= 100;

        }
        if (slot4.transform.childCount != 0)
        {
            slot4.transform.GetChild(0).gameObject.GetComponent<cardAtk>().Def -= 100;

        }
        if (slot5.transform.childCount != 0)
        {
            slot5.transform.GetChild(0).gameObject.GetComponent<cardAtk>().Def -= 100;

        }
        if (slot6.transform.childCount != 0)
        {
            slot6.transform.GetChild(0).gameObject.GetComponent<cardAtk>().Def -= 100;

        }

        this.GetComponent<Image>().CrossFadeAlpha(0, 1f, false);
        StartCoroutine(Wait(1f));
    }
    private IEnumerator Wait(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        if (slot1.transform.childCount != 0 && ((slot1.transform.GetChild(0).gameObject.GetComponent<cardAtk>().modifyDef <= 0)))
        {
            Destroy(slot1.transform.GetChild(0).gameObject);
            Debug.Log("vapo");
        }
        if (slot2.transform.childCount != 0 && ((slot2.transform.GetChild(0).gameObject.GetComponent<cardAtk>().modifyDef <= 0)))
        {
            Destroy(slot2.transform.GetChild(0).gameObject);
            Debug.Log("vapo");
        }
        if (slot3.transform.childCount != 0 && ((slot3.transform.GetChild(0).gameObject.GetComponent<cardAtk>().modifyDef <= 0)))
        {
            Destroy(slot3.transform.GetChild(0).gameObject);
            Debug.Log("vapo");
        }
        if (slot4.transform.childCount != 0 && ((slot4.transform.GetChild(0).gameObject.GetComponent<cardAtk>().modifyDef <= 0)))
        {
            Destroy(slot4.transform.GetChild(0).gameObject);
            Debug.Log("vapo");
        }
        if (slot5.transform.childCount != 0 && ((slot5.transform.GetChild(0).gameObject.GetComponent<cardAtk>().modifyDef <= 0)))
        {
            Destroy(slot5.transform.GetChild(0).gameObject);
            Debug.Log("vapo");
        }
        if (slot6.transform.childCount != 0 && ((slot6.transform.GetChild(0).gameObject.GetComponent<cardAtk>().modifyDef <= 0)))
        {
            Destroy(slot6.transform.GetChild(0).gameObject);
            Debug.Log("vapo");
        }
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
