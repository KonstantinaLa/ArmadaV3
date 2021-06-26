namespace ArmadaV3.Database.Migrations
{
    using ArmadaV3.Entities;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ArmadaV3.Database.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ArmadaV3.Database.ApplicationDbContext context)
        {
            var c1 = new Crew { Number = 14, Specialty = "Engineers" };
            var c2 = new Crew { Number = 15, Specialty = "Developers" };
            var c3 = new Crew { Number = 27, Specialty = "Radiation Techs" };
            var c4 = new Crew { Number = 22, Specialty = "Scientists" };
            var c5 = new Crew { Number = 105, Specialty = "Soldiers" };
            var c6 = new Crew { Number = 24, Specialty = "Nuclear Scientists" };
            var c7 = new Crew { Number = 45, Specialty = "Rocket Scientists" };
            var c8 = new Crew { Number = 22, Specialty = "Toxicologists" };
            var c9 = new Crew { Number = 58, Specialty = "Geneticists" };
            var c10 = new Crew { Number = 64, Specialty = "Biochemical Geneticists" };
            var c11 = new Crew { Number = 24, Specialty = "Veterans" };
            var c12 = new Crew { Number = 67, Specialty = "Xenos" };
            var c13 = new Crew { Number = 133, Specialty = "Clone Troopers" };
            var c14 = new Crew { Number = 218, Specialty = "Crusaders" };
            var c15 = new Crew { Number = 319, Specialty = "Surveillance Crew" };
            var c16 = new Crew { Number = 45, Specialty = "Monitor Techs" };
            var c17 = new Crew { Number = 182, Specialty = "Exterminators" };
            var c18 = new Crew { Number = 88, Specialty = "Necromancers" };
            var c19 = new Crew { Number = 75, Specialty = "Priests" };
            var c20 = new Crew { Number = 167, Specialty = "Slaves" };
            var c21 = new Crew { Number = 1260, Specialty = "Colonists" };
            var c22 = new Crew { Number = 450, Specialty = "Droids" };
            var c23 = new Crew { Number = 1345, Specialty = "Synthetics" };
            var c24 = new Crew { Number = 415, Specialty = "Executives" };
            var c25 = new Crew { Number = 15, Specialty = "Nobles" };
            var c26 = new Crew { Number = 43, Specialty = "High Priests" };
            var c27 = new Crew { Number = 217, Specialty = "Merchants" };
            var c28 = new Crew { Number = 68, Specialty = "Roboticists" };
            var c29 = new Crew { Number = 6, Specialty = "Science Directors" };
            var c30 = new Crew { Number = 17, Specialty = "Coordinators" };
            var c31 = new Crew { Number = 22, Specialty = "Administrators" };
            var c32 = new Crew { Number = 57, Specialty = "Entertainers" };
            var c33 = new Crew { Number = 16, Specialty = "Overseers" };
            var c34 = new Crew { Number = 82, Specialty = "Drones" };
            var c35 = new Crew { Number = 19, Specialty = "Managers" };
            var c36 = new Crew { Number = 376, Specialty = "Bureaucrats" };
            var c37 = new Crew { Number = 680, Specialty = "Warriors" };
            var c38 = new Crew { Number = 28, Specialty = "Facilitators" };

            var crews = new List<Crew> { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38 };

            foreach (var crew in crews)
            {
                context.Crews.AddOrUpdate(c => new { c.Number, c.Specialty }, crew);
            }

            var a1 = new Admiral { Name = "Tom Driscoll", Age = 32, EnlistmentDate = new DateTime(2206, 2, 26), Specialty = (AdmiralSpecialty)0, Species = (EmperorSpecies)0, Description = "Description", Crew = c1 };
            var a2 = new Admiral { Name = "Rainer Hofstedt", Age = 44, EnlistmentDate = new DateTime(2205, 5, 15), Specialty = (AdmiralSpecialty)1, Species = (EmperorSpecies)0, Description = "Description", Crew = c2 };
            var a3 = new Admiral { Name = "Aaron Reynolds", Age = 38, EnlistmentDate = new DateTime(2203, 6, 18), Specialty = (AdmiralSpecialty)2, Species = (EmperorSpecies)0, Description = "Description", Crew = c3 };
            var a4 = new Admiral { Name = "Kathleen MacDonald", Age = 45, EnlistmentDate = new DateTime(2206, 7, 22), Specialty = (AdmiralSpecialty)3, Species = (EmperorSpecies)0, Description = "Description", Crew = c4 };
            var a5 = new Admiral { Name = "Amelia Spencer", Age = 39, EnlistmentDate = new DateTime(2204, 2, 15), Specialty = (AdmiralSpecialty)4, Species = (EmperorSpecies)0, Description = "Description", Crew = c5 };
            var a6 = new Admiral { Name = "Julianne Price", Age = 38, EnlistmentDate = new DateTime(2209, 12, 22), Specialty = (AdmiralSpecialty)5, Species = (EmperorSpecies)0, Description = "Description", Crew = c6 };
            var a7 = new Admiral { Name = "Geoffrey Quinn", Age = 52, EnlistmentDate = new DateTime(2204, 10, 22), Specialty = (AdmiralSpecialty)6, Species = (EmperorSpecies)0, Description = "Description", Crew = c7 };
            var a8 = new Admiral { Name = "Ross Lancaster", Age = 49, EnlistmentDate = new DateTime(2202, 4, 15), Specialty = (AdmiralSpecialty)6, Species = (EmperorSpecies)0, Description = "Description", Crew = c8 };
            var a9 = new Admiral { Name = "James Stuart", Age = 50, EnlistmentDate = new DateTime(2204, 7, 18), Specialty = (AdmiralSpecialty)5, Species = (EmperorSpecies)0, Description = "Description", Crew = c9 };
            var a10 = new Admiral { Name = "Kate Samuels", Age = 46, EnlistmentDate = new DateTime(2212, 6, 27), Specialty = (AdmiralSpecialty)2, Species = (EmperorSpecies)0, Description = "Description", Crew = c10 };
            var a11 = new Admiral { Name = "Meredith Scott", Age = 32, EnlistmentDate = new DateTime(2205, 5, 28), Specialty = (AdmiralSpecialty)3, Species = (EmperorSpecies)0, Description = "Description", Crew = c11 };
            var a12 = new Admiral { Name = "Theon", Age = 55, EnlistmentDate = new DateTime(2205, 2, 1), Specialty = (AdmiralSpecialty)4, Species = (EmperorSpecies)2, Description = "Description", Crew = c12 };
            var a13 = new Admiral { Name = "Yara", Age = 23, EnlistmentDate = new DateTime(2205, 3, 6), Specialty = (AdmiralSpecialty)6, Species = (EmperorSpecies)2, Description = "Description", Crew = c13 };
            var a14 = new Admiral { Name = "Vickon", Age = 54, EnlistmentDate = new DateTime(2205, 6, 22), Specialty = (AdmiralSpecialty)5, Species = (EmperorSpecies)4, Description = "Description", Crew = c14 };
            var a15 = new Admiral { Name = "Balon", Age = 80, EnlistmentDate = new DateTime(2205, 11, 15), Specialty = (AdmiralSpecialty)1, Species = (EmperorSpecies)3, Description = "Description", Crew = c15 };
            var a16 = new Admiral { Name = "Azura", Age = 102, EnlistmentDate = new DateTime(2202, 2, 22), Specialty = (AdmiralSpecialty)2, Species = (EmperorSpecies)6, Description = "Description", Crew = c16 };
            var a17 = new Admiral { Name = "Boethiah", Age = 204, EnlistmentDate = new DateTime(2204, 11, 21), Specialty = (AdmiralSpecialty)1, Species = (EmperorSpecies)6, Description = "Description", Crew = c17 };
            var a18 = new Admiral { Name = "Clavicus Vile", Age = 125, EnlistmentDate = new DateTime(2207, 12, 18), Specialty = (AdmiralSpecialty)4, Species = (EmperorSpecies)6, Description = "Description", Crew = c18 };
            var a19 = new Admiral { Name = "Mehrunes Dagon", Age = 150, EnlistmentDate = new DateTime(2204, 1, 6), Specialty = (AdmiralSpecialty)6, Species = (EmperorSpecies)6, Description = "Description", Crew = c19 };
            var a20 = new Admiral { Name = "Sanguine", Age = 189, EnlistmentDate = new DateTime(2201, 4, 9), Specialty = (AdmiralSpecialty)1, Species = (EmperorSpecies)6, Description = "Description", Crew = c20 };
            var a21 = new Admiral { Name = "Minsc", Age = 24, EnlistmentDate = new DateTime(2201, 2, 11), Specialty = (AdmiralSpecialty)3, Species = (EmperorSpecies)0, Description = "Description", Crew = c21 };
            var a22 = new Admiral { Name = "Jaheira", Age = 48, EnlistmentDate = new DateTime(2203, 3, 9), Specialty = (AdmiralSpecialty)4, Species = (EmperorSpecies)0, Description = "Description", Crew = c22 };
            var a23 = new Admiral { Name = "Imoen", Age = 25, EnlistmentDate = new DateTime(2210, 2, 15), Specialty = (AdmiralSpecialty)3, Species = (EmperorSpecies)0, Description = "Description", Crew = c23 };
            var a24 = new Admiral { Name = "Drizzt Do'Urden", Age = 86, EnlistmentDate = new DateTime(2212, 3, 17), Specialty = (AdmiralSpecialty)1, Species = (EmperorSpecies)2, Description = "Description", Crew = c24 };
            var a25 = new Admiral { Name = "Edwin", Age = 51, EnlistmentDate = new DateTime(2210, 7, 19), Specialty = (AdmiralSpecialty)5, Species = (EmperorSpecies)0, Description = "Description", Crew = c25 };
            var a26 = new Admiral { Name = "Sarevok", Age = 29, EnlistmentDate = new DateTime(2211, 7, 18), Specialty = (AdmiralSpecialty)6, Species = (EmperorSpecies)3, Description = "Description", Crew = c26 };
            var a27 = new Admiral { Name = "Aegon", Age = 54, EnlistmentDate = new DateTime(2202, 2, 5), Specialty = (AdmiralSpecialty)5, Species = (EmperorSpecies)5, Description = "Description", Crew = c27 };
            var a28 = new Admiral { Name = "Rhaenys", Age = 51, EnlistmentDate = new DateTime(2206, 4, 12), Specialty = (AdmiralSpecialty)5, Species = (EmperorSpecies)5, Description = "Description", Crew = c28 };
            var a29 = new Admiral { Name = "Visenya", Age = 48, EnlistmentDate = new DateTime(2210, 2, 14), Specialty = (AdmiralSpecialty)2, Species = (EmperorSpecies)2, Description = "Description", Crew = c29 };
            var a30 = new Admiral { Name = "Rhaegar", Age = 33, EnlistmentDate = new DateTime(2211, 1, 20), Specialty = (AdmiralSpecialty)3, Species = (EmperorSpecies)3, Description = "Description", Crew = c30 };
            var a31 = new Admiral { Name = "Viserys", Age = 25, EnlistmentDate = new DateTime(2213, 9, 18), Specialty = (AdmiralSpecialty)1, Species = (EmperorSpecies)1, Description = "Description", Crew = c31 };
            var a32 = new Admiral { Name = "Amenemhat", Age = 75, EnlistmentDate = new DateTime(2188, 4, 28), Specialty = (AdmiralSpecialty)3, Species = (EmperorSpecies)7, Description = "Description", Crew = c32 };
            var a33 = new Admiral { Name = "Thutmose", Age = 80, EnlistmentDate = new DateTime(2160, 8, 10), Specialty = (AdmiralSpecialty)5, Species = (EmperorSpecies)7, Description = "Description", Crew = c33 };
            var a34 = new Admiral { Name = "Djoser", Age = 88, EnlistmentDate = new DateTime(2199, 10, 10), Specialty = (AdmiralSpecialty)4, Species = (EmperorSpecies)7, Description = "Description", Crew = c34 };
            var a35 = new Admiral { Name = "Ozymandias", Age = 92, EnlistmentDate = new DateTime(2200, 4, 20), Specialty = (AdmiralSpecialty)6, Species = (EmperorSpecies)7, Description = "Description", Crew = c35 };
            var a36 = new Admiral { Name = "Enceladus", Age = 788, EnlistmentDate = new DateTime(1745, 5, 28), Specialty = (AdmiralSpecialty)5, Species = (EmperorSpecies)1, Description = "Description", Crew = c36 };
            var a37 = new Admiral { Name = "Leviathan", Age = 875, EnlistmentDate = new DateTime(1825, 9, 27), Specialty = (AdmiralSpecialty)5, Species = (EmperorSpecies)1, Description = "Description", Crew = c37 };
            var a38 = new Admiral { Name = "Porphyrion", Age = 602, EnlistmentDate = new DateTime(1848, 11, 15), Specialty = (AdmiralSpecialty)5, Species = (EmperorSpecies)1, Description = "Description", Crew = c38 };

            var admirals = new List<Admiral> { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20, a21, a22, a23, a24, a25, a26, a27, a28, a29, a30, a31, a32, a33, a34, a35, a36, a37, a38 };

            foreach (var admiral in admirals)
            {
                context.Admirals.AddOrUpdate(a => new { a.Name }, admiral);
            }

            var e1 = new Empire { Name = "United Nations of Earth", Trait = "Constitutional Dictatorship", ControlledSystems = 245, Admirals = new Collection<Admiral>() { a1, a2, a3, a4, a5, a6 }, Description = "The myriad Human nations that constitute their interstellar government are disparate, yet united in purpose." };
            var e2 = new Empire { Name = "Imperium of Man", Trait = "Martial Empire", ControlledSystems = 889, Admirals = new Collection<Admiral>() { a7, a8, a9, a10, a11 }, Description = "Humans determined to realize humanity's manifest destiny - dominion over the galaxy at any cost." };
            var e3 = new Empire { Name = "Divine League", Trait = "Imperial Cult", ControlledSystems = 446, Admirals = new Collection<Admiral>() { a12, a13, a14, a15 }, Description = "Highly spiritual and place great importance on religion, venerating their high kings as living gods." };
            var e4 = new Empire { Name = "Daedric Legion", Trait = "Theocratic Monarchy", ControlledSystems = 756, Admirals = new Collection<Admiral>() { a16, a17, a18, a19, a20 }, Description = "Using a mixture of spiritual doctrine and careful organization, a globally united society." };
            var e5 = new Empire { Name = "Argent Crusade", Trait = "Illuminated Autocracy", ControlledSystems = 68, Admirals = new Collection<Admiral>() { a21, a22, a23, a24, a25, a26 }, Description = "Having conquered the planet that once threatened to blast them out of existence the Crusade now have their sights firmly set on the stars." };
            var e6 = new Empire { Name = "Children of Crisis", Trait = "Blood Court", ControlledSystems = 460, Admirals = new Collection<Admiral>() { a27, a28, a29, a30, a31 }, Description = "Poised to take to the stars, the Harbingers stand ready to pursue what they see as their solemn duty - the conversion of all lesser life forms to their likeness." };
            var e7 = new Empire { Name = "Custodian Collective", Trait = "Purification Committee", ControlledSystems = 897, Admirals = new Collection<Admiral>() { a32, a33, a34, a35 }, Description = "Once separated into a fractious society of competing trader enclaves, the Collective were forced to unite under one banner in order to repel the catastrophic spread of an invasive species on their home continent." };
            var e8 = new Empire { Name = "Reapers", Trait = "Determined Exterminators", ControlledSystems = 1359, Admirals = new Collection<Admiral>() { a36,a37,a38 }, Description = "All organic life poses an intolerable threat to Reaper survival and expansion. If there were any other sapient organics in the galaxy, they would be exterminated." };

            var empires = new List<Empire> { e1, e2, e3, e4, e5, e6, e7, e8 };

            foreach (var empire in empires)
            {
                context.Empires.AddOrUpdate(e => new { e.Name }, empire);
            }

            var emperor1 = new Emperor { Name = "Alexander Romanov", Age = 54, Description = "Scion of the old Tsarist royal family, came to power after centuries of obscurity.", Species = (EmperorSpecies)0, Empire = e1 };
            var emperor2 = new Emperor { Name = "Euron Greyiron", Age = 87, Description = "Pirate origins, seized power in a coup d'etat.", Species = (EmperorSpecies)3, Empire = e3 };
            var emperor3 = new Emperor { Name = "Sheogorath the Mad", Age = 467, Description = "Double personality and known to have deadly fits of rage, feared by all.", Species = (EmperorSpecies)5, Empire = e4 };
            var emperor4 = new Emperor { Name = "Caelar Argent", Age = 32, Description = "Righteous crusader, labored under the high expectations that came with her semi-divine heritage.", Species = (EmperorSpecies)0, Empire = e5 };
            var emperor5 = new Emperor { Name = "Sovereign", Age = 1868, Description = "The eternal leader of the Reapers, leading them with a single directive.", Species = (EmperorSpecies)1, Empire = e8 };

            var emperors = new List<Emperor> { emperor1, emperor2, emperor3, emperor4, emperor5 };

            foreach (var emperor in emperors)
            {
                context.Emperors.AddOrUpdate(e => new { e.Name }, emperor);
            }

            var p1 = new Planet { Name = "Albion", StarSystem = "Nugget", Type = (PlanetType)0 };
            var p2 = new Planet { Name = "Far Reach", StarSystem = "Polaris", Type = (PlanetType)1 };
            var p3 = new Planet { Name = "Orion", StarSystem = "Polaris", Type = (PlanetType)2 };
            var p4 = new Planet { Name = "Bataan", StarSystem = "Polaris", Type = (PlanetType)3 };
            var p5 = new Planet { Name = "Onderon", StarSystem = "Polaris", Type = (PlanetType)4 };
            var p6 = new Planet { Name = "Phobos", StarSystem = "Alpha Centauri", Type = (PlanetType)5 };
            var p7 = new Planet { Name = "Charon", StarSystem = "Alpha Centauri", Type = (PlanetType)6 };
            var p8 = new Planet { Name = "Miranda", StarSystem = "Alpha Centauri", Type = (PlanetType)7 };
            var p9 = new Planet { Name = "Olympia", StarSystem = "Alpha Centauri", Type = (PlanetType)8 };
            var p10 = new Planet { Name = "Serendipity", StarSystem = "Alpha Centauri", Type = (PlanetType)9 };
            var p11 = new Planet { Name = "Akatsuki", StarSystem = "Luyten's Star", Type = (PlanetType)10 };
            var p12 = new Planet { Name = "Kyzyl Kum", StarSystem = "Luyten's Star", Type = (PlanetType)11 };
            var p13 = new Planet { Name = "Antioch", StarSystem = "Luyten's Star", Type = (PlanetType)12 };
            var p14 = new Planet { Name = "Erythraea", StarSystem = "Omicron Persei", Type = (PlanetType)13 };
            var p15 = new Planet { Name = "Revenant", StarSystem = "Omicron Persei", Type = (PlanetType)14 };
            var p16 = new Planet { Name = "Fortune", StarSystem = "Omicron Persei", Type = (PlanetType)15 };
            var p17 = new Planet { Name = "Athena", StarSystem = "Omicron Persei", Type = (PlanetType)15 };
            var p18 = new Planet { Name = "Ascension", StarSystem = "Trappist-1", Type = (PlanetType)15 };
            var p19 = new Planet { Name = "Aurora", StarSystem = "Trappist-1", Type = (PlanetType)15 };
            var p20 = new Planet { Name = "Carthago Nova", StarSystem = "Trappist-1", Type = (PlanetType)15 };

            var planets = new List<Planet> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20 };

            foreach (var planet in planets)
            {
                context.Planets.AddOrUpdate(p => new { p.Name, p.StarSystem });
            }

            context.SaveChanges();
        }
    }
}
