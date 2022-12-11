using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public Transform selected;
    public GameObject PawnW,PawnB,RookW,RookB,KnightW,KnightB,BishopW,BishopB,QueenW,QueenB,KingW,KingB; // prefabs
    enum Turn{WHITE, BLACK};
    Turn current = Turn.WHITE;
    Transform[][] AllTiles;
    List<Transform> WhitePieces;
    List<Transform> BlackPieces;
    // Start is called before the first frame update
    void Start()
    {
        RegisterTiles();
        Populate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RegisterTiles(){
        AllTiles = new Transform[8][];
        List<Transform> columns = new List<Transform>();
        columns.Add(gameObject.transform.Find("A"));
        columns.Add(gameObject.transform.Find("B"));
        columns.Add(gameObject.transform.Find("C"));
        columns.Add(gameObject.transform.Find("D"));
        columns.Add(gameObject.transform.Find("E"));
        columns.Add(gameObject.transform.Find("F"));
        columns.Add(gameObject.transform.Find("G"));
        columns.Add(gameObject.transform.Find("H"));
        /**
        string testout = "All columns pushed: ";
        foreach(Transform c in columns){
            testout += c.gameObject.name + " ";
        }
        Debug.Log(testout);
        **/
        int i = 0;
        foreach(Transform c in columns){
            AllTiles[i] = new Transform[8];
            List<Transform> rows = new List<Transform>();
            rows.Add(c.Find("8"));
            rows.Add(c.Find("7"));
            rows.Add(c.Find("6"));
            rows.Add(c.Find("5"));
            rows.Add(c.Find("4"));
            rows.Add(c.Find("3"));
            rows.Add(c.Find("2"));
            rows.Add(c.Find("1"));
            int j = 0;
            string testout2 = "Rows pushed to column " + c.gameObject.name + ": ";
            foreach(Transform tile in rows){
                testout2 += tile.gameObject.name + " ";
                AllTiles[i][j] = tile;
                j++;
            }
            Debug.Log(testout2);
            i++;
        }
    }

    void Populate(){
        WhitePieces = new List<Transform>();
        BlackPieces = new List<Transform>();
        int i = 0;
        bool isWhite = false;
        bool add = false;
        GameObject newPiece = null;
        foreach(Transform[] column in AllTiles){
            int j = 0;
            foreach(Transform row in column){
                if(i == 0 || i == 7) { // col A and H : rook + pawn
                    if(j == 0){ // black rook
                        Debug.Log("Placed a black rook at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(RookB);
                        isWhite = false; add = true;
                    } else if (j == 7){ // white rook
                        Debug.Log("Placed a white rook at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(RookW);
                        isWhite = true; add = true;
                    } else if (j == 1){ // black pawn
                        Debug.Log("Placed a black pawn at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(PawnB);
                        isWhite = false; add = true;
                    } else if (j == 6){ // white pawn
                        Debug.Log("Placed a white pawn at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(PawnW);
                        isWhite = true; add = true;
                    } else {
                        add = false;
                    }
                } else if (i == 1 || i == 6){ // col B and G : knight + pawn
                    if(j == 0){ // black knight
                        Debug.Log("Placed a black knight at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(KnightB);
                        isWhite = false; add = true;
                    } else if (j == 7){ // white knight
                        Debug.Log("Placed a white knight at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(KnightW);
                        isWhite = true; add = true;
                    } else if (j == 1){ // black pawn
                        Debug.Log("Placed a black pawn at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(PawnB);
                        isWhite = false; add = true;
                    } else if (j == 6){ // white pawn
                        Debug.Log("Placed a white pawn at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(PawnW);
                        isWhite = true; add = true;
                    } else {
                        add = false;
                    }
                } else if (i == 2 || i == 5){ // col C and F : bishop + pawn
                    if(j == 0){ // black bishop
                        Debug.Log("Placed a black bishop at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(BishopB);
                        isWhite = false; add = true;
                    } else if (j == 7){ // white bishop
                        Debug.Log("Placed a white bishop at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(BishopW);
                        isWhite = true; add = true;
                    } else if (j == 1){ // black pawn
                        Debug.Log("Placed a black pawn at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(PawnB);
                        isWhite = false; add = true;
                    } else if (j == 6){ // white pawn
                        Debug.Log("Placed a white pawn at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(PawnW);
                        isWhite = true; add = true;
                    } else {
                        add = false;
                    }
                } else if (i == 3){ // col D : queen + pawn
                    if(j == 0){ // black queen
                        Debug.Log("Placed a black queen at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(QueenB);
                        isWhite = false; add = true;
                    } else if (j == 7){ // white queen
                        Debug.Log("Placed a white queen at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(QueenW);
                        isWhite = true; add = true;
                    } else if (j == 1){ // black pawn
                        Debug.Log("Placed a black pawn at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(PawnB);
                        isWhite = false; add = true;
                    } else if (j == 6){ // white pawn
                        Debug.Log("Placed a white pawn at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(PawnW);
                        isWhite = true; add = true;
                    } else {
                        add = false;
                    }
                } else { // col E : king + pawn
                    if(j == 0){ // black king
                        Debug.Log("Placed a black king at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(KingB);
                        isWhite = false; add = true;
                    } else if (j == 7){ // white king
                        Debug.Log("Placed a white king at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(KingW);
                        isWhite = true; add = true;
                    } else if (j == 1){ // black pawn
                        Debug.Log("Placed a black pawn at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(PawnB);
                        isWhite = false; add = true;
                    } else if (j == 6){ // white pawn
                        Debug.Log("Placed a white pawn at (" + j+1 + ", " + i+1 + ")");
                        newPiece = Instantiate(PawnW);
                        isWhite = true; add = true;
                    } else {
                        add = false;
                    }
                }
                if(add){
                    newPiece.transform.parent = AllTiles[i][j];
                    newPiece.GetComponent<Selectable>().LoadBoard();
                    newPiece.transform.localScale = new Vector3(newPiece.transform.localScale.x*0.8f,newPiece.transform.localScale.y*0.8f,newPiece.transform.localScale.z*0.8f); // make each piece a bit smaller
                    newPiece.transform.localPosition = new Vector3(0f, 1f, newPiece.transform.parent.localPosition.z);
                    Vector3 rot = newPiece.transform.rotation.eulerAngles;
                    rot.y -= 90f; // rotate pieces 90 degrees counterclockwise
                    newPiece.transform.rotation = Quaternion.Euler(rot); 
                    if(isWhite) WhitePieces.Add(newPiece.transform);
                    else BlackPieces.Add(newPiece.transform);
                }
                j++;
            }
            i++;
        }
    }

    public void Select(Transform NewSelect){
        if((current == Turn.WHITE && NewSelect.gameObject.GetComponent<White>()) || (current == Turn.BLACK && NewSelect.gameObject.GetComponent<Black>())){
            selected = NewSelect;
            Debug.Log("Selected " + selected.gameObject.name);
        }
    }
}
