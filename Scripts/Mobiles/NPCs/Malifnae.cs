using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{ 
    public class SecretsOfTheNetherworld : BaseQuest
    {
        /* Secrets of the Netherworld */
        public override object Title
        {
            get
            {
                return 1078034;
            }
        }
        /* How do you do? If you wish to learn skills that complement the Necromancer profession, seek out the following
         * instructors:<br><br>Mulcivikh teaches Necromancy.I suggest seeking him out first.Necromancy is the study of dark
         * magic.You can curse your foes, animate the dead, transform into wicked creatures, and summon some of the most
         * deadly spells in the world.<br><br>Morganna teaches Spirit Speak. This skill allows you to heal yourself by
         * channeling spiritual energy from either a corpse or yourself.<br><br>Gustar teaches Meditation. This skill allows
         * someone to regenerate mana at an accelerated rate.<br><br>Jockles teaches Swordsmanship.You will want to know how
         * to handle a weapon. Without this skill, you will find your blows miss more often than not.<br><br>Kaelynna teaches
         * Magery.This skill allows one to cast spells that can heal, transport, weaken, and even slay opponents with fireballs
         * and lightning bolts.Magery spells can also summon elementals and powerful daemons to aid the caster in battle.
         * <br><br>Alefian teaches Resisting Spells which allows someone to lessen the severity of spells that lower your
         * stats or ones that last for a specific duration of time.<br><br>Mulcivikh and Morganna are located here in the
         * Necromancer School.Jockles is located in the Warrior Guild Hall, and the other instructors are located throughout
         * the New Haven Magery School.<br><br>Soon, the secrets of the netherworld will be revealed to you. */
        public override object Description
        {
            get
            {
                return 1078035;
            }
        }
    }
    public class Malifnae : MondainQuester
    {
        public override Type[] Quests
        {
            get
            {
                return new Type[]
                {
                    typeof(SecretsOfTheNetherworld)
                };
            }
        }

        public override void InitSBInfo()
        {
            this.SBInfos.Add(new SBMage());
        }

        [Constructable]
        public Malifnae()
            : base("Malifnae", "The Necromancer Guildmaster")
        {
            this.SetSkill(SkillName.Magery, 120.0, 120.0);
            this.SetSkill(SkillName.MagicResist, 120.0, 120.0);
            this.SetSkill(SkillName.SpiritSpeak, 120.0, 120.0);
            this.SetSkill(SkillName.Swords, 120.0, 120.0);
            this.SetSkill(SkillName.Meditation, 120.0, 120.0);
            this.SetSkill(SkillName.Necromancy, 120.0, 120.0);
        }

        public Malifnae(Serial serial)
            : base(serial)
        {
        }

       // public override void Advertise()
       // {
        //    this.Say(1078131); // Allured by dark magic, aren't you?
       // }

        public override void OnOfferFailed()
        {
            this.Say(1077772); // I cannot teach you, for you know all I can teach!
        }

        public override void InitBody()
        {
            this.Female = true;
            this.CantWalk = true;
            this.Race = Race.Human;

            base.InitBody();
        }

        public override void InitOutfit()
        {
            this.AddItem(new Backpack());
            this.AddItem(new Sandals(0x8FD));
            this.AddItem(new BoneHelm());

            Item item;

            item = new LeatherLegs();
            item.Hue = 0x2C3;
            this.AddItem(item);

            item = new LeatherGloves();
            item.Hue = 0x2C3;
            this.AddItem(item);

            item = new LeatherGorget();
            item.Hue = 0x2C3;
            this.AddItem(item);

            item = new LeatherChest();
            item.Hue = 0x2C3;
            this.AddItem(item);

            item = new LeatherArms();
            item.Hue = 0x2C3;
            this.AddItem(item);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    } 
}
