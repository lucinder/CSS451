using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public Transform selected, LookAt;
    public GameObject PawnW,PawnB,RookW,RookB,KnightW,KnightB,BishopW,BishopB,QueenW,QueenB,KingW,KingB; // prefabs
    enum Turn{WHITE, BLACK};
    Turn current = Turn.WHITE;
    int turnCtr = 0;
    Transform[][] AllTiles;
    List<Transform> WhitePieces, BlackPieces, ValidTiles;
    IDictionary<string,int> ColumnMap = new Dictionary<string,int>();
    IDictionary<string,int> RowMap = new Dictionary<string,int>();
    public Camera Camera1, Camera2;
    // Start is called before the first frame update
    void Start()
    {
        RegisterTiles();
        Populate();
    }

    void RegisterTiles(){
        ValidTiles = new List<Transform>();
        AllTiles = new Transform[8][];
        List<Transform> columns = new List<Transform>();
        columns.Add(gameObject.transform.Find("A"));
        ColumnMap.Add("A",0);
        columns.Add(gameObject.transform.Find("B"));
        ColumnMap.Add("B",1);
        columns.Add(gameObject.transform.Find("C"));
        ColumnMap.Add("C",2);
        columns.Add(gameObject.transform.Find("D"));
        ColumnMap.Add("D",3);
        columns.Add(gameObject.transform.Find("E"));
        ColumnMap.Add("E",4);
        columns.Add(gameObject.transform.Find("F"));
        ColumnMap.Add("F",5);
        columns.Add(gameObject.transform.Find("G"));
        ColumnMap.Add("G",6);
        columns.Add(gameObject.transform.Find("H"));
        ColumnMap.Add("H",7);
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
                tile.GetComponent<Selectable>().LoadBoard();
                AllTiles[i][j] = tile;
                j++;
            }
            Debug.Log(testout2);
            i++;
        }
        RowMap.Add("8",0);
        RowMap.Add("7",1);
        RowMap.Add("6",2);
        RowMap.Add("5",3);
        RowMap.Add("4",4);
        RowMap.Add("3",5);
        RowMap.Add("2",6);
        RowMap.Add("1",7);
    }

    void Populate(){
        WhitePieces = new List<Transform>();
        BlackPieces = new List<Transform>();
        int i = 0;
        bool isWhite = false;
        bool add = false;
        GameObject newPiece = null;
        string PieceName = "";
        foreach(Transform[] column in AllTiles){
            int j = 0;
            foreach(Transform row in column){
                if(i == 0 || i == 7) { // col A and H : rook + pawn
                    if(j == 0){ // black rook
                        PieceName = "BlackRook";
                        newPiece = Instantiate(RookB);
                        isWhite = false; add = true;
                    } else if (j == 7){ // white rook
                        PieceName = "WhiteRook";
                        newPiece = Instantiate(RookW);
                        isWhite = true; add = true;
                    } else if (j == 1){ // black pawn
                        PieceName = "BlackPawn";
                        newPiece = Instantiate(PawnB);
                        isWhite = false; add = true;
                    } else if (j == 6){ // white pawn
                        PieceName = "WhitePawn";
                        newPiece = Instantiate(PawnW);
                        isWhite = true; add = true;
                    } else {
                        add = false;
                    }
                } else if (i == 1 || i == 6){ // col B and G : knight + pawn
                    if(j == 0){ // black knight
                        PieceName = "BlackKnight";
                        newPiece = Instantiate(KnightB);
                        isWhite = false; add = true;
                    } else if (j == 7){ // white knight
                        PieceName = "WhiteKnight";
                        newPiece = Instantiate(KnightW);
                        isWhite = true; add = true;
                    } else if (j == 1){ // black pawn
                        PieceName = "BlackPawn";
                        newPiece = Instantiate(PawnB);
                        isWhite = false; add = true;
                    } else if (j == 6){ // white pawn
                        PieceName = "WhitePawn";
                        newPiece = Instantiate(PawnW);
                        isWhite = true; add = true;
                    } else {
                        add = false;
                    }
                } else if (i == 2 || i == 5){ // col C and F : bishop + pawn
                    if(j == 0){ // black bishop
                        PieceName = "BlackBishop";
                        newPiece = Instantiate(BishopB);
                        isWhite = false; add = true;
                    } else if (j == 7){ // white bishop
                        PieceName = "WhiteBishop";
                        newPiece = Instantiate(BishopW);
                        isWhite = true; add = true;
                    } else if (j == 1){ // black pawn
                        PieceName = "BlackPawn";
                        newPiece = Instantiate(PawnB);
                        isWhite = false; add = true;
                    } else if (j == 6){ // white pawn
                        PieceName = "WhitePawn";
                        newPiece = Instantiate(PawnW);
                        isWhite = true; add = true;
                    } else {
                        add = false;
                    }
                } else if (i == 3){ // col D : queen + pawn
                    if(j == 0){ // black queen
                        PieceName = "BlackQueen";
                        newPiece = Instantiate(QueenB);
                        isWhite = false; add = true;
                    } else if (j == 7){ // white queen
                        PieceName = "WhiteQueen";
                        newPiece = Instantiate(QueenW);
                        isWhite = true; add = true;
                    } else if (j == 1){ // black pawn
                        PieceName = "BlackPawn";
                        newPiece = Instantiate(PawnB);
                        isWhite = false; add = true;
                    } else if (j == 6){ // white pawn
                        PieceName = "WhitePawn";
                        newPiece = Instantiate(PawnW);
                        isWhite = true; add = true;
                    } else {
                        add = false;
                    }
                } else { // col E : king + pawn
                    if(j == 0){ // black king
                        PieceName = "BlackKing";
                        newPiece = Instantiate(KingB);
                        isWhite = false; add = true;
                    } else if (j == 7){ // white king
                        PieceName = "WhiteKing";
                        newPiece = Instantiate(KingW);
                        isWhite = true; add = true;
                    } else if (j == 1){ // black pawn
                        PieceName = "BlackPawn";
                        newPiece = Instantiate(PawnB);
                        isWhite = false; add = true;
                    } else if (j == 6){ // white pawn
                        PieceName = "WhitePawn";
                        newPiece = Instantiate(PawnW);
                        isWhite = true; add = true;
                    } else {
                        add = false;
                    }
                }
                if(add){
                    Debug.Log("Placed a " + PieceName + " at (" + j+1 + ", " + i+1 + ")");
                    newPiece.name = PieceName;
                    newPiece.transform.parent = AllTiles[i][j];
                    AllTiles[i][j].gameObject.GetComponent<Tile>().HasPiece = true;
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
        if(NewSelect.gameObject.GetComponent<Piece>() && ((current == Turn.WHITE && NewSelect.gameObject.GetComponent<White>()) || (current == Turn.BLACK && NewSelect.gameObject.GetComponent<Black>()))){
            selected = NewSelect;
            LoadValids();
            Debug.Log("Selected " + selected.gameObject.name);
        } else if (selected && NewSelect.gameObject.GetComponent<Tile>() && NewSelect.gameObject.GetComponent<Tile>().Valid){
            selected.transform.parent.gameObject.GetComponent<Tile>().HasPiece = false; // remove from this tile
            if(NewSelect.gameObject.GetComponent<Tile>().HasPiece){
                Destroy(NewSelect.gameObject.GetComponent<Tile>().GetPiece().gameObject);
            } else {
                NewSelect.gameObject.GetComponent<Tile>().HasPiece = true; // add to new tile
            }
            selected.transform.parent = NewSelect;
            float startX = selected.transform.localPosition.x;
            float targetX = 0f;
            float startZ = selected.transform.localPosition.z;
            float targetZ = selected.parent.transform.localPosition.z;
            while(selected.transform.localPosition.z < targetZ-0.1f || selected.transform.localPosition.z > targetZ+0.1f){
                selected.transform.localPosition = new Vector3(selected.transform.localPosition.x + ((targetX-startX)*Time.deltaTime/5f),1f, selected.transform.localPosition.z+((targetZ-startZ)*Time.deltaTime/5f));
            }
            selected.transform.localPosition = new Vector3(0f, 1f, selected.transform.parent.localPosition.z);
            ClearValids();
            Debug.Log("Moved " + selected.gameObject.name + " to tile " + NewSelect.parent.gameObject.name + NewSelect.gameObject.name);
            selected = null; // deselect
            // switch turns
            TurnSwitch();
        }
    }

    void LoadValids(){
        ClearValids();
        int i = ColumnMap[selected.parent.transform.parent.gameObject.name];
        int j = RowMap[selected.parent.gameObject.name];
        if(selected.gameObject.name == "WhiteKing" || selected.gameObject.name == "BlackKing"){ // king logic
            if((i-1) >= 0){
                if((j-1) >= 0 && !OccupiedByAlly(i-1,j-1)) ValidTiles.Add(AllTiles[i-1][j-1]);
                if(!OccupiedByAlly(i-1,j)) ValidTiles.Add(AllTiles[i-1][j]);
                if((j+1) <= 7 && !OccupiedByAlly(i-1,j+1)) ValidTiles.Add(AllTiles[i-1][j+1]);
            }
            if((j-1) >= 0 && !OccupiedByAlly(i,j-1)) ValidTiles.Add(AllTiles[i][j-1]);
            if((j+1) <= 7 && !OccupiedByAlly(i,j+1)) ValidTiles.Add(AllTiles[i][j+1]);
            if((i+1) <= 7){
               if((j-1) >= 0 && !OccupiedByAlly(i+1,j-1)) ValidTiles.Add(AllTiles[i+1][j-1]);
                if(!OccupiedByAlly(i-1,j)) ValidTiles.Add(AllTiles[i+1][j]);
                if((j+1) <= 7 && !OccupiedByAlly(i+1,j+1)) ValidTiles.Add(AllTiles[i+1][j+1]); 
            }
        } else if (selected.gameObject.name == "WhiteQueen" || selected.gameObject.name == "BlackQueen"){
            bool Diag1Stopped = false; bool Diag2Stopped = false; bool Diag3Stopped = false; bool Diag4Stopped = false;
            bool Lin1Stopped = false; bool Lin2Stopped = false; bool Lin3Stopped = false; bool Lin4Stopped = false;
            for(int k = 1; k < 8; k++){ // validate directionally until blocked
                if((i-k) >= 0){
                    if(!Diag1Stopped && (j-k) >= 0){
                        if(Occupied(i-k,j-k)) Diag1Stopped = true;
                        if(!OccupiedByAlly(i-k,j-k)){
                            ValidTiles.Add(AllTiles[i-k][j-k]);
                            Debug.Log("Added a valid tile for queen!");
                        }
                    } else {
                        Diag1Stopped = true;
                    }
                    if(!Lin1Stopped){
                        if(Occupied(i-k,j)) Lin1Stopped = true;
                        if(!OccupiedByAlly(i-k,j)){
                            ValidTiles.Add(AllTiles[i-k][j]);
                            Debug.Log("Added a valid tile for queen!");
                        }
                    } else {
                        Lin1Stopped = true;
                    }
                    if(!Diag2Stopped && (j+k) <= 7){
                        if(Occupied(i-k,j+k)) Diag2Stopped = true;
                        if(!OccupiedByAlly(i-k,j+k)){
                            ValidTiles.Add(AllTiles[i-k][j+k]);
                            Debug.Log("Added a valid tile for queen!");
                        }
                    } else {
                        Diag2Stopped = true;
                    }
                }
                if(!Lin2Stopped && (j-k) >= 0){
                    if(Occupied(i,j-k)) Lin2Stopped = true;
                    if(!OccupiedByAlly(i,j-k)){
                        ValidTiles.Add(AllTiles[i][j-k]);
                        Debug.Log("Added a valid tile for queen!");
                    }
                } else {
                    Lin2Stopped = true;
                }
                if(!Lin3Stopped && (j+k) <= 7){
                    if(Occupied(i,j+k)) Lin3Stopped = true;
                    if(!OccupiedByAlly(i,j+k)){
                        ValidTiles.Add(AllTiles[i][j+k]);
                        Debug.Log("Added a valid tile for queen!");
                    }
                } else {
                    Lin3Stopped = true;
                }
                if((i+k) <= 7){
                    if(!Diag3Stopped && (j-k) >= 0){
                        if(Occupied(i+k,j-k)) Diag3Stopped = true;
                        if(!OccupiedByAlly(i+k,j-k)){
                            ValidTiles.Add(AllTiles[i+k][j-k]);
                            Debug.Log("Added a valid tile for queen!");
                        }
                    } else {
                        Diag3Stopped = true;
                    }
                    if(!Lin4Stopped){
                        if(Occupied(i+k,j)) Lin4Stopped = true;
                        if(!OccupiedByAlly(i+k,j)){
                            ValidTiles.Add(AllTiles[i+k][j]);
                            Debug.Log("Added a valid tile for queen!");
                        }
                    } else {
                        Lin4Stopped = true;
                    }
                    if(!Diag4Stopped && (j+k) <= 7){
                        if(Occupied(i+k,j+k)) Diag3Stopped = true;
                        if(!OccupiedByAlly(i+k,j+k)){
                            ValidTiles.Add(AllTiles[i+k][j+k]); 
                            Debug.Log("Added a valid tile for queen!");
                        }
                    } else {
                        Diag4Stopped = true;
                    }
                }
            }
        } else if (selected.gameObject.name == "WhiteBishop" || selected.gameObject.name == "BlackBishop"){
            bool Diag1Stopped = false; bool Diag2Stopped = false; bool Diag3Stopped = false; bool Diag4Stopped = false;
            for(int k = 1; k < 8; k++){ // validate diagonally until blocked
                if((i-k) >= 0){
                    if(!Diag1Stopped && (j-k) >= 0){
                        if(Occupied(i-k,j-k)) Diag1Stopped = true;
                        if(!OccupiedByAlly(i-k,j-k)){
                            ValidTiles.Add(AllTiles[i-k][j-k]);
                            Debug.Log("Added a valid tile for bishop!");
                        }
                    } else {
                        Diag1Stopped = true;
                    }
                    if(!Diag2Stopped && (j+k) <= 7){
                        if(Occupied(i-k,j+k)) Diag2Stopped = true;
                        if(!OccupiedByAlly(i-k,j+k)){
                            ValidTiles.Add(AllTiles[i-k][j+k]);
                            Debug.Log("Added a valid tile for bishop!");
                        }
                    } else {
                        Diag2Stopped = true;
                    }
                }
                if((i+k) <= 7){
                    if(!Diag3Stopped && (j-k) >= 0){
                        if(Occupied(i+k,j-k)) Diag3Stopped = true;
                        if(!OccupiedByAlly(i+k,j-k)){
                            ValidTiles.Add(AllTiles[i+k][j-k]);
                            Debug.Log("Added a valid tile for bishop!");
                        }
                    } else {
                        Diag3Stopped = true;
                    }
                    if(!Diag4Stopped && (j+k) <= 7){
                        if(Occupied(i+k,j+k)) Diag4Stopped = true;
                        if(!OccupiedByAlly(i+k,j+k)){
                            ValidTiles.Add(AllTiles[i+k][j+k]); 
                            Debug.Log("Added a valid tile for bishop!");
                        }
                    } else {
                        Diag4Stopped = true;
                    }
                }
            }
        } else if (selected.gameObject.name == "WhiteRook" || selected.gameObject.name == "BlackRook"){ // rook logic
            bool Lin1Stopped = false; bool Lin2Stopped = false; bool Lin3Stopped = false; bool Lin4Stopped = false;
            for(int k = 1; k < 8; k++){ // validate linearly until blocked
                if((i-k) >= 0 && !Lin1Stopped){
                    if(Occupied(i-k,j)) Lin1Stopped = true;
                    if(!OccupiedByAlly(i-k,j)){
                        ValidTiles.Add(AllTiles[i-k][j]);
                        Debug.Log("Added a valid tile for rook!");
                    }
                }
                if((i+k) >= 0 && !Lin2Stopped){
                    if(Occupied(i+k,j)) Lin2Stopped = true;
                    if(!OccupiedByAlly(i+k,j)){
                        ValidTiles.Add(AllTiles[i+k][j]);
                        Debug.Log("Added a valid tile for rook!");
                    }
                }
                if((j-k) >= 0 && !Lin3Stopped){
                    if(Occupied(i,j-k)) Lin3Stopped = true;
                    if(!OccupiedByAlly(i,j-k)){
                        ValidTiles.Add(AllTiles[i][j-k]);
                        Debug.Log("Added a valid tile for rook!");
                    }
                }
                if((j+k) >= 0 && !Lin4Stopped){
                    if(Occupied(i,j+k)) Lin4Stopped = true;
                    if(!OccupiedByAlly(i,j+k)){
                        ValidTiles.Add(AllTiles[i][j+k]);
                        Debug.Log("Added a valid tile for rook!");
                    }
                }
            }
        } else if(selected.gameObject.name == "WhiteKnight" || selected.gameObject.name == "BlackKnight"){ // knight logic
            if((i-2) >= 0){
                if((j-1) >= 0 && !OccupiedByAlly(i-2,j-1)) ValidTiles.Add(AllTiles[i-2][j-1]);
                if((j+1) <= 7 && !OccupiedByAlly(i-2,j+1)) ValidTiles.Add(AllTiles[i-2][j+1]);
            }
            if((i+2) <= 7){
               if((j-1) >= 0 && !OccupiedByAlly(i+2,j-1)) ValidTiles.Add(AllTiles[i+2][j-1]);
                if((j+1) <= 7 && !OccupiedByAlly(i+2,j+1)) ValidTiles.Add(AllTiles[i+2][j+1]); 
            }
            if((j-2) >= 0){
                if((i-1) >= 0 && !OccupiedByAlly(i-1,j-2)) ValidTiles.Add(AllTiles[i-1][j-2]);
                if((i+1) <= 7 && !OccupiedByAlly(i+1,j-2)) ValidTiles.Add(AllTiles[i+1][j-2]);
            }
            if((j+2) <= 7){
               if((i-1) >= 0 && !OccupiedByAlly(i-1,j+2)) ValidTiles.Add(AllTiles[i-1][j+2]);
                if((i+1) <= 7 && !OccupiedByAlly(i+1,j+2)) ValidTiles.Add(AllTiles[i+1][j+2]); 
            }
        } else if (selected.gameObject.name == "WhitePawn"){ // white pawns go up
            if((j-1) >= 0 && !Occupied(i,j-1)) ValidTiles.Add(AllTiles[i][j-1]);
            if(turnCtr < 2 && (j-2) >= 0 && !Occupied(i,j-2)) ValidTiles.Add(AllTiles[i][j-2]); // turn 1 double movement
            if((j-1) >= 0 && (i-1) >= 0 && Occupied(i-1,j-1) && !OccupiedByAlly(i-1,j-1)) ValidTiles.Add(AllTiles[i-1][j-1]); // taking pieces
            if((j-1) >= 0 && (i+1) <= 7 && Occupied(i+1,j-1) && !OccupiedByAlly(i+1,j-1)) ValidTiles.Add(AllTiles[i+1][j-1]); // taking pieces
        } else if (selected.gameObject.name == "BlackPawn"){ // black pawns go down
            if((j+1) <= 7 && !Occupied(i,j+1)) ValidTiles.Add(AllTiles[i][j+1]);
            if(turnCtr < 2 && (j+2) <= 7 && !Occupied(i,j+2)) ValidTiles.Add(AllTiles[i][j+2]); // turn 1 double movement
            if((j+1) <= 7 && (i-1) >= 0 && Occupied(i-1,j+1) && !OccupiedByAlly(i-1,j+1)) ValidTiles.Add(AllTiles[i-1][j+1]); // taking pieces
            if((j+1) <= 7 && (i+1) <= 7 && Occupied(i+1,j+1) && !OccupiedByAlly(i+1,j+1)) ValidTiles.Add(AllTiles[i+1][j+1]); // taking pieces
        }
        ToggleValids();
    }

    bool Occupied(int x, int y){ return AllTiles[x][y].gameObject.GetComponent<Tile>().HasPiece; }
    bool OccupiedByAlly(int x, int y){ return Occupied(x,y) && ((current == Turn.WHITE && AllTiles[x][y].gameObject.GetComponent<Tile>().PieceIsWhite()) || (current == Turn.BLACK && AllTiles[x][y].gameObject.GetComponent<Tile>().PieceIsBlack())); }

    void ClearValids(){
        ToggleValids();
        ValidTiles = new List<Transform>();
    }

    void ToggleValids(){
        foreach(Transform t in ValidTiles){
            t.gameObject.GetComponent<Tile>().ToggleValid();
        }
    }

    void TurnSwitch(){
        turnCtr++;
        Debug.Log("Current turn is now " + turnCtr);
        if(current == Turn.WHITE) current = Turn.BLACK;
        else current = Turn.WHITE;
        if(Camera1.depth == 0){ // switch cameras
            Destroy(Camera1.GetComponent<CameraManipulation>()); // remove manipulation from camera 1
            Camera2.gameObject.AddComponent<CameraManipulation>(); // add manipulation to camera 2
            Camera2.gameObject.GetComponent<CameraManipulation>().LookAt = LookAt;
            Camera1.depth = 1;
            Camera1.rect = new Rect(0.8f,-0.8f,1f,1f);
            Camera2.depth = 0;
            Camera2.rect = new Rect(0f,0f,1f,1f);
        } else {
            Destroy(Camera2.GetComponent<CameraManipulation>()); // remove manipulation from camera 2
            Camera1.gameObject.AddComponent<CameraManipulation>(); // add manipulation to camera 1
            Camera1.gameObject.GetComponent<CameraManipulation>().LookAt = LookAt;
            Camera2.depth = 1;
            Camera2.rect = new Rect(0.8f,-0.8f,1f,1f);
            Camera1.depth = 0;
            Camera1.rect = new Rect(0f,0f,1f,1f);
        }
    }
}
