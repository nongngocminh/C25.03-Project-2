using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectData : MonoBehaviour
{
    [SerializeField] public MeshRenderer meshRenderer;
    [SerializeField] public EColorData colorData;
    [SerializeField] public ColorDataConfig colorDataConfig;

    public void ChangeColor(Material material)
    {
        meshRenderer.material = material;
    }
}
