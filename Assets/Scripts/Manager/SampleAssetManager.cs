using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace SB.UI.Sample
{
    /// <summary>
    /// This is just a sample class.
    /// It loads asssets from the resources folder.
    /// </summary>
    public class SampleAssetManager : IUIAssetManager
    {
        private Dictionary<string, AssetBundle> _loadedAssetBundles = new Dictionary<string, AssetBundle>();

        private Dictionary<string, int> _countOfAssetsLoadedFromBundle = new Dictionary<string, int>();

        private Dictionary<UIAsset, object> _loadedAssets = new Dictionary<UIAsset, object>();

        public void LoadAssetAsync<T>(UIAsset definition, Action<T> loaded) where T : UnityEngine.Object
        {
            if (_loadedAssets.TryGetValue(definition, out object asset))
            {
                loaded.Invoke((T)asset);
                return;
            }

            if (_loadedAssetBundles.TryGetValue(definition.Bundle, out AssetBundle assetBundle))
            {
                LoadAssetAsync(assetBundle, definition, loaded);
                return;
            }

            string path = $"{Application.streamingAssetsPath}//{definition.Bundle}";
            StreamReader streamReader = new StreamReader(path);
            AssetBundleCreateRequest assetBundleLoadRequest = AssetBundle.LoadFromStreamAsync(streamReader.BaseStream);
            assetBundleLoadRequest.completed += (async) =>
            {
                _loadedAssetBundles.Add(definition.Bundle, assetBundleLoadRequest.assetBundle);
                _countOfAssetsLoadedFromBundle[definition.Bundle] = 0;
                LoadAssetAsync(assetBundleLoadRequest.assetBundle, definition, loaded);
            };
        }

        public bool IsLoad(UIAsset definition)
        {
            return _loadedAssets.ContainsKey(definition);
        }

        public void UnloadAsset(UIAsset asset)
        {
            if (_loadedAssets.ContainsKey(asset))
            {
                _loadedAssets.Remove(asset);
                _countOfAssetsLoadedFromBundle[asset.Bundle]--;
                if (_countOfAssetsLoadedFromBundle[asset.Bundle] == 0)
                {
                    _loadedAssetBundles[asset.Bundle].Unload(true);
                    _loadedAssetBundles.Remove(asset.Bundle);
                    _countOfAssetsLoadedFromBundle.Remove(asset.Bundle);
                }
            }
        }

        private void LoadAssetAsync<T>(AssetBundle assetBundle, UIAsset definition, Action<T> loaded) where T :UnityEngine.Object
        {
            AssetBundleRequest assetLoadRequest = assetBundle.LoadAssetAsync<T>(definition.Name);
            assetLoadRequest.completed += (async) =>
            {
                _loadedAssets.Add(definition, assetLoadRequest.asset);
                _countOfAssetsLoadedFromBundle[definition.Bundle]++;
                loaded.Invoke((T)assetLoadRequest.asset);
            };
        }
    }
}