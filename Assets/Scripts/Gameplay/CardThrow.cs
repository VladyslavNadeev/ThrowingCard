using Assets.Scripts.Infrastructure.Factories;
using UnityEngine;
using Dreamteck.Splines;
using UnityEngine.Serialization;

public class CardThrow : MonoBehaviour
{
    [SerializeField] private bool _canThrow;

    private Card _card;
    private SplineComputer _splineComputer;
    private GameFactory _gameFactory;
    private Transform _spawnPointCard;

    public bool CanThrow
    {
        get => _canThrow;
        set => _canThrow = value;
    }

    public void Init(
        SplineComputer splineComputer,
        GameFactory gameFactory,
        Transform spawnPointCard)
    {
        _spawnPointCard = spawnPointCard;
        _gameFactory = gameFactory;
        _splineComputer = splineComputer;
        InitCardAndSetCardPath();
    }

    private void InitCardAndSetCardPath()
    {
        GameObject card = _gameFactory.CreateCard(_spawnPointCard);
        _card = card.GetComponent<Card>();
        _card.Init();
        _card.SetPath(_splineComputer);

        //Some delay needed, because card appear With animation
        Invoke("AllowThrow", 0.3f);
    }
    
    public void Throwing()
    {
        _card.ThrowCard();
        CanThrow = false;
        Invoke("InitCardAndSetCardPath", 1f);
    }

    private void AllowThrow()
    {
            CanThrow = true;
    }
}