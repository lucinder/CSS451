using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    public bool HasPiece = false;
    public bool Valid = false;
    Material DefaultMaterial;
    public Material WhiteMaterial, BlackMaterial, ValidMaterial;
    void Start()
    {
        Debug.Log("Logging tilename: " + gameObject.name);
        if(int.Parse(gameObject.name)%2 == 0 && (gameObject.transform.parent.gameObject.name.Equals("A") || gameObject.transform.parent.gameObject.name.Equals("C") || gameObject.transform.parent.gameObject.name.Equals("E") || gameObject.transform.parent.gameObject.name.Equals("G"))){
            DefaultMaterial = WhiteMaterial;
        } else if (int.Parse(gameObject.name)%2 == 1 && (gameObject.transform.parent.gameObject.name.Equals("B") || gameObject.transform.parent.gameObject.name.Equals("D") || gameObject.transform.parent.gameObject.name.Equals("F") || gameObject.transform.parent.gameObject.name.Equals("H"))){
            DefaultMaterial = WhiteMaterial;
        } else {
            DefaultMaterial = BlackMaterial;
        }
    }

    public Transform GetPiece(){
        if(gameObject.transform.Find("WhitePawn")) return gameObject.transform.Find("WhitePawn");
        if(gameObject.transform.Find("WhiteRook")) return gameObject.transform.Find("WhiteRook");
        if(gameObject.transform.Find("WhiteKnight")) return gameObject.transform.Find("WhiteKnight");
        if(gameObject.transform.Find("WhiteBishop")) return gameObject.transform.Find("WhiteBishop");
        if(gameObject.transform.Find("WhiteQueen")) return gameObject.transform.Find("WhiteQueen");
        if(gameObject.transform.Find("WhiteKing")) return gameObject.transform.Find("WhiteKing");
        if(gameObject.transform.Find("BlackPawn")) return gameObject.transform.Find("BlackPawn");
        if(gameObject.transform.Find("BlackRook")) return gameObject.transform.Find("BlackRook");
        if(gameObject.transform.Find("BlackKnight")) return gameObject.transform.Find("BlackKnight");
        if(gameObject.transform.Find("BlackBishop")) return gameObject.transform.Find("BlackBishop");
        if(gameObject.transform.Find("BlackQueen")) return gameObject.transform.Find("BlackQueen");
        if(gameObject.transform.Find("BlackKing")) return gameObject.transform.Find("BlackKing");
        return null;
    }

    public bool PieceIsWhite(){
        return HasPiece && (gameObject.transform.Find("WhitePawn") || gameObject.transform.Find("WhiteRook") || gameObject.transform.Find("WhiteKnight") || gameObject.transform.Find("WhiteBishop") || gameObject.transform.Find("WhiteQueen") || gameObject.transform.Find("WhiteKing"));
    }

    public bool PieceIsBlack(){
        return HasPiece && (gameObject.transform.Find("BlackPawn") || gameObject.transform.Find("BlackRook") || gameObject.transform.Find("BlackKnight") || gameObject.transform.Find("BlackBishop") || gameObject.transform.Find("BlackQueen") || gameObject.transform.Find("BlackKing"));
    }

    // Update is called once per frame
    public void ToggleValid()
    {
        Valid = !Valid;
        if(Valid){
            gameObject.GetComponent<Renderer>().material = ValidMaterial;
        } else {
            gameObject.GetComponent<Renderer>().material = DefaultMaterial;
        }
    }
}
