﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject spawner;

    public GameObject spawnthis;
    public GameObject win_state;
    public GameObject lose_state;
    public float gamestate;
    public float sealevelmax;
    public float currentsealevel;
    public Transform sealeveltransform;

    public float victories;
    public float victorygoal;

    public float victorystatus;

    public GameObject sky;
    public GameObject water;
    
    public GameObject[] tenpercent;
    public GameObject[] twentypercent;
    public GameObject[] thirtypercent;
    public GameObject[] fourtypercent;
    public GameObject[] fiftypercent;
    public GameObject[] sixtypercent;
    public GameObject[] seventypercent;
    public GameObject[] eightypercent;
    public GameObject[] ninetypercent;
    public GameObject[] onehundredpercent;

    void Start()
    {
        gamestate = 1; // Game has started

        InvokeRepeating("UpdateSeaLevel", 1.0f, 1.0f);

        InvokeRepeating("Spawn", 3.0f, 12.0f);

        //InvokeRepeating("Survive", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gamestate==2)
            win_state.SetActive(true);
        if (gamestate==3)
            lose_state.SetActive(true);
        
        if (currentsealevel>sealevelmax)
            Debug.Log("Game Over");

        if (victories>0)
            victorystatus = victories/victorygoal * 100;


        if (victorystatus>99)
        {
            foreach (var obj in onehundredpercent) {
                obj.SetActive(true);
            }
            gamestate = 2;
        }
        else if (victorystatus>90)
        {
            foreach (var obj in ninetypercent) {
                obj.SetActive(true);
            }
        }
        else if (victorystatus>80)
        {
            foreach (var obj in eightypercent) {
                obj.SetActive(true);
            }
        }
        else if (victorystatus>70)
        {
            foreach (var obj in seventypercent) {
                obj.SetActive(true);
            }
        }
        else if (victorystatus>60)
        {
            foreach (var obj in sixtypercent) {
                obj.SetActive(true);
            }
        }
        else if (victorystatus>50)
        {
            foreach (var obj in fiftypercent) {
                obj.SetActive(true);
            }
        }
        else if (victorystatus>40)
        {
            foreach (var obj in fourtypercent) {
                obj.SetActive(true);
            }
        }
        else if (victorystatus>30)
        {
            foreach (var obj in thirtypercent) {
                obj.SetActive(true);
            }
        }
        else if (victorystatus>20)
        {
            foreach (var obj in twentypercent) {
                obj.SetActive(true);
            }
        }
        else if (victorystatus>10) 
        {   
            foreach (var obj in tenpercent) {
                obj.SetActive(true);
            }
        }
    }

    void Spawn()
    {
        Instantiate(spawnthis, new Vector3(Random.Range(-57.0f, -19.0f), 22.3f, 0.0f), Quaternion.identity);
    }

    public float GetVictoryStatus()
    {
        return(victorystatus);
    }
 
    private void UpdateSeaLevel()
    {
        if (gamestate==1)
            currentsealevel = sealeveltransform.position.y;

        if (currentsealevel>sealevelmax)
            gamestate = 3;
        
    }

    public void AddPoints(float morepoints)
    {
        victories += morepoints;
    }
}
