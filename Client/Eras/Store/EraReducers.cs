﻿using System.Linq;
using DeusVultClicker.Client.Shared.Store.Actions;
using Fluxor;

namespace DeusVultClicker.Client.Eras.Store
{
    public static class EraReducers
    {
        [ReducerMethod]
        public static EraState ReduceAdvanceToEraAction(EraState state, AdvanceToEraAction action)
        {
            var era = EraStorage.EraAdvancements[action.Id];
            return state with
            {
                Era = era,
                PastEras = state.PastEras.Concat(new[] { action.Id })
            };
        }

        [ReducerMethod]
        public static EraState ReduceSetEraStateAction(EraState state, SetEraStateAction action)
        {
            return action.EraState;
        }
    }
}
