using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using Unity.Collections;
using TMPro;

public class SetPlayerName : NetworkBehaviour
{
    [SerializeField] private TMP_Text _NameString;
    [SerializeField] private SyncType syncType = SyncType.NetworkVariable;
    public TMP_InputField _playerName;
    public Button _confirmName;

    FixedString32Bytes _playerNameSring = new FixedString32Bytes("");
    NetworkVariable<FixedString32Bytes> _networkName = 
        new NetworkVariable<FixedString32Bytes>(new FixedString32Bytes(""),
            NetworkVariableReadPermission.Everyone,
            NetworkVariableWritePermission.Owner);

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if (IsOwner)
        {
            GameObject temp = GameObject.Find("ConfirmName");
            _confirmName = temp.GetComponent<Button>();
            temp = GameObject.Find("NameField");
            _playerName = temp.GetComponent<TMP_InputField>();
            _confirmName.onClick.AddListener(ChangeName);
        }
        _networkName.OnValueChanged += UpdateName;
        _playerName.text = _networkName.Value.ToString();
    }
    public override void OnNetworkDespawn()
    {
        base.OnNetworkDespawn();
        _networkName.OnValueChanged -= UpdateName;
    }

    private void UpdateName(FixedString32Bytes oldValue, FixedString32Bytes newvalue)
    {
        _NameString.text = newvalue.ToString();
        Debug.Log("ChangedName");
    }

    public void ChangeName()
    {
        switch (syncType)
        {
            case SyncType.RPC:
                _playerNameSring = new FixedString32Bytes(_playerName.text);
                ChangeNameServerRPC(_playerNameSring);
                break;
            case SyncType.NetworkVariable:
                _networkName.Value = new FixedString32Bytes(_playerName.text);
                break;
        }
    }

    [ServerRpc]
    private void ChangeNameServerRPC(FixedString32Bytes name)
    {
        ChangeNameClientRPC(name);
    }
    [ClientRpc]
    private void ChangeNameClientRPC(FixedString32Bytes name)
    {
        _NameString.text = name.ToString();
    }
}

enum SyncType
{
    RPC,
    NetworkVariable
}