using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infrastructure
{
    public class DependencyInjection
    {
        /*private static DependencyInjection _instance;

        public static DependencyInjection Container =>
            _instance ?? (_instance = new DependencyInjection());*/

        public TDependency RegisterDependency<TDependency>(TDependency dependency) =>
            Implementation<TDependency>.Instance = dependency;

        public TDependency GetDependency<TDependency>() =>
            Implementation<TDependency>.Instance;

        private static class Implementation<TDependency>
        {
            public static TDependency Instance;
        }
    }
}