using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    [SerializeField] private Anchor[] anchors;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Anchor[] GetAnchors(bool onlyAvailableAnchors = false)
    {
        if (!onlyAvailableAnchors)
            return anchors;
        else
        {
            List<Anchor> anchorsFiltered = new List<Anchor>();
            for (int i = 0; i < anchors.Length; i++)
            {
                if (!anchors[i].IsOccupied())
                    anchorsFiltered.Add(anchors[i]);
            }
            return anchorsFiltered.ToArray();
        }
    }
}
