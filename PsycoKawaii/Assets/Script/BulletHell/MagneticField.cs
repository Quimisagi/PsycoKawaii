using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticField : MonoBehaviour
{
    [SerializeField] private int _energy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Charge")
        {
            var charge = collision.GetComponent<SoulCharge>();
            if(_energy == charge.Value)
            {
                charge.IsSoulNear = true;
                charge.Soul = this.gameObject;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Charge")
        {
            var charge = collision.GetComponent<SoulCharge>();
            if (_energy == charge.Value)
            {
                charge.IsSoulNear = false;
                charge.Soul = null;
            }
                
        }
    }
}
