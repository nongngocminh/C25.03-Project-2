using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBrickController : GameObjectData
{
    [SerializeField] public BoxCollider boxCol;

    public bool IsSameColorData(EColorData colorData)
    {
        return this.colorData == colorData;
    }

    public void EnableBridge()
    {
        boxCol.enabled = false;
        meshRenderer.enabled = true;
        boxCol.isTrigger = false;
    }
}
