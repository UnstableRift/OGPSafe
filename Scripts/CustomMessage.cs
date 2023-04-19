using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class CustomMessage : NetworkBehaviour
{
    [SerializeField] private Button sendButton;
    // Start is called before the first frame update
    public override void OnNetworkSpawn()
    {
        NetworkManager.Singleton.CustomMessagingManager.RegisterNamedMessageHandler("Hello", ReadMessage);
        sendButton.onClick.AddListener(SendMessage);
    }

    // Update is called once per frame
    void ReadMessage(ulong clientID, FastBufferReader messageBuffer)
    {
        string message;
        messageBuffer.ReadValueSafe(out message);
        Debug.Log(message);
    }
    void SendMessage()
    {
        if(NetworkManager.Singleton.IsClient)
        {
            FastBufferWriter writer = new FastBufferWriter(258, Unity.Collections.Allocator.Temp);
            using (writer)
            {
                writer.WriteValueSafe("Hello form the other side.");
            }
            NetworkManager.Singleton.CustomMessagingManager.SendNamedMessage("Hello", NetworkManager.ServerClientId, writer);
        }
    }
}
