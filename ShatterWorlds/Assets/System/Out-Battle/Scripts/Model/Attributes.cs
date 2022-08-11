using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace outBattle
{
    [Serializable]
    public class Attributes
    {
        public int id;

        public int Strength;

        public int Technique;
 
        public int Dexterity;

        public int Velocity;

        public int Intelligence;

        public int Knowledge;

        public int Spirituality;

        public int Will;

        public Attributes(int id, int strength, int technique, int dexterity, int velocity, int intelligence, int knowledge, int spirituality, int will)
        {
            this.id = id;
            Strength = strength;
            Technique = technique;
            Dexterity = dexterity;
            Velocity = velocity;
            Intelligence = intelligence;
            Knowledge = knowledge;
            Spirituality = spirituality;
            Will = will;
        }

        public Attributes(int strength, int technique, int dexterity, int velocity, int intelligence, int knowledge, int spirituality, int will)
        {
            Strength = strength;
            Technique = technique;
            Dexterity = dexterity;
            Velocity = velocity;
            Intelligence = intelligence;
            Knowledge = knowledge;
            Spirituality = spirituality;
            Will = will;
        }
    }
}