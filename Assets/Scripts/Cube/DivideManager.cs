using System.Collections.Generic;
using UnityEngine;

public class DivideManager : MonoBehaviour
{
    [SerializeField] private MouseManager _mouseManager;
    [SerializeField] private CubeFactory _cubeFactory;
    [SerializeField] private ExplosionFactory _explosionFactory;

    private void Awake()
    {
        _mouseManager.clickOnCube += HandleCubeDivision;
    }

    private void OnDestroy()
    {
        _mouseManager.clickOnCube -= HandleCubeDivision;
    }

    private void HandleCubeDivision(Cube selected—ube)
    {
        float minProcent = 0f;
        float maxProcent = 100f;
        bool isSplittingUp = Random.Range(minProcent, maxProcent) <= selected—ube.Split—hance;

        if (isSplittingUp)
        {
            List<Cube> newCubes = _cubeFactory.SpawnCubes(selected—ube);

            List<Rigidbody> rigidbodiesNewCubes = new List<Rigidbody>();
            foreach (Cube cube in newCubes)
                rigidbodiesNewCubes.Add(cube.Rigidbody);

            _explosionFactory.Explode(rigidbodiesNewCubes, selected—ube.transform.position);
        }

        Destroy(selected—ube.gameObject);
    }
}