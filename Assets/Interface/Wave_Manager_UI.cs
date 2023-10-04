using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Wave_Manager_UI : MonoBehaviour
{
    public TextMeshProUGUI WaveNumber;
    public int actualWave;
    private int actualWaveTen;

    public Image[] WaveImg;

    // Start is called before the first frame update
    void Start()
    {
        UpdateWaveImg();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            actualWave++;
            if(actualWave == 10)
            {
                actualWave = 0;
            }
            UpdateWaveImg();
        }
    }


    

    void UpdateWaveImg()
    {
        
        WaveImg[actualWave].color = new Color(1f,0.5f,0f);
        if (actualWave >= 1)
        {
            WaveImg[actualWave - 1].color = Color.grey;

        }
        if(actualWave == 0)
        {
            for (int i = 0; i< WaveImg.Length; i++)
            {
                WaveImg[i].color = Color.white;

            }
        }

        WaveImg[actualWave].color = new Color(1f, 0.5f, 0f);

    }
}
