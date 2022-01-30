using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateOfNPCs : MonoBehaviour
{
    private static StateOfNPCs _instance;
    public static StateOfNPCs Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new StateOfNPCs();
            }
            return _instance;
        }
    }

    public List<int> DeadNPCs { get; set; }

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        DeadNPCs = new List<int>();

        DontDestroyOnLoad(this.gameObject);
    }

}
