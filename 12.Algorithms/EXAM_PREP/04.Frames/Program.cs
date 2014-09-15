using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Frames
{
    class Program
    {
        static int framesCount = 0;
        static List<Tuple<int, int>> frames = new List<Tuple<int, int>>();
        static StringBuilder framePermutation = new StringBuilder();
        static SortedSet<string> framesStrings = new SortedSet<string>();
        static StringBuilder frameSB = new StringBuilder();
        static void Main(string[] args)
        {
            ReadInput();
            GeneratePermutations(0);
            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(framesStrings.Count);
            foreach (var frameString in framesStrings)
            {
                Console.WriteLine(frameString);
            }
        }

        static void GeneratePermutations(int frameIndex)
        {
            if (frameIndex == frames.Count)
            {
                for (int i = 0; i < frames.Count; i++)
                {
                    frameSB.Append("(" + frames[i].Item1 + ", " + frames[i].Item2 + ")");
                    if (i != frames.Count - 1)
                    {
                        frameSB.Append(" | ");
                    }
                }

                framesStrings.Add(frameSB.ToString());
                frameSB.Clear();

                return;
            }

            for (int i = 0; i < frames.Count; i++)
            {
                SwapFrames(frameIndex, i);
                GeneratePermutations(frameIndex + 1);
                RotateFrame(frameIndex);
                GeneratePermutations(frameIndex + 1);
                RotateFrame(frameIndex);
              //  SwapFrames(frameIndex, i);
            }
        }

        static void SwapFrames(int j, int i)
        {
            var oldFrame = frames[i];
            frames[i] = frames[j];
            frames[j] = oldFrame;
        }
        private static void RotateFrame(int frameIndex)
        {
            var origA = frames[frameIndex].Item1;
            var origB = frames[frameIndex].Item2;
            var newFrame = new Tuple<int, int>(origB, origA);
            frames[frameIndex] = newFrame;
        }

        static void ReadInput()
        {
            framesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < framesCount; i++)
            {
                var frame = Console.ReadLine().Split(' ');
                frames.Add(new Tuple<int, int>(int.Parse(frame[0]), int.Parse(frame[1])));
            }
        }
    }
}
