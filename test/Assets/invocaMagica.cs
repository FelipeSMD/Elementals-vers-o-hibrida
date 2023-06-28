using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using ZXing;
using ZXing.QrCode;





public class invocaMagica : MonoBehaviour
{
    private WebCamTexture camTexture;
    private Rect screenRect;
    public Text resultado;
    public int playermana;
   
    
    public GameObject cardMagic;
    
    public bool isScanning = false;
    void Start()
    {
       
    }

    void OnEnable()
    {
        screenRect = new Rect(0, 0, 1920, 1080);
        camTexture = new WebCamTexture();
        camTexture.requestedHeight = 1920;
        camTexture.requestedWidth = 1080;
        camTexture.requestedFPS = 30;


        if (camTexture != null)
        {
            camTexture.Play();
        }
    }

    private void Update()
    {
        if (varGlobais.playerTurn == "P1")
        {
            playermana = varGlobais.p1Mana;
        }
        else
        {
            playermana = varGlobais.p2Mana;
        }
        try
        {

            IBarcodeReader barcodeReader = new BarcodeReader();
            // decode the current frame
            var result = barcodeReader.Decode(camTexture.GetPixels32(), camTexture.width, camTexture.height);
            if (result != null)
            {
                isScanning = true;
                Debug.Log("DECODED TEXT FROM QR:" + result.Text);
                //resultado.text = result.Text;
                //this.GetComponent<testSensor>().enabled = true;
                //this.GetComponent<qrCode>().enabled = false;

                String[] attribs = cardRecog.cardList(result.Text).Split(',');

                /*
                 * attribs[0] = atk ou efeito
                 * attribs[1] = def ou 0
                 * attribs[2] = elemento
                 * attribs[3] = Lacaio ou Mágica
                 * attribs[4] = Custo de mana
                 */

                /* @Renan
                 * Checagem pra ver se possui mana suficiente
                 */
                Debug.Log(result.Text);
                if (playermana >= int.Parse(attribs[4]))
                {
                    if (attribs[3] == "Mágica")
                    {
                        cardMagic = Resources.Load<GameObject>(result.Text);
                        if (varGlobais.playerTurn == "P1")
                        {
                             varGlobais.p1Mana -= int.Parse(attribs[4]);
                        }
                        else
                        {
                           varGlobais.p2Mana -= int.Parse(attribs[4]);
                        }
                        GameObject newCard = Instantiate(cardMagic, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                        Transform cardCentral = GameObject.Find("cardCentral").transform;
                        newCard.transform.SetParent(cardCentral);
                        newCard.transform.position = cardCentral.position;
                        newCard.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(result.Text);
                        newCard.transform.localScale = new Vector3(2, 2, 1);
                        //newCard.transform.GetChild(0).GetComponent<Text>().text = attribs[0];
                        resultado.text = result.Text;
                        camTexture.Stop();
                        this.transform.GetComponent<invocaMagica>().enabled = false;
                    }
                    if (attribs[3] == "Lacaio")
                    {
                        resultado.text = "Está não é uma carta mágica!";
                        camTexture.Stop();
                        this.transform.GetComponent<invocaMagica>().enabled = false;

                    }
                }
                else
                {
                    resultado.text = "Você não tem mana suficiente";
                    camTexture.Stop();
                    this.transform.GetComponent<invocaMagica>().enabled = false;
                }
                

            }
        }
        catch (Exception ex) { Debug.LogWarning(ex.Message); }
        //timer = 0;
        //}

    }

    private IEnumerator WaitAndPrint(float waitTime)
    {

        while (true)
        {
            resultado.enabled = false;
            this.transform.GetComponent<invocaMagica>().enabled = false;


        }
    }
    void OnGUI()
    {
        // drawing the camera on screen
        GUI.DrawTexture(screenRect, camTexture, ScaleMode.ScaleAndCrop);
        // do the reading — you might want to attempt to read less often than you draw on the screen for performance sake

    }

  
}
