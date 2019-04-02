using UnityEngine;
using System.Collections;

public class ChearingCrowdStepForward : MonoBehaviour, IChearingCrowd
{

    public bool IsFinished { get { return !IsRuning(); } }

    private Coroutine coroutine;
    private float time = 0;

    public void Chear()
    {
        coroutine = StartCoroutine(StepForwardAndBack());
    }

    private IEnumerator StepForwardAndBack()
    {

        Vector3 originalPosition = transform.position;
        time = 0;
        while (time < .5f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            time = time + Time.deltaTime;
            yield return null;
        }

        while (time < 1f)
        {
            transform.Translate(Vector3.back * Time.deltaTime);
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
