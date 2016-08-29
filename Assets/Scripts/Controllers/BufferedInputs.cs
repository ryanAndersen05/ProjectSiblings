using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BufferedInputs {
    Dictionary<string, InputNode> bufferedInputs = new Dictionary<string, InputNode>();

    public void addInputNode(string inputName, float bufferTime)
    {
        InputNode iNode = new InputNode(inputName, bufferTime);
        bufferedInputs.Add(inputName, iNode);
    }

    public void addInputNode(string inputName)
    {
        addInputNode(inputName, .07f);
    }

    public void updateInputs()
    {
        foreach (InputNode i in bufferedInputs.Values)
        {
            i.updateBuffer(Time.deltaTime);
        }
    }

    public void resetBuffer(string inputName)
    {
        if (Input.GetButtonDown(inputName))
        {
            bufferedInputs[inputName].resetBuffer();
        }
    }

    public void cancelBuffer(string inputName, bool cancel)
    {
        if (cancel)
        {
            bufferedInputs[inputName].cancelBuffer();
        }
    }

    public bool isActive(string inputName)
    {
        return bufferedInputs[inputName].isActive();
    }


    private class InputNode
    {
        float maxBuffer;
        float bufferedCount;

        public InputNode(string inputName, float maxBuffer)
        {
            this.maxBuffer = maxBuffer;
        }

        public void resetBuffer()
        {
            bufferedCount = maxBuffer;
        }

        public void cancelBuffer()
        {
            bufferedCount = 0;
        }

        public void updateBuffer(float deltaTime)
        {
            bufferedCount = Mathf.MoveTowards(bufferedCount, 0, deltaTime);
        }

        public bool isActive()
        {
            return bufferedCount > 0;
        }
    }
}
