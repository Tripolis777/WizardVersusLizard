// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using Cysharp.Threading.Tasks;
using Gameplay.Configs;

namespace Gameplay.Ability
{
    public abstract class AbilityResolver
    {
        public abstract UniTask Resolve();
    }
}