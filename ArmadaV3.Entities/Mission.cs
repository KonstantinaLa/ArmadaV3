using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped] public string Duration => $"{(EndDate.Year - StartDate.Year)} years";
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