﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    [SerializeField]
    private GameManager manager;

    private Text textField;
    private void Awake()
    {
        textField = GetComponent<Text>();
    }
    private void Update()
    {
        textField.text = (manager.score).ToString();
    }
}