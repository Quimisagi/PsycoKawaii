using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcKiller : MonoBehaviour
{
    [SerializeField] private GameObject _npcList;
    void Start()
    {
        foreach(int id in StateOfNPCs.Instance.DeadNPCs)
        {
            Debug.Log(id);
            foreach (Transform child in _npcList.transform)
            {
                var npcMediator = child.GetComponent<NpcMediator>();

                if (npcMediator.Id == id)
                {
                    npcMediator._lifeController.Kill();
                    break;
                }
        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
