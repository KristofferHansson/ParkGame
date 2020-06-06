using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorCollider : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Parkgoer")) // check if parkgoer
        {
            Anchor anchor = gameObject.GetComponent<Anchor>();
            if (!anchor.IsOccupied() && other.gameObject.transform.parent.GetComponent<Parkgoer>().TargetAnchorEquals(anchor))
                anchor.Occupy(other.gameObject.transform.parent.gameObject);
        }
    }
}
