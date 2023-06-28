using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ativaScanMagic : MonoBehaviour
{
    public Button testSlot;
    void Start()
    {
        Button btn = testSlot.GetComponent<Button>();
        btn.onClick.AddListener(isAvaliable);

        

    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    void isAvaliable()
    {
            this.transform.GetComponent<invocaMagica>().enabled = true;
    }
}
