// ----------------------------------------------------------------------------
// MIT License
// Copyright (c) 2024  vladimir <tripolis777@gmail.com>
// ----------------------------------------------------------------------------

namespace Core
{
    public delegate void ActionIn<T>(in T obj) where T : struct;
}