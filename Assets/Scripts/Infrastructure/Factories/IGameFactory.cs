using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factories
{
    public interface IGameFactory
    {
        public GameObject CreateCard(Transform position);

        public GameObject CreateFruit(Vector3 position);

        public GameObject CreateGameHud();

        public GameObject CreateCardThrow();

        public GameObject CreateSplineToAim(Vector3 position);

        public GameObject CreateWinWindow();
    }
}