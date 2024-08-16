using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-50)]
public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    private int numPieces = 4;
    public static List<GameObject> puzzlePiece;
    private int I = -1;
    [SerializeField] private Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        GM = this;
        puzzlePiece = new(numPieces);
    }

    // Update is called once per frame
    void Update()
    {
        if (I < 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                pieceSelection();
            }
        }
        else
        {
            //if (Input.GetMouseButtonDown(0))
            {
                float horizontalMouseMove = Input.GetAxis("Mouse X");
                float verticalMouseMove = Input.GetAxis("Mouse Y");
                puzzlePiece[I].transform.Translate(horizontalMouseMove, 0.0f, verticalMouseMove);
            }
        }
        
    }

    void pieceSelection()
    {
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            I = hit.collider.GetComponentInParent<PuzzleBehavior>().index;
        }
    }
}
