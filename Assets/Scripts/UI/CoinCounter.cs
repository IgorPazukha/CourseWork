using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HasChangeCoin += ChangeCoin;
    }

    private void OnDisable()
    {
        _player.HasChangeCoin -= ChangeCoin;
    }

    private void ChangeCoin(int coin)
    {
        _text.text = coin.ToString();
    }
}