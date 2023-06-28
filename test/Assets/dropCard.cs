using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dropCard : MonoBehaviour
{
    public Button testSlot;
    public string slotOwner;
    void Start()
    {
        Button btn = testSlot.GetComponent<Button>();
        btn.onClick.AddListener(isAvaliable);
    }

    
    void Update()
    {
        
    }

    void isAvaliable()
    {
        if(this.transform.childCount == 0 && slotOwner == varGlobais.playerTurn)
        {
            this.transform.GetComponent<qrCode>().enabled = true;
        }
    }
}
