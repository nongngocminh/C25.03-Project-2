using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrickController : GameObjectData
{
    private void Start()
    {
        ChangeColor(colorDataConfig.GetMaterial((int)colorData));
    }
}
