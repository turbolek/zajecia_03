using UnityEngine;
using System.Collections;

public class ChearingCrowdJump360 : MonoBehaviour, IChearingCrowd
{
    public bool IsFinished { get { return !IsRuning(); } }

    private Coroutine coroutine;
    private float time = 0;

    public void Chear()
    {
        coroutine = StartCoroutine(Jump360());
    }

    private IEnumerator Jump360()
    {

        Vector3 originalPosition = transform.position;
        float yCoord = 0f;
        time = 0;

        while (time < .5f)
        {
            transform.Rotate(Vector3.right * 360 * Time.deltaTime);
            time = time + Time.deltaTime;
            yCoord += Time.deltaTime;
            transform.position = new Vector3(originalPosition.x, yCoord, originalPosition.z);
            yield return null;
        }

        while (time < 1f)
        {
            transform.Rotate(Vector3.right * 360 * Time.deltaTime);
            time = time + Time.deltaTime;
            yCoord -= Time.deltaTime;
            transform.position = new Vector3(originalPosition.x, yCoord, originalPosition.z);
            yield return null;
        }

        transform.position = originalPosition;
        transform.rotation = Quaternion.identity;
        time = 0;
    }

    private bool IsRuning()
    {
        return time != 0;
    }
}
