using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    [SerializeField] private Material highlightMat;
    private GameObject selectedObject;
    private Material[] oldMats;
    private Vector3 mvStart; // cursor hit location at start of move operation
    private Vector3 objStart; // selectedobject position at start of move operation

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Object selection
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                //print("Clicked on " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag.Equals("SelectableObject"))
                {
                    //print(hitInfo.transform.gameObject.name + " selected");
                    // Revert materials of previously selected object
                    if (selectedObject)
                        selectedObject.GetComponentInChildren<MeshRenderer>().materials = oldMats;

                    // Add highlight mat to newly selected object
                    selectedObject = hitInfo.transform.gameObject.transform.parent.gameObject;
                    MeshRenderer mesh = selectedObject.GetComponentInChildren<MeshRenderer>();
                    int idx = mesh.materials.Length - 1;
                    oldMats = mesh.materials;
                    Material[] temp = mesh.materials;
                    temp[idx] = highlightMat;
                    mesh.materials = temp;
                }
                // If left clicked on something other than selectable object, deselect current
                else if (Input.GetMouseButtonDown(0))
                {
                    if (selectedObject)
                        selectedObject.GetComponentInChildren<MeshRenderer>().materials = oldMats;
                    selectedObject = null;
                }
            }
        }
        // Object movement
        if (selectedObject)
        {
            // Set movement start point
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 10000, (1 << 8));
                mvStart = hitInfo.point;
                objStart = selectedObject.transform.position;
            }
            if (Input.GetMouseButton(1))
            {
                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 10000, (1 << 8));
                if (hit)
                {
                    selectedObject.transform.position = objStart + (hitInfo.point - mvStart);
                }
            }
        }

        // Object rotation
        if (selectedObject)
        {
            int rot = 0;
            if (Input.GetKey(KeyCode.Q))
            {
                rot++;
            }
            if (Input.GetKey(KeyCode.E))
            {
                rot--;
            }
            if (rot != 0)
            {
                selectedObject.transform.Rotate(0, 50 * rot * Time.deltaTime, 0);
            }
        }
    }
}
