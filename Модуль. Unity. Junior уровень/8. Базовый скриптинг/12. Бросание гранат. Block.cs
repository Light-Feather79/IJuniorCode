using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Block : MonoBehaviour
{
    public void Destroy() =>
        Destroy(gameObject);
}
