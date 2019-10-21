using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public Camera cam;

    public string birdTag = "Bird";
    public string groundTag = "Ground";

    private List<Transform> selectedUnits = new List<Transform>();

    private Vector3 targetPos = Vector3.zero;

    public Transform moveCollider;

    public LayerMask mask;

    private void OnClick()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 10000, mask))
        {
            if (hit.transform.gameObject.CompareTag(birdTag))
            {
                if (hit.transform.gameObject.GetComponent<Entity>().selected)
                {
                    hit.transform.gameObject.GetComponent<Entity>().selected = false;
                    hit.transform.gameObject.GetComponent<Renderer>().enabled = false;
                    selectedUnits.Remove(hit.transform);
                }
                else
                {
                    hit.transform.gameObject.GetComponent<Entity>().selected = true;
                    hit.transform.gameObject.GetComponent<Renderer>().enabled = true;
                    selectedUnits.Add(hit.transform);
                }
            }
            else if (hit.transform.gameObject.CompareTag(groundTag))
            {
                targetPos = hit.point;
                for (int i = 0; i < selectedUnits.Count; i++)
                {
                    selectedUnits[i].gameObject.GetComponent<Entity>().MoveTo(targetPos);
                    moveCollider.position = targetPos;
                }
            }
        }
    }



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }
}
