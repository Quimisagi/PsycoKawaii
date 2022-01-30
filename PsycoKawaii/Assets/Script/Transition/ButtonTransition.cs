using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTransition : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private string _sceneName;
    [SerializeField] private bool _destroy;

    void Start()
    {
        _button.onClick.AddListener(ChangeScene);
    }

   
    void ChangeScene()
    {
        SceneController.Instance.ChangeSceneName(_sceneName);
        if (_destroy)
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(PlayerInstaller.Instance.gameObject);
        Destroy(MisionInstaller.Instance.gameObject);
        Destroy(Camera.main.gameObject);
        Destroy(FindObjectOfType<PlayerMediator>().gameObject);
        Destroy(FindObjectOfType<ViewMision>().gameObject);
        Destroy(FindObjectOfType<StateOfNPCs>().gameObject);
    }

}
