using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    crate, crystal, rock, heart                 //add as needed
}


public class PickUpPrefab : MonoBehaviour
{

    [SerializeField]
    private int item_value=0;

    //property for item_value updating health, score
    public int Value
    {
        get
        {
            return item_value;
        }
        set
        {
            value = item_value;
        }

    }   

    public PickupType type; //what is the PickupType of this object

}// end class
