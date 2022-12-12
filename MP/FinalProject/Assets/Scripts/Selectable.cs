using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    ChessBoard Board;
    void OnMouseDown(){
        Board.Select(gameObject.transform);
    }
    public void LoadBoard(){
        Transform cur = gameObject.transform;
        while(cur.parent){
            cur = cur.parent;
            if(cur.gameObject.GetComponent<ChessBoard>()){ // set our board
                Board = cur.gameObject.GetComponent<ChessBoard>();
                break;
            }
        }
    }
    public Transform GetBoard(){
        return Board.gameObject.transform;
    }
}
