using UnityEngine;
using System.Collections;

public class ChearingCrowdCreateAndDestroy : MonoBehaviour, IChearingCrowd
{

    public bool IsFinished { get { return !isRunning; } }

    private Coroutine coroutine;
    [SerializeField]
    private GameObject objectToCreatePrefab;

    private bool isRunning = false;

    public void Chear()
    {
        coroutine = StartCoroutine(CreateAndDestroy());
    }

    private IEnumerator CreateAndDestroy()
    {
        isRunning = true;
        GameObject objectInstance = null;

        if (objectToCreatePrefab != null)
        {
            objectInstance = Instantiate(objectToCreatePrefab, transform);
            objectInstance.transform.position = transform.position;
        }

        yield return new WaitForSeconds(1f);

        if (objectInstance != null)
            Destroy(objectInstance);

        isRunning = false;
    }
}
