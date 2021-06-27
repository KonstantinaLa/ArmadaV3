﻿using System;
using System.Collections.Generic;
using ArmadaV3.Entities.CustomValidations;
using FluentValidation.Attributes;

namespace ArmadaV3.Entities
{
    [Validator(typeof(MissionValidator))]
    public class Mission
    {
        public int MissionId { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Navigation Properties
        public virtual ICollection<AdmiralMission> AdmiralMissions { get; set; }
        public virtual ICollection<Planet> Planets { get; set; }

        public Mission()
        {
            Planets = new HashSet<Planet>();
            AdmiralMissions = new HashSet<AdmiralMission>();
        }
    }
}