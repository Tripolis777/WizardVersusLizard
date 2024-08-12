// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using Gameplay.Service;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<KeyboardPlayerInput>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}