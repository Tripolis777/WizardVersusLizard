// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using System;

namespace Gameplay.Player.Interfaces
{
    public interface IPlayerMovement
    {
        public event Action OnMoveBegin;
        public event Action OnMoveEnd;
        public event Action<DirectionType> OnChangeDirection;

        public DirectionType LastDirection { get; }
    }

    public enum DirectionType
    {
        None,
        Left,
        Right
    }
}