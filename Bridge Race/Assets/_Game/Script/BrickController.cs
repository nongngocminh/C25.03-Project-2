using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : GameObjectData
{
    [SerializeField] BoxCollider boxcol;

    public bool IsSameColorData(EColorData colorData)
    {
        return this.colorData == colorData;
    }

    internal void DisableBrick()
    {
        boxcol.enabled = false;
        meshRenderer.enabled = false;
    }

}
