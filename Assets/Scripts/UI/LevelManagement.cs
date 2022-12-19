using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagement : MonoBehaviour
{
    public GameObject[] levels;
    void Start()
    {
        int level = levels.Length;
        for (int i = 0; i < level; i++)
        {
            if (i < PlayerPrefs.GetInt("Knight", 1))
            {
                levels[i].SetActive(true);
            }
        }
    }
}
