﻿using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace ZBase.UnityScreenNavigator.Core.Views
{
    public abstract class ContainerLayer : Window, IContainerLayer
    {
        public string LayerName { get; private set; }

        public ContainerLayerType LayerType { get; private set; }

        public IContainerLayerManager ContainerLayerManager { get; private set; }

        public Canvas Canvas { get; private set; }

        protected ContainerLayerConfig Config { get; private set; }

        protected UnityScreenNavigatorSettings Settings { get; private set; }

        protected async UniTask InitializeAsync(ContainerLayerConfig config, IContainerLayerManager manager)
        {
            Config = config ?? throw new ArgumentNullException(nameof(config));
            Settings = UnityScreenNavigatorSettings.Instance;

            ContainerLayerManager = manager ?? throw new ArgumentNullException(nameof(manager));
            ContainerLayerManager.Add(this);

            await UniTask.DelayFrame(1);

            LayerName = config.name;
            LayerType = config.layerType;
            
            var canvas = GetComponent<Canvas>();

            if (config.overrideSorting)
            {
                canvas.overrideSorting = true;
                canvas.sortingLayerID = config.sortingLayer.id;
                canvas.sortingOrder = config.orderInLayer;
            }

            Canvas = canvas;
        }
    }
}