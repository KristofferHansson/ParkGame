using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parkgoer : MonoBehaviour
{
    [SerializeField] private float maxSpd = -1.0f; // default val causes random
    private float spd;

    private GameObject targetObject; // Where the parkgoer is headed
    private ObjectInfo targetObjectInfo;
    private Anchor targetAnchor;
    private Rigidbody rb;
    private GameObject[] potentialTargetObjects;

    // Start is called before the first frame update
    void Start()
    {
        if (maxSpd == -1.0f)
        {
            // Randomize max speed
            maxSpd = Random.Range(5f, 10f);
        }
        spd = maxSpd;

        rb = GetComponent<Rigidbody>();
        SelectNewTargetObject();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = transform.position;

        if (targetObject)
        {
            // Move towards target anchor if object uses anchor as target
            if (targetAnchor)
            {
                // If anchor is invalid (no longer available)
                // Occupied by different PG?
                if (targetAnchor.IsOccupied() && !targetAnchor.IsOccupiedBy(gameObject))
                {
                    SelectNewTargetAnchor();
                }
            }
            // Else prepare to move towards target object position
            else
            {
                targetPosition = targetObject.transform.position; // default target pos to targetobject position
                SelectNewTargetAnchor();
            }
            if (targetAnchor)
                targetPosition = targetAnchor.GetPosition();
        }

        // Apply movement
        // Move in direction of target until close
        float distToTarget = Vector3.Distance(transform.position, targetPosition);
        if (distToTarget > 0.1f)
        {
            Vector3 trans = transform.position + (targetPosition - transform.position).normalized * Time.deltaTime * spd * 0.2f;
            trans.y = 0;
            trans += 0.02f * Physics.gravity * Time.deltaTime;
            rb.MovePosition(trans);
        }
    }

    private void SelectNewTargetObject()
    {
        potentialTargetObjects = GameObject.FindGameObjectsWithTag("ParkElement");
        if (potentialTargetObjects.Length > 0)
        {
            int ind = Random.Range(0, potentialTargetObjects.Length);
            targetObject = potentialTargetObjects[ind];
            targetObjectInfo = targetObject.GetComponent<ObjectInfo>();
        }
    }

    // Selects new anchor of current target objectinfo
    // Sets to null if no anchors available or no target object
    private void SelectNewTargetAnchor()
    {
        // If target has objInfo and objInfo has anchors, use one of the anchors as target pos
        if (targetObjectInfo)
        {
            Anchor[] anchors = targetObjectInfo.GetAnchors(true);
            if (anchors.Length > 0)
            {
                //print(anchors[0]);
                targetAnchor = anchors[0];
            }
            // No valid anchors
            else
            {
                // Clear all targets -- change to selecting another object once method takes into account fullness
                targetObject = null;
                targetObjectInfo = null;
                targetAnchor = null;
            }

        }
        else
        {
            targetAnchor = null;
        }
    }


    public bool TargetAnchorEquals(Anchor comp)
    {
        return targetAnchor == comp;
    }

    public void SetRunning(bool tf)
    {
        if (tf)
            spd = maxSpd;
        else
            spd = 0.5f * maxSpd;
    }
}
