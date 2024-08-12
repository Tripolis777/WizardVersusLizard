// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using System;
using UnityEngine;

namespace Gameplay.Service
{
    public interface IPlayerInputService
    {
        public event Action<PlayerAction> OnAction;

        public Vector3 MoveDirection { get; }
    }

    public enum PlayerAction
    {
        None,
        Cast,
        NextSpell,
        PreviousSpell,
    }
}