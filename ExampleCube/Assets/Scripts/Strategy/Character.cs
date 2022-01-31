using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    IStrategy _strategy;
    MoveStrategy _moveStrategy;
    ScaleStrategy _scaleStrategy;

    void Awake()
    {
        _moveStrategy = new MoveStrategy();
        _scaleStrategy = new ScaleStrategy();
        _strategy = _moveStrategy;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput() {
        if (Input.GetKeyDown(KeyCode.M)) {
            Debug.Log("Change to move strategy");
            _strategy = _moveStrategy;
        } 
        else if (Input.GetKeyDown(KeyCode.S)) {
            Debug.Log("Change to scale strategy");
            _strategy = _scaleStrategy;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            _strategy.Up(gameObject);
        } 
        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            _strategy.Down(gameObject);
        }
    }
}
