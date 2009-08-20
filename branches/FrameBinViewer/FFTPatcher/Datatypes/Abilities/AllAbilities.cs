/*
    Copyright 2007, Joe Davidson <joedavidson@gmail.com>

    This file is part of FFTPatcher.

    FFTPatcher is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    FFTPatcher is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with FFTPatcher.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Xml;
using PatcherLib;
using PatcherLib.Datatypes;
using PatcherLib.Utilities;

namespace FFTPatcher.Datatypes
{
    public class AllAbilityEffects : PatchableFile
    {
		#region�Instance�Variables�(1)�

        private AllAbilities owner;

		#endregion�Instance�Variables�

		#region�Public�Properties�(1)�

        public override bool HasChanged
        {
            get 
            { 
                return owner.Abilities.Exists( 
                    ability => 
                        ability.Effect != null && 
                        ability.Default != null && 
                        ability.Default.Effect != null && 
                        ability.Effect.Value != ability.Default.Effect.Value );
            }
        }

		#endregion�Public�Properties�

		#region�Constructors�(1)�

        public AllAbilityEffects( AllAbilities owner )
        {
            this.owner = owner;
        }

		#endregion�Constructors�

		#region�Public�Methods�(1)�

        public override IList<PatchedByteArray> GetPatches( Context context )
        {
            byte[] effects = owner.ToEffectsByteArray();
            byte[] otherEffects = owner.ToReactionEffectsByteArray();

            List<PatchedByteArray> result = new List<PatchedByteArray>( 2 );
            if (context == Context.US_PSX)
            {
                result.Add(PatcherLib.Iso.PsxIso.AbilityEffects.GetPatchedByteArray(effects));
                result.Add( PatcherLib.Iso.PsxIso.ReactionAbilityEffects.GetPatchedByteArray( otherEffects ) );
            }
            else if (context == Context.US_PSP)
            {
                PatcherLib.Iso.PspIso.AbilityEffects.ForEach(
                    kl => result.Add( kl.GetPatchedByteArray( effects ) ) );
                PatcherLib.Iso.PspIso.ReactionAbilityEffects.ForEach(
                    kl => result.Add( kl.GetPatchedByteArray( otherEffects ) ) );
            }

            return result;
        }

		#endregion�Public�Methods�
    }

    /// <summary>
    /// Represents all of the Abilities in this file.
    /// </summary>
    public class AllAbilities : PatchableFile, IXmlDigest, IGenerateCodes
    {

        #region�Static�Fields�(2)

        private static Ability[] pspEventAbilites;
        private static Ability[] psxEventAbilites;

        #endregion�Static�Fields

        #region�Static�Properties�(7)


        public static Ability[] DummyAbilities
        {
            get
            {
                return FFTPatch.Context == Context.US_PSP ? PSPAbilities : PSXAbilities;
            }
        }

        public static Ability[] EventAbilities
        {
            get { return FFTPatch.Context == Context.US_PSP ? pspEventAbilites : psxEventAbilites; }
        }

        /// <summary>
        /// Gets the names of all abilities, based on the current Context.
        /// </summary>
        public static IList<string> Names
        {
            get
            {
                return FFTPatch.Context == Context.US_PSP ? PSPNames : PSXNames;
            }
        }

        public static Ability[] PSPAbilities { get; private set; }

        public static IList<string> PSPNames { get; private set; }

        public static Ability[] PSXAbilities { get; private set; }

        public static IList<string> PSXNames { get; private set; }


        #endregion�Static�Properties

        #region�Properties�(3)


        public Ability[] Abilities { get; private set; }

        public Ability[] DefaultAbilities { get; private set; }

        public AllAbilityEffects AllEffects { get; private set;}

        /// <summary>
        /// Gets a value indicating whether this instance has changed.
        /// </summary>
        /// <value></value>
        public override bool HasChanged
        {
            get
            {
                return defaultBytes != null && !Utilities.CompareArrays( ToByteArray(), defaultBytes );
            }
        }


        #endregion�Properties

        #region�Constructors�(2)

        static AllAbilities()
        {
            PSPAbilities = new Ability[512];
            PSXAbilities = new Ability[512];
            psxEventAbilites = new Ability[512];
            pspEventAbilites = new Ability[512];

            PSPNames = PatcherLib.PSPResources.Lists.AbilityNames;
            PSXNames = PatcherLib.PSXResources.Lists.AbilityNames;

            for( int i = 0; i < 512; i++ )
            {
                PSPAbilities[i] = new Ability( PSPNames[i], (UInt16)i );
                PSXAbilities[i] = new Ability( PSXNames[i], (UInt16)i );
                pspEventAbilites[i] = new Ability( PSPNames[i], (UInt16)i );
                psxEventAbilites[i] = new Ability( PSXNames[i], (UInt16)i );
            }

            pspEventAbilites[510] = new Ability( "<Random>", 510 );
            pspEventAbilites[511] = new Ability( "Nothing", 511 );
            psxEventAbilites[510] = new Ability( "<Random>", 510 );
            psxEventAbilites[511] = new Ability( "Nothing", 511 );

        }

        private IList<byte> defaultBytes;

        public AllAbilities( IList<byte> bytes, IList<byte> effectsBytes, IList<byte> reactionEffects )
        {
            AllEffects = new AllAbilityEffects( this );
            this.defaultBytes = FFTPatch.Context == Context.US_PSP ? PSPResources.Binaries.Abilities : PSXResources.Binaries.Abilities;
            
            IDictionary<UInt16, Effect> effects = FFTPatch.Context == Context.US_PSP ? Effect.PSPEffects : Effect.PSXEffects;
            IList<byte> defaultEffects = FFTPatch.Context == Context.US_PSP ? PSPResources.Binaries.AbilityEffects : PSXResources.Binaries.AbilityEffects;
            IList<byte> defaultReaction = FFTPatch.Context == Context.US_PSP ? PSPResources.Binaries.ReactionAbilityEffects : PSXResources.Binaries.ReactionAbilityEffects;

            Abilities = new Ability[512];
            DefaultAbilities = new Ability[512];
            for( UInt16 i = 0; i < 512; i++ )
            {
                IList<byte> defaultFirst = defaultBytes.Sub( i * 8, i * 8 + 7 );
                IList<byte> first = bytes.Sub( i * 8, i * 8 + 7 );
                IList<byte> second;
                IList<byte> defaultSecond;
                Effect effect = null;
                Effect defaultEffect = null;

                if( i <= 0x16F )
                {
                    second = bytes.Sub( 0x1000 + 14 * i, 0x1000 + 14 * i + 13 );
                    defaultSecond = defaultBytes.Sub( 0x1000 + 14 * i, 0x1000 + 14 * i + 13 );
                    effect = effects[PatcherLib.Utilities.Utilities.BytesToUShort( effectsBytes[i * 2], effectsBytes[i * 2 + 1] )];
                    defaultEffect = effects[PatcherLib.Utilities.Utilities.BytesToUShort( defaultEffects[i * 2], defaultEffects[i * 2 + 1] )];
                }
                else if( i <= 0x17D )
                {
                    second = bytes.Sub( 0x2420 + i - 0x170, 0x2420 + i - 0x170 );
                    defaultSecond = defaultBytes.Sub( 0x2420 + i - 0x170, 0x2420 + i - 0x170 );
                }
                else if( i <= 0x189 )
                {
                    second = bytes.Sub( 0x2430 + i - 0x17E, 0x2430 + i - 0x17E );
                    defaultSecond = defaultBytes.Sub( 0x2430 + i - 0x17E, 0x2430 + i - 0x17E );
                }
                else if( i <= 0x195 )
                {
                    second = bytes.Sub( 0x243C + (i - 0x18A) * 2, 0x243C + (i - 0x18A) * 2 + 1 );
                    defaultSecond = defaultBytes.Sub( 0x243C + (i - 0x18A) * 2, 0x243C + (i - 0x18A) * 2 + 1 );
                }
                else if( i <= 0x19D )
                {
                    second = bytes.Sub( 0x2454 + (i - 0x196) * 2, 0x2454 + (i - 0x196) * 2 + 1 );
                    defaultSecond = defaultBytes.Sub( 0x2454 + (i - 0x196) * 2, 0x2454 + (i - 0x196) * 2 + 1 );
                }
                else if( i <= 0x1A5 )
                {
                    second = bytes.Sub( 0x2464 + i - 0x19E, 0x2464 + i - 0x19E );
                    defaultSecond = defaultBytes.Sub( 0x2464 + i - 0x19E, 0x2464 + i - 0x19E );
                }
                else
                {
                    if (i >= 422 && i <= 453)
                    {
                        effect = effects[PatcherLib.Utilities.Utilities.BytesToUShort( reactionEffects[(i - 422) * 2], reactionEffects[(i - 422) * 2 + 1] )];
                        defaultEffect = effects[PatcherLib.Utilities.Utilities.BytesToUShort( defaultReaction[(i - 422) * 2], defaultReaction[(i - 422) * 2 + 1] )];
                    }
                    second = bytes.Sub( 0x246C + i - 0x1A6, 0x246C + i - 0x1A6 );
                    defaultSecond = defaultBytes.Sub( 0x246C + i - 0x1A6, 0x246C + i - 0x1A6 );
                }

                Abilities[i] = new Ability( Names[i], i, first, second, new Ability( Names[i], i, defaultFirst, defaultSecond ) );
                if( effect != null && defaultEffect != null )
                {
                    Abilities[i].Effect = effect;
                    Abilities[i].Default.Effect = defaultEffect;
                }
            }
        }

        #endregion�Constructors

        #region�Methods�(5)

        string IGenerateCodes.GetCodeHeader( Context context )
        {
            const string PSPHeader = "_C0 Abilities";
            const string PSXHeader = "\"Abilities";
            return context == Context.US_PSP ? PSPHeader : PSXHeader;
        }

        public IList<string> GenerateCodes( Context context )
        {
            List<string> result = new List<string>();
            if (context == Context.US_PSP)
            {
                result.AddRange( Codes.GenerateCodes( Context.US_PSP, PSPResources.Binaries.Abilities, this.ToByteArray(), 0x2754C0 ) );
                result.AddRange( Codes.GenerateCodes( Context.US_PSP, PSPResources.Binaries.AbilityEffects, this.ToEffectsByteArray(), 0x31B760 ) );
                result.AddRange( Codes.GenerateCodes( Context.US_PSP, PSPResources.Binaries.ReactionAbilityEffects, this.ToReactionEffectsByteArray(), 0x31B760 + 0x34C ) );
            }
            else
            {
                result.AddRange( Codes.GenerateCodes( Context.US_PSX, PSXResources.Binaries.AbilityEffects, this.ToEffectsByteArray(), 0x1B63F0, Codes.CodeEnabledOnlyWhen.Battle ) );
                result.AddRange( Codes.GenerateCodes( Context.US_PSX, PSXResources.Binaries.ReactionAbilityEffects, this.ToReactionEffectsByteArray(), 0x1B673C, Codes.CodeEnabledOnlyWhen.Battle ) );
                result.AddRange( Codes.GenerateCodes( Context.US_PSX, PSXResources.Binaries.Abilities, this.ToByteArray(), 0x05EBF0 ) );
            }
            return result.AsReadOnly();
        }

        public byte[] ToByteArray()
        {
            List<byte> bytes = new List<byte>();
            for( UInt16 i = 0; i < 512; i++ )
            {
                bytes.AddRange( Abilities[i].ToByteArray() );
            }
            for( UInt16 i = 0; i < 512; i++ )
            {
                bytes.AddRange( Abilities[i].ToSecondByteArray() );
            }

            bytes.Insert( 0x242E, 0x00 );
            bytes.Insert( 0x242E, 0x00 );
            return bytes.ToArray();
        }

        public byte[] ToByteArray( Context context )
        {
            return ToByteArray();
        }

        public byte[] ToEffectsByteArray()
        {
            List<byte> result = new List<byte>( 0x2E0 );
            foreach (Ability a in Abilities)
            {
                if (a.IsNormal)
                {
                    result.AddRange( a.Effect.Value.ToBytes() );
                }
            }

            return result.ToArray();
        }

        public byte[] ToReactionEffectsByteArray()
        {
            List<byte> result = new List<byte>( 0x40 );
            foreach (Ability a in Abilities)
            {
                if (!a.IsNormal && a.Effect != null)
                {
                    result.AddRange( a.Effect.Value.ToBytes() );
                }
            }

            return result.ToArray();
        }

        public void WriteXmlDigest( XmlWriter writer )
        {
            if( HasChanged )
            {
                writer.WriteStartElement( this.GetType().Name );
                writer.WriteAttributeString( "changed", HasChanged.ToString() );
                foreach( Ability a in Abilities )
                {
                    a.WriteXmlDigest( writer );
                }
                writer.WriteEndElement();
            }
        }


        #endregion�Methods


        public override IList<PatchedByteArray> GetPatches(Context context)
        {
            var result = new List<PatchedByteArray>(4);
            byte[] bytes = ToByteArray(context);

            if (context == Context.US_PSX)
            {
                result.Add(PatcherLib.Iso.PsxIso.Abilities.GetPatchedByteArray(bytes));
            }
            else if (context == Context.US_PSP)
            {
                PatcherLib.Iso.PspIso.Abilities.ForEach(
                    kl => result.Add(kl.GetPatchedByteArray(bytes)));
            }

            return result;
        }
    }
}