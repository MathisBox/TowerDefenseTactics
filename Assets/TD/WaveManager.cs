using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Wave_Manager_UI UIManager;
    
    public GameObject[] Ennemies;
    //Ennemy0 = light
    //Ennemy1 = normal
    //Ennemy2 = heavy


    public GameObject[] Checkpoints;

    public Waves[] Waves;
    public GameObject[] EnnemiesALive;
    private bool WaveIsFinished = true;
    private bool EnnemiesListEmpty = true;


    private int actualWave;
    private int actualWaveTen;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWave());
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnnemiesList();

        if(EnnemiesListEmpty == false && WaveIsFinished == true)
        {
            Debug.Log("Wave Finished");
        }
    }

    private IEnumerator StartWave()
    {
        WaveIsFinished = false;
        UIManager.actualWave = actualWave;
       
        for (int i = 0; i < Waves[actualWave].numberOfEnnemies; i++)
        {
            GameObject ennemy = Instantiate(Ennemies[Waves[actualWave].type], transform.position, Quaternion.identity);

            ennemy.transform.position = Checkpoints[0].transform.position;
            EnnemyController ennemyController = ennemy.GetComponent<EnnemyController>();
            AddEnnemiesToList(ennemy);
            ennemyController.waypoints = Checkpoints;

            yield return new WaitForSeconds(Waves[actualWave].spawnInterval);
        }
        WaveIsFinished = true;







    }
    void AddEnnemiesToList(GameObject EnnemieToAdd)
    {
        
        for (int i= 0; i<EnnemiesALive.Length; i++)
        {

            if (EnnemiesALive[i] == null)
            {
                EnnemiesALive[i] = EnnemieToAdd;
                break;
            }
        }
    }

    void CheckEnnemiesList()
    {
        for (int i = 0; i < EnnemiesALive.Length; i++)
        {

            if (EnnemiesALive[i] != null)
            {
                EnnemiesListEmpty = false;
                break;
            }
            else
            {

            }


        }
        


    }


}



[System.Serializable]
public class Waves
{
    public float spawnInterval;
    public float numberOfEnnemies;
    public float multiplicateur;
    public float delay;
    public int type;
}
