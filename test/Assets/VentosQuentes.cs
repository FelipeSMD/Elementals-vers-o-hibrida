using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VentosQuentes : MonoBehaviour
{

    void Start() {
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
