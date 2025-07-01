using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameObjectData
{   

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Brick")) return;
        Debug.Log("Hit Brick!");
        BrickController brick = other.gameObject.GetComponent<BrickController>();
        if (brick == null) return;
        if (brick.IsSameColorData(colorData))
            brick.DisableBrick();
    }
}
