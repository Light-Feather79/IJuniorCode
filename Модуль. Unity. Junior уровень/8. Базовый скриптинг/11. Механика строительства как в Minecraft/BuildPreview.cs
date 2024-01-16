using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPreview : MonoBehaviour
{
    public bool IsActive => gameObject.activeSelf;

    public void Enable() =>
        gameObject.SetActive(true);

    public void Disable() =>
        gameObject.SetActive(false);

    public void SetPosition(Vector3 position) =>
        transform.position = position;
}
