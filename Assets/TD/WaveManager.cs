using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    
    public GameObject[] Ennemies;
    //Ennemy0 = light
    //Ennemy1 = normal
    //Ennemy2 = heavy


    public GameObject[] Checkpoints;

    public Waves[] Waves;
    private int actualWave;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartWave()
    {
       
        for (int i = 0; i < Waves[actualWave].numberOfEnnemies; i++)
        {
            GameObject ennemy = Instantiate(Ennemies[Waves[actualWave].type], transform.position, Quaternion.identity);

            ennemy.transform.position = Checkpoints[0].transform.position;
            EnnemyController ennemyController = ennemy.GetComponent<EnnemyController>();

            ennemyController.waypoints = Checkpoints;

            yield return new WaitForSeconds(Waves[actualWave].spawnInterval);
        }

        



    }

    void instantiateEnnemie()
    {

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
