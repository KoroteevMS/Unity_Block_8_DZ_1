using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance;

    public float SplitÑhance => _splitChance;
    public Rigidbody Rigidbody { get; private set; }
    public MeshRenderer MeshRenderer { get; private set; }

    public void Initialize(float splitChance)
    {
        _splitChance = splitChance;
    }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        MeshRenderer = GetComponent<MeshRenderer>();
    }
}