using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject cat, block, box;
    [SerializeField] private GameObject piecePrefab;
    private float catOffset = 0.3f, boxOffset = 0.425f, pieceOffset = 0.1f;
    private float unitLenght = 1.0f;

    private int boardSize = 5;
    // boardState is a boardSizexboardSize matrix taking values 0, 1, 2, 3
    // 0: empty
    // 1: cat
    // 2: box
    // 3: block
    private int[,] boardState = { {1,0,0,0,0},
                                  {0,0,1,0,1},
                                  {0,0,0,0,0},
                                  {1,0,0,0,0},
                                  {0,0,0,0,1} };
    private int numPieces = 4;
    //public List<GameObject> puzzlePiece;
    private int[,,] pieceShape = { {{2,3,0},
                                    {0,3,2},
                                    {0,3,0}},

                                   {{0,0,0},
                                    {2,3,3},
                                    {3,0,0}},

                                   {{0,0,0},
                                    {3,2,3},
                                    {3,0,0}},

                                   {{0,3,0},
                                    {3,2,3},
                                    {0,0,0}},};

    // puzzleState[n] = r,x,y indicating the orientation and position of puzzlePiece[n]
    // i.e. puzzlePiece[n] is rotated by rx90 degrees clockwise,
    // its center is located on the case corresponding to boardState[x][y]
    public int[,] puzzleState = { {3,2,3},
                                  {2,4,3},
                                  {0,0,2},
                                  {1,3,4},};

    // Start is called before the first frame update
    void Start()
    {
        InitializeBoard();
        InitializePuzzle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeBoard()
    {
        for(int i=0;i<boardSize;i++)
        {
            for(int j=0;j<boardSize;j++)
            {
                if (boardState[i,j] == 1)
                {
                    _place(Instantiate(cat), i, j, catOffset);
                }
            }
        }
    }

    void InitializePuzzle()
    {
        List<GameObject> puzzlePiece = new(numPieces);
        for(int n = 0; n < numPieces; n++)
        {
            GameObject newPiece = Instantiate(piecePrefab);
            newPiece.GetComponent<PuzzleBehavior>().index = n;
            newPiece.transform.position = new Vector3(0, 0, 0);
            int r = puzzleState[n, 0];
            int x = puzzleState[n, 1];
            int y = puzzleState[n, 2];
            
            // Create the piece according to pieceShape
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    float a = (i - 1) * unitLenght, b = (j - 1) * unitLenght;
                    Vector3 position = new(a, 4, b);
                    switch (pieceShape[n, i, j])
                    {
                        case 2:
                            Instantiate(box, newPiece.transform, false).transform.position = new(a, boxOffset, b);
                            Instantiate(block, newPiece.transform, false).transform.position = new(a, pieceOffset, b);
                            break;

                        case 3:
                            Instantiate(block, newPiece.transform, false).transform.position = new(a, pieceOffset, b);
                            break;
                    }
                }
            }
            
            puzzlePiece.Add(newPiece);
            _place(newPiece, x, y);
            newPiece.transform.Rotate(0, r * 90, 0);
        }

    }
    void _place(GameObject obj, int i, int j, float offset = 0.0f)
    {
        obj.transform.position = new Vector3((i + 0.5f - boardSize * 0.5f) * unitLenght, offset, (j + 0.5f - boardSize * 0.5f) * unitLenght);
    }
}
