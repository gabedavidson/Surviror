using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float TextFloatSpeed = 1f;

    void Start()
    {
        StartCoroutine(DestroyTimer());
    }

    void Update()
    {
        gameObject.transform.Translate(0, TextFloatSpeed * Time.deltaTime, 0);
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
