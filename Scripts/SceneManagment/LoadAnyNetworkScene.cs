using UnityEngine;
using Unity.Netcode;

public class LoadAnyNetworkScene : NetworkBehaviour
{
    [SerializeField] private string scenename;
    public void LoadScene()
    {
        NetworkManager.Singleton.SceneManager.LoadScene(scenename, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
