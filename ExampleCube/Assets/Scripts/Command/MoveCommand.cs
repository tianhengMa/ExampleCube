using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    Vector3 _prevPosition;
    Vector3 _nextPosition;
    public MoveCommand (CommandProcessor commandProcessor, Vector3 prevPosition, Vector3 nextPosition) : base(commandProcessor) {
        _prevPosition = prevPosition;
        _nextPosition = nextPosition;
    }
    public override IEnumerator Execute()
    {
        Debug.Log("Execute move: prev position: " + _prevPosition + " , next position: " + _nextPosition);
        _commandProcessor.commandExecuting = true;
        for (float ratio = 0; ratio < 1; ratio += Time.deltaTime) {
            _commandProcessor.Cube.transform.localPosition = Vector3.Lerp(_prevPosition, _nextPosition, ratio);
            yield return null;
        }
        _commandProcessor.commandExecuting = false;
    }

    public override IEnumerator Undo()
    {
        Debug.Log("Undo move: prev position: " + _prevPosition + " , next position: " + _nextPosition);
        _commandProcessor.commandExecuting = true;
        for (float ratio = 0; ratio < 1; ratio += Time.deltaTime) {
            _commandProcessor.Cube.transform.localPosition = Vector3.Lerp(_nextPosition, _prevPosition, ratio);
            yield return null;
        }
        _commandProcessor.commandExecuting = false;
    }
}
