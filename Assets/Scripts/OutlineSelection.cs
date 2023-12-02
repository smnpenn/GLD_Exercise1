using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class OutlineSelection : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI tooltipText;
    private Transform highlight;
    private RaycastHit raycastHit;

    void Update()
    {
        // Highlight
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit))
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Selectable"))
            {
                tooltipText.gameObject.SetActive(true);
                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.yellow;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = 10.0f;
                }
            }
            else
            {
                highlight = null;
                tooltipText.gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (highlight)
            {
                Destroy(highlight.gameObject);
                highlight = null;
            }
        }

    }

}
