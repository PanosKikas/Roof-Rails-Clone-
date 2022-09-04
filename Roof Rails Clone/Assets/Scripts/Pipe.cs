using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    private float ExtensionAmount = 0.1f;

    private MeshRenderer meshRenderer;

    public GameObject PipePrefab;

    public float cutForce = 100f;

    public float recenterSpeed = 10f;
    public bool needRecenter = false;

    public float recenterDelay = 1.25f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Extend()
    {
        transform.localScale += Vector3.up * ExtensionAmount;
    }

    public void Cut(Vector3 cutPoint)
    {
        Vector3 center = meshRenderer.bounds.center;
        Vector3 min = new Vector3(meshRenderer.bounds.min.x, center.y, center.z);
        Vector3 max = new Vector3(meshRenderer.bounds.max.x, center.y, center.z);
        Vector3 dir;
        Vector3 spawnPosition;
        if (cutPoint.x - transform.position.x >= 0)
        {
            dir = max - new Vector3(cutPoint.x, center.y, center.z);
            spawnPosition = new Vector3(cutPoint.x, center.y, center.z) + (dir / 2.0f);
        }
        else
        {
            dir = new Vector3(cutPoint.x, min.y, min.z) - min;
            spawnPosition = min + (dir/2.0f);
        }
             
        float cutScaleY = dir.magnitude * 0.5f;
        if (cutScaleY <= 0.09f)
        {
            return;
        }

        GameObject cutInstance  = Instantiate(PipePrefab, spawnPosition, transform.rotation);
        cutInstance.transform.localScale = new Vector3(transform.localScale.x, cutScaleY, transform.localScale.z);
        cutInstance.GetComponent<Rigidbody>().AddForce(-1 * cutInstance.transform.forward * cutForce, ForceMode.Impulse);
        float remainingScaleY = transform.localScale.y - cutScaleY;

        Vector3 newDir;
        Vector3 newPos;

        if (cutPoint.x - transform.position.x >= 0)
        {
            newDir = new Vector3(cutPoint.x, center.y, center.z) - min;
            newPos = min + (newDir / 2.0f);
        }
        else
        {
            newDir = max - new Vector3(cutPoint.x, max.y, max.z);
            newPos = cutPoint + newDir/2.0f;
        }

        transform.position = newPos;
        transform.localScale = new Vector3(transform.localScale.x, remainingScaleY, transform.localScale.z);
        Debug.LogError("Min:" + min + "Direction: " +  dir + "Spawn position: " + spawnPosition + " scale Y:" + cutScaleY);
        StartCoroutine(Recenter());
    }

    IEnumerator Recenter()
    {
        yield return new WaitForSeconds(recenterDelay);
        needRecenter = true;
    }

    private void Update()
    {
        if (!needRecenter)
        {
            return;
        }

        if (transform.localPosition.x == 0f)
        {
            needRecenter = false;
            return;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0f, transform.localPosition.y, transform.localPosition.z), Time.deltaTime * recenterSpeed);
    }
}
