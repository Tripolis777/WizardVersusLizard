// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

using System;
using Core;
using UnityEngine;
using VContainer.Unity;

namespace Gameplay.Service
{
    public sealed class KeyboardPlayerInput : IPlayerInputService, ITickable
    {
        private static readonly Vector3 LeftDirection = Vector3.left;
        private static readonly Vector3 RightDirection = Vector3.right;
        
        public static readonly KeyboardSchema DefaultSchema = new KeyboardSchema()
        {
            MoveLeft = KeyCode.LeftArrow,
            MoveRight = KeyCode.RightArrow,
            Cast = KeyCode.X,
            NextSpell = KeyCode.W,
            PreviousSpell = KeyCode.Q
        };
        
        public event Action<PlayerAction> OnAction;
        
        public Vector3 MoveDirection { get; private set; }

        private KeyboardSchema _schema;

        public KeyboardPlayerInput()
        {
            _schema = DefaultSchema;
        }
        
        public void Tick()
        { 
            CheckMove();
            CheckActions();
        }

        private void CheckMove()
        {
            if (Input.GetKeyDown(_schema.MoveLeft)) 
                MoveDirection = LeftDirection;
            else if (Input.GetKeyDown(_schema.MoveRight))
                MoveDirection = RightDirection;
            else if (Input.GetKey(_schema.MoveLeft) || Input.GetKey(_schema.MoveRight))
                return;
            else
                MoveDirection = Vector3.zero;
        }
        
        private void CheckActions()
        {
            var actionType = PlayerAction.None;
            if (Input.GetKeyDown(_schema.Cast))
                actionType = PlayerAction.Cast;
            else if (Input.GetKeyDown(_schema.NextSpell))
                actionType = PlayerAction.NextSpell;
            else if (Input.GetKeyDown(_schema.PreviousSpell))
                actionType = PlayerAction.PreviousSpell;

            if (actionType == PlayerAction.None)
                return;
            
            OnAction?.Invoke(actionType);
        }

        public struct KeyboardSchema
        {
            public KeyCode MoveLeft;
            public KeyCode MoveRight;
            public KeyCode Cast;
            public KeyCode NextSpell;
            public KeyCode PreviousSpell;
        }
    }
}