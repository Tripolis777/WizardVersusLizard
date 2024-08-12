// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Gameplay.Player.Interfaces
{
    public interface IPlayerView
    {
        Transform PlayerTransform { get; }
        Transform ProjectilePivot { get; }
        Animator PlayerAnimator { get; }
    }
}