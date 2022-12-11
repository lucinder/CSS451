using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public ChessBoard Board;
    public Transform Piece;
    void OnMouseDown(){
        Board.Select(Piece);
    }
    public void LoadBoard(){
        Transform cur = Piece;
        while(cur.parent){
            cur = cur.parent;
            if(cur.gameObject.GetComponent<ChessBoard>()){ // set our board
                Board = cur.gameObject.GetComponent<ChessBoard>();
                break;
            }
        }
    }
}
