using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class onCardOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    GameObject clone;
    GameObject cardCentral;
    bool dontScale = false;
    private void Start()
    {
        Debug.Log("iniciei");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        clone = Instantiate(this.gameObject, transform.position, transform.rotation);
        cardCentral = GameObject.Find("cardCentral");
        clone.transform.SetParent(cardCentral.transform);
        clone.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        clone.GetComponent<cardAtk>().amplifyAtk.SetActive(false);
        clone.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
        clone.GetComponent<cardAtk>().enabled = false;
        if(varGlobais.playerTurn == "P2"){
            clone.transform.rotation = new Quaternion(0, 0, -180, 0);
        }
        else
        {
            clone.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        clone.transform.position = new Vector3(Screen.width/2, Screen.height/2, clone.transform.position.z);
        clone.GetComponent<onCardOver>().enabled = false;
        clone.transform.localScale = new Vector3(2, 2, 1);
   
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(clone);
    }

    private void OnDestroy()
    {
        Destroy(clone);
    }

    
}
