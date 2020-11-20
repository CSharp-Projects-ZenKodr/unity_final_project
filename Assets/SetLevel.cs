﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetLevel : MonoBehaviour
{
    public GameData.GameLevel Level;
    public GameData GameData;
    public GameObject panelEnterName;
    public GameObject panelSetLevel;
    public enum GameLevel
    {
        Easy,
        Normal,
        Hard,
    }
    // Start is called before the first frame update
    private void Start()
    {
        GameData = GameObject.Find("GameData").GetComponent<GameData>();
        Level = GameData.Level;
    }

    public void SetLevelEasy()
    {
        Level = GameData.GameLevel.Easy;
        panelEnterName.SetActive(true);
        panelSetLevel.SetActive(false);
    }

    public void SetLevelNormal()
    {
        Level = GameData.GameLevel.Normal;
        panelEnterName.SetActive(true);
        panelSetLevel.SetActive(false);
    }

    public void SetLevelHard()
    {
        Level = GameData.GameLevel.Hard;
        panelEnterName.SetActive(true);
        panelSetLevel.SetActive(false);
    }
   
}