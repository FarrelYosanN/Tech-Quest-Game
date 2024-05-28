using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Drag1 : MonoBehaviour
{
    public Vector2 SavePosisi;
    public bool IsDiatasObj;

    Transform SaveObj;
    
    // Start is called before the first frame update
    void Start()
    {
        SavePosisi = transform.position;
    }

    // Update is called once per frame
    void Update() 
    {

    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseUp()
    {
        
        if (IsDiatasObj)
        { 
            {
                transform.SetParent(SaveObj);
                transform.localPosition = Vector3.zero;
                transform.localScale = new Vector2(0.75f, 0.75f);


                SaveObj.GetComponent<SpriteRenderer>().enabled = false;
            }

        }
        else
        {
           transform.position = SavePosisi; 
        }
    }

    private void OnMouseDrag()
    {
        Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Pos;
    }


    private void OnTriggerStay2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Drop"))
        {
            IsDiatasObj = true;
            SaveObj = trig.gameObject.transform;
        }
    }  

    
    private void OnTriggerExit2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Drop"))
        {
            IsDiatasObj = false;
        }
    }

}