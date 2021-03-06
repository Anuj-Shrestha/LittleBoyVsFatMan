﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public static float generateRate = 4f;
    public GameObject enemy;
    public static int enemyPoolAmount = 4;
    List<GameObject> enemies;
    
    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        enemyPoolAmount = 4;
        generateRate = 4f;

        for (int i = 0; i < enemyPoolAmount * 4; i++)
        {
            GameObject obj = (GameObject)Instantiate(enemy);
            obj.SetActive(false);
            enemies.Add(obj);

        }

        InvokeRepeating("SpawnEnemyInGroup", 0, generateRate);
    }

    void SpawnEnemyInGroup()
    {
        int PatternNo = Random.Range(0, 6);
        var pattern = GetEnemyPattern(PatternNo);
        int active = 0;

        for (int i = 0; i < enemies.Count; i++)
        {
            if (!enemies[i].activeInHierarchy && active < enemyPoolAmount)
            {
                enemies[i].transform.position = new Vector3(pattern.initPos.x, pattern.initPos.y + active, pattern.initPos.z);
                //enemies[i].transform.rotation = transform.rotation;
                enemies[i].SetActive(true);
                active++;
            }
        }
    }

    EnemyPattern GetEnemyPattern(int ptNo)
    {
        var pattern = ScriptableObject.CreateInstance<EnemyPattern>();

        switch (ptNo)
        {
            case 0:
                {
                    pattern.patternNo = ptNo;
                    pattern.initPos = new Vector3(0, 10, -1);
                    pattern.increment = new Vector3(0, 1, 0);
                    break;
                }
            case 1:
                {
                    pattern.patternNo = ptNo;
                    pattern.initPos = new Vector3(1, 10, -1);
                    pattern.increment = new Vector3(0, 1, 0);
                    break;
                }
            case 2:
                {
                    pattern.patternNo = ptNo;
                    pattern.initPos = new Vector3(-1, 10, -1);
                    pattern.increment = new Vector3(0, 1, 0);
                    break;
                }
            case 3:
                {
                    pattern.patternNo = ptNo;
                    pattern.initPos = new Vector3(1.5f, 10, -1);
                    pattern.increment = new Vector3(0, 1, 0);
                    break;
                }
            case 4:
                {
                    pattern.patternNo = ptNo;
                    pattern.initPos = new Vector3(-1.5f, 10, -1);
                    pattern.increment = new Vector3(0, 1, 0);
                    break;
                }
            case 5:
                {
                    pattern.patternNo = ptNo;
                    pattern.initPos = new Vector3(2f, 10, -1);
                    pattern.increment = new Vector3(-0.2f, 1, 0);
                    break;
                }
            case 6:
                {
                    pattern.patternNo = ptNo;
                    pattern.initPos = new Vector3(-2f, 10, -1);
                    pattern.increment = new Vector3(0.2f, 1, 0);
                    break;
                }
            case 7:
                {
                    pattern.patternNo = ptNo;
                    pattern.initPos = new Vector3(2f, 10, -1);
                    pattern.increment = new Vector3(-0.4f, 1, 0);
                    break;
                }
            case 8:
                {
                    pattern.patternNo = ptNo;
                    pattern.initPos = new Vector3(-2f, 10, -1);
                    pattern.increment = new Vector3(0.4f, 1, 0);
                    break;
                }
            default:
                {
                    pattern.patternNo = ptNo;
                    pattern.initPos = new Vector3(0, 10, -1);
                    pattern.increment = new Vector3(0, 1, 0);
                    break;
                }
        }
        return pattern;
    }
}
