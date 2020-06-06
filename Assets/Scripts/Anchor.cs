using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    private GameObject occupying; // Game object which occupies this anchor, if any
    
    public bool IsOccupied()
    {
        return occupying;
    }

    public bool IsOccupiedBy(GameObject target)
    {
        //print(occupying);
        //print(target);
        if (occupying && target == occupying)
            return true;
        else
            return false;
    }

    public void Occupy(GameObject target)
    {
        occupying = target;
    }

    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }
}
