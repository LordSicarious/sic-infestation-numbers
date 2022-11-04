//Prefix for [RimWorld.BeautyDrawer.DrawBeautyAroundMouse]
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using HarmonyLib;
using Verse;
using RimWorld;
using UnityEngine;

using static RimWorld.BeautyUtility;
using static RimWorld.InfestationCellFinder;

namespace InfestationNumbers {
public static class Prefix_DrawBeautyAroundMouse {

    private static float score;
    private static IntVec3 pos;

    // Replaces the whole colour system with just drawing the actual scores
    public static bool Patch() {
        if (DebugViewSettings.drawInfestationChance) {
            Map map = Find.CurrentMap;
            FillBeautyRelevantCells(UI.MouseCell(), map);
            foreach (LocationCandidate loc in locationCandidates.Where(loc => beautyRelevantCells.Contains(loc.cell))) {
                pos = loc.cell; score = loc.score;
                if (score >= 7.5f) {
                    GenMapUI.DrawThingLabel((Vector3)GenMapUI.LabelDrawPosFor(pos), score.ToString("0.##"), Color.white);
                }
            }
            return false;
        }
        return true;
    }
}
}