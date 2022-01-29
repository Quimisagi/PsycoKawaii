﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TransitionScene : MonoBehaviour
{
    [SerializeField] private Vector2 _traslatePosition;
    [SerializeField] private string _nameScene;

    [SerializeField] private float _timeFade;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<PlayerMediator>();
            SceneController.Instance.ChangeScene(_nameScene, _timeFade, player, _traslatePosition);
        }
    }
}