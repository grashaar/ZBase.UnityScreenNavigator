using System;
using ZBase.UnityScreenNavigator.Core.Screens;
using ZBase.UnityScreenNavigator.Core.Windows;

namespace Demo.Scripts
{
    public class HomeLoadingScreen : Screen
    {
        public override void DidPushEnter(Memory<object> args)
        {
            var options = new WindowOptions(ResourceKey.HomePagePrefab(), true);
            // Transition to "Home".
            ScreenContainer.Of(transform).Push(options);
        }
    }
}