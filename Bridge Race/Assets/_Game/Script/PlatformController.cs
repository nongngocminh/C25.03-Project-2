using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : GameObjectData
{
    [SerializeField] private List<BrickController> bricks;
    [SerializeField] private List<BrickController> shuffledBricks;
    [SerializeField] private BrickController brickPrefab;

    [SerializeField] private Transform startBrickSpawn;
    [SerializeField] private Transform brickHolder;

    [SerializeField] private int spawnAmountByRow;
    [SerializeField] private float spawnOffset;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBrick();
        SetBrickColor();
    }

    private void SpawnBrick()
    {
        Vector3 spawnPosition = startBrickSpawn.position;
        System.Random rng = new System.Random();

        for (int i = 1; i <= spawnAmountByRow; i++)
        {
            for (int j = 1; j <= spawnAmountByRow; j++)
            {
                BrickController brick = Instantiate(brickPrefab, spawnPosition, Quaternion.identity, brickHolder.transform);
                bricks.Add(brick);
                spawnPosition = new Vector3(spawnPosition.x + spawnOffset, spawnPosition.y, spawnPosition.z);
            }

            spawnPosition.z -= spawnOffset;
            spawnPosition.x = spawnPosition.x - spawnAmountByRow * spawnOffset;
        }

        shuffledBricks = ShuffledList<BrickController>(bricks);
    }

    private void SetBrickColor()
    {
        int i = 1;
        foreach (var brick in shuffledBricks)
        {
            if (i == 5)
            {
                i = 1;
                brick.ChangeColor(colorDataConfig.GetMaterial(i));
                brick.colorData = (EColorData)i;
                i++;
            }
            else
            {
                brick.ChangeColor(colorDataConfig.GetMaterial(i));
                brick.colorData = (EColorData)i;
                i++;
            }
        }
    }

    public List<BrickController> ShuffledList<BrickController>(List<BrickController> bricks)
    {
        System.Random rng = new System.Random();

        int n = bricks.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            BrickController value = bricks[k];
            bricks[k] = bricks[n];
            bricks[n] = value;
        }

        return bricks;
    }
}
