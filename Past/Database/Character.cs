﻿using MySql.Data.MySqlClient;
using Past.Protocol.Enums;
using Past.Protocol.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Past.Database
{
    public class Character
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public byte Level { get; set; }
        public long Experience { get; set; }
        public BreedEnum Breed { get; set; }
        public string EntityLookString { get; set; }
        public bool Sex { get; set; }
        public EntityLook Look { get { return ReturnCharacterLook(this); } }
        public int MapId { get; set; }
        public short CellId { get; set; }
        public DirectionsEnum Direction { get; set; }
        public EntityDispositionInformations Disposition { get { return new EntityDispositionInformations(CellId, (sbyte)Direction); } }
        public Map Map { get { return Map.Maps[MapId]; } }
        public AlignmentSideEnum AlignementSide;
        public ushort Honor { get; set; }
        public ushort Dishonor { get; set; }
        public bool PvPEnabled { get; set; }
        public int Kamas { get; set; }
        public short StatsPoints { get; set; }
        public short SpellsPoints { get; set; }
        public DateTime? LastUsage { get; set; }
        public GameRolePlayCharacterInformations CharacterInformations { get { return ReturnGameRolePlayCharacterInformations(this); } }

        public Character(int id, int ownerId, string name, byte level, long experience, BreedEnum breed, string entityLookString, bool sex, int mapId, short cellId, DirectionsEnum direction, AlignmentSideEnum alignementSide, ushort honor, ushort dishonor, bool pvpEnabled, int kamas, short statsPoints, short spellsPoints, DateTime? lastUsage)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
            Level = level;
            Experience = experience;
            Breed = breed;
            EntityLookString = entityLookString;
            Sex = sex;
            MapId = mapId;
            CellId = cellId;
            Direction = direction;
            AlignementSide = alignementSide;
            Honor = honor;
            Dishonor = dishonor;
            PvPEnabled = pvpEnabled;
            Kamas = kamas;
            StatsPoints = statsPoints;
            SpellsPoints = spellsPoints;
            LastUsage = lastUsage;
        }

        public static List<Character> ReturnCharacters(int ownerId)
        {
            List<Character> characters = new List<Character>();
            MySqlCommand command = new MySqlCommand("SELECT * FROM characters WHERE OwnerId = '" + ownerId + "' LIMIT 5;", DatabaseManager.Connection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    characters.Add(new Character(
                        int.Parse(reader["Id"].ToString()),
                        int.Parse(reader["OwnerId"].ToString()),
                        reader["Name"].ToString(),
                        byte.Parse(reader["Level"].ToString()),
                        long.Parse(reader["Experience"].ToString()),
                        (BreedEnum)byte.Parse(reader["Breed"].ToString()),
                        reader["EntityLookString"].ToString(),
                        bool.Parse(reader["Sex"].ToString()),
                        int.Parse(reader["MapId"].ToString()),
                        short.Parse(reader["CellId"].ToString()),
                        (DirectionsEnum)byte.Parse(reader["Direction"].ToString()),
                        (AlignmentSideEnum)byte.Parse(reader["AlignementSide"].ToString()),
                        ushort.Parse(reader["Honor"].ToString()),
                        ushort.Parse(reader["Dishonor"].ToString()),
                        bool.Parse(reader["PvPEnabled"].ToString()),
                        int.Parse(reader["Kamas"].ToString()),
                        short.Parse(reader["StatsPoints"].ToString()),
                        short.Parse(reader["SpellsPoints"].ToString()),
                        reader["LastUsage"] as DateTime?));
                }
                reader.Close();
                return characters.OrderByDescending(x => x.LastUsage).ToList();
            }
        }

        public static void Update(Character character)
        {
            MySqlCommand command = new MySqlCommand("UPDATE characters SET Id = @Id, OwnerId = @OwnerId, Name = @Name, Level = @Level, Experience = @Experience, Breed = @Breed, EntityLookString = @EntityLookString, Sex = @Sex, MapId = @MapId, CellId = @CellId, Direction = @Direction, AlignementSide = @AlignementSide, Honor = @Honor, Dishonor = @Dishonor, PvPEnabled = @PvPEnabled, Kamas = @Kamas, StatsPoints = @StatsPoints, SpellsPoints = @SpellsPoints, LastUsage = @LastUsage WHERE Id = @Id", DatabaseManager.Connection);
            command.Parameters.Add(new MySqlParameter("@Id", character.Id));
            command.Parameters.Add(new MySqlParameter("@OwnerId", character.OwnerId));
            command.Parameters.Add(new MySqlParameter("@Name", character.Name));
            command.Parameters.Add(new MySqlParameter("@Level", character.Level));
            command.Parameters.Add(new MySqlParameter("@Experience", character.Experience));
            command.Parameters.Add(new MySqlParameter("@Breed", character.Breed));
            command.Parameters.Add(new MySqlParameter("@EntityLookString", character.EntityLookString));
            command.Parameters.Add(new MySqlParameter("@Sex", character.Sex));
            command.Parameters.Add(new MySqlParameter("@MapId", character.MapId));
            command.Parameters.Add(new MySqlParameter("@CellId", character.CellId));
            command.Parameters.Add(new MySqlParameter("@Direction", character.Direction));
            command.Parameters.Add(new MySqlParameter("@AlignementSide", character.AlignementSide));
            command.Parameters.Add(new MySqlParameter("@Honor", character.Honor));
            command.Parameters.Add(new MySqlParameter("@Dishonor", character.Dishonor));
            command.Parameters.Add(new MySqlParameter("@PvPEnabled", character.PvPEnabled));
            command.Parameters.Add(new MySqlParameter("@Kamas", character.Kamas));
            command.Parameters.Add(new MySqlParameter("@StatsPoints", character.StatsPoints));
            command.Parameters.Add(new MySqlParameter("@SpellsPoints", character.SpellsPoints));
            command.Parameters.Add(new MySqlParameter("@LastUsage", character.LastUsage));
            command.ExecuteNonQuery();
        }

        public static void Create(Character character)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO characters SET OwnerId = @OwnerId, Name = @Name, Breed = @Breed, EntityLookString = @EntityLookString, Sex = @Sex, MapId = @MapId, CellId = @CellId, Direction = @Direction, LastUsage = @LastUsage", DatabaseManager.Connection);
            command.Parameters.Add(new MySqlParameter("@OwnerId", character.OwnerId));
            command.Parameters.Add(new MySqlParameter("@Name", character.Name));
            command.Parameters.Add(new MySqlParameter("@Breed", character.Breed));
            command.Parameters.Add(new MySqlParameter("@EntityLookString", character.EntityLookString));
            command.Parameters.Add(new MySqlParameter("@Sex", character.Sex));
            command.Parameters.Add(new MySqlParameter("@MapId", character.MapId));
            command.Parameters.Add(new MySqlParameter("@CellId", character.CellId));
            command.Parameters.Add(new MySqlParameter("@Direction", character.Direction));
            command.Parameters.Add(new MySqlParameter("@LastUsage", character.LastUsage));
            command.ExecuteNonQuery();
        }

        public static void Delete(Character character)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM characters WHERE Id = @Id", DatabaseManager.Connection);
            command.Parameters.Add(new MySqlParameter("@Id", character.Id));
            command.ExecuteNonQuery();
        }

        public static EntityLook ReturnCharacterLook(Character character) //TODO SubEntity & BonesId
        {
            var look_string = character.EntityLookString.Replace("{", "").Replace("}", "").Split('|');
            short bonesId = short.Parse(look_string[0]);
            
            short[] skins;
            if (look_string[1].Contains(","))
            {
                var skins_string = look_string[1].Split(',');
                skins = new short[skins_string.Length];
                for (int i = 0; i < skins_string.Length; i++)
                    skins[i] = short.Parse(skins_string[i]);
            }
            else
                skins = new short[] { short.Parse(look_string[1]) };

            int[] colors;
            if (look_string[2].Contains(","))
            {
                var colors_string = look_string[2].Split(',');
                colors = new int[colors_string.Length];
                for (int i = 0; i < colors_string.Length; i++)
                {
                    var color = int.Parse(colors_string[i].Remove(0, 2));
                    if (color == -1) { }
                    else
                        colors[i] = (i + 1 & 255) << 24 | color & 16777215;
                }
            }
            else
                colors = new int[0];

            short[] size = new short[] { short.Parse(look_string[3]) };

            return new EntityLook(bonesId, skins, colors, size, new SubEntity[0]);
        }

        public static GameRolePlayCharacterInformations ReturnGameRolePlayCharacterInformations(Character character)
        {
            return new GameRolePlayCharacterInformations(character.Id, character.Look, character.Disposition, character.Name, new HumanInformations(new EntityLook[0], 0, 0, new ActorRestrictionsInformations(false, false, false, false, false, false, false, false, true, false, false, false, false, true, true, true, false, false, false, false, false), 0), character.PvPEnabled == true ? new ActorAlignmentInformations((sbyte)character.AlignementSide, 0, (sbyte)Database.Experience.GetCharacterGrade(character.Honor), 0) : new ActorAlignmentInformations(0, 0, 0, 0));
        }

        public static bool NameExist(string name)
        {
            MySqlCommand command = new MySqlCommand("SELECT EXISTS (SELECT 1 FROM characters WHERE Name = @Name)", DatabaseManager.Connection);
            command.Parameters.AddWithValue("Name", name);
            return Convert.ToBoolean(command.ExecuteScalar());
        }
    }
}