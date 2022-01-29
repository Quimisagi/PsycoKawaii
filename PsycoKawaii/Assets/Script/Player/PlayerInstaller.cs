using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstaller : MonoBehaviour
{
    public static PlayerInstaller Instance { get; private set; }

    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private Canvas _ui;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        CreatePlayer();
        CreateUI();
    }

    private void CreatePlayer()
    {
        var player = Instantiate(_player, _spawnPoint.position, Quaternion.identity);
        DontDestroyOnLoad(player);
    }

    
    private void CreateUI()
    {
        var ui = Instantiate(_ui, _spawnPoint.position, Quaternion.identity);
        DontDestroyOnLoad(ui);
    }
}
