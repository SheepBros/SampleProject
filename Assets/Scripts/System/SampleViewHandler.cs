using System;
using UnityEngine;
using SimpleDI;

namespace SB.UI.Sample
{
    public class SampleViewHandler : ViewHandler, IInitializable
    {
        private DiContainer _container;

        [Inject]
        public void InitContexts(DiContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {
            base.Initialize(new SampleAssetManager());
        }

        protected override void InstantiateView(UIElement element, Transform parent, Action<GameObject> callback)
        {
            _assetManager.LoadAssetAsync<GameObject>(element.Asset, (asset) =>
            {
                GameObject viewObject = Instantiate(asset, parent);
                Transform viewTransform = viewObject.transform;
                _container.Inject(viewObject);
                callback?.Invoke(viewObject);
            });
        }
    }
}