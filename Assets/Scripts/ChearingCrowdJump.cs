using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChearingCrowdJump : MonoBehaviour, IChearingCrowd
{
    public bool IsFinished { get { return !IsRuning(); } }

    private Coroutine coroutine;
    private float time = 0;

    public void Chear()
    {
        coroutine = StartCoroutine(Jump());
    }

    private IEnumerator Jump()
    {

        Vector3 originalPosition = transform.position;
        time = 0;
        while (time < .5f)
        {
            transform.Translate(Vector3.up * Time.deltaTime);
            time = time + Time.deltaTime;
            yield return null;
        }

        while (time < 1f)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
            time = time + Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;
        time = 0;
    }

    private bool IsRuning()
    {
        return time != 0;
    }
}
