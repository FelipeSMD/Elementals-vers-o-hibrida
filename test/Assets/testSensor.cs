using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testSensor : MonoBehaviour
{
    public Text tm;
    public  float lums;

    public Text aceX;
    public Text aceY;
    public Text giro;
    public Text disponibilidade;
    LightSensorPluginScript test;

    Gyroscope m_Gyro;

    public Button accButton;
    public Button gyroButton;
    public Button weatherButton;
    public Button qrCodeButton;
    public bool accOn = false;
    public bool gyroOn = false;
    float aux = 0;
    public Vector3 auxGyro;

   
    
    private String[] biomes = {"Fortaleza", "São Paulo", "Curitiba", "Natal", "Pelotas"};
    void Start()
    {
        giro.text = "ta funfando";
        m_Gyro = Input.gyro;
        m_Gyro.enabled = true;
        test = GetComponent<LightSensorPluginScript>();

        Button btn = accButton.GetComponent<Button>();
        btn.onClick.AddListener(accOnClick);

        Button btngyro = gyroButton.GetComponent<Button>();
        btngyro.onClick.AddListener(gyroOnClick);

        Button btnweather = weatherButton.GetComponent<Button>();
        btnweather.onClick.AddListener(weatherOnClick);

        Button btnQR = qrCodeButton.GetComponent<Button>();
        btnQR.onClick.AddListener(enableScan);
    }
    void Update()
    {
        tm.text = test.getLux().ToString();
        lums = test.getLux();
        //disponibilidade.text = SystemInfo.supportsGyroscope.ToString();
        disponibilidade.text = Input.gyro.rotationRate.ToString();

        if (accOn)
        {
            aux += Input.accelerationEventCount;//Mathf.Abs(Input.acceleration.x) + Mathf.Abs(Input.acceleration.y) + Mathf.Abs(Input.acceleration.z);
            
        }
        else
        {
            aceX.text = aux.ToString();
            if(aux >= 200)
            {
                aceY.text = "Enjoado";
            }
            else
            {
                aceY.text = "Ataque aumentado em " + (aux).ToString();
            }
        }

        if (gyroOn)
        {
            auxGyro = Input.gyro.rotationRate;

            GyroToUnity(auxGyro);

            if (auxGyro.x >= 3)
            {
                giro.text = "Reposicionou para a baixo";
                gyroOn = false;
            }
                
            if (auxGyro.y >= 3)
            {
                giro.text = "Reposicionou para a esquerda";
                gyroOn = false;
            }
                
            if (auxGyro.x <= -3)
            {
                giro.text = "Reposicionou para a cima";
                gyroOn = false;
            }
                
            if (auxGyro.y <= -3)
            {
                giro.text = "Reposicionou para a direita";
                gyroOn = false;
            }
                

        }
       


    }

    private static Vector3 GyroToUnity(Vector3 q)
    {
        return new Vector3(q.x, q.y, -q.z);
    }



    void accOnClick()
    {
        aux = 0;
        aceX.text ="0";
        accOn = true;
        StartCoroutine(WaitAndPrint(10));
    }

    void gyroOnClick()
    {
        aux = 0;
        gyroOn = true;
        StartCoroutine(waitGyro(10));
    }

    void weatherOnClick()
    {
        
        //this.gameObject.GetComponent<waether>().local = biomes[UnityEngine.Random.Range(0, biomes.Length)].ToString() ;
        StartCoroutine(this.gameObject.GetComponent<waether>().test());

        
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        
        while (true)
        {
            
            yield return new WaitForSeconds(waitTime);
            accOn = false;
        }
    }

    private IEnumerator waitGyro(float waitTime)
    {

        while (true)
        {

            yield return new WaitForSeconds(waitTime);
            gyroOn = false;
        }
    }

    void enableScan()
    {
        this.GetComponent<qrCode>().enabled = true;
        this.GetComponent<testSensor>().enabled = false;
    }
}
