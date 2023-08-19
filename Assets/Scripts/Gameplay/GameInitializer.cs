using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Infrastructure.Factories;
using Dreamteck.Splines;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private GameFactory _gameFactory;
    
    private Fruit _createdFruitScript;
    private GameObject _gameHud;

    private void Start()
    {
        Transform spawnCardTransform = GameObject.FindWithTag("CardSpawnPoint").transform;
        
        GameObject[] spawnFruitPoint = GameObject.FindGameObjectsWithTag("FruitSpawnPoint");
        int randomSpawnFruitPoint = Random.Range(0, spawnFruitPoint.Length);
        
        GameObject createdFruit = _gameFactory.CreateFruit(spawnFruitPoint[randomSpawnFruitPoint].transform.position);
        _createdFruitScript = createdFruit.GetComponentInChildren<Fruit>();
        _createdFruitScript.OnCutGameobject += ShowWinPanel;

        GameObject splineToAim = InitSplineToAim(spawnCardTransform);
        CardThrow cardThrow = InitCardThrow(splineToAim, _gameFactory, spawnCardTransform);

        _gameHud = InitGameHud(splineToAim, cardThrow);
    }

    private void OnDisable()
    {
        _createdFruitScript.OnCutGameobject -= ShowWinPanel;
    }

    private void ShowWinPanel()
    {
        StartCoroutine(DelayShowWinWindow());
    }

    private IEnumerator DelayShowWinWindow()
    {
        yield return new WaitForSeconds(4f);
        Destroy(_gameHud);
        GameObject winWindow = _gameFactory.CreateWinWindow();
    }

    private GameObject InitSplineToAim(Transform spawnCardTransform)
    {
        GameObject splineToAim = _gameFactory.CreateSplineToAim(spawnCardTransform.position);
        return splineToAim;
    }

    private CardThrow InitCardThrow(GameObject splineToAim, GameFactory gameFactory, Transform spawnCardTransform)
    {
        GameObject cardThrow = _gameFactory.CreateCardThrow();
        CardThrow cardThrowScript = cardThrow.GetComponent<CardThrow>();

        cardThrowScript.Init(
            splineToAim.GetComponent<SplineComputer>(),
            gameFactory,
            spawnCardTransform);

        cardThrowScript.GetComponentInChildren<DirectionSetter>().Init(
            cardThrowScript,
            splineToAim.GetComponent<SplineComputer>());
        return cardThrowScript;
    }

    private GameObject InitGameHud(GameObject splineToAim, CardThrow cardThrow )
    {
        GameObject gameHud = _gameFactory.CreateGameHud();
        gameHud.GetComponentInChildren<UITapPanel>().Init(
            splineToAim.GetComponent<SplineComputer>().GetComponent<MeshRenderer>(),
            cardThrow);
        return gameHud;
    }
}
