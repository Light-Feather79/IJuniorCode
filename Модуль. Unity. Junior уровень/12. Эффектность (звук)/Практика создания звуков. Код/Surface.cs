using UnityEngine;

public class Surface : MonoBehaviour
{
    [SerializeField] private SurfaceType _type;

    public SurfaceType Type => _type;
}