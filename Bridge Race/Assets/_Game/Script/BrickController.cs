using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : GameObjectData
{
    [SerializeField] public BoxCollider boxCol;
    [SerializeField] private float delayReAppear;

    public bool IsSameColorData(EColorData colorData)
    {
        return this.colorData == colorData;
    }

    internal void DisableBrick()
    {
        IEnumerator coroutine = ReAppear();

        boxCol.enabled = false;
        meshRenderer.enabled = false;

        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = ReAppear();
        StartCoroutine(coroutine);
    }


    private IEnumerator ReAppear()
    {
        yield return new WaitForSeconds(delayReAppear);
        boxCol.enabled = true;
        meshRenderer.enabled = true;
    }
}
