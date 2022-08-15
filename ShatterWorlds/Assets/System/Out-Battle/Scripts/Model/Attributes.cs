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

        public int strength;

        public int technique;
 
        public int dexterity;

        public int velocity;

        public int intelligence;

        public int knowledge;

        public int spirituality;

        public int will;

        public Attributes(int id, int strength, int technique, int dexterity, int velocity, int intelligence, int knowledge, int spirituality, int will)
        {
            this.id = id;
            this.strength = strength;
            this.technique = technique;
            this.dexterity = dexterity;
            this.velocity = velocity;
            this.intelligence = intelligence;
            this.knowledge = knowledge;
            this.spirituality = spirituality;
            this.will = will;
        }

        public Attributes(int strength, int technique, int dexterity, int velocity, int intelligence, int knowledge, int spirituality, int will)
        {
            this.strength = strength;
            this.technique = technique;
            this.dexterity = dexterity;
            this.velocity = velocity;
            this.intelligence = intelligence;
            this.knowledge = knowledge;
            this.spirituality = spirituality;
            this.will = will;
        }
    }
}