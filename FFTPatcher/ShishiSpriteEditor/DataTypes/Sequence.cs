﻿using System;
using System.Collections.Generic;
using System.Text;
using PatcherLib.Utilities;
using PatcherLib.Datatypes;

namespace FFTPatcher.SpriteEditor
{
    class Sequence
    {
        IList<AnimationFrame> frames;
        public AnimationFrame this[int i]
        {
            get { return frames[i]; }
        }

        private Set<int> uniqueFrames;

        public static IList<Sequence> BuildSequences( IList<byte> bytes )
        {
            List<UInt32> offsets = new List<uint>();
            for ( int i = 0; i < 0x100; i++ )
            {
                UInt32 currentOffset = bytes.Sub( i * 4 + 4, ( i + 1 ) * 4 + 4 - 1 ).ToUInt32();
                if ( currentOffset == 0xFFFFFFFF )
                {
                    break;
                }
                else
                {
                    offsets.Add( currentOffset );
                }
            }
            const int animationStart = 0x0406;
            List<Sequence> result = new List<Sequence>(offsets.Count);
            for ( int i = 0; i < offsets.Count - 1; i++ )
            {
                if ( offsets[i] == offsets[i + 1] )
                    continue;
                var seq = BuildSequence( bytes.Sub( animationStart + offsets[i], animationStart + offsets[i + 1] - 1 ), i );
                if ( seq != null )
                    result.Add( seq );
            }

            var seq2 = BuildSequence( bytes.Sub( animationStart + offsets[offsets.Count - 1] ), offsets.Count - 1 );
            if ( seq2 != null )
                result.Add( seq2 );
            return result.AsReadOnly();
        }

        private Sequence( IList<AnimationFrame> frames )
        {
            this.frames = frames;
            uniqueFrames = new Set<int>();
            foreach ( var frame in frames )
            {
                uniqueFrames.Add( frame.Index );
            }
        }

        public class AnimationFrame
        {
            public int Delay { get; private set; }
            public int Index { get; private set; }
            public AnimationFrame( int delay, int index )
            {
                Delay = delay;
                Index = index;
            }
        }

        private static Sequence BuildSequence( IList<byte> bytes, int index )
        {
            var frames =
                ProcessSequence( bytes, index );
            if ( frames == null )
                return null;
            else
            {
                return new Sequence( frames );
            }
        }

        private static Dictionary<byte, int> jumps = new Dictionary<byte, int> {
                { 192, 1 },{ 198, 1 },{ 211, 1 },{ 212, 1 },{ 214, 1 },
                { 215, 1 },{ 216, 1 },{ 226, 1 },{ 238, 1 },{ 239, 1 },
                { 240, 1 },{ 246, 1 },{ 193, 2 },{ 217, 2 },{ 242, 2 },
                { 252, 2 },{ 250, 3 } };

        private static IList<AnimationFrame> ProcessSequence( IList<byte> bytes, int number )
        {
            int i = 0;
            List<byte[]> sequence = new List<byte[]>();
            while ( i < bytes.Count - 1 )
            {
                if ( bytes[i] != 0xFF )
                {
                    sequence.Add( new byte[2] { bytes[i], bytes[i + 1] } );
                }
                else if ( jumps.ContainsKey( bytes[i + 1] ) )
                {
                    i += jumps[bytes[i + 1]];
                }

                i += 2;
            }
            if ( sequence.Count == 0 ) return null;

            List<AnimationFrame> result = new List<AnimationFrame>( sequence.Count );
            foreach ( byte[] frame in sequence )
            {
                result.Add( new AnimationFrame( frame[1], frame[0] ) );
            }

            return result;
        }

        public void BuildAnimation( AbstractSprite sprite, out IList<System.Drawing.Bitmap> bitmaps, out IList<double> delays )
        {
            // Given the set of unique frame indices, build the minimal amount of Bitmaps necessary
            Dictionary<int, System.Drawing.Bitmap> frameToBitmap = new Dictionary<int, System.Drawing.Bitmap>( uniqueFrames.Count );
            foreach ( int frame in uniqueFrames )
            {
                frameToBitmap[frame] = sprite.Shape.Frames[frame].GetFrame( sprite );
            }

            List<System.Drawing.Bitmap> result = new List<System.Drawing.Bitmap>();
            List<double> ourDelays = new List<double>();

            foreach ( AnimationFrame frame in frames )
            {
                result.Add( frameToBitmap[frame.Index] );
                ourDelays.Add( ( (double)frame.Delay ) / 60 );
            }

            bitmaps = result.ToArray();
            delays = ourDelays.ToArray();
        }
    }
}