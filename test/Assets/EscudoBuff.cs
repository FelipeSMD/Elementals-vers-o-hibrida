﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoBuff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && varGlobais.buffLiberado){
            this.gameObject.GetComponent<cardAtk>().Def += 200;
            varGlobais.buffLiberado = false;
        }
    }
}
