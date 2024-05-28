using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Obj_Drag : MonoBehaviour
{
    [HideInInspector]public Vector2 SavePosisi;
    [HideInInspector]public bool IsDiatasObj;

    Transform SaveObj;

    public int ID;
    public Text Teks;
    
    [Space]

    public UnityEvent OnDragBenar;
    
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
		int ID_TempatDrop = SaveObj.GetComponent<Tempat_Drop>().ID;

		if(ID == ID_TempatDrop)
                {
			        transform.SetParent(SaveObj);
                	transform.localPosition = Vector3.zero;
                	transform.localScale = new Vector2(1f, 1f);
                    
                    SaveObj.GetComponent<SpriteRenderer>().enabled = false;
                    SaveObj.GetComponent<Rigidbody2D>().simulated = false;
                    SaveObj.GetComponent<BoxCollider2D>().enabled = false;

                    gameObject.GetComponent<BoxCollider2D>().enabled = false;

                    OnDragBenar.Invoke();

                    // ini jika sukses
                    GameSystem.instance.DataSaatIni++;
                    Data.DataScore += 200;

                }
		else
		{
			transform.position = SavePosisi; 

                    // jika salah
                    Data.DataDarah--;
		}

        }
        else
        {
           transform.position = SavePosisi; 

           // jika tempat tidak ada
        }
    }

    private void OnMouseDrag()
    {
        if(!GameSystem.instance.GameSelesai)
        {
            Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Pos;
        }
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