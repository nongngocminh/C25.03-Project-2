using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorDataConfig", menuName = "ScriptableObjects/ColorDataConfig", order = 1)]

public class ColorDataConfig : ScriptableObject
{
    public List<Material> materials = new List<Material>();
    
    public Material GetMaterial(int index)
    {
        return materials[index];
    }
}

public enum EColorData
{
    None = 0,
    Red = 1,
    Green = 2,
    Blue = 3,
    Yellow = 4
}
