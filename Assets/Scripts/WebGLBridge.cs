using UnityEngine;
using System.Runtime.InteropServices;

public class WebGLBridge : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SendMessageToNextJS(string message);

    public void SendMessage(string message)
    {
        #if UNITY_WEBGL && !UNITY_EDITOR
            SendMessageToNextJS(message);
        #else
            Debug.Log("Sending message: " + message);
        #endif
    }

    public void ReceiveMessageFromNextJS(string message)
    {
        Debug.Log("Received message from Next.js: " + message);
        // ここでメッセージに基づいて処理を行う
    }
}