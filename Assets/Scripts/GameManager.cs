using UnityEngine;

public class GameManager : MonoBehaviour
{
    private WebGLBridge webGLBridge;

    void Start()
    {
        webGLBridge = FindObjectOfType<WebGLBridge>();
        if (webGLBridge == null)
        {
            Debug.LogError("WebGLBridge not found in the scene!");
        }
    }

    public void SendMessageToNextJS(string message)
    {
        if (webGLBridge != null)
        {
            webGLBridge.SendMessage(message);
        }
    }

    // 例: ボタンクリック時にメッセージを送信
    public void OnButtonClick()
    {
        SendMessageToNextJS("Button clicked in Unity!");
    }
}