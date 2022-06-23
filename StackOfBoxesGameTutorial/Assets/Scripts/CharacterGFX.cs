using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGFX : MonoBehaviour
{
    public void Kick()
    {
        Boxes.instance.KickAgainstBox();
    }
}
