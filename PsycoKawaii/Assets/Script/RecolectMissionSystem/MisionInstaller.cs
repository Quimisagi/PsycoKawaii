using UnityEngine;
using System;

public class MisionInstaller : MonoBehaviour
{
    public static MisionInstaller Instance { get; private set; }

    [SerializeField] public Mision CurrentMision;

    public static event Action<Mision> _EventMision;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    public void AddMision(Mision currentMision)
    {
        if (CurrentMision != null)
        {
            return;
        }
        CurrentMision = Instantiate(currentMision);
        _EventMision(currentMision);
    }

    public void CompleteMision()
    {
        CurrentMision = null;
    }

    public bool ComprobateMisionComplete()
    {
        if (CurrentMision == null)
        {
            return false;
        }

        int numb = 0;
        foreach (var item in CurrentMision.CollectItems)
        {
            if (item.IsCollet)
            {
                numb++;
            }
        }

        if (numb == CurrentMision.CollectItems.Length)
        {
            Debug.Log("Se completo la mision");
            CurrentMision.MisionComplete = true;
            return true;
        }
        return false;
    }

}
