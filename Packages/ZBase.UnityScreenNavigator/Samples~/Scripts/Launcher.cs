﻿using ZBase.UnityScreenNavigator.Core.Screens;
using ZBase.UnityScreenNavigator.Core;
using ZBase.UnityScreenNavigator.Core.Views;
using Cysharp.Threading.Tasks;
using ZBase.UnityScreenNavigator.Core.Windows;

namespace Demo.Scripts
{
    public class Launcher : UnityScreenNavigatorLauncher
    {
        public static WindowContainerManager ContainerManager { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            ContainerManager = this;
        }

        protected override void Start()
        {
            base.Start();
            ShowTopPage().Forget();
        }

        private async UniTaskVoid ShowTopPage()
        {
            var options = new ViewOptions(ResourceKey.TopScreenPrefab(), false, loadAsync: false);
            await ContainerManager.Find<ScreenContainer>(ContainerKey.Screens).PushAsync(options);
        }
    }
}