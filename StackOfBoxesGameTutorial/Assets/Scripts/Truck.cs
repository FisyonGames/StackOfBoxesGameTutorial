using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public static Truck instance = null;

    private void Awake()
    {
        if (instance == null) instance = this;
    }


}
