using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : GameObjectData
{
    [SerializeField] List<Transform> characterBricks;
    [SerializeField] Transform characterBrickHolder, characterBrickPrefab;
    [SerializeField] private Stack<Transform> characterBrickStack = new Stack<Transform>();

    public float brickHeight = 0.55f;
    public float rotationSpeed = 25f;

    private void Start()
    {
        ChangeColor(colorDataConfig.GetMaterial((int)colorData));
    }

    public virtual void OnInit()
    {

    }

    public virtual void OnExecute()
    {

    }

    public virtual void OnDestruction()
    {

    }

    public void CharacterAddBrick()
    {
        Transform newCharacterBrick = Instantiate(characterBrickPrefab, characterBrickHolder);
        newCharacterBrick.localPosition = GameManager.Instance.playerBrickCount * Vector3.up * brickHeight;
        characterBrickStack.Push(newCharacterBrick);
    }

    public void CharacterRemoveBrick()
    {
        Destroy(characterBrickStack.Pop().gameObject);
    }


}
