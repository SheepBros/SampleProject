using UnityEngine;
using SimpleDI;
using SB.Async;

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

        protected override IPromise<UIElement, GameObject> InstantiateView(UIElement element, Transform parent)
        {
            Promise<UIElement, GameObject> promise = new Promise<UIElement, GameObject>();
            if (_precachedViews.TryGetValue(element, out GameObject cachedView))
            {
                promise.Resolve(element, cachedView);
                return promise;
            }

            _assetManager.LoadAssetAsync<GameObject>(element.Asset, (asset) =>
            {
                GameObject viewObject = Instantiate(asset, parent);
                Transform viewTransform = viewObject.transform;
                _container.Inject(viewObject);
                promise.Resolve(element, viewObject);
            });
            return promise;
        }
    }
}