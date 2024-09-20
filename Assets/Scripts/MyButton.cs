using UnityEngine;
using UnityEngine.UIElements;
using System.Runtime.InteropServices;

namespace UIToolkitExamplesA
{
    [UxmlElement]
    public partial class MyButton : VisualElement
    {
         [DllImport("__Internal")]
        private static extern void SendMessageToNextJS(string message);
        public new class UxmlFactory : UxmlFactory<MyButton, UxmlTraits> { }

        public MyButton()
        {
            Debug.Log("MyButton");

            //var treeAsset = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Resources/MyButton.uxml");
            var treeAsset = Resources.Load<VisualTreeAsset>("MyButton");
            if (treeAsset != null)
            {
                var container = treeAsset.Instantiate();
                if (container != null)
                {
                    hierarchy.Add(container);
                    var buttonElement = container.Q<Button>("Payment");
                    buttonElement.clicked += () => {SendMessage("Clicked!");};
                }
                else
                {
                    Debug.LogError("Failed to instantiate UXML.");
                }
            }
            else
            {
                Debug.LogError("Failed to load UXML asset for MyButton. Make sure the file is in the Resources folder and the path is correct.");
            }
        }

        public void SendMessage(string message)
        {
            Debug.Log("Sending message");

            #if UNITY_WEBGL && !UNITY_EDITOR
                SendMessageToNextJS(message);
            #else
                Debug.Log("Sending message: " + message);
            #endif
        }
    }
}