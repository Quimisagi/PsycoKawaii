using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilnessSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _evilnessList;
    [SerializeField] private List<GameObject> _patternsList;
    public int MaxEvilness { get; set; }

    private void Start()
    {
        MaxEvilness = 15;
        GeneratePattern();
        GenerateEvilness();
    }

    public void GeneratePattern()
    {
        int num = Random.Range(0, _patternsList.Count);
        var temp = Instantiate(_patternsList[num]);
        temp.transform.position = new Vector3(0, 0, 0);
    }

    public void GenerateEvilness()
    {
        for (int i = 0; i < MaxEvilness; i++)
        {
            int num = Random.Range(0, _evilnessList.Count);
            var temp = Instantiate(_evilnessList[num]);
            temp.transform.position = GenerateRandomPosition();
            
        }
    }

    public Vector3 GenerateRandomPosition()
    {
        float posX = Random.Range(-8F, 8F);
        float posY = Random.Range(-4.5F, 4.5F);
        if (posX < 1F && posX > 0) posX += 1F;
        if (posX > -1F && posX < 0) posX -= 1F;
        if (posY < 1F && posY > 0) posY += 1F;
        if (posY > -1F && posY < 0) posY -= 1F;


        return new Vector3(posX, posY, 0);
    }
}
