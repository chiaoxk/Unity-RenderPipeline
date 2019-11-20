using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public static class CommandBufferPool
{
    static Stack<CommandBuffer> cmdStack = new Stack<CommandBuffer>();
    public static CommandBuffer Get()
    {
        CommandBuffer cmd = null;
        if (cmdStack.Count == 0)
        {
            cmd = new CommandBuffer();
        }
        else
        {
            cmd = cmdStack.Pop();
        }
        return cmd;
    }

    public static void Release(CommandBuffer cmd)
    {
        if (cmdStack.Contains(cmd))
        {
            Debug.LogError("this is already released");
        }
        else
        {
            cmd.Clear();
            cmdStack.Push(cmd);
        }
    }

}
