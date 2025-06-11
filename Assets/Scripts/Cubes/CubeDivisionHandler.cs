using System.Collections.Generic;
using UnityEngine;

public class CubeDivisionHandler : MonoBehaviour
{
    [SerializeField] private CubeClickHandler _cubeClickHandler;
    [SerializeField] private CubeFactory _cubeFactory;
    [SerializeField] private Exploader _explosionFactory;

    private void Awake()
    {
        _cubeClickHandler.Click += ProcessClickOnCube;
    }

    private void OnDestroy()
    {
        _cubeClickHandler.Click -= ProcessClickOnCube;
    }

    private void ProcessClickOnCube(Cube selected—ube)
    {
        float minProcent = 0f;
        float maxProcent = 100f;
        bool isSplittingUp = Random.Range(minProcent, maxProcent) <= selected—ube.SplitChance;

        if (isSplittingUp)
        {
            List<Cube> cubes = _cubeFactory.SpawnCubes(selected—ube);

            List<Rigidbody> rigidbodiesCubes = new List<Rigidbody>();

            foreach (Cube cube in cubes)
                rigidbodiesCubes.Add(cube.Rigidbody);

            _explosionFactory.Explode(rigidbodiesCubes, selected—ube.transform.position);
        }

        Destroy(selected—ube.gameObject);
    }
}