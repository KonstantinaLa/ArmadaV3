namespace ArmadaV3.Database.Migrations
{
    using ArmadaV3.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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
            if (!context.Roles.Any(x=>x.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(x=>x.Name == "Emperor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Emperor" };

                manager.Create(role);
            }

            var PaswordHash = new PasswordHasher();
            if (!context.Users.Any(x => x.UserName == "admin@admin.net"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "admin@admin.net",
                    Email = "admin@admin.net",
                    PasswordHash = PaswordHash.HashPassword("Admin1!")
                };

                manager.Create(user);
                manager.AddToRole(user.Id, "Admin");
            }
           
            if (!context.Users.Any(x => x.UserName == "emperor@emperor.net"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "emperor@emperor.net",
                    Email = "emperor@emperor.net",
                    PasswordHash = PaswordHash.HashPassword("Admin1!")
                };

                manager.Create(user);
                manager.AddToRole(user.Id, "Emperor");
            }


            #region Seed Empires

            var e1 = new Empire
            {
                Name = "United Nations of Earth",
                Trait = "Constitutional Dictatorship",
                ControlledSystems = 245,
                Description = "The myriad Human nations that constitute their interstellar government are disparate, yet united in purpose."
            };
            var e2 = new Empire
            {
                Name = "Imperium of Man",
                Trait = "Martial Empire",
                ControlledSystems = 889,
                Description = "Humans determined to realize humanity's manifest destiny - dominion over the galaxy at any cost."
            };
            var e3 = new Empire
            {
                Name = "Divine League",
                Trait = "Imperial Cult",
                ControlledSystems = 446,
                Description = "Highly spiritual and place great importance on religion, venerating their high kings as living gods."
            };
            var e4 = new Empire
            {
                Name = "Daedric Legion",
                Trait = "Theocratic Monarchy",
                ControlledSystems = 756,
                Description = "Using a mixture of spiritual doctrine and careful organization, a globally united society."
            };
            var e5 = new Empire
            {
                Name = "Argent Crusade",
                Trait = "Illuminated Autocracy",
                ControlledSystems = 68,
                Description = "Having conquered the planet that once threatened to blast them out of existence the Crusade now have their sights firmly set on the stars."
            };
            var e6 = new Empire
            {
                Name = "Children of Crisis",
                Trait = "Blood Court",
                ControlledSystems = 460,
                Description = "Poised to take to the stars, the Harbingers stand ready to pursue what they see as their solemn duty - the conversion of all lesser life forms to their likeness."
            };
            var e7 = new Empire
            {
                Name = "Custodian Collective",
                Trait = "Purification Committee",
                ControlledSystems = 897,
                Description = "Once separated into a fractious society of competing trader enclaves, the Collective were forced to unite under one banner in order to repel the catastrophic spread of an invasive species on their home continent."
            };
            var e8 = new Empire
            {
                Name = "Reapers",
                Trait = "Determined Exterminators",
                ControlledSystems = 1359,
                Description = "All organic life poses an intolerable threat to Reaper survival and expansion. If there were any other sapient organics in the galaxy, they would be exterminated."
            };

            var empires = new List<Empire> { e1, e2, e3, e4, e5, e6, e7, e8 };

            foreach (var empire in empires)
            {
                context.Empires.AddOrUpdate(e => e.Name, empire);
            }
            #endregion

            #region Seed Admiral

            var a1 = new Admiral
            {
                Name = "Tom Driscoll",
                Age = 32,
                EnlistmentDate = new DateTime(2206, 2, 26),
                Specialty = AdmiralSpecialty.Computing,
                Species = EmperorSpecies.Human,
                Description = "Description",
                Crew = new Crew { Number = 14, Specialty = "Engineers" },
                Empire = e1,
                EmpireId = e1.EmpireId

            };
            var a2 = new Admiral
            {
                Name = "Rainer Hofstedt",
                Age = 44,
                EnlistmentDate = new DateTime(2205, 5, 15),
                Specialty = AdmiralSpecialty.Propulsion,
                Species = EmperorSpecies.Human,
                Description = "Description",
                
                Empire = e1,
                EmpireId = e1.EmpireId
            };
            var a3 = new Admiral
            {
                Name = "Aaron Reynolds",
                Age = 38,
                EnlistmentDate = new DateTime(2203, 6, 18),
                Specialty = AdmiralSpecialty.MilitaryTheory,
                Species = EmperorSpecies.Human,
                Description = "Description",
                
                Empire = e1,
                EmpireId = e1.EmpireId
            };
            var a4 = new Admiral
            {
                Name = "Kathleen MacDonald",
                Age = 45,
                EnlistmentDate = new DateTime(2206, 7, 22),
                Specialty = AdmiralSpecialty.Psionics,
                Species = EmperorSpecies.Human,
                Description = "Description",
                
                Empire = e1,
                EmpireId = e1.EmpireId
            };
            var a5 = new Admiral
            {
                Name = "Amelia Spencer",
                Age = 39,
                EnlistmentDate = new DateTime(2204, 2, 15),
                Specialty = AdmiralSpecialty.Propulsion,
                Species = EmperorSpecies.Human,
                Description = "Description",
                
                Empire = e1,
                EmpireId = e1.EmpireId
            };
            var a6 = new Admiral
            {
                Name = "Julianne Price",
                Age = 38,
                EnlistmentDate = new DateTime(2209, 12, 22),
                Specialty = AdmiralSpecialty.Scout,
                Species = EmperorSpecies.Human,
                Description = "Description",
                
                Empire = e1,
                EmpireId = e1.EmpireId
            };
            var a7 = new Admiral
            {
                Name = "Geoffrey Quinn",
                Age = 52,
                EnlistmentDate = new DateTime(2204, 10, 22),
                Specialty = AdmiralSpecialty.VoidHunter,
                Species = EmperorSpecies.Human,
                Description = "Description",
                
                Empire = e2,
                EmpireId = e2.EmpireId
            };
            var a8 = new Admiral
            {
                Name = "Ross Lancaster",
                Age = 49,
                EnlistmentDate = new DateTime(2202, 4, 15),
                Specialty = AdmiralSpecialty.Computing,
                Species = EmperorSpecies.Human,
                Description = "Description",
                
                Empire = e2,
                EmpireId = e2.EmpireId
            };
            var a9 = new Admiral
            {
                Name = "James Stuart",
                Age = 50,
                EnlistmentDate = new DateTime(2204, 7, 18),
                Specialty = AdmiralSpecialty.ArmyLogistics,
                Species = EmperorSpecies.Human,
                Description = "Description",
                
                Empire = e2,
                EmpireId = e2.EmpireId
            };
            var a10 = new Admiral
            {
                Name = "Kate Samuels",
                Age = 46,
                EnlistmentDate = new DateTime(2212, 6, 27),
                Specialty = AdmiralSpecialty.Propulsion,
                Species = EmperorSpecies.Human,
                Description = "Description",
                
                Empire = e2,
                EmpireId = e2.EmpireId
            };
            var a11 = new Admiral
            {
                Name = "Meredith Scott",
                Age = 32,
                EnlistmentDate = new DateTime(2205, 5, 28),
                Specialty = AdmiralSpecialty.Psionics,
                Species = EmperorSpecies.Human,
                Description = "Description",
                
                Empire = e2,
                EmpireId = e2.EmpireId
            };
            var a12 = new Admiral
            {
                Name = "Theon",
                Age = 55,
                EnlistmentDate = new DateTime(2205, 2, 1),
                Specialty = AdmiralSpecialty.Propulsion,
                Species = EmperorSpecies.Mantis,
                Description = "Description",
                
                Empire = e3,
                EmpireId = e3.EmpireId
            };
            var a13 = new Admiral
            {
                Name = "Yara",
                Age = 23,
                EnlistmentDate = new DateTime(2205, 3, 6),
                Specialty = AdmiralSpecialty.Scout,
                Species = EmperorSpecies.Engi,
                Description = "Description",
                
                Empire = e3,
                EmpireId = e3.EmpireId
            };
            var a14 = new Admiral
            {
                Name = "Vickon",
                Age = 54,
                EnlistmentDate = new DateTime(2205, 6, 22),
                Specialty = AdmiralSpecialty.Propulsion,
                Species = EmperorSpecies.Blorg,
                Description = "Description",
                
                Empire = e3,
                EmpireId = e3.EmpireId
            };
            var a15 = new Admiral
            {
                Name = "Balon",
                Age = 80,
                EnlistmentDate = new DateTime(2205, 11, 15),
                Specialty = AdmiralSpecialty.ArmyLogistics,
                Species = EmperorSpecies.Vheln,
                Description = "Description",
                
                Empire = e3,
                EmpireId = e3.EmpireId
            };
            var a16 = new Admiral
            {
                Name = "Azura",
                Age = 102,
                EnlistmentDate = new DateTime(2202, 2, 22),
                Specialty = AdmiralSpecialty.Psionics,
                Species = EmperorSpecies.Zoltan,

                Description = "Description",
                
                Empire = e4,
                EmpireId = e4.EmpireId
            };
            var a17 = new Admiral
            {
                Name = "Boethiah",
                Age = 204,
                EnlistmentDate = new DateTime(2204, 11, 21),
                Specialty = AdmiralSpecialty.Propulsion,
                Species = EmperorSpecies.Scyldari,
                Description = "Description",
                
                Empire = e4,
                EmpireId = e4.EmpireId
            };
            var a18 = new Admiral
            {
                Name = "Clavicus Vile",
                Age = 125,
                EnlistmentDate = new DateTime(2207, 12, 18),
                Specialty = AdmiralSpecialty.ArmyLogistics,
                Species = EmperorSpecies.Scyldari,
                Description = "Description",
                
                Empire = e4,
                EmpireId = e4.EmpireId
            };
            var a19 = new Admiral
            {
                Name = "Mehrunes Dagon",
                Age = 150,
                EnlistmentDate = new DateTime(2204, 1, 6),
                Specialty = AdmiralSpecialty.MilitaryTheory,
                Species = EmperorSpecies.Scyldari,
                Description = "Description",
                
                Empire = e4,
                EmpireId = e4.EmpireId
            };
            var a20 = new Admiral
            {
                Name = "Sanguine",
                Age = 189,
                EnlistmentDate = new DateTime(2201, 4, 9),
                Specialty = AdmiralSpecialty.Psionics,
                Species = EmperorSpecies.Engi,
                Description = "Description",
                
                Empire = e5,
                EmpireId = e5.EmpireId
            };
            var a21 = new Admiral
            {
                Name = "Minsc",
                Age = 24,
                EnlistmentDate = new DateTime(2201, 2, 11),
                Specialty = AdmiralSpecialty.Scout,
                Species = EmperorSpecies.Gecko,
                Description = "Description",
                
                Empire = e5,
                EmpireId = e5.EmpireId
            };
            var a22 = new Admiral
            {
                Name = "Jaheira",
                Age = 48,
                EnlistmentDate = new DateTime(2203, 3, 9),
                Specialty = AdmiralSpecialty.Computing,
                Species = EmperorSpecies.Orbis,
                Description = "Description",
                
                Empire = e5,
                EmpireId = e5.EmpireId
            };
            var a23 = new Admiral
            {
                Name = "Imoen",
                Age = 25,
                EnlistmentDate = new DateTime(2210, 2, 15),
                Specialty = AdmiralSpecialty.VoidHunter,
                Species = EmperorSpecies.Blorg,
                Description = "Description",
                
                Empire = e5,
                EmpireId = e5.EmpireId
            };
            var a24 = new Admiral
            {
                Name = "Drizzt Do'Urden",
                Age = 86,
                EnlistmentDate = new DateTime(2212, 3, 17),
                Specialty = AdmiralSpecialty.Computing,
                Species = EmperorSpecies.Blorg,
                Description = "Description",
                
                Empire = e5,
                EmpireId = e5.EmpireId
            };
            var a25 = new Admiral
            {
                Name = "Edwin",
                Age = 51,
                EnlistmentDate = new DateTime(2210, 7, 19),
                Specialty = AdmiralSpecialty.Computing,
                Species = EmperorSpecies.Engi,
                Description = "Description",
                
                Empire = e6,
                EmpireId = e6.EmpireId
            };
            var a26 = new Admiral
            {
                Name = "Sarevok",
                Age = 29,
                EnlistmentDate = new DateTime(2211, 7, 18),
                Specialty = AdmiralSpecialty.ArmyLogistics,
                Species = EmperorSpecies.Lok,
                Description = "Description",
                
                Empire = e6,
                EmpireId = e6.EmpireId
            };
            var a27 = new Admiral
            {
                Name = "Aegon",
                Age = 54,
                EnlistmentDate = new DateTime(2202, 2, 5),
                Specialty = AdmiralSpecialty.Psionics,
                Species = EmperorSpecies.Pasharti,
                Description = "Description",
                
                Empire = e6,
                EmpireId = e6.EmpireId
            };
            var a28 = new Admiral
            {
                Name = "Rhaenys",
                Age = 51,
                EnlistmentDate = new DateTime(2206, 4, 12),
                Specialty = AdmiralSpecialty.VoidHunter,
                Species = EmperorSpecies.Scyldari,
                Description = "Description",
                
                Empire = e6,
                EmpireId = e6.EmpireId
            };
            var a29 = new Admiral
            {
                Name = "Visenya",
                Age = 48,
                EnlistmentDate = new DateTime(2210, 2, 14),
                Specialty = AdmiralSpecialty.Computing,
                Species = EmperorSpecies.Blorg,
                Description = "Description",
                
                Empire = e7,
                EmpireId = e7.EmpireId
            };
            var a30 = new Admiral
            {
                Name = "Rhaegar",
                Age = 33,
                EnlistmentDate = new DateTime(2211, 1, 20),
                Specialty = AdmiralSpecialty.ArmyLogistics,
                Species = EmperorSpecies.Gecko,
                Description = "Description",
                
                Empire = e7,
                EmpireId = e7.EmpireId
            };
            var a31 = new Admiral
            {
                Name = "Viserys",
                Age = 25,
                EnlistmentDate = new DateTime(2213, 9, 18),
                Specialty = AdmiralSpecialty.Propulsion,
                Species = EmperorSpecies.Pasharti,
                Description = "Description",
                
                Empire = e7,
                EmpireId = e7.EmpireId
            };
            var a32 = new Admiral
            {
                Name = "Amenemhat",
                Age = 75,
                EnlistmentDate = new DateTime(2188, 4, 28),
                Specialty = AdmiralSpecialty.ArmyLogistics,
                Species = EmperorSpecies.Mantis,
                Description = "Description",
                
                Empire = e8,
                EmpireId = e8.EmpireId
            };
            var a33 = new Admiral
            {
                Name = "Thutmose",
                Age = 80,
                EnlistmentDate = new DateTime(2160, 8, 10),
                Specialty = AdmiralSpecialty.MilitaryTheory,
                Species = EmperorSpecies.Engi,
                Description = "Description",
                
                Empire = e8,
                EmpireId = e8.EmpireId
            };
            var a34 = new Admiral
            {
                Name = "Djoser",
                Age = 88,
                EnlistmentDate = new DateTime(2199, 10, 10),
                Specialty = AdmiralSpecialty.MilitaryTheory,
                Species = EmperorSpecies.Vheln,
                Description = "Description",
                
                Empire = e8,
                EmpireId = e8.EmpireId
            };
            var a35 = new Admiral
            {
                Name = "Ozymandias",
                Age = 92,
                EnlistmentDate = new DateTime(2200, 4, 20),
                Specialty = AdmiralSpecialty.MilitaryTheory,
                Species = EmperorSpecies.Lok,
                Description = "Description",
                
                Empire = e8,
                EmpireId = e8.EmpireId
            };
            var a36 = new Admiral
            {
                Name = "Enceladus",
                Age = 788,
                EnlistmentDate = new DateTime(1745, 5, 28),
                Specialty = AdmiralSpecialty.Computing,
                Species = EmperorSpecies.Zoltan,
                Description = "Description",
                
                Empire = e8,
                EmpireId = e8.EmpireId
            };
            var a37 = new Admiral
            {
                Name = "Leviathan",
                Age = 875,
                EnlistmentDate = new DateTime(1825, 9, 27),
                Specialty = AdmiralSpecialty.MilitaryTheory,
                Species = EmperorSpecies.Zoltan,
                Description = "Description",
                
                Empire = e8,
                EmpireId = e8.EmpireId
            };
            var a38 = new Admiral
            {
                Name = "Porphyrion",
                Age = 602,
                EnlistmentDate = new DateTime(1848, 11, 15),
                Specialty = (AdmiralSpecialty)5,
                Species = EmperorSpecies.Zoltan,
                Description = "Description",
                
                Empire = e8,
                EmpireId = e8.EmpireId
            };

            var admirals = new List<Admiral>
            {
                a1, a2, a3, a4, a5, a6, a7, a8, a9, a10,
                a11, a12, a13, a14, a15, a16, a17, a18, a19, a20,
                a21, a22, a23, a24, a25, a26, a27, a28, a29, a30,
                a31, a32, a33, a34, a35, a36, a37, a38
            };

            foreach (var admiral in admirals)
            {
                context.Admirals.AddOrUpdate(a => a.Name, admiral);
            }

            #endregion

            #region Seed Crew

            var c1 = new Crew { Number = 14, Specialty = "Engineers", Admiral =a1 } ;
            var c2 = new Crew { Number = 15, Specialty = "Developers", Admiral = a2 };
            var c3 = new Crew { Number = 27, Specialty = "Radiation Techs", Admiral = a3 };
            var c4 = new Crew { Number = 22, Specialty = "Scientists", Admiral = a4 };
            var c5 = new Crew { Number = 105, Specialty = "Soldiers", Admiral = a5 };
            var c6 = new Crew { Number = 24, Specialty = "Nuclear Scientists", Admiral = a6 };
            var c7 = new Crew { Number = 45, Specialty = "Rocket Scientists", Admiral = a7 };
            var c8 = new Crew { Number = 22, Specialty = "Toxicologists", Admiral = a8 };
            var c9 = new Crew { Number = 58, Specialty = "Geneticists", Admiral = a9 };
            var c10 = new Crew { Number = 64, Specialty = "Biochemical Geneticists", Admiral = a10 };
            var c11 = new Crew { Number = 24, Specialty = "Veterans", Admiral = a11 };
            var c12 = new Crew { Number = 67, Specialty = "Xenos", Admiral = a12 };
            var c13 = new Crew { Number = 133, Specialty = "Clone Troopers", Admiral = a13 };
            var c14 = new Crew { Number = 218, Specialty = "Crusaders", Admiral = a14 };
            var c15 = new Crew { Number = 319, Specialty = "Surveillance Crew", Admiral = a15 };
            var c16 = new Crew { Number = 45, Specialty = "Monitor Techs", Admiral = a16 };
            var c17 = new Crew { Number = 182, Specialty = "Exterminators", Admiral = a17 };
            var c18 = new Crew { Number = 88, Specialty = "Necromancers", Admiral = a18 };
            var c19 = new Crew { Number = 75, Specialty = "Priests", Admiral = a19 };
            var c20 = new Crew { Number = 167, Specialty = "Slaves", Admiral = a20 };
            var c21 = new Crew { Number = 1260, Specialty = "Colonists", Admiral = a21 };
            var c22 = new Crew { Number = 450, Specialty = "Droids", Admiral = a22 };
            var c23 = new Crew { Number = 1345, Specialty = "Synthetics", Admiral = a23 };
            var c24 = new Crew { Number = 415, Specialty = "Executives", Admiral = a24 };
            var c25 = new Crew { Number = 15, Specialty = "Nobles", Admiral = a25 };
            var c26 = new Crew { Number = 43, Specialty = "High Priests", Admiral = a26 };
            var c27 = new Crew { Number = 217, Specialty = "Merchants", Admiral = a27 };
            var c28 = new Crew { Number = 68, Specialty = "Roboticists", Admiral = a28 };
            var c29 = new Crew { Number = 6, Specialty = "Science Directors", Admiral = a29 };
            var c30 = new Crew { Number = 17, Specialty = "Coordinators", Admiral = a30 };
            var c31 = new Crew { Number = 22, Specialty = "Administrators", Admiral = a31 };
            var c32 = new Crew { Number = 57, Specialty = "Entertainers", Admiral = a32 };
            var c33 = new Crew { Number = 16, Specialty = "Overseers", Admiral = a33 };
            var c34 = new Crew { Number = 82, Specialty = "Drones", Admiral = a34 };
            var c35 = new Crew { Number = 19, Specialty = "Managers", Admiral = a35 };
            var c36 = new Crew { Number = 376, Specialty = "Bureaucrats", Admiral = a36 };
            var c37 = new Crew { Number = 680, Specialty = "Warriors", Admiral = a37 };
            var c38 = new Crew { Number = 28, Specialty = "Facilitators", Admiral = a38 };

            var crews = new List<Crew> { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38 };

            foreach (var crew in crews)
            {
                context.Crews.AddOrUpdate(c => new { c.Number, c.Specialty }, crew);
            }
            #endregion

            #region Seed Emperors

            var emperor1 = new Emperor
            {
                Name = "Alexander Romanov",
                Age = 54,
                Description = "Scion of the old Tsarist royal family, came to power after centuries of obscurity.",
                Species = EmperorSpecies.Human,
                Empire = e1
            };
            var emperor2 = new Emperor
            {
                Name = "Euron Greyiron",
                Age = 87,
                Description = "Pirate origins, seized power in a coup d'etat.",
                Species = EmperorSpecies.Blorg,
                Empire = e3
            };
            var emperor3 = new Emperor
            {
                Name = "Sheogorath the Mad",
                Age = 467,
                Description = "Double personality and known to have deadly fits of rage, feared by all.",
                Species = EmperorSpecies.Lok,
                Empire = e4
            };
            var emperor4 = new Emperor
            {
                Name = "Caelar Argent",
                Age = 32,
                Description = "Righteous crusader, labored under the high expectations that came with her semi-divine heritage.",
                Species = EmperorSpecies.Vheln,
                Empire = e5
            };
            var emperor5 = new Emperor
            {
                Name = "Sovereign",
                Age = 1868,
                Description = "The eternal leader of the Reapers, leading them with a single directive.",
                Species = EmperorSpecies.Scyldari,
                Empire = e8
            };

            var emperors = new List<Emperor> { emperor1, emperor2, emperor3, emperor4, emperor5 };

            foreach (var emperor in emperors)
            {
                context.Emperors.AddOrUpdate(e => new { e.Name }, emperor);
            }
            #endregion

            #region Seed Planets

            var p1 = new Planet { Name = "Albion", StarSystem = "Nugget", Type = PlanetType.CarbonPlanet };
            var p2 = new Planet { Name = "Far Reach", StarSystem = "Polaris", Type = PlanetType.ChthonianPlanet };
            var p3 = new Planet { Name = "Orion", StarSystem = "Polaris", Type = PlanetType.DesertPlanet };
            var p4 = new Planet { Name = "Bataan", StarSystem = "Polaris", Type = PlanetType.GasDwarf };
            var p5 = new Planet { Name = "Onderon", StarSystem = "Polaris", Type = PlanetType.HeliumPlane };
            var p6 = new Planet { Name = "Phobos", StarSystem = "Alpha Centauri", Type = PlanetType.IceGiant };
            var p7 = new Planet { Name = "Charon", StarSystem = "Alpha Centauri", Type = PlanetType.LavaPlanet };
            var p8 = new Planet { Name = "Miranda", StarSystem = "Alpha Centauri", Type = PlanetType.DesertPlanet };
            var p9 = new Planet { Name = "Olympia", StarSystem = "Alpha Centauri", Type = PlanetType.SilicatePlanet };
            var p10 = new Planet { Name = "Serendipity", StarSystem = "Alpha Centauri", Type = PlanetType.CorelessPlanet };
            var p11 = new Planet { Name = "Akatsuki", StarSystem = "Luyten's Star", Type = PlanetType.PuffyPlanet };
            var p12 = new Planet { Name = "Kyzyl Kum", StarSystem = "Luyten's Star", Type = PlanetType.TerrestrialPlanet };
            var p13 = new Planet { Name = "Antioch", StarSystem = "Luyten's Star", Type = PlanetType.SilicatePlanet };
            var p14 = new Planet { Name = "Erythraea", StarSystem = "Omicron Persei", Type = PlanetType.CarbonPlanet };
            var p15 = new Planet { Name = "Revenant", StarSystem = "Omicron Persei", Type = PlanetType.TerrestrialPlanet };
            var p16 = new Planet { Name = "Fortune", StarSystem = "Omicron Persei", Type = PlanetType.ChthonianPlanet };
            var p17 = new Planet { Name = "Athena", StarSystem = "Omicron Persei", Type = PlanetType.PuffyPlanet };
            var p18 = new Planet { Name = "Ascension", StarSystem = "Trappist-1", Type = PlanetType.HeliumPlane };
            var p19 = new Planet { Name = "Aurora", StarSystem = "Trappist-1", Type = PlanetType.IceGiant };
            var p20 = new Planet { Name = "Carthago Nova", StarSystem = "Trappist-1", Type = PlanetType.GasGiant };

            var planets = new List<Planet> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20 };

            foreach (var planet in planets)
            {
                context.Planets.AddOrUpdate(p => new { p.Name, p.StarSystem }, planet);
            }
            #endregion

            #region Seed Missions

            var m1 = new Mission()
            {
                Type = "Execute Order",
                StartDate = new DateTime(2030, 2, 22),
                EndDate = new DateTime(2045, 9, 30),
                Planets = new Collection<Planet> { p1, p2 }
            };

            var m2 = new Mission()
            {
                Type = "Expanding Voyage",
                StartDate = new DateTime(2050, 3, 15),
                EndDate = new DateTime(2062, 10, 17),
                Planets = new Collection<Planet> { p3, p4 }
            };

            var m3 = new Mission()
            {
                Type = "Commercial Resupply Services",
                StartDate = new DateTime(2100, 1, 10),
                EndDate = new DateTime(2102, 12, 07),
                Planets = new Collection<Planet> { p5, p6 }
            };

            var m4 = new Mission()
            {
                Type = "Compton Gamma-Ray Observatory",
                StartDate = new DateTime(2050, 1, 10),
                EndDate = new DateTime(2052, 1, 07),
                Planets = new Collection<Planet> { p7, p8 }
            };

            var m5 = new Mission()
            {
                Type = "Shuttle Radar Topography Mission",
                StartDate = new DateTime(2113, 1, 10),
                EndDate = new DateTime(2122, 1, 07),
                Planets = new Collection<Planet> { p19, p20 }
            };

            var m6 = new Mission()
            {
                Type = "Explorer",
                StartDate = new DateTime(2040, 1, 10),
                EndDate = new DateTime(2152, 1, 07),
                Planets = new Collection<Planet> { p8, p9 }
            };

            var m7 = new Mission()
            {
                Type = "Juno",
                StartDate = new DateTime(2043, 1, 10),
                EndDate = new DateTime(2152, 1, 07),
                Planets = new Collection<Planet> { p10, p11 }
            };

            var m8 = new Mission()
            {
                Type = "Magnetospheric Multiscale MMS",
                StartDate = new DateTime(2053, 1, 10),
                EndDate = new DateTime(2172, 1, 07),
                Planets = new Collection<Planet> { p12, p13 }
            };

            var m9 = new Mission()
            {
                Type = "Ocean Surface Topography",
                StartDate = new DateTime(2113, 1, 10),
                EndDate = new DateTime(2122, 1, 07),
                Planets = new Collection<Planet> { p14, p15 }
            };


            var m10 = new Mission()
            {
                Type = "Radiation Belt Storm Probes Van Allen Probes",
                StartDate = new DateTime(2113, 1, 10),
                EndDate = new DateTime(2122, 1, 07),
                Planets = new Collection<Planet> { p16, p17, p18 }
            };


            var missions = new List<Mission> { m1, m2, m3, m4, m5, m6, m7, m8, m9, m10 };

            foreach (var mission in missions)
            {
                context.Missions.AddOrUpdate(m => m.Type, mission);
            }

            #endregion

            #region Seed AdmiralMissions

            var am1 = new AdmiralMission() { UniqueNumberForSeed = 1, Admiral = a1, Mission = m1, IsSuccess = true };
            var am2 = new AdmiralMission() { UniqueNumberForSeed = 2, Admiral = a1, Mission = m2, IsSuccess = false };
            var am3 = new AdmiralMission() { UniqueNumberForSeed = 3, Admiral = a2, Mission = m3, IsSuccess = false };
            var am4 = new AdmiralMission() { UniqueNumberForSeed = 4, Admiral = a2, Mission = m4, IsSuccess = true };
            var am5 = new AdmiralMission() { UniqueNumberForSeed = 5, Admiral = a3, Mission = m5, IsSuccess = true };
            var am6 = new AdmiralMission() { UniqueNumberForSeed = 6, Admiral = a3, Mission = m6, IsSuccess = true };
            var am7 = new AdmiralMission() { UniqueNumberForSeed = 7, Admiral = a4, Mission = m7, IsSuccess = true };
            var am8 = new AdmiralMission() { UniqueNumberForSeed = 8, Admiral = a5, Mission = m8, IsSuccess = false };
            var am9 = new AdmiralMission() { UniqueNumberForSeed = 9, Admiral = a6, Mission = m9, IsSuccess = false };
            var am10 = new AdmiralMission() { UniqueNumberForSeed = 10, Admiral = a7, Mission = m10, IsSuccess = true };
            var am11 = new AdmiralMission() { UniqueNumberForSeed = 11, Admiral = a7, Mission = m1, IsSuccess = true };
            var am12 = new AdmiralMission() { UniqueNumberForSeed = 12, Admiral = a8, Mission = m1, IsSuccess = false };
            var am13 = new AdmiralMission() { UniqueNumberForSeed = 13, Admiral = a8, Mission = m2, IsSuccess = true };
            var am14 = new AdmiralMission() { UniqueNumberForSeed = 14, Admiral = a9, Mission = m3, IsSuccess = false };
            var am15 = new AdmiralMission() { UniqueNumberForSeed = 15, Admiral = a9, Mission = m4, IsSuccess = true };
            var am16 = new AdmiralMission() { UniqueNumberForSeed = 16, Admiral = a10, Mission = m4, IsSuccess = false };
            var am17 = new AdmiralMission() { UniqueNumberForSeed = 17, Admiral = a10, Mission = m5, IsSuccess = true };
            var am18 = new AdmiralMission() { UniqueNumberForSeed = 18, Admiral = a11, Mission = m5, IsSuccess = false };
            var am19 = new AdmiralMission() { UniqueNumberForSeed = 19, Admiral = a11, Mission = m6, IsSuccess = true };
            var am20 = new AdmiralMission() { UniqueNumberForSeed = 20, Admiral = a11, Mission = m7, IsSuccess = true };
            var am21 = new AdmiralMission() { UniqueNumberForSeed = 21, Admiral = a12, Mission = m8, IsSuccess = true };
            var am22 = new AdmiralMission() { UniqueNumberForSeed = 22, Admiral = a12, Mission = m9, IsSuccess = false };
            var am23 = new AdmiralMission() { UniqueNumberForSeed = 23, Admiral = a13, Mission = m9, IsSuccess = false };
            var am24 = new AdmiralMission() { UniqueNumberForSeed = 24, Admiral = a13, Mission = m10, IsSuccess = true };

            var admiralMissions = new List<AdmiralMission>
            {
                am1,am2,am3,am4,am5,am6,am7,am8,am9,am10,am11,am12,am13,
                am14,am15,am16,am17,am18,am19,am20,am21,am22,am23,am24
            };

            foreach (var admiralMission in admiralMissions)
            {
                context.AdmiralMissions.AddOrUpdate(aM => aM.UniqueNumberForSeed, admiralMission);
            }
            #endregion



            context.SaveChanges();
        }
    }
}
