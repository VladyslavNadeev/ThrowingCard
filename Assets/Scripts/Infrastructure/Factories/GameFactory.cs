using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Infrastructure.Factories
{
    public class GameFactory : MonoBehaviour, IGameFactory
    {
        private const string SplineToAimPath = "SplineToAim/SplineToAim";
        private const string CardThrowPath = "CardThrow/CardThrow";
        private const string CardPath = "CardThrow/BlackJoker(Card)";
        
        private const string GameHudPath = "UI/GameHud";
        private const string WinWindowPath = "UI/WinWindow";
        private const string FruitsPath = "Fruits";

        public GameObject CreateCard(Transform position)
        {
            GameObject loadedCard = Resources.Load<GameObject>(CardPath);
            GameObject card = Instantiate(loadedCard, position.position, Quaternion.Euler(0,0,90f), position);
            return card;
        }
        
        public GameObject CreateFruit(Vector3 position)
        {
            List<GameObject> fruits = Resources.LoadAll<GameObject>(FruitsPath).ToList();
            int randomFruitCount = Random.Range(0, fruits.Count);

            GameObject randomFruit = Instantiate(fruits[randomFruitCount], position, quaternion.identity, null);
            return randomFruit;
        }

        public GameObject CreateGameHud()
        {
            GameObject loadedGameHud = Resources.Load<GameObject>(GameHudPath);
            GameObject gameHud = Instantiate(loadedGameHud);
            return gameHud;
        }

        public GameObject CreateCardThrow()
        {
            GameObject loadedCardThrow = Resources.Load<GameObject>(CardThrowPath);
            GameObject cardThrow = Instantiate(loadedCardThrow);
            return cardThrow;
        }

        public GameObject CreateSplineToAim(Vector3 position)
        {
            GameObject loadedSplineToAim = Resources.Load<GameObject>(SplineToAimPath);
            GameObject splineToAim = Instantiate(loadedSplineToAim, position, Quaternion.Euler(-90,0, 180), null);
            return splineToAim;
        }

        public GameObject CreateWinWindow()
        {
            GameObject loadedWinWindow = Resources.Load<GameObject>(WinWindowPath);
            GameObject winWindow = Instantiate(loadedWinWindow);
            return winWindow;
        }
    }
}