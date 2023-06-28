using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlechadaDeVacuo : MonoBehaviour
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

        if(varGlobais.playerTurn == "P2")
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

        GameObject[] lacaiosNoCampo = new GameObject[6];
        int aux = 0;
        if (slot1.transform.childCount != 0)
        {
            lacaiosNoCampo[aux] = slot1.transform.GetChild(0).gameObject;
            aux++;
        }
        if (slot2.transform.childCount != 0)
        {
            lacaiosNoCampo[aux] = slot2.transform.GetChild(0).gameObject;
            aux++;
        }
        if (slot3.transform.childCount != 0)
        {
            lacaiosNoCampo[aux] = slot3.transform.GetChild(0).gameObject;
            aux++;
        }
        if (slot4.transform.childCount != 0)
        {
            lacaiosNoCampo[aux] = slot4.transform.GetChild(0).gameObject;
            aux++;
        }
        if (slot5.transform.childCount != 0)
        {
            lacaiosNoCampo[aux] = slot5.transform.GetChild(0).gameObject;
            aux++;
        }
        if (slot6.transform.childCount != 0)
        {
            lacaiosNoCampo[aux] = slot6.transform.GetChild(0).gameObject;
            aux++;
        }
        if (aux != 0)
        {
            Destroy(lacaiosNoCampo[Random.Range(0, aux)]);
        }

        this.GetComponent<Image>().CrossFadeAlpha(0, 1f, false);
        StartCoroutine(Wait(1f));
    }
    private IEnumerator Wait(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
