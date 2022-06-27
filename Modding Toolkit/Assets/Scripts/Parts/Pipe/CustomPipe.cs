﻿using Sirenix.OdinInspector;
using UnityEngine;
using SFS.Variables;
using System.Collections.Generic;

namespace SFS.Parts.Modules
{
    [HideMonoScript]
    public class CustomPipe : PipeData, I_InitializePartModule
    {
        [InlineProperty, HideLabel, Space(2)] public Composed_Shape composedShape = new Composed_Shape { points = new List<Composed_ShapePoint> { new Composed_ShapePoint(Vector2.zero, Vector2.right), new Composed_ShapePoint(Vector2.up, Vector2.right) } };

        
        [BoxGroup("edit", false), HorizontalGroup("edit/a")] public bool edit = true, view = true;
        [BoxGroup("edit", false), ShowIf("edit")] public float gridSize = 0.1f;
        
        
        int I_InitializePartModule.Priority => 10;
        void I_InitializePartModule.Initialize() => composedShape.OnChange += Output;

        public override void Output() => SetData(composedShape.Value);
    }
}