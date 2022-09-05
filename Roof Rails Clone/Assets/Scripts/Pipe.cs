using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public PlayerMovement PlayerMovement;

    public LayerMask RailLayerMask;

    private Rigidbody rigidBody;

    private List<Rail> collidingRails = new List<Rail>();

    public event Action OnExtensionCollected;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rigidBody = GetComponent<Rigidbody>();
    }

    public void AddRail(Rail rail)
    {
        if (collidingRails.Contains(rail))
        {
            return;
        }

        collidingRails.Add(rail);
    }

    public void RemoveRail(Rail rail)
    {
        if (!collidingRails.Contains(rail))
        {
            return;
        }

        collidingRails.Remove(rail);
    }

    public void Extend()
    {
        transform.localScale += Vector3.up * ExtensionAmount;
        OnExtensionCollected?.Invoke();
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

        GameObject cutInstance = Instantiate(PipePrefab, spawnPosition, transform.rotation);
        cutInstance.transform.localScale = new Vector3(transform.localScale.x, cutScaleY, transform.localScale.z);
        float remainingScaleY = transform.localScale.y - cutScaleY;
        float cutTargetRotation;
        Vector3 newDir;
        Vector3 newPos;

        if (cutPoint.x - transform.position.x >= 0)
        {
            newDir = new Vector3(cutPoint.x, center.y, center.z) - min;
            newPos = min + (newDir / 2.0f);
            cutTargetRotation = -90f;
        }
        else
        {
            newDir = max - new Vector3(cutPoint.x, max.y, max.z);
            newPos = cutPoint + newDir/2.0f;
            cutTargetRotation = 90f;
        }

        cutInstance.GetComponent<PipeCut>().RotateTo(cutTargetRotation);
        Destroy(cutInstance.gameObject, 1.5f);
        transform.position = newPos;
        transform.localScale = new Vector3(transform.localScale.x, remainingScaleY, transform.localScale.z);
        StartCoroutine(Recenter());
    }

    IEnumerator Recenter()
    {
        yield return new WaitForSeconds(recenterDelay);
        needRecenter = true;
    }

    private void Update()
    {
        if (transform.parent == null)
        {
            return;
        }

        if (collidingRails.Any())
        {
            CheckIfLostBalance();
        }

        if (!needRecenter)
        {
            return;
        }

        if (Mathf.Abs(transform.localPosition.x) <= 0.001f)
        {
            transform.localPosition = new Vector3(0f, transform.localPosition.y, transform.localPosition.z);
            needRecenter = false;
            return;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0f, transform.localPosition.y, transform.localPosition.z), Time.deltaTime * recenterSpeed);
    }

    void CheckIfLostBalance()
    {
        if (collidingRails.Count == 1)
        {
            gameObject.transform.SetParent(null);
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            collidingRails.Clear();        
        }
    }
}
