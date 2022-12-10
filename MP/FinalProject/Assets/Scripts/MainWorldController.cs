using HelperNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainWorldController : MonoBehaviour {

    public ChessBoard Board;

    private void Start()
    {
        Board.gameObject.SetActive(true);
    }
}
