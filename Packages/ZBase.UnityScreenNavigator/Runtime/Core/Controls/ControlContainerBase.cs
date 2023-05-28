﻿using System;
using UnityEngine;
using UnityEngine.UI;
using ZBase.UnityScreenNavigator.Core.Views;

namespace ZBase.UnityScreenNavigator.Core.Controls
{
    [RequireComponent(typeof(RectMask2D))]
    public abstract class ControlContainerBase : ViewContainerBase
    {
        [SerializeField] private string _name;
        [SerializeField] private UnityScreenNavigatorSettings _settings;

        public string ContainerName => _name;

        public override UnityScreenNavigatorSettings Settings
        {
            get
            {
                if (_settings == false)
                {
                    _settings = UnityScreenNavigatorSettings.DefaultSettings;
                }

                return _settings;
            }

            set
            {
                if (value == false)
                    throw new ArgumentNullException(nameof(value));

                _settings = value;
            }
        }

        protected override void Awake()
        {
            var _ = CanvasGroup;
            InitializePool();
        }
    }
}