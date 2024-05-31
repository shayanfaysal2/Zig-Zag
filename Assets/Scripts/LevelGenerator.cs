using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;

    public GameObject cubePrefab;
    public int startingCubesCount;
    public int distanceBetweenCubes;
    public float diamondChance;

    Vector3 spawnPosition = Vector3.zero;
    int cubesCount = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }

    public void GenerateCube()
    {
        //Spawn cube
        GameObject cube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
        cube.GetComponent<Cube>().index = cubesCount++;

        //Show diamond
        GameObject diamond = cube.transform.GetChild(0).gameObject;
        if (Random.value < diamondChance)
            diamond.SetActive(true);
        else
            diamond.SetActive(false);

        //Set its direction
        Vector3 direction = (Random.Range(0, 2) == 0) ? Vector3.right : Vector3.forward;

        //Update spawn position
        spawnPosition += direction * distanceBetweenCubes;
    }

    void GenerateLevel()
    {
        for (int i = 0; i < startingCubesCount; i++)
        {
            GenerateCube();
        }
    }
}
