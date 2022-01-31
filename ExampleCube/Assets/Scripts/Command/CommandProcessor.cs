using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor : MonoBehaviour
{
    [SerializeField] GameObject _cube;
    public bool commandExecuting = false;
    public GameObject Cube { get {return _cube;}}
    Stack<Command> commandStack;

    void Awake() {
        commandStack = new Stack<Command>();
        commandExecuting = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (!commandExecuting) {
            HandleInput();
        }
    }

    public void ExecuteCommand(Command command) {
        commandStack.Push(command);
        StartCoroutine(command.Execute());
    }

    public void UndoCommand() {
        Debug.Log(commandStack.Count);
        if (commandStack.Count > 0) {
            var command = commandStack.Pop();
            StartCoroutine(command.Undo());
        }
    }

    public void IncreaseSize() {
        var scale = 1.1f * Cube.transform.localScale;
        ExecuteCommand(new ScaleCommand(this, Cube.transform.localScale, scale));
    }

    public void DecreaseSize() {
        var scale = 0.9f * _cube.transform.localScale;
        ExecuteCommand(new ScaleCommand(this, Cube.transform.localScale, scale));
    }

    public void MoveLeft() {
        Vector3 pos = Cube.transform.localPosition + Vector3.left;
        ExecuteCommand(new MoveCommand(this, Cube.transform.localPosition, pos));
    }

    public void MoveRight() {
        Vector3 pos = Cube.transform.localPosition + Vector3.right;
        ExecuteCommand(new MoveCommand(this, Cube.transform.localPosition, pos));
    }

    public void HandleInput() {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            MoveRight();
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            IncreaseSize();
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow)) {
            DecreaseSize();
        }

        else if (Input.GetKeyDown(KeyCode.Backspace)) {
            UndoCommand();
        }
    }
}
