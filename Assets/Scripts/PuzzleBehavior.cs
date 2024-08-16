using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBehavior : MonoBehaviour
{
    public int index;
    public bool selected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void move(float x, float y, float z)
    {
        transform.Translate(x, y, z);
    }

    //public void HandleSelection()
    //{
    //    // start of code cut from GetMouseButtonDown(0) check
    //    var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        // the collider could be children of the unit, so we make sure to check in the parent
    //        var unit = hit.collider.GetComponentInParent<Unit>();
    //        m_Selected = unit;


    //        // check if the hit object have a IUIInfoContent to display in the UI
    //        // if there is none, this will be null, so this will hid the panel if it was displayed
    //        var uiInfo = hit.collider.GetComponentInParent<UIMainScene.IUIInfoContent>();
    //        UIMainScene.Instance.SetNewInfoContent(uiInfo);
    //    }
    //    // end of code cut from GetMouseButtonDown(0) check
    //}
}
