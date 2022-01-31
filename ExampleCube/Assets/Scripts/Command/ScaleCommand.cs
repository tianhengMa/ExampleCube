using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCommand : Command
{
    Vector3 _prevScale;
    Vector3 _nextScale;
    public ScaleCommand (CommandProcessor commandProcessor, Vector3 prevScale, Vector3 nextScale) : base(commandProcessor) {
        _prevScale = prevScale;
        _nextScale = nextScale;
    }
    public override IEnumerator Execute()
    {
        Debug.Log("Execute scaling: prev scale: " + _prevScale + " , next scale: " + _nextScale);
        _commandProcessor.commandExecuting = true;
        for (float ratio = 0; ratio < 1; ratio += Time.deltaTime) {
            _commandProcessor.Cube.transform.localScale = Vector3.Lerp(_prevScale, _nextScale, ratio);
            yield return null;
        }
        _commandProcessor.commandExecuting = false;
    }

    public override IEnumerator Undo()
    {
        Debug.Log("Undo scaling: prev scale: " + _prevScale + " , next scale: " + _nextScale);
        _commandProcessor.commandExecuting = true;
        for (float ratio = 0; ratio < 1; ratio += Time.deltaTime) {
            _commandProcessor.Cube.transform.localScale = Vector3.Lerp(_nextScale, _prevScale, ratio);
            yield return null;
        }
        _commandProcessor.commandExecuting = false;
    }
}
