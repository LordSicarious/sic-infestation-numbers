using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using Verse;

using static RimWorld.InfestationCellFinder;

namespace InfestationNumbers {
    public class RoomStatWorker_InfestationChance : RoomStatWorker {

        public override float GetScore(Room room) {
            CalculateLocationCandidates(room.Map);
            float mapTotal = 0f, roomTotal = 0f;
            foreach (LocationCandidate loc in locationCandidates) {
                mapTotal += loc.score;
                if (room.Cells.Contains(loc.cell)) {
                    roomTotal += loc.score;
                }
            }
            if (mapTotal == 0f) { return 0f; }
            else { return roomTotal/mapTotal*100f; }
        }
    }
}